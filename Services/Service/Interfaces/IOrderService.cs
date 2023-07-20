using DTO.DTO.Models;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service;

public interface IOrderService : IDisposable
{
    Task<PagedList<Order>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<Order>> SearchByOrderStatus(QueryStringParameters pagingParams, ORDER_STATUS orderStatus);
    Task<PagedList<Order>> SearchByOrderStatus(QueryStringParameters query, ORDER_STATUS orderStatus, int userId);
    Task<PagedList<Order>> SearchByOrderStatus(QueryStringParameters query, int userId);
    Task<Order> GetById(int id);
    Task<int> Create(OrderCreateReq req);
    Task<bool> Update(int orderId, ORDER_STATUS orderStatus);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
    Task<bool> T3PDeliveryInTransit(int orderId);
    Task<bool> T3PDeliveryUpdateSuccessful(int orderId);
    Task<DeliveryCancelRes> T3PDeliveryUpdateFail(int orderId, string cancel_reason);
    Task<IEnumerable<Product>> InventoryHandler(int id);
    Task<string> InventoryChecking(int orderId);
}

