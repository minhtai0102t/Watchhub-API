using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Interfaces;

namespace Services.Repositories
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<PaymentMethod>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
           var dataQuery = dbSet.AsNoTracking();
            return await GetWithPaging(dataQuery, pagingParams);
        }
    }
}
