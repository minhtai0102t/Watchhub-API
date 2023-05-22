using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }
    }
}
