using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using System.Linq.Expressions;
using static Ecom_API.Helpers.Constants;

namespace Services.Repositories
{
    public interface IProductTypeRepository : IGenericRepository<ProductType>
    {
        Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams);
        Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate);
        Task<PagedList<ProductType>> GetAllWithPaging(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate, SORT_OPTION sortOption, bool isDecending);
        Task<PagedList<ProductType>> GetFullRes(QueryStringParameters pagingParams);
        Task<PagedList<ProductType>> GetFullResWithCondition(QueryStringParameters pagingParams, Expression<Func<ProductType, bool>> predicate);
        Task<IEnumerable<ProductType>> GetFullResByListId(List<int> ids);
        Task<ProductType> GetFullResById(int id);
    }
}
