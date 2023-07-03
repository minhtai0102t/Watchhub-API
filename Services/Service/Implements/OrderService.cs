using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Newtonsoft.Json;
using Services.Repositories;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IProductTypeService _productTypeService;
        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IProductTypeService productTypeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productTypeService = productTypeService;
        }
        public async Task<PagedList<Order>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.Orders.GetAllWithPaging(query);
        }
        public async Task<PagedList<Order>> SearchByOrderStatus(QueryStringParameters query, ORDER_STATUS orderStatus)
        {
            return await _unitOfWork.Orders.GetAllWithPaging(query, c => c.order_status == orderStatus.ToString());
        }
        public async Task<PagedList<Order>> SearchByOrderStatus(QueryStringParameters query, ORDER_STATUS orderStatus, int userId)
        {
            return await _unitOfWork.Orders.GetAllWithPaging(query, c => c.order_status == orderStatus.ToString() && c.user_id == userId);
        }
        public async Task<PagedList<Order>> SearchByOrderStatus(QueryStringParameters query, int userId)
        {
            return await _unitOfWork.Orders.GetAllWithPaging(query, c => c.user_id == userId);
        }
        public async Task<Order> GetById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }
        public async Task<bool> Create(OrderCreateReq req)
        {
            // get list product type by list id
            var listProductTypeId = req.items.Select(c => c.id).ToList();
            var listProductType = await _productTypeService.GetByListId(listProductTypeId);
            foreach (var product in listProductType)
            {
                product.quantity = req.items.FirstOrDefault(c => c.id == product.id).quantity;
            }
            var orderInfo = JsonConvert.SerializeObject(listProductType).ToString();
            var item = _mapper.Map<Order>(req);

            item.order_status = req.order_status.ToString();
            item.order_info = orderInfo;
            item.product_type_ids = listProductTypeId;

            await _unitOfWork.Orders.CreateAsync(item);

            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Update(int orderId, ORDER_STATUS orderStatus)
        {
            // map model to new user object
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
}

