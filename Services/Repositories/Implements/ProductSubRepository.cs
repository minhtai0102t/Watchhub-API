using Ecom_API.DTO.Entities;
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
        public async Task DeleteByProductTypeId(int productTypeId)
        {
            try
            {
                var listDelete = await dbSet.Where(c => c.product_type_id == productTypeId).ToListAsync();
                dbSet.RemoveRange(listDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteBySubCateId(int subCateId)
        {
            try
            {
                var listDelete = await dbSet.Where(c => c.sub_category_id == subCateId).ToListAsync();
                dbSet.RemoveRange(listDelete);
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
