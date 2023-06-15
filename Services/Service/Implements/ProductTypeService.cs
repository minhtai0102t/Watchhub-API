using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Microsoft.Extensions.Caching.Memory;
using Services.Repositories;

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
                result.Add(new ProductTypeFullRes
                {
                    id = item.id,
                    product_type_name = item.product_type_name,
                    quantity = item.quantity,
                    price = item.price,
                    product_image_uuid = item.product_image_uuid,
                    brand_id = brand.id,
                    brand_name = brand.brand_name,
                    brand_logo = brand.brand_logo,
                    sub_category_id = subCategory.id,
                    sub_category_name = subCategory.sub_category_name,
                    product_feedback_ids = item.product_feedback_ids,
                    alberts = albert,
                    cores = core,
                    glasses = glass,
                    product_source = item.product_source,
                    product_guarantee = item.product_guarantee,
                    product_dial_width = item.product_dial_width,
                    product_dial_height = item.product_dial_height,
                    product_dial_color = item.product_dial_color,
                    product_waterproof = item.product_waterproof,
                    product_features = item.product_features,
                    product_additional_information = item.product_additional_information
                });
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
                    result.Add(new ProductTypeFullRes
                    {
                        id = item.id,
                        product_type_name = item.product_type_name,
                        quantity = item.quantity,
                        price = item.price,
                        product_image_uuid = item.product_image_uuid,
                        brand_id = brand.id,
                        brand_name = brand.brand_name,
                        brand_logo = brand.brand_logo,
                        sub_category_id = subCategory.id,
                        sub_category_name = subCategory.sub_category_name,
                        product_feedback_ids = item.product_feedback_ids,
                        alberts = albert,
                        cores = core,
                        glasses = glass,
                        product_source = item.product_source,
                        product_guarantee = item.product_guarantee,
                        product_dial_width = item.product_dial_width,
                        product_dial_height = item.product_dial_height,
                        product_dial_color = item.product_dial_color,
                        product_waterproof = item.product_waterproof,
                        product_features = item.product_features,
                        product_additional_information = item.product_additional_information
                    });
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
                result.Add(new ProductTypeFullRes
                {
                    id = item.id,
                    product_type_name = item.product_type_name,
                    quantity = item.quantity,
                    price = item.price,
                    product_image_uuid = item.product_image_uuid,
                    brand_id = brand.id,
                    brand_name = brand.brand_name,
                    brand_logo = brand.brand_logo,
                    sub_category_id = subCategory.id,
                    sub_category_name = subCategory.sub_category_name,
                    product_feedback_ids = item.product_feedback_ids,
                    alberts = albert,
                    cores = core,
                    glasses = glass,
                    product_source = item.product_source,
                    product_guarantee = item.product_guarantee,
                    product_dial_width = item.product_dial_width,
                    product_dial_height = item.product_dial_height,
                    product_dial_color = item.product_dial_color,
                    product_waterproof = item.product_waterproof,
                    product_features = item.product_features,
                    product_additional_information = item.product_additional_information
                });

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
        public async Task<ProductType> GetById(int id)
        {
            return await _unitOfWork.ProductTypes.GetByIdAsync(id);
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
        public async Task<bool> Create(ProductTypeCreateReq model)
        {
            var validate = await _unitOfWork.ProductTypes.FindWithCondition(c => c.product_type_name == model.product_type_name);
            if (validate != null)
                throw new AppException("product_type_name '" + model.product_type_name + "' is already existed in system");

            // map model to new user object
            var productType = _mapper.Map<ProductType>(model);

            await _unitOfWork.ProductTypes.CreateAsync(productType);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.ProductTypes.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
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

