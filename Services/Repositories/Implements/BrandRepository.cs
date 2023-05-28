using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext context) : base(context)
        {

        }
    }
}
