using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<PagedList<Order>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
