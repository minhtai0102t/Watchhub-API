using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Services.Repositories
{
    public interface IProductSubRepository
    {
        Task Update(int productTypeId, List<int> subIds);
        Task<ICollection<ProductSubCategory>> GetWithProductTypeId(int productTypeId);
    }
}
