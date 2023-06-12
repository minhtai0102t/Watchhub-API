using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IProductGlassRepository : IGenericRepository<ProductGlass>
    {
        Task<PagedList<ProductGlass>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
