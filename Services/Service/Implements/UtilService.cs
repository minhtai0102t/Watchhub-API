using Ecom_API.Service;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace Services.Service.Implements
{
    public class UtilService : IUtilService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private bool disposedValue;

        public UtilService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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

                ipAddress = _httpContextAccessor.HttpContext.Request.Headers["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown") || ipAddress.Length > 45)
                    ipAddress = _httpContextAccessor.HttpContext.Request.Headers["REMOTE_ADDR"];
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP:" + ex.Message;
            }

            return ipAddress;
        }
        public async Task<bool> StoreTransaction()
        {
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        ~UtilService()
        {
            //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
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
