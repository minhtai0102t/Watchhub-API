using AutoMapper;
using DTO.DTO.Models;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Microsoft.Extensions.Caching.Memory;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class ProductFeedbackService : IProductFeedbackService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ProductFeedbackService(
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
        public async Task<PagedList<ProductFeedbackFullRes>> GetAll(QueryStringParameters query)
        {
            try
            {
                var listRes = await _unitOfWork.ProductFeedback.GetFullRes(query);
                var result = _mapper.Map<PagedList<ProductFeedbackFullRes>>(listRes);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<ProductFeedbackFullRes>> GetByUserId(QueryStringParameters query, int userId)
        {
            try
            {
                var listRes = await _unitOfWork.ProductFeedback.GetFullRes(query, c => c.user_id == userId);
                var result = _mapper.Map<PagedList<ProductFeedbackFullRes>>(listRes);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<ProductFeedbackFullRes>> GetByProductTypeId(QueryStringParameters query, int productTypeId)
        {
            try
            {
                var listRes = await _unitOfWork.ProductFeedback.GetFullRes(query, c => c.product_type_id == productTypeId);
                var result = _mapper.Map<PagedList<ProductFeedbackFullRes>>(listRes);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProductFeedbackFullRes> GetById(int id)
        {
            try
            {
                var listRes = await _unitOfWork.ProductFeedback.GetByIdAsync(id);
                var result = _mapper.Map<ProductFeedbackFullRes>(listRes);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(ProductFeedbackCreateReq req)
        {
            try
            {
                // map model to new user object
                var isUserExisted = await _unitOfWork.Users.FindWithCondition(c => c.id == req.user_id);
                if (isUserExisted == null)
                {
                    throw new AppException($"User {req.user_id} is not exist");
                }
                var isProductExisted = await _unitOfWork.ProductTypes.FindWithCondition(c => c.id == req.product_type_id);
                if (isProductExisted == null)
                {
                    throw new AppException($"Product Type {req.product_type_id} is not exist");
                }
                var feedback = _mapper.Map<ProductFeedback>(req);
                await _unitOfWork.ProductFeedback.CreateAsync(feedback);

                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.ProductFeedback.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ProductFeedback.DeleteAsync(id);
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
        ~ProductFeedbackService()
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

