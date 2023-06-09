using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<PagedList<Category>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
    
}
