using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface ISubCategoryService : IDisposable
{
    Task<PagedList<SubCategory>> GetAll(QueryStringParameters query);
    Task<PagedList<SubCategory>> GetAllById(QueryStringParameters query, int categoryId);
    Task<SubCategory> GetById(int id);
    Task<bool> Update(SubCategoryUpdateReq model, int id);
    Task<bool> Create(SubCategoryCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

