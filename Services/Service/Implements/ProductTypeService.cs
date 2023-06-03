using AutoMapper;
using Ecom_API.Authorization;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Isopoh.Cryptography.Argon2;
using Services.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Ecom_API.PagingModel;

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

        public async Task<IEnumerable<ProductType>> GetAll(QueryStringParameters pagingParams)
        {
            return await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams);
        }

        public async Task<IEnumerable<ProductType>> GetAllBySubCategoryId(int subCategoryId)
        {
            return await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.sub_category_id == subCategoryId);
        }
        public async Task<IEnumerable<ProductType>> GetAllByBrandId(int brandId)
        {
            return await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.brand_id == brandId);
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
                item.product_type_name = model.product_type_name;
                item.price = model.price;
                item.brand_id = model.brand_id;
                item.sub_category_id = model.sub_category_id;

                await _unitOfWork.ProductTypes.UpdateAsync(item);
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

