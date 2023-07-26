using Ecom_API.DBHelpers;
using Services.Repositories.Interfaces;

namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        IBrandRepository Brands { get; }
        IProductTypeRepository ProductTypes { get; }
        IProductRepository Products { get; }
        IProductAlbertRepository ProductAlberts { get; }
        IProductCoreRepository ProductCores { get; }
        IProductGlassRepository ProductGlasses { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IVNPayRepository VNPays { get; }
        IOrderRepository Orders { get; }
        IProductSubRepository ProductSub { get; }
        IProductFeedbackRepository ProductFeedback { get; }
        Task<int> SaveChangesAsync();
        ApiDbContextHosting GetDbContextHosting();
    }
}
