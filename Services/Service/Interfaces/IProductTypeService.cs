using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service;

public interface IProductTypeService : IDisposable
{
    Task<PagedList<ProductType>> Search(QueryStringParameters pagingParams, string searchTerm);
    //Task<PagedList<ProductType>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<ProductTypeFullRes>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId);
    Task<PagedList<ProductTypeFullRes>> GetAllByBrandIdPaging(QueryStringParameters pagingParams, int brandId);
    Task<int> GetTotalBySubCategoryId(int subCategoryId);
    Task<int> GetTotalByBrandId(int brandId);
    Task<IEnumerable<ProductTypeFullRes>> GetByListId(List<int> listId);
    Task<ProductTypeFullRes> GetById(int id);
    Task<List<string>> GetImagesById(int id);
    Task<PagedList<ProductType>> Filter(QueryStringParameters pagingParams, int subCategoryId, FilterOptions filterOptions);
    Task<PagedList<ProductType>> FilterBestSeller(QueryStringParameters pagingParams, SORT_OPTION sortOption, GENDER gender);
    Task<PagedList<ProductType>> FilterByPrice(QueryStringParameters pagingParams, int minPrice, int maxPrice);
    Task<PagedList<ProductType>> FilterByGender(QueryStringParameters pagingParams, GENDER gender);
    Task<PagedList<ProductType>> FilterByDialColor(QueryStringParameters pagingParams, DIAL_COLOR color);
    Task<PagedList<ProductType>> Sort(QueryStringParameters param, SORT_OPTION sortOption, bool isDescending = false);
    Task<bool> Update(ProductTypeUpdateReq model, int id);
    Task<bool> Create(ProductTypeCreateReq id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

