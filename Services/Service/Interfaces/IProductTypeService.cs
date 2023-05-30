using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface IProductTypeService : IDisposable
{
    Task<IEnumerable<ProductType>> GetAll();
    Task<ProductType> GetById(int id);
    Task<bool> Update(ProductTypeUpdateReq model, int id);
    Task<bool> Create(ProductTypeCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

