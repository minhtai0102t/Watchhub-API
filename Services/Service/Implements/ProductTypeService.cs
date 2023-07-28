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
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedList<ProductType>> Search(QueryStringParameters pagingParams, string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, c => c.quantity > 0 && c.product_type_name.Trim().ToLower().Contains(searchTerm.Trim().ToLower()));
                return result;
            }
            return new PagedList<ProductType>();
        }
        public async Task<PagedList<ProductType>> SearchByProductTypeCodeOrId(QueryStringParameters pagingParams, string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams,
                                            c => c.quantity > 0 && (c.product_type_code.Trim().ToLower().Contains(searchTerm.Trim().ToLower()))
                                            || c.id.ToString().Contains(searchTerm.Trim().ToLower()));
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
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PagedList<ProductTypeFullRes>> GetAllBySubCategoryIdPaging(QueryStringParameters pagingParams, int subCategoryId)
        {
            Expression<Func<ProductType, bool>> predicate = p => p.productSubCategories.Any(pc => pc.sub_category_id == subCategoryId) && p.is_deleted == false && p.quantity > 0;

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
            Expression<Func<ProductType, bool>> predicate = p => p.brand_id == brandId && p.is_deleted == false && p.quantity > 0;
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
            var items = await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.quantity > 0 && c.productSubCategories.Any(pc => pc.sub_category_id == subCategoryId));
            return items.Count();
        }
        public async Task<int> GetTotalByBrandId(int brandId)
        {
            var items = await _unitOfWork.ProductTypes.FindAllWithCondition(c => c.quantity > 0 && c.brand_id == brandId);
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
        public async Task<PagedList<ProductTypeFullRes>> Filter(QueryStringParameters pagingParams, int subCategoryId, FilterOptions filterOptions)
        {
            try
            {
                List<int> brands = filterOptions.brands;
                int? minPrice = filterOptions.minPrice;
                int? maxPrice = filterOptions.maxPrice;
                List<int> alberts = filterOptions.alberts;
                List<int> cores = filterOptions.cores;
                List<int> glasses = filterOptions.glasses;
                List<string> genders = filterOptions.genders;
                List<string> dialColors = filterOptions.dialColors;

                Expression<Func<ProductType, bool>> predicate = p => p.quantity > 0 && p.productSubCategories.Any(pc => pc.sub_category_id == subCategoryId);
                if (alberts.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => alberts.Any(q => q == p.product_albert_id);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (cores.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => cores.Any(q => q == p.product_core_id);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (glasses.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => glasses.Any(q => q == p.product_glass_id);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (dialColors.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => dialColors.Any(q => q == p.product_dial_color);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (genders.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => genders.Any(q => p.gender == q);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (brands.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => brands.Any(q => p.brand_id == q);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (minPrice != null && maxPrice != null && minPrice >= 0 && maxPrice > minPrice)
                {
                    Expression<Func<ProductType, bool>> condition = p => p.price >= filterOptions.minPrice && p.price <= filterOptions.maxPrice;
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                var listRes = await _unitOfWork.ProductTypes.GetFullResWithCondition(pagingParams, predicate);
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
                throw;
            }

        }
        public async Task<PagedList<ProductTypeFullRes>> Filter(QueryStringParameters pagingParams, FilterOptions filterOptions)
        {
            try
            {
                List<int> brands = filterOptions.brands;
                int? minPrice = filterOptions.minPrice;
                int? maxPrice = filterOptions.maxPrice;
                List<int> alberts = filterOptions.alberts;
                List<int> cores = filterOptions.cores;
                List<int> glasses = filterOptions.glasses;
                List<string> genders = filterOptions.genders;
                List<string> dialColors = filterOptions.dialColors;

                Expression<Func<ProductType, bool>> predicate = p => p.quantity > 0;
                if (alberts.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => alberts.Any(q => q == p.product_albert_id);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (cores.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => cores.Any(q => q == p.product_core_id);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (glasses.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => glasses.Any(q => q == p.product_glass_id);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (dialColors.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => dialColors.Any(q => q == p.product_dial_color);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (genders.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => genders.Any(q => p.gender == q);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (brands.Any())
                {
                    Expression<Func<ProductType, bool>> condition = p => brands.Any(q => p.brand_id == q);
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                if (minPrice != null && maxPrice != null && minPrice >= 0 && maxPrice > minPrice)
                {
                    Expression<Func<ProductType, bool>> condition = p => p.price >= filterOptions.minPrice && p.price <= filterOptions.maxPrice;
                    predicate = PredicateBuilder.And(predicate, condition);
                }
                var listRes = await _unitOfWork.ProductTypes.GetFullResWithCondition(pagingParams, predicate);
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
                throw;
            }
        }
        public async Task<PagedList<ProductType>> FilterBestSeller(QueryStringParameters pagingParams, SORT_OPTION sortOption, GENDER gender)
        {
            try
            {
                Expression<Func<ProductType, bool>> predicate = p => p.quantity > 0;
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
                throw;
            }
        }
        public async Task<PagedList<ProductType>> FilterByPrice(QueryStringParameters pagingParams, int minPrice, int maxPrice)
        {
            if (maxPrice == 0)
            {
                return new PagedList<ProductType>();
            }
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.quantity > 0 && c.price >= minPrice && c.price <= maxPrice));
            return result;
        }
        public async Task<PagedList<ProductType>> FilterByGender(QueryStringParameters pagingParams, GENDER gender)
        {
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.quantity > 0 && c.gender == gender.ToString()));
            return result;
        }
        public async Task<PagedList<ProductType>> FilterByDialColor(QueryStringParameters pagingParams, DIAL_COLOR color)
        {
            var result = await _unitOfWork.ProductTypes.GetAllWithPaging(pagingParams, (c => c.quantity > 0 && c.product_dial_color == color.ToString()));
            return result;
        }
        public async Task<PagedList<ProductType>> Sort(QueryStringParameters param, SORT_OPTION sortOption, bool isDescending = false)
        {
            try
            {
                var result = await _unitOfWork.ProductTypes.GetAllWithPaging(param, c => c.quantity > 0, sortOption, isDescending);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<bool> Update(ProductTypeUpdateReq model, int id)
        {
            try
            {
                var item = await _unitOfWork.ProductTypes.GetFullResById(id);
                var subCategoryIds = item.productSubCategories.Select(c => c.sub_category_id).ToList();
                if (item == null)
                {
                    throw new AppException("ProductType " + id + " does not exist");
                }
                if (!model.sub_category_ids.Any())
                {
                    throw new AppException("Sub categories cannot be empty");
                }
                else
                {
                    var isALlExisted = await _unitOfWork.SubCategories.GetByListId(model.sub_category_ids);
                    if (isALlExisted == null || isALlExisted.Count() != model.sub_category_ids.Count())
                    {
                        throw new AppException("Some of sub categories are not exist in database");
                    }
                }
                // mapper
                item.product_type_name = model.product_type_name;
                item.product_image_uuid = model.product_image_uuid;
                item.price = model.price;
                item.brand_id = model.brand_id;
                item.product_albert_id = model.product_albert_id;
                item.product_core_id = model.product_core_id;
                item.product_glass_id = model.product_glass_id;
                item.product_source = model.product_source;
                item.product_guarantee = model.product_guarantee;
                item.product_dial_width = model.product_dial_width;
                item.product_dial_height = model.product_dial_height;
                item.product_dial_color = model.product_dial_color.ToString();
                item.product_waterproof = model.product_waterproof;
                item.product_features = model.product_features;
                item.product_additional_information = model.product_additional_information;
                item.gender = model.gender.ToString();
                item.updated_date = DateTime.Now.ToUniversalTime();
                item.product_dial_color = model.product_dial_color.ToString();
                item.gender = model.gender.ToString();

                // resolve ProductSubCategories
                // B1: Delete all Product sub categories
                // B2: Update product type
                // B3: Add new Product sub categories
                await _unitOfWork.ProductSub.DeleteByProductTypeId(item.id);
                var res = await _unitOfWork.SaveChangesAsync();

                item.productSubCategories = model.sub_category_ids.Select(subCategoryId => new ProductSubCategory
                {
                    product_type_id = item.id,
                    sub_category_id = subCategoryId
                }).ToList();
                await _unitOfWork.ProductTypes.UpdateAsync(item);

                res = await _unitOfWork.SaveChangesAsync();

                return res >= 1 ? true : false;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateQuantityAfterInventoryCheckingSuccess(int id, int quantity)
        {
            try
            {
                var item = await _unitOfWork.ProductTypes.FindWithCondition(c => c.id == id);
                item.quantity -= quantity;
                item.updated_date = DateTime.Now.ToUniversalTime();
                await _unitOfWork.ProductTypes.UpdateAsync(item);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;

            }
            catch
            {
                throw;
            }
            // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
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
                throw;
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

