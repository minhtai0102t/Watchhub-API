using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IProductTypeRepository : IGenericRepository<ProductType>
    {
        Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
