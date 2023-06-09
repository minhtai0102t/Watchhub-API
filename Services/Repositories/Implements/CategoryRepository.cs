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
    }
}
