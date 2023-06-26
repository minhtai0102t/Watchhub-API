using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IOrderService : IDisposable
{
    Task<PagedList<Order>> GetAll(QueryStringParameters pagingParams);
    Task<Order> GetById(int id);
    Task<bool> Create(OrderCreateReq req);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

