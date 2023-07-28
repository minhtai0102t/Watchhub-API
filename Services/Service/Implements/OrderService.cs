using AutoMapper;
using DTO.DTO.Models;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Newtonsoft.Json;
using Services.Repositories;
using System.Text.RegularExpressions;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IProductTypeService _productTypeService;
        IProductService _productService;
        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IProductTypeService productTypeService,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productTypeService = productTypeService;
            _productService = productService;
        }
        public async Task<int> Create(OrderCreateReq req)
        {
            try
            {
                // get list product type by list id
                var listProductTypeId = req.items.Select(c => c.id).ToList();
                var listProductType = await _productTypeService.GetByListId(listProductTypeId);
                foreach (var product in listProductType)
                {
                    // check product quantity and order quantity
                    if (product.quantity >= req.items.FirstOrDefault(c => c.id == product.id).quantity)
                    {
                        // select quantity for order Info
                        product.quantity = req.items.FirstOrDefault(c => c.id == product.id).quantity;
                    }
                    else
                    {
                        if (product.quantity == 0)
                        {
                            throw new AppException($"Sản phẩm đã được khách hàng khác mua trong khi quý khách mua sắm, vui lòng liên hệ với chúng tôi để đặt mua sản phẩm này ngay khi có hàng");
                        }
                        throw new AppException($"Sản phẩm {product.product_type_code} trong kho chỉ còn {product.quantity} so với số lượng đặt {req.items.FirstOrDefault(c => c.id == product.id).quantity}, quý khách vui lòng mua {product.quantity} sản phẩm nhé");
                    }
                }
                var orderInfo = JsonConvert.SerializeObject(listProductType).ToString();
                var item = _mapper.Map<Order>(req);

                item.order_status = req.order_status.ToString();
                item.order_info = orderInfo;
                item.product_type_ids = listProductTypeId;
                item.cancel_reason = string.Empty;
                await _unitOfWork.Orders.CreateAsync(item);

                var res = await _unitOfWork.SaveChangesAsync();
                return item.id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PagedList<OrderFullRes>> GetAll(QueryStringParameters query)
        {
            try
            {
                var orders = await _unitOfWork.Orders.GetAllWithPaging(query);
                var result = _mapper.Map<PagedList<OrderFullRes>>(orders);
                result.TotalCount = orders.TotalCount;
                await AutoCancel(orders);
                return result;
            }
            catch
            {
                throw;
            }
        }
        private async Task AutoCancel(PagedList<Order> orders)
        {
            try
            {
                // Check if VNPay Order is pending more than 15 minutes => cancel
                int maxMins = 15;
                var reason = "Đơn hàng bị huỷ do quá thời hạn thanh toán";
                var listValidate = orders.Where(c => c.payment_method_id == (int)PAYMENT_METHOD.VNPAY && c.isPaid == false &&
                c.order_status == ORDER_STATUS.AWAITING_CONFIRMATION.ToString() &&
                ((DateTime.Now.ToUniversalTime().ToUniversalTime().Year != c.created_date.Year ||
                    DateTime.Now.ToUniversalTime().Month != c.created_date.Month ||
                    DateTime.Now.ToUniversalTime().Day != c.created_date.Day ||
                    Math.Abs(DateTime.Now.ToUniversalTime().Hour - c.created_date.Hour) != 1 ||
                    Math.Abs(DateTime.Now.ToUniversalTime().Hour - c.created_date.Hour) != 11
                    )) &&
                (DateTime.Now.ToUniversalTime().Minute - c.created_date.Minute >= maxMins));
                foreach (var order in listValidate)
                {
                    order.order_status = ORDER_STATUS.CANCELLED.ToString();
                    order.cancel_reason = reason;
                    order.updated_date = DateTime.Now.ToUniversalTime();
                    await _unitOfWork.Orders.UpdateAsync(order);
                }
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<PagedList<OrderFullRes>> SearchByOrderStatus(QueryStringParameters query, ORDER_STATUS orderStatus)
        {
            var orders = await _unitOfWork.Orders.GetAllWithPaging(query, c => c.order_status == orderStatus.ToString());
            var result = _mapper.Map<PagedList<OrderFullRes>>(orders);
            result.TotalCount = orders.TotalCount;

            return result;
        }
        public async Task<PagedList<OrderFullRes>> SearchByOrderStatus(QueryStringParameters query, ORDER_STATUS orderStatus, int userId)
        {
            var orders = await _unitOfWork.Orders.GetAllWithPaging(query, c => c.order_status == orderStatus.ToString() && c.user_id == userId);
            var result = _mapper.Map<PagedList<OrderFullRes>>(orders);
            result.TotalCount = orders.TotalCount;

            return result;

        }
        public async Task<PagedList<OrderFullRes>> SearchByOrderStatus(QueryStringParameters query, int userId)
        {
            var orders = await _unitOfWork.Orders.GetAllWithPaging(query, c => c.user_id == userId);
            var result = _mapper.Map<PagedList<OrderFullRes>>(orders);
            result.TotalCount = orders.TotalCount;

            return result;
        }
        public async Task<Order> GetById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }
        public async Task<OrderFullRes> GetByIdFullRes(int id)
        {
            var order = await _unitOfWork.Orders.GetFullRes(id);
            var result = _mapper.Map<OrderFullRes>(order);

            return result;
        }
        public async Task<bool> Update(int orderId, ORDER_STATUS orderStatus)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    throw new AppException($"Order {orderId} is not exist");
                }
                order.order_status = orderStatus.ToString();
                order.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.Orders.UpdateAsync(order);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> ConfirmationChecking(int orderId)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    throw new AppException($"Order {orderId} không tồn tại");
                }
                if (order.order_status != ORDER_STATUS.AWAITING_CONFIRMATION.ToString())
                {
                    throw new AppException($"Trạng thái của Order {orderId} phải là CHỜ XÁC NHẬN");
                }
                if (order.payment_method_id == (int)PAYMENT_METHOD.VNPAY)
                {
                    if (!order.isPaid)
                    {
                        return false;
                    }
                }
                order.order_status = ORDER_STATUS.CONFIRMED.ToString();
                order.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.Orders.UpdateAsync(order);
                var res = await _unitOfWork.SaveChangesAsync();

                return res >= 1 ? true : false;
            }
            catch
            {
                throw;
            }
        }
        #region Warehouse
        public async Task<IEnumerable<Product>> InventoryHandler(Order order)
        {
            try
            {
                var result = new List<Product>();

                var productTypesIds = order.product_type_ids;

                var products = await _productService.GetByListProductTypeId(productTypesIds);
                // Deserialize the JSON string
                var orderDetailInfos = JsonConvert.DeserializeObject<OrderDetailInfo[]>(order.order_info);

                // Access the quantity and id fields
                if (orderDetailInfos != null)
                {
                    for (int i = 0; i < productTypesIds.Count(); i++)
                    {
                        var itemCount = products.Where(c => c.product_type_id == productTypesIds[i]);
                        if (itemCount.Count() >= orderDetailInfos[i].Quantity)
                        {
                            result.AddRange(products.Where(c => c.product_type_id == productTypesIds[i]).Take(orderDetailInfos[i].Quantity));
                            // update product type quantity
                            await _productTypeService.UpdateQuantityAfterInventoryCheckingSuccess(productTypesIds[i], orderDetailInfos[i].Quantity);
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> InventoryChecking(int orderId)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    throw new AppException($"Order {orderId} không tồn tại");
                }
                if (order.order_status != ORDER_STATUS.CONFIRMED.ToString() && order.order_status != ORDER_STATUS.AWAITING_SHIPMENT.ToString())
                {
                    throw new AppException($"Trạng thái của Order {orderId} phải là ĐÃ XÁC NHẬN hoặc CHỜ LẤY HÀNG");
                }
                // inventory check
                var orderDetail = await InventoryHandler(order);
                if (orderDetail == null || !orderDetail.Any())
                {
                    // fail
                    // update order status to awaiting shipment
                    order.order_status = ORDER_STATUS.AWAITING_SHIPMENT.ToString();
                    order.updated_date = DateTime.Now.ToUniversalTime();

                    await _unitOfWork.Orders.UpdateAsync(order);
                    await _unitOfWork.SaveChangesAsync();

                    return order.order_status;
                }
                // success
                // update order status to awaiting collection
                order.order_status = ORDER_STATUS.AWAITING_COLLECTION.ToString();
                order.updated_date = DateTime.Now.ToUniversalTime();

                // update product type quantity
                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.SaveChangesAsync();

                return order.order_status;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region Delivery
        public async Task<bool> T3PDeliveryInTransit(int orderId)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    throw new AppException($"Order {orderId} không tồn tại");
                }
                if (order.order_status != ORDER_STATUS.AWAITING_COLLECTION.ToString())
                {
                    throw new AppException($"Trạng thái của Order {orderId} phải là ĐANG ĐÓNG GÓI");
                }
                var listOrderInfo = JsonConvert.DeserializeObject<List<ProductTypeFullRes>>(order.order_info);
                if (listOrderInfo != null)
                {
                    var listProductTypeId = listOrderInfo.Select(c => c.id).ToList();
                    var listProductType = await _unitOfWork.ProductTypes.GetByListId(listProductTypeId);
                    foreach (var productType in listProductType)
                    {
                        productType.quantity -= listOrderInfo.FirstOrDefault(c => c.id == productType.id).quantity;
                        await _unitOfWork.ProductTypes.UpdateAsync(productType);
                    }
                }
                order.order_status = ORDER_STATUS.IN_TRANSIT.ToString();
                order.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.Orders.UpdateAsync(order);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> T3PDeliveryUpdateSuccessful(int orderId)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    throw new AppException($"Order {orderId} is not exist");
                }
                if (order.order_status != ORDER_STATUS.IN_TRANSIT.ToString())
                {
                    throw new AppException($"Trạng thái của Order {orderId} phải là ĐANG GIAO HÀNG");
                }
                order.order_status = ORDER_STATUS.DELIVERED.ToString();
                order.isPaid = true;
                order.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.Orders.UpdateAsync(order);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch
            {
                throw;
            }
        }
        public async Task<DeliveryCancelRes> T3PDeliveryUpdateFail(int orderId, string cancel_reason)
        {
            try
            {
                var result = new DeliveryCancelRes();
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                if (order == null)
                {
                    throw new AppException($"Order {orderId} is not exist");
                }
                if (order.order_status != ORDER_STATUS.IN_TRANSIT.ToString())
                {
                    throw new AppException($"Trạng thái của Order {orderId} phải là ĐANG GIAO HÀNG");
                }
                var listOrderInfo = JsonConvert.DeserializeObject<List<ProductTypeFullRes>>(order.order_info);
                if (listOrderInfo != null)
                {
                    // return quantity of product type 
                    var listProductTypeId = listOrderInfo.Select(c => c.id).ToList();
                    var listProductType = await _unitOfWork.ProductTypes.GetByListId(listProductTypeId);
                    foreach (var productType in listProductType)
                    {
                        productType.quantity += listOrderInfo.FirstOrDefault(c => c.id == productType.id).quantity;
                        await _unitOfWork.ProductTypes.UpdateAsync(productType);
                    }
                }
                order.order_status = ORDER_STATUS.CANCELLED.ToString();
                order.cancel_reason = cancel_reason.Trim();
                order.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.Orders.UpdateAsync(order);
                var saveChangeRes = await _unitOfWork.SaveChangesAsync();
                if (saveChangeRes >= 1)
                {
                    result.orderId = orderId;
                    result.cancelReason = cancel_reason;
                }
                return result;
            }

            catch
            {
                throw;
            }
        }
        #endregion
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.Orders.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Orders.DeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
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
        ~OrderService()
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
    public class OrderDetailInfo
    {
        public int Quantity { get; set; }
        public int Id { get; set; }
    }
}


