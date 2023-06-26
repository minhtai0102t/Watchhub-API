using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IVNPayRepository : IGenericRepository<VNPay>
    {
        Task<PagedList<VNPay>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
