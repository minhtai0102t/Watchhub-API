using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Microsoft.Extensions.Caching.Memory;
using Services.Repositories;
using System.Linq.Expressions;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ProductTypeService(
            IJwtUtils jwtUtils,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<bool> Create(ProductTypeCreateReq model)
        {
            try
            {
                var validate = await _unitOfWork.ProductTypes.FindWithCondition(c => c.product_type_name == model.product_type_name);
                if (validate != null)
                    throw new AppException("product_type_name '" + model.product_type_name + "' is already existed in system");

                // map model to new user object
                var productType = _mapper.Map<ProductType>(model);
                productType.gender = model.gender.ToString();
                productType.product_dial_color = model.product_dial_color.ToString();
                // product type full name generate

                await _unitOfWork.ProductTypes.CreateAsync(productType);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<ProductType>> Search(QueryStringParameters pagingParams, string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, c => c.product_type_name.ToLower().Contains(searchTerm.Trim().ToLower()));
                return result;
            }
            return new PagedList<ProductType>();
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAll(QueryStringParameters pagingParams)
        {
            var result = new PagedList<ProductTypeFullRes>();
            var listRes = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams);
            foreach (var item in listRes)
            {
                var brand = await _unitOfWork.Brands.GetByIdAsync(item.brand_id);
                var subCategory = await _unitOfWork.SubCategories.GetByIdAsync(item.sub_category_id);

                var albert = await _unitOfWork.ProductAlberts.GetByIdAsync(item.product_albert_id);
                var core = await _unitOfWork.ProductCores.GetByIdAsync(item.product_core_id);
                var glass = await _unitOfWork.ProductGlasses.GetByIdAsync(item.product_glass_id);
                var productTypeRes = _mapper.Map<ProductTypeFullRes>(item);

                productTypeRes.alberts = albert;
                productTypeRes.cores = core;
                productTypeRes.glasses = glass;

                if (brand != null)
                {
                    productTypeRes.brand_id = brand.id;
                    productTypeRes.brand_name = brand.brand_name;
                    productTypeRes.brand_logo = brand.brand_logo;
                }
                if (subCategory != null)
                {
                    productTypeRes.sub_category_id = subCategory.id;
                    productTypeRes.sub_category_name = subCategory.sub_category_name;
                }
                result.Add(productTypeRes);
            }

            result.TotalCount = listRes.TotalCount;
            return result;
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId)
        {
            var items = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, c => c.sub_category_id == subCategoryId);
            var result = new PagedList<ProductTypeFullRes>();
            foreach (var item in items)
            {
                if (item.sub_category_id == subCategoryId)
                {
                    var brand = await _unitOfWork.Brands.GetByIdAsync(item.brand_id);
                    var subCategory = await _unitOfWork.SubCategories.GetByIdAsync(item.sub_category_id);

                    var albert = await _unitOfWork.ProductAlberts.GetByIdAsync(item.product_albert_id);
                    var core = await _unitOfWork.ProductCores.GetByIdAsync(item.product_core_id);
                    var glass = await _unitOfWork.ProductGlasses.GetByIdAsync(item.product_glass_id);

                    var productTypeRes = _mapper.Map<ProductTypeFullRes>(item);
                    productTypeRes.alberts = albert;
                    productTypeRes.cores = core;
                    productTypeRes.glasses = glass;

                    if (brand != null)
                    {
                        productTypeRes.brand_id = brand.id;
                        productTypeRes.brand_name = brand.brand_name;
                        productTypeRes.brand_logo = brand.brand_logo;
                    }
                    if (subCategory != null)
                    {
                        productTypeRes.sub_category_id = subCategory.id;
                        productTypeRes.sub_category_name = subCategory.sub_category_name;
                    }

                    result.Add(productTypeRes);
                }
            }

            result.TotalCount = items.TotalCount;
            return result;
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAllByBrandIdPaging(QueryStringParameters pagingParams, int brandId)
        {
            var items = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, c => c.brand_id == brandId);
            var result = new PagedList<ProductTypeFullRes>();
            foreach (var item in items)
            {
                var brand = await _unitOfWork.Brands.GetByIdAsync(item.brand_id);
                var subCategory = await _unitOfWork.SubCategories.GetByIdAsync(item.sub_category_id);

                var albert = await _unitOfWork.ProductAlberts.GetByIdAsync(item.product_albert_id);
                var core = await _unitOfWork.ProductCores.GetByIdAsync(item.product_core_id);
                var glass = await _unitOfWork.ProductGlasses.GetByIdAsync(item.product_glass_id);
                var productTypeRes = _mapper.Map<ProductTypeFullRes>(item);

                productTypeRes.alberts = albert;
                productTypeRes.cores = core;
                productTypeRes.glasses = glass;

                if (brand != null)
                {
                    productTypeRes.brand_id = brand.id;
                    productTypeRes.brand_name = brand.brand_name;
                    productTypeRes.brand_logo = brand.brand_logo;
                }
                if (subCategory != null)
                {
                    productTypeRes.sub_category_id = subCategory.id;
                    productTypeRes.sub_category_name = subCategory.sub_category_name;
                }

                result.Add(productTypeRes);
            }
            result.TotalCount = items.TotalCount;
            return result;
        }
        public async Task<int> GetTotalBySubCategoryId(int subCategoryId)
        {
            var items = await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.sub_category_id == subCategoryId);
            return items.Count();
        }
        public async Task<int> GetTotalByBrandId(int brandId)
        {
            var items = await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.brand_id == brandId);
            return items.Count();
        }
        public async Task<ProductTypeFullRes> GetById(int id)
        {
            var item = await _unitOfWork.ProductTypes.GetByIdAsync(id);

            var brand = await _unitOfWork.Brands.GetByIdAsync(item.brand_id);
            var subCategory = await _unitOfWork.SubCategories.GetByIdAsync(item.sub_category_id);
            var albert = await _unitOfWork.ProductAlberts.GetByIdAsync(item.product_albert_id);
            var core = await _unitOfWork.ProductCores.GetByIdAsync(item.product_core_id);
            var glass = await _unitOfWork.ProductGlasses.GetByIdAsync(item.product_glass_id);
            var productTypeRes = _mapper.Map<ProductTypeFullRes>(item);

            productTypeRes.alberts = albert;
            productTypeRes.cores = core;
            productTypeRes.glasses = glass;

            if (brand != null)
            {
                productTypeRes.brand_id = brand.id;
                productTypeRes.brand_name = brand.brand_name;
                productTypeRes.brand_logo = brand.brand_logo;
            }

            if (subCategory != null)
            {
                productTypeRes.sub_category_id = subCategory.id;
                productTypeRes.sub_category_name = subCategory.sub_category_name;
            }

            return productTypeRes;
        }
        public async Task<IEnumerable<ProductTypeFullRes>> GetByListId(List<int> listId)
        {
            var result = new List<ProductTypeFullRes>();
            var listItem = await _unitOfWork.ProductTypes.FindAllWithCondition(c => listId.Any(p => p == c.id));
            foreach (var item in listItem)
            {
                var brand = await _unitOfWork.Brands.GetByIdAsync(item.brand_id);
                var subCategory = await _unitOfWork.SubCategories.GetByIdAsync(item.sub_category_id);
                var albert = await _unitOfWork.ProductAlberts.GetByIdAsync(item.product_albert_id);
                var core = await _unitOfWork.ProductCores.GetByIdAsync(item.product_core_id);
                var glass = await _unitOfWork.ProductGlasses.GetByIdAsync(item.product_glass_id);
                var productTypeRes = _mapper.Map<ProductTypeFullRes>(item);

                productTypeRes.alberts = albert;
                productTypeRes.cores = core;
                productTypeRes.glasses = glass;

                if (brand != null)
                {
                    productTypeRes.brand_id = brand.id;
                    productTypeRes.brand_name = brand.brand_name;
                    productTypeRes.brand_logo = brand.brand_logo;
                }

                if (subCategory != null)
                {
                    productTypeRes.sub_category_id = subCategory.id;
                    productTypeRes.sub_category_name = subCategory.sub_category_name;
                }
                result.Add(productTypeRes);
            }
            return result.OrderBy(c => c.id);
        }
        public async Task<List<string>> GetImagesById(int id)
        {
            var item = await _unitOfWork.ProductTypes.GetByIdAsync(id);
            return item.product_image_uuid;
        }
        public async Task<PagedList<ProductType>> Filter(QueryStringParameters pagingParams, int subCategoryId, FilterOptions filterOptions)
        {
            try
            {
                string dialColor = filterOptions.dialColor.ToString();
                string gender = filterOptions.gender.ToString();
                int? minPrice = filterOptions.minPrice;
                int? maxPrice = filterOptions.maxPrice;
                Expression<Func<ProductType, bool>> predicate = p => p.sub_category_id == subCategoryId;

                if (!string.IsNullOrEmpty(dialColor))
                {
                    Expression<Func<ProductType, bool>> condition = p => p.product_dial_color.Equals(dialColor);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    Expression<Func<ProductType, bool>> condition = p => p.gender.Equals(gender);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (minPrice != null && maxPrice != null && minPrice >= 0 && maxPrice > minPrice)
                {
                    Expression<Func<ProductType, bool>> condition = p => p.price >= filterOptions.minPrice && p.price <= filterOptions.maxPrice;
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, predicate);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<PagedList<ProductType>> FilterByPrice(QueryStringParameters pagingParams, int minPrice, int maxPrice)
        {
            if (maxPrice == 0)
            {
                return new PagedList<ProductType>();
            }
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.price >= minPrice && c.price <= maxPrice));
            return result;
        }
        public async Task<PagedList<ProductType>> FilterByGender(QueryStringParameters pagingParams, GENDER gender)
        {
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.gender == gender.ToString()));
            return result;
        }
        public async Task<PagedList<ProductType>> FilterByDialColor(QueryStringParameters pagingParams, DIAL_COLOR color)
        {
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.product_dial_color == color.ToString()));
            return result;
        }
        public async Task<PagedList<ProductType>> Sort(QueryStringParameters param, SORT_OPTION sortOption, bool isDescending = false)
        {
            try
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(param, sortOption, isDescending);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Update(ProductTypeUpdateReq model, int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                {
                    throw new AppException("ProductType " + id + " does not exist");
                }
                var mapData = _mapper.Map<ProductType>(model);
                mapData.gender = model.gender.ToString();
                mapData.product_dial_color = model.product_dial_color.ToString();
                mapData.id = item.id;
                mapData.updated_date = DateTime.Now.ToUniversalTime();
                await _unitOfWork.ProductTypes.UpdateAsync(mapData);
                var res = await _unitOfWork.SaveChangesAsync();

                return res == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> SoftDelete(int id)
        {
            try
            {
                await _unitOfWork.ProductTypes.SoftDeleteAsync(id);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ProductTypes.DeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~ProductTypeService()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

