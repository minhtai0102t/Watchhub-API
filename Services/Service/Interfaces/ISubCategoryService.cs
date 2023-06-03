using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface ISubCategoryService : IDisposable
{
    Task<IEnumerable<SubCategory>> GetAll();
    Task<IEnumerable<SubCategory>> GetAllById(int categoryId);
    Task<SubCategory> GetById(int id);
    Task<bool> Update(SubCategoryUpdateReq model, int id);
    Task<bool> Create(SubCategoryCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

