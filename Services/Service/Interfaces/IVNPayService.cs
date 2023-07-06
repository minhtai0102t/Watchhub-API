using DTO.DTO.Models;
using DTO.DTO.Models.Response;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IVNPayService : IDisposable
{
    Task<PagedList<VNPay>> GetAll(QueryStringParameters query);
    Task<VNPay> GetById(int id);
    Task<bool> Create(StoreVnPayCreateReq model);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
    string CreateRequestUrl(PaymentRequestModel model);
}

