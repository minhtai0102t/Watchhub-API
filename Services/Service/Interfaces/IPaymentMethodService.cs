using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IPaymentMethodService : IDisposable
{
    Task<PagedList<PaymentMethod>> GetAll(QueryStringParameters query);
    Task<PaymentMethod> GetById(int id);
    Task<bool> Update(PaymentMethodCreateReq model, int id);
    Task<bool> Create(PaymentMethodCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

