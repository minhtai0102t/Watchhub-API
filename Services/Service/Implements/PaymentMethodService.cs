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
    public class PaymentMethodService : IPaymentMethodService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public PaymentMethodService(
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
        public async Task<PagedList<PaymentMethod>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.PaymentMethods.GetAllWithPaging(query);
        }
        public async Task<PaymentMethod> GetById(int id)
        {
            return await _unitOfWork.PaymentMethods.GetByIdAsync(id);
        }
        public async Task<bool> Update(PaymentMethodCreateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.PaymentMethods.FindWithCondition(c => c.id == id);
                if (item == null)
                {
                    throw new AppException("PaymentMethod " + id + " does not exist");
                }
                else
                {
                    var name = await _unitOfWork.PaymentMethods.FindAllWithCondition(c => c.payment_method_name == model.payment_method_name);
                    if (name.Any())
                    {
                        throw new AppException("category " + model.payment_method_name + " is already exist");
                    }
                }
                item.payment_method_name = model.payment_method_name;
                item.updated_date = DateTime.Now.ToUniversalTime();
                await _unitOfWork.PaymentMethods.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(PaymentMethodCreateReq model)
        {
            var validate = await _unitOfWork.PaymentMethods.FindWithCondition(c => c.payment_method_name == model.payment_method_name);
            if (validate != null)
                throw new AppException("payment_method_name '" + model.payment_method_name + "' is already existed in system");

            // map model to new user object
            var category = _mapper.Map<PaymentMethod>(model);

            await _unitOfWork.PaymentMethods.CreateAsync(category);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.PaymentMethods.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PaymentMethods.DeleteAsync(id);
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
        ~PaymentMethodService()
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

