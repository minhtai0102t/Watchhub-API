using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<Product>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<Product>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<Product, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
        public async Task<IEnumerable<Product>> GetByListProductTypeId(List<int> ids)
        {
            var dataQuery = dbSet.AsNoTracking()
                        .Where(c => ids.Any(p => p == c.product_type_id) && c.is_deleted == false && c.is_on_sale)
                        .OrderByDescending(c => c.created_date)
                        .Take(99);
            return await dataQuery.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetByProductTypeId(int id)
        {
            var dataQuery = dbSet.AsNoTracking()
                        .Where(c => c.product_type_id == id && c.is_deleted == false && c.is_on_sale)
                        .OrderByDescending(c => c.created_date)
                        .Take(99);
            return await dataQuery.ToListAsync();
        }
    }
}
