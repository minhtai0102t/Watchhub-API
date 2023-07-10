using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Ecom_API.Helpers.Constants;

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
        public async Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate, SORT_OPTION sortOption, bool isDecending)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams, predicate, sortOption, isDecending);
        }
        public async Task<PagedList<ProductType>> GetFullRes(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.productSubCategories)
                    .ThenInclude(x => x.subCategory)
                .Include(c => c.brand)
                .Include(c => c.albert)
                .Include(c => c.core)
                .Include(c => c.glass)
                .Where(c => c.is_deleted == false);
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<ProductType>> GetFullResWithCondition(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.productSubCategories)
                    .ThenInclude(x => x.subCategory)
                .Include(c => c.brand)
                .Include(c => c.albert)
                .Include(c => c.core)
                .Include(c => c.glass)
                .Where(predicate);
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
        public async Task<IEnumerable<ProductType>> GetFullResByListId(List<int> ids)
        {
            var dataQuery = dbSet.AsNoTracking()
               .Include(c => c.productSubCategories)
                    .ThenInclude(x => x.subCategory)
               .Include(c => c.brand)
               .Include(c => c.albert)
               .Include(c => c.core)
               .Include(c => c.glass)
               .Where(c => ids.Any(p => p == c.id)&& c.is_deleted == false);
            return await dataQuery.ToListAsync();
        }
        public async Task<ProductType> GetFullResByIdReadOnly(int id)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.productSubCategories)
                    .ThenInclude(x => x.subCategory)
                .Include(c => c.brand)
                .Include(c => c.albert)
                .Include(c => c.core)
                .Include(c => c.glass)
                .Where(c => c.id == id && c.is_deleted == false);
            return await dataQuery.SingleOrDefaultAsync();
        }
        public async Task<ProductType> GetFullResById(int id)
        {
            var dataQuery = dbSet
                .Include(c => c.productSubCategories)
                    .ThenInclude(x => x.subCategory)
                .Include(c => c.brand)
                .Include(c => c.albert)
                .Include(c => c.core)
                .Include(c => c.glass)
                .Where(c => c.id == id && c.is_deleted == false);
            return await dataQuery.SingleOrDefaultAsync();
        }
    }
}

