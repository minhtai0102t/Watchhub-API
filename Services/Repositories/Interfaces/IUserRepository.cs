using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<PagedList<User>> GetAllWithPaging(QueryStringParameters pagingParams);
    }
}
