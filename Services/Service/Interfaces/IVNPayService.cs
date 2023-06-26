using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using VNPAY_CS_ASPX;

namespace Ecom_API.Service;

public interface IVNPayService : IDisposable
{
    Task<PagedList<VNPay>> GetAll(QueryStringParameters query);
    Task<VNPay> GetById(int id);
    Task<bool> Create(PaymentResponse model);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

