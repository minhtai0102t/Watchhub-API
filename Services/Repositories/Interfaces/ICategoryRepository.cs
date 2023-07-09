using System.Linq.Expressions;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<PagedList<Category>> GetAllWithPaging(QueryStringParameters pagingParams);
        Task<PagedList<Category>> GetFullRes(QueryStringParameters pagingParams);
         Task<PagedList<Category>> GetFullResWithCondition(QueryStringParameters pagingParams, Expression<Func<Category, bool>> predicate);
        Task<IEnumerable<Category>> GetFullResByListId(List<int> ids);
        Task<Category> GetFullResById(int id);
    }
    
}
