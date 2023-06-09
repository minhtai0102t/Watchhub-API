using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<PagedList<Brand>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
