using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IProductCoreRepository : IGenericRepository<ProductCore>
    {
        Task<PagedList<ProductCore>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
