using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface ICategoryService : IDisposable
{
    Task<PagedList<Category>> GetAll(QueryStringParameters query);
    Task<Category> GetById(int id);
    Task<bool> Update(CategoryUpdateReq model, int id);
    Task<bool> Create(CategoryCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

