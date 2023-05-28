using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface ICategoryService : IDisposable
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<bool> Update(CategoryUpdateReq model, int id);
    Task<bool> Create(CategoryCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

