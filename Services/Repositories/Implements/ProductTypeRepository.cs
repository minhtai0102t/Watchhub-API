using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class ProducTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProducTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
