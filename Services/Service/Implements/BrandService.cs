using AutoMapper;
using Ecom_API.Authorization;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Isopoh.Cryptography.Argon2;
using Services.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Ecom_API.PagingModel;
using EBird.Application.Model.PagingModel;

namespace Ecom_API.Service
{
    public class BrandService : IBrandService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public BrandService(
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
        public async Task<PagedList<Brand>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.Brands.GetAllWithPaging(query);
        }
        public async Task<Brand> GetById(int id)
        {
            return await _unitOfWork.Brands.GetByIdAsync(id);
        }
        public async Task<bool> Update(BrandUpdateReq model, int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                {
                    throw new AppException("brand " + id + " does not exist");
                }
                item.brand_name = model.brand_name;
                item.brand_logo = model.brand_logo;
                await _unitOfWork.Brands.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(BrandCreateReq model)
        {
            var validate = await _unitOfWork.Brands.FindWithCondition(c => c.brand_name == model.brand_name);
            if (validate != null)
                throw new AppException("brand_name '" + model.brand_name + "' is already existed in system");

            // map model to new user object
            var category = _mapper.Map<Brand>(model);

            await _unitOfWork.Brands.CreateAsync(category);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.Brands.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Brands.DeleteAsync(id);
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
        ~BrandService()
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

