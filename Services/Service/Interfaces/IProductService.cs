using DTO.DTO.Models.Request;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductService : IDisposable
{
    Task<PagedList<Product>> GetAll(QueryStringParameters pagingParams);
    Task<Product> GetById(int id);
    Task<bool> Update(ProductCreateReq model, int id);
    Task<bool> Create(ProductCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

