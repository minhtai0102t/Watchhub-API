using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

using System.Linq.Expressions;

namespace Services.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagedList<Product>> GetAllWithPaging(QueryStringParameters pagingParams);
        Task<PagedList<Product>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> GetByListProductTypeId(List<int> ids);
    }
}
