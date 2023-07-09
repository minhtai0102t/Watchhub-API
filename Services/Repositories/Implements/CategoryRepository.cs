using System.Linq.Expressions;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<Category>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<Category>> GetFullRes(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.subCategories);
            // .ThenInclude(x => x.sub_category_name);
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<Category>> GetFullResWithCondition(QueryStringParameters pagingParams, Expression<Func<Category, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking()
                .Include(c => c.subCategories)
                // .ThenInclude(x => x.sub_category_name)
                .Where(predicate);

            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
        public async Task<IEnumerable<Category>> GetFullResByListId(List<int> ids)
        {
            var dataQuery = dbSet.AsNoTracking()
              .Include(c => c.subCategories)
               // .ThenInclude(x => x.sub_category_name)
               .Where(c => ids.Any(p => p == c.id));
            return await dataQuery.ToListAsync();
        }
        public async Task<Category> GetFullResById(int id)
        {
            var dataQuery = dbSet.AsNoTracking()
                 .Include(c => c.subCategories)
                    .ThenInclude(x => x.sub_category_name)
                .Where(c => c.id == id);
            return await dataQuery.SingleOrDefaultAsync();
        }
    }
}
