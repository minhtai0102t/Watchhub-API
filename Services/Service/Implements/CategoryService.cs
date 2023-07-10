using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public CategoryService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<CategoryFullRes>> GetAll(QueryStringParameters query)
        {
            var listRes = await _unitOfWork.Categories.GetFullRes(query);
            var res = _mapper.Map<PagedList<CategoryFullRes>>(listRes);

            foreach(var item in res){
                item.subCategories = item.subCategories.GroupBy(x => x.sub_category_name)
                                                        .Select(g => g.First())
                                                        .ToList();
            }
            res.TotalCount = listRes.TotalCount;
            return res;

        }
        public async Task<CategoryFullRes> GetById(int id)
        {
            var listRes = await _unitOfWork.Categories.GetFullResById(id);

            var res = _mapper.Map<CategoryFullRes>(listRes);

            return res;
        }
        public async Task<IEnumerable<CategoryFullRes>> GetByListId(List<int> ids)
        {
            var listRes = await _unitOfWork.Categories.GetFullResByListId(ids);

            var res = _mapper.Map<IEnumerable<CategoryFullRes>>(listRes);

            return res;
        }
        public async Task<bool> Update(CategoryUpdateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.Categories.FindWithCondition(c => c.id == id);
                if (item == null)
                {
                    throw new AppException("category " + id + " does not exist");
                }
                else
                {
                    var name = await _unitOfWork.Categories.FindAllWithCondition(c => c.category_name == model.category_name);
                    if (name.Any())
                    {
                        throw new AppException("category " + model.category_name + " is already exist");
                    }
                }
                item.category_name = model.category_name;
                item.updated_date = DateTime.Now.ToUniversalTime();
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
            var validate = await _unitOfWork.Categories.FindWithCondition(c => c.category_name.ToLower() == model.category_name.ToLower());
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
            try
            {
                await _unitOfWork.Categories.SoftDeleteAsync(id);
                var res = await _unitOfWork.SaveChangesAsync();

                return res >= 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int id)
        {
            // delete all record in sub categories contain category id
            await _unitOfWork.SubCategories.DeleteByCategoryId(id);
            var res = await _unitOfWork.SaveChangesAsync();

            // delete category
            await _unitOfWork.Categories.DeleteAsync(id);
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

