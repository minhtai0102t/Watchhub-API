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
    public class ProductGlassService : IProductGlassService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public ProductGlassService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<ProductGlass>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.ProductGlasses.GetAllWithPaging(query);
        }
        public async Task<ProductGlass> GetById(int id)
        {
            return await _unitOfWork.ProductGlasses.GetByIdAsync(id);
        }
        public async Task<bool> Update(ProductGlassCreateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.ProductGlasses.FindWithCondition(c => c.id == id);
                if (item == null)
                {
                    throw new AppException("ProductGlass " + id + " does not exist");
                }
                else
                {
                    var itemName = await _unitOfWork.ProductGlasses.FindWithCondition(c => c.glass_name.Trim().ToLower() == model.glass_name.Trim().ToLower());
                    if (itemName != null)
                    {
                        throw new AppException("ProductGlass " + model.glass_name + " is already exist");
                    }
                }
                item.glass_name = model.glass_name;
                item.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.ProductGlasses.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(ProductGlassCreateReq model)
        {
            var validate = await _unitOfWork.ProductGlasses.FindWithCondition(c => c.glass_name == model.glass_name);
            if (validate != null)
                throw new AppException("glass_name '" + model.glass_name + "' is already existed in system");

            // map model to new user object
            var category = _mapper.Map<ProductGlass>(model);

            await _unitOfWork.ProductGlasses.CreateAsync(category);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.ProductGlasses.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ProductGlasses.DeleteAsync(id);
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
        ~ProductGlassService()
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

