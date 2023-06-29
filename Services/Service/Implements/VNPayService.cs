using AutoMapper;
using DTO.DTO.Models;
using DTO.DTO.Models.Response;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Services.Repositories;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Ecom_API.Service
{
    public class VNPayService : IVNPayService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public const string VERSION = "2.1.0";
        private SortedList<String, String> _requestData = new SortedList<String, String>(new VnPayCompare());
        private SortedList<String, String> _responseData = new SortedList<String, String>(new VnPayCompare());
        private readonly IConfiguration _config;
        private string callbackUrl = "https://localhost:8383/payment/payment_response";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VNPayService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IConfiguration config,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PagedList<VNPay>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.VNPays.GetAllWithPaging(query);
        }
        public async Task<VNPay> GetById(int id)
        {
            return await _unitOfWork.VNPays.GetByIdAsync(id);
        }
        public async Task<bool> Create(PaymentResponse model)
        {
            // map model to new user object
            var vNPay = _mapper.Map<VNPay>(model);

            await _unitOfWork.VNPays.CreateAsync(vNPay);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.VNPays.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.VNPays.DeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }

        public void AddRequestData(string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                _requestData.Add(key, value);
            }
        }

        public void AddResponseData(string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                _responseData.Add(key, value);
            }
        }

        public string GetResponseData(string key)
        {
            string retValue;
            if (_responseData.TryGetValue(key, out retValue))
            {
                return retValue;
            }
            else
            {
                return string.Empty;
            }
        }

        #region Request
        public string CreateRequestUrl(PaymentRequestModel model)
        {
            var baseUrl = _config["VNPay:vnp_Url"];
            var txnRef = DateTime.Now.Millisecond.ToString();
            TimeZoneInfo gmtPlus7TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            AddRequestData("vnp_Version", VERSION);
            AddRequestData("vnp_Command", "pay");
            AddRequestData("vnp_TmnCode", _config["VNPay:vnp_TmnCode"]);
            AddRequestData("vnp_Amount", ((long)model.Amount * 100).ToString());
            AddRequestData("vnp_CreateDate", TimeZoneInfo.ConvertTime(DateTime.UtcNow, gmtPlus7TimeZone).ToString("yyyyMMddHHmmss"));
            AddRequestData("vnp_CurrCode", "VND");
            AddRequestData("vnp_IpAddr", GetIpAddress());
            AddRequestData("vnp_Locale", "vn");
            AddRequestData("vnp_OrderInfo", "Thanh toan don hang: " + Guid.NewGuid().ToString());
            AddRequestData("vnp_OrderType", "other");
            AddRequestData("vnp_ReturnUrl", model.callbackUrl);
            AddRequestData("vnp_TxnRef", txnRef); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in _requestData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            string queryString = data.ToString();
            baseUrl += "?" + queryString;
            String signData = queryString;
            if (signData.Length > 0)
            {
                signData = signData.Remove(data.Length - 1, 1);
            }
            string vnp_SecureHash = HmacSHA512(_config["VNPay:vnp_HashSecret"], signData);
            baseUrl += "vnp_SecureHash=" + vnp_SecureHash;
            return baseUrl;

        }
        #endregion
        #region Response process
        public bool ValidateSignature(string inputHash, string secretKey)
        {
            string rspRaw = GetResponseData();
            string myChecksum = HmacSHA512(secretKey, rspRaw);
            return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }
        private string GetResponseData()
        {

            StringBuilder data = new StringBuilder();
            if (_responseData.ContainsKey("vnp_SecureHashType"))
            {
                _responseData.Remove("vnp_SecureHashType");
            }
            if (_responseData.ContainsKey("vnp_SecureHash"))
            {
                _responseData.Remove("vnp_SecureHash");
            }
            foreach (KeyValuePair<string, string> kv in _responseData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            //remove last '&'
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }
            return data.ToString();
        }
        #endregion
        public class VnPayCompare : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x == y) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                var vnpCompare = CompareInfo.GetCompareInfo("en-US");
                return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
            }
        }
        public String HmacSHA512(string key, String inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }
        public string GetIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
                if (string.IsNullOrEmpty(ipAddress) || ipAddress.ToLower() == "unknown" || ipAddress.Length > 45)
                {
                    ipAddress = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
                }
            }
            catch (InvalidOperationException ex)
            {
                ipAddress = "Invalid IP: " + ex.Message;
            }

            return ipAddress;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~VNPayService()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

