using System.Linq.Expressions;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }
        public async Task<PagedList<Order>> GetAllWithPaging(QueryStringParameters pagingParams)
        {
            var dataQuery = dbSet.AsNoTracking().Include(c => c.vnpay);
            return await GetWithPaging(dataQuery, pagingParams);
        }
        public async Task<PagedList<Order>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<Order, bool>> predicate)
        {
            var dataQuery = dbSet.AsNoTracking().Include(c => c.vnpay);
            return await GetWithPaging(dataQuery, pagingParams, predicate);
        }
        public async Task<Order> GetFullRes(int id){
            var dataQuery = dbSet.AsNoTracking().Include(c => c.vnpay).Where(c => c.id == id);
            return await dataQuery.SingleOrDefaultAsync();
        }
    }
}
