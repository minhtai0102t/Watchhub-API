using System.Linq.Expressions;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<SubCategory>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams);
        }
         public async Task<PagedList<SubCategory>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<SubCategory, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
    }
}
