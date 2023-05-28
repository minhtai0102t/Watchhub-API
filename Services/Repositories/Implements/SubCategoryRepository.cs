using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
