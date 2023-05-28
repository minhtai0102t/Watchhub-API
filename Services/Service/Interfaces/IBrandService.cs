using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface IBrandService : IDisposable
{
    Task<IEnumerable<Brand>> GetAll();
    Task<Brand> GetById(int id);
    Task<bool> Update(BrandUpdateReq model, int id);
    Task<bool> Create(BrandCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

