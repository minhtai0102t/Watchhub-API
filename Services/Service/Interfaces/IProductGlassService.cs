using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductGlassService : IDisposable
{
    Task<PagedList<ProductGlass>> GetAll(QueryStringParameters query);
    Task<ProductGlass> GetById(int id);
    Task<bool> Update(ProductGlassCreateReq model, int id);
    Task<bool> Create(ProductGlassCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

