using Ecom_API.DTO.Entities;

namespace Services.Repositories
{
    public interface IProductSubRepository
    {
        Task DeleteByProductTypeId(int productTypeId);
        Task DeleteBySubCateId(int subCateId);
        Task<ICollection<ProductSubCategory>> GetWithProductTypeId(int productTypeId);
    }
}
