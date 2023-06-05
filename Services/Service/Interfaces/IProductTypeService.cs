using System;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductTypeService : IDisposable
{
    //Task<IEnumerable<ProductType>> GetAll();
    Task<IEnumerable<ProductType>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId);
    Task<IEnumerable<ProductType>> GetAllByBrandIdPaging(QueryStringParameters pagingParams, int brandId);
    Task<int> GetTotalBySubCategoryId(int subCategoryId);
    Task<int> GetTotalByBrandId(int brandId);
    Task<PagedList<ProductType>> GetAll(QueryStringParameters pagingParams);
    Task<ProductType> GetById(int id);
    Task<bool> Update(ProductTypeUpdateReq model, int id);
    Task<bool> Create(ProductTypeCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

