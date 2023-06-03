using AutoMapper;
using Ecom_API.Authorization;
using Ecom_API.DTO.Entities;
using Ecom_API.Helpers;
using Services.Repositories;
using Microsoft.Extensions.Caching.Memory;
using DTO.DTO.Models;

namespace Ecom_API.Service
{
    public class ProductImageService : IProductImageService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ProductImageService(
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
        public async Task<IEnumerable<ProductImage>> GetAll()
        {
            return await _unitOfWork.ProductImages.GetAllAsync();
        }
        public async Task<ProductImage> GetById(int id)
        {
            return await _unitOfWork.ProductImages.GetByIdAsync(id);
        }
        public async Task<bool> Create(ProductImageCreateReq model)
        {
            var validate = await _unitOfWork.ProductImages.FindWithCondition(c => c.product_image_url == model.product_image_url);
            if (validate != null)
                throw new AppException("product_image_url '" + model.product_image_url + "' is already existed in system");

            // map model to new user object
            var productType = _mapper.Map<ProductImage>(model);
            
            await _unitOfWork.ProductImages.CreateAsync(productType);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.ProductImages.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ProductImages.DeleteAsync(id);
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
        ~ProductImageService()
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

