using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductService : IDisposable
{
    Task<PagedList<Product>> GetAll(QueryStringParameters pagingParams);
    Task<Product> GetById(int id);
    Task<bool> Create(int product_type_id, string product_code);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

