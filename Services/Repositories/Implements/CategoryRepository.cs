using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
