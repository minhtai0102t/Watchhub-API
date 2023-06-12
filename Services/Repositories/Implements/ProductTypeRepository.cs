using System.Linq.Expressions;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class ProducTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProducTypeRepository(DbContext context) : base(context)
        {

        }

        public async Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
           var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams);
        }
         public async Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
    }
}
