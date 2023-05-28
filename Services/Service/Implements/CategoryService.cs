using AutoMapper;
using Ecom_API.Authorization;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Isopoh.Cryptography.Argon2;
using Services.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Ecom_API.Service
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public CategoryService(
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
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }
        public async Task<bool> Update(CategoryUpdateReq model, int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                {
                    throw new AppException("category " + id + " does not exist");
                }
                item.category_name = model.category_name;

                await _unitOfWork.Categories.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(CategoryCreateReq model)
        {
            var validate = await _unitOfWork.Categories.FindWithCondition(c => c.category_name == model.category_name);
            if (validate != null)
                throw new AppException("category_name '" + model.category_name + "' is already existed in system");

            // map model to new user object
            var category = _mapper.Map<Category>(model);

            await _unitOfWork.Categories.CreateAsync(category);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.Categories.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Categories.DeleteAsync(id);
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
        ~CategoryService()
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

