using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Microsoft.Extensions.Caching.Memory;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public ProductService(
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
        public async Task<PagedList<Product>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.Products.GetAllWithPaging(query);
        }
        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
        public async Task<PagedList<Product>> GetByProductTypeId(QueryStringParameters pagingParams, int id)
        {
            var items = await _unitOfWork.Products.GetAllWithPaging(pagingParams, c => c.product_type_id == id);
            return items;
        }
        public async Task<bool> Create(int product_type_id, string product_code)
        {
            var validate = await _unitOfWork.Products.FindWithCondition(c => c.product_code == product_code);
            if (validate != null)
                throw new AppException("product_code '" + product_code + "' is already existed in system");
            // map model to new user object
            await _unitOfWork.Products.CreateAsync(new Product
            {
                product_type_id = product_type_id,
                product_code = product_code
            });

            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.Products.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
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
        ~ProductService()
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

