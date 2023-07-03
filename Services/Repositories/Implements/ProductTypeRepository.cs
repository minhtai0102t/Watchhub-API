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
                .Include(c => c.subCategory)
                .Include(c => c.brand)
                .Include(c => c.alberts)
                .Include(c => c.cores)
                .Include(c => c.glasses);
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<ProductType>> GetFullResWithCondition(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.subCategory)
                .Include(c => c.brand)
                .Include(c => c.alberts)
                .Include(c => c.cores)
                .Include(c => c.glasses)
                .Where(predicate);
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
        public async Task<IEnumerable<ProductType>> GetFullResByListId(List<int> ids)
        {
            var dataQuery = dbSet.AsNoTracking()
               .Include(c => c.subCategory)
               .Include(c => c.brand)
               .Include(c => c.alberts)
               .Include(c => c.cores)
               .Include(c => c.glasses)
               .Where(c => ids.Any(p => p == c.id));
            return await dataQuery.ToListAsync();
        }
        public async Task<ProductType> GetFullResById(int id)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.subCategory)
                .Include(c => c.brand)
                .Include(c => c.alberts)
                .Include(c => c.cores)
                .Include(c => c.glasses)
                .Where(c => c.id == id);
            return await dataQuery.SingleOrDefaultAsync();    
        }
    }
}

