using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class ProductSubRepository : IProductSubRepository
    {
        protected readonly DbContext _context;
        protected readonly DbSet<ProductSubCategory> dbSet;
        public ProductSubRepository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<ProductSubCategory>();
        }
        public async Task Update(int productTypeId, List<int> subIds)
        {
            try
            {
                var entities = await dbSet.Where(e => e.product_type_id == productTypeId).ToListAsync();
                dbSet.RemoveRange(entities);

                var listNewEntity = subIds.Select(c => new ProductSubCategory
                {
                    product_type_id = productTypeId,
                    sub_category_id = c
                }).ToList();
                await dbSet.AddRangeAsync(listNewEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ICollection<ProductSubCategory>> GetWithProductTypeId(int productTypeId)
        {
            return await dbSet.Where(c => c.product_type_id == productTypeId).ToListAsync();
        }
    }
}
