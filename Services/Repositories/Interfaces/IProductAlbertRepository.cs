using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IProductAlbertRepository : IGenericRepository<ProductAlbert>
    {
        Task<PagedList<ProductAlbert>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
