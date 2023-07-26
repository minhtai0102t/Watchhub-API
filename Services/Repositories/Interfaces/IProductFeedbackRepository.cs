using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

using System.Linq.Expressions;

namespace Services.Repositories
{
    public interface IProductFeedbackRepository : IGenericRepository<ProductFeedback>
    {
        Task<PagedList<ProductFeedback>> GetFullRes(QueryStringParameters pagingParams);
        Task<PagedList<ProductFeedback>> GetFullRes(QueryStringParameters pagingParams, Expression<Func<ProductFeedback, bool>> predicate);
    }
}
