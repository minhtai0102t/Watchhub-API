using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class ProductAlbertService : IProductAlbertService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public ProductAlbertService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<ProductAlbert>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.ProductAlberts.GetAllWithPaging(query);
        }
        public async Task<ProductAlbert> GetById(int id)
        {
            return await _unitOfWork.ProductAlberts.GetByIdAsync(id);
        }
        public async Task<bool> Update(ProductAlbertCreateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.ProductAlberts.FindWithCondition(c => c.id == id);
                if (item == null)
                {
                    throw new AppException("ProductAlbert " + id + " does not exist");
                }
                else
                {
                    var itemName = await _unitOfWork.ProductAlberts.FindWithCondition(c => c.albert_name.Trim().ToLower() == model.albert_name.Trim().ToLower());
                    if(itemName != null)
                    {
                        throw new AppException("ProductAlbert " + model.albert_name + " is already exist");
                    }
                }
                item.albert_name = model.albert_name;
                item.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.ProductAlberts.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(ProductAlbertCreateReq model)
        {
            var validate = await _unitOfWork.ProductAlberts.FindWithCondition(c => c.albert_name == model.albert_name);
            if (validate != null)
                throw new AppException("albert_name '" + model.albert_name + "' is already existed in system");

            // map model to new user object
            var albert = _mapper.Map<ProductAlbert>(model);

            await _unitOfWork.ProductAlberts.CreateAsync(albert);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.ProductAlberts.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ProductAlberts.DeleteAsync(id);
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
        ~ProductAlbertService()
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

