using System.Linq.Expressions;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        Task<PagedList<SubCategory>> GetAllWithPaging(QueryStringParameters pagingParams);
        Task<PagedList<SubCategory>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<SubCategory, bool>> predicate);
        Task DeleteByCategoryId(int cateId);
    }

}
