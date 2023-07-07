using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Services.Repositories;
using System.Linq.Expressions;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private IUnitOfWork _unitOfWork;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public ProductTypeService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Create(ProductTypeCreateReq model)
        {
            try
            {

                var validate = await _unitOfWork.ProductTypes.FindWithCondition(c => c.product_type_code.Trim().ToLower() == model.product_type_code.Trim().ToLower());
                if (validate != null)
                    throw new AppException("product_type_code '" + model.product_type_code + "' is already existed in system");

                // map model
                var productType = _mapper.Map<ProductType>(model);
                productType.gender = model.gender.ToString();
                productType.product_dial_color = model.product_dial_color.ToString();

                using (var transaction = _unitOfWork.GetDbContextHosting().Database.BeginTransaction())
                {
                    try
                    {
                        await _unitOfWork.ProductTypes.CreateAsync(productType);
                        var res = await _unitOfWork.SaveChangesAsync();

                        productType.productSubCategories = model.sub_category_ids.Select(subCategoryId => new ProductSubCategory
                        {
                            product_type_id = productType.id,
                            sub_category_id = subCategoryId
                        }).ToList();

                        res = await _unitOfWork.SaveChangesAsync();

                        transaction.Commit();
                        return res >= 1 ? true : false;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<ProductType>> Search(QueryStringParameters pagingParams, string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, c => c.product_type_name.Trim().ToLower().Contains(searchTerm.Trim().ToLower()));
                return result;
            }
            return new PagedList<ProductType>();
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAll(QueryStringParameters pagingParams)
        {
            try
            {
                var listRes = await _unitOfWork.ProductTypes.GetFullRes(pagingParams);

                var result = _mapper.Map<PagedList<ProductTypeFullRes>>(listRes);

                for (int i = 0; i < result.Count; i++)
                {
                    result[i].products = _mapper.Map<ICollection<ProductMapper>>(listRes[i].products);
                }

                result.TotalCount = listRes.TotalCount;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId)
        {
            Expression<Func<ProductType, bool>> predicate = p => p.productSubCategories.Any(pc => pc.sub_category_id == subCategoryId);

            var listRes = await _unitOfWork.ProductTypes.GetFullResWithCondition(pagingParams, predicate);
            var result = _mapper.Map<PagedList<ProductTypeFullRes>>(listRes);

            for (int i = 0; i < result.Count; i++)
            {
                result[i].products = _mapper.Map<ICollection<ProductMapper>>(listRes[i].products);
            }
            result.TotalCount = listRes.TotalCount;
            return result;
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAllByBrandIdPaging(QueryStringParameters pagingParams, int brandId)
        {
            Expression<Func<ProductType, bool>> predicate = p => p.brand_id == brandId;
            var listRes = await _unitOfWork.ProductTypes.GetFullResWithCondition(pagingParams, predicate);

            var result = _mapper.Map<PagedList<ProductTypeFullRes>>(listRes);
            for (int i = 0; i < result.Count; i++)
            {
                result[i].products = _mapper.Map<ICollection<ProductMapper>>(listRes[i].products);
            }
            result.TotalCount = listRes.TotalCount;

            return result;
        }
        public async Task<int> GetTotalBySubCategoryId(int subCategoryId)
        {
            var items = await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.productSubCategories.Any(pc => pc.sub_category_id == subCategoryId));
            return items.Count();
        }
        public async Task<int> GetTotalByBrandId(int brandId)
        {
            var items = await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.brand_id == brandId);
            return items.Count();
        }
        public async Task<ProductTypeFullRes> GetById(int id)
        {
            var listRes = await _unitOfWork.ProductTypes.GetFullResById(id);

            var result = _mapper.Map<ProductTypeFullRes>(listRes);
            result.products = _mapper.Map<IEnumerable<ProductMapper>>(listRes.products).ToList();

            return result;
        }
        public async Task<IEnumerable<ProductTypeFullRes>> GetByListId(List<int> listId)
        {
            var listRes = await _unitOfWork.ProductTypes.GetFullResByListId(listId);

            var result = _mapper.Map<IEnumerable<ProductTypeFullRes>>(listRes).ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                result[i].products = _mapper.Map<ICollection<ProductMapper>>(listRes.ToList()[i].products);
            }
            return result;
        }
        public async Task<List<string>> GetImagesById(int id)
        {
            var item = await _unitOfWork.ProductTypes.GetByIdAsync(id);
            return item.product_image_uuid;
        }
        public async Task<PagedList<ProductType>> Filter(QueryStringParameters pagingParams, int subCategoryId, FilterOptions filterOptions)
        {
            try
            {
                string dialColor = filterOptions.dialColor.ToString();
                string gender = filterOptions.gender.ToString();
                int? minPrice = filterOptions.minPrice;
                int? maxPrice = filterOptions.maxPrice;
                Expression<Func<ProductType, bool>> predicate = p => p.productSubCategories.Any(pc => pc.sub_category_id == subCategoryId);

                if (!string.IsNullOrEmpty(dialColor))
                {
                    Expression<Func<ProductType, bool>> condition = p => p.product_dial_color.Equals(dialColor);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    Expression<Func<ProductType, bool>> condition = p => p.gender.Equals(gender);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (minPrice != null && maxPrice != null && minPrice >= 0 && maxPrice > minPrice)
                {
                    Expression<Func<ProductType, bool>> condition = p => p.price >= filterOptions.minPrice && p.price <= filterOptions.maxPrice;
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, predicate);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<PagedList<ProductType>> FilterBestSeller(QueryStringParameters pagingParams, SORT_OPTION sortOption, GENDER gender)
        {
            try
            {
                Expression<Func<ProductType, bool>> predicate = p => true;
                switch (gender.ToString())
                {
                    case "MALE":
                        {
                            Expression<Func<ProductType, bool>> condition = p => p.gender.Equals("MALE");
                            predicate = PredicateBuilder.And(predicate, condition);
                            break;
                        }
                    case "FEMALE":
                        {
                            Expression<Func<ProductType, bool>> condition = p => p.gender.Equals("FEMALE");
                            predicate = PredicateBuilder.And(predicate, condition);
                            break;
                        }
                    case "COUPLE":
                        {
                            Expression<Func<ProductType, bool>> condition = p => p.gender.Equals("COUPLE");
                            predicate = PredicateBuilder.And(predicate, condition);
                            break;
                        }
                    case "UNISEX":
                        {

                            Expression<Func<ProductType, bool>> condition = p => p.gender.Equals("UNISEX");
                            predicate = PredicateBuilder.And(predicate, condition);
                            break;
                        }
                }
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, predicate, sortOption, true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<ProductType>> FilterByPrice(QueryStringParameters pagingParams, int minPrice, int maxPrice)
        {
            if (maxPrice == 0)
            {
                return new PagedList<ProductType>();
            }
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.price >= minPrice && c.price <= maxPrice));
            return result;
        }
        public async Task<PagedList<ProductType>> FilterByGender(QueryStringParameters pagingParams, GENDER gender)
        {
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.gender == gender.ToString()));
            return result;
        }
        public async Task<PagedList<ProductType>> FilterByDialColor(QueryStringParameters pagingParams, DIAL_COLOR color)
        {
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.product_dial_color == color.ToString()));
            return result;
        }
        public async Task<PagedList<ProductType>> Sort(QueryStringParameters param, SORT_OPTION sortOption, bool isDescending = false)
        {
            try
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(param, c => true, sortOption, isDescending);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Update(ProductTypeUpdateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.ProductTypes.FindWithCondition(c => c.id == id);
                if (item == null)
                {
                    throw new AppException("ProductType " + id + " does not exist");
                }
                var mapData = _mapper.Map<ProductType>(model);
                mapData.gender = model.gender.ToString();
                mapData.product_dial_color = model.product_dial_color.ToString();
                mapData.id = item.id;
                mapData.created_date = item.created_date;
                mapData.updated_date = DateTime.Now.ToUniversalTime();

                await _unitOfWork.ProductTypes.UpdateAsync(mapData);
                var res = await _unitOfWork.SaveChangesAsync();

                return res == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> SoftDelete(int id)
        {
            try
            {
                await _unitOfWork.ProductTypes.SoftDeleteAsync(id);
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
            await _unitOfWork.ProductTypes.DeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        //private async Task UpdateForeignKeyId(int id, int product_albert_id, int product_core_id, int product_glass_id)
        //{
        //    // update albert, glass, core id
        //    if (product_albert_id > 0)
        //    {
        //        await _productAlbertService.Update(new ProductAlbertUpdateReq { product_type_id = id }, product_albert_id);
        //    }
        //    if (product_core_id > 0)
        //    {
        //        await _productCoreService.Update(new ProductAlbertUpdateReq { product_type_id = id }, product_core_id);
        //    }
        //    if (product_glass_id > 0)
        //    {
        //        await _productGlassService.Update(new ProductAlbertUpdateReq { product_type_id = id }, product_glass_id);
        //    }
        //}
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
        ~ProductTypeService()
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

