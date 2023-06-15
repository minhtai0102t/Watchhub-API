using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories.Interfaces
{
    public interface IPaymentMethodRepository : IGenericRepository<PaymentMethod>
    {
        Task<PagedList<PaymentMethod>> GetAllWithPaging(QueryStringParameters pagingParams);

    }
}
