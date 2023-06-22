using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductTypeService : IDisposable
{
    Task<PagedList<ProductType>> Search(QueryStringParameters pagingParams, string searchTerm);
    Task<PagedList<ProductTypeFullRes>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId);
    Task<PagedList<ProductTypeFullRes>> GetAllByBrandIdPaging(QueryStringParameters pagingParams, int brandId);
    Task<int> GetTotalBySubCategoryId(int subCategoryId);
    Task<int> GetTotalByBrandId(int brandId);
    Task<ProductTypeFullRes> GetById(int id);
    Task<bool> Update(ProductTypeUpdateReq model, int id);
    Task<bool> Create(ProductTypeCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

