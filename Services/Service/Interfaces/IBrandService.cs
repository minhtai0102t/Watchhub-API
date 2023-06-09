using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IBrandService : IDisposable
{
    Task<PagedList<Brand>> GetAll(QueryStringParameters query);
    Task<Brand> GetById(int id);
    Task<bool> Update(BrandUpdateReq model, int id);
    Task<bool> Create(BrandCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

