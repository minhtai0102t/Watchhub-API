using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface ICategoryService : IDisposable
{
    Task<PagedList<CategoryFullRes>> GetAll(QueryStringParameters query);
    Task<CategoryFullRes> GetById(int id);
    Task<IEnumerable<CategoryFullRes>> GetByListId(List<int> ids);
    Task<bool> Update(CategoryUpdateReq model, int id);
    Task<bool> Create(CategoryCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

