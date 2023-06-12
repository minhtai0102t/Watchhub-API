using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductCoreService : IDisposable
{
    Task<PagedList<ProductCore>> GetAll(QueryStringParameters query);
    Task<ProductCore> GetById(int id);
    Task<bool> Update(ProductCoreCreateReq model, int id);
    Task<bool> Create(ProductCoreCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

