using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<Brand>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
           var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams);
        }
    }
}
