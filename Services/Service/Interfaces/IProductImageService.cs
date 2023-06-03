using DTO.DTO.Models;
using Ecom_API.DTO.Entities;

namespace Ecom_API.Service;

public interface IProductImageService : IDisposable
{
    Task<IEnumerable<ProductImage>> GetAll();
    Task<ProductImage> GetById(int id);
    Task<bool> Create(ProductImageCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

