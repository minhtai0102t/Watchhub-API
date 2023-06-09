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
    public class SubCategoryService : ISubCategoryService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public SubCategoryService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<SubCategory>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.SubCategories.GetAllWithPaging(query);
        }
        public async Task<PagedList<SubCategory>> GetAllById(QueryStringParameters query, int categoryId)
        {
            return await _unitOfWork.SubCategories.GetAllWithPaging(query, c => c.category_id == categoryId);
        }
        public async Task<SubCategory> GetById(int id)
        {
            return await _unitOfWork.SubCategories.GetByIdAsync(id);
        }
        public async Task<bool> Update(SubCategoryUpdateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.SubCategories.FindWithCondition(c => c.id == id);
                if (item == null)
                {
                    throw new AppException("sub_category " + id + " does not exist");
                }
                else{
                    var name = await _unitOfWork.SubCategories.FindAllWithCondition(c => c.sub_category_name == model.sub_category_name);
                    if(name.Any()){
                        throw new AppException("category " + model.sub_category_name + " is already exist");
                    }
                }
                item.sub_category_name = model.sub_category_name;
                item.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.SubCategories.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(SubCategoryCreateReq model)
        {
            var validate = await _unitOfWork.SubCategories.FindWithCondition(c => c.sub_category_name == model.sub_category_name);
            if (validate != null)
                throw new AppException("sub_category_name '" + model.sub_category_name + "' is already existed in system");
            // map model to new user object
            var subCategory = _mapper.Map<SubCategory>(model);

            await _unitOfWork.SubCategories.CreateAsync(subCategory);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.SubCategories.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ProductSub.DeleteBySubCateId(id);
            var res = await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.SubCategories.DeleteAsync(id);
            res = await _unitOfWork.SaveChangesAsync();

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
        ~SubCategoryService()
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

