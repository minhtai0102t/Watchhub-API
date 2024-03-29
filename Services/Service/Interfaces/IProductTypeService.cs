using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service;

public interface IProductTypeService : IDisposable
{
    #region Admin
    Task<PagedList<ProductType>> SearchAdmin(QueryStringParameters pagingParams, string searchTerm);
    Task<PagedList<ProductType>> SearchByProductTypeCodeOrIdAdmin(QueryStringParameters pagingParams, string searchTerm);
    Task<PagedList<ProductTypeFullRes>> GetAllAdmin(QueryStringParameters pagingParams);
    Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPagingAdmin(QueryStringParameters pagingParams, int subCategoryId);
    #endregion
    Task<PagedList<ProductType>> Search(QueryStringParameters pagingParams, string searchTerm);
    Task<PagedList<ProductType>> SearchByProductTypeCodeOrId(QueryStringParameters pagingParams, string searchTerm);
    //Task<PagedList<ProductType>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<ProductTypeFullRes>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId);
    Task<PagedList<ProductTypeFullRes>> GetAllByBrandIdPaging(QueryStringParameters pagingParams, int brandId);
    Task<int> GetTotalBySubCategoryId(int subCategoryId);
    Task<int> GetTotalByBrandId(int brandId);
    Task<IEnumerable<ProductTypeFullRes>> GetByListId(List<int> listId);
    Task<ProductTypeFullRes> GetById(int id);
    Task<List<string>> GetImagesById(int id);
    Task<PagedList<ProductTypeFullRes>> Filter(QueryStringParameters pagingParams, int subCategoryId, FilterOptions filterOptions);
    Task<PagedList<ProductTypeFullRes>> Filter(QueryStringParameters pagingParams, FilterOptions filterOptions);
    Task<PagedList<ProductType>> FilterBestSeller(QueryStringParameters pagingParams, SORT_OPTION sortOption, GENDER gender);
    Task<PagedList<ProductType>> FilterByPrice(QueryStringParameters pagingParams, int minPrice, int maxPrice);
    Task<PagedList<ProductType>> FilterByGender(QueryStringParameters pagingParams, GENDER gender);
    Task<PagedList<ProductType>> FilterByDialColor(QueryStringParameters pagingParams, DIAL_COLOR color);
    Task<PagedList<ProductType>> Sort(QueryStringParameters param, SORT_OPTION sortOption, bool isDescending = false);
    Task<bool> Update(ProductTypeUpdateReq model, int id);
    Task<bool> UpdateQuantityAfterInventoryCheckingSuccess(int quantity, int id);
    Task<bool> Create(ProductTypeCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

