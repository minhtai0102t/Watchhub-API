using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public class ProductFeedbackRepository : GenericRepository<ProductFeedback>, IProductFeedbackRepository
    {
        public ProductFeedbackRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<ProductFeedback>> GetFullRes(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.User);
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<ProductFeedback>> GetFullRes(QueryStringParameters pagingParams, Expression<Func<ProductFeedback, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.User);
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
    }
}
