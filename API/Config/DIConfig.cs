using Ecom_API.Helpers;
using Ecom_API.Service;
using Services.Repositories;

namespace Ecom_API.Config
{
    public static class DIConfig
    {
        public static void DIConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IJwtUtils, JwtUtils>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ISubCategoryService, SubCategoryService>();
            service.AddScoped<IBrandService, BrandService>();
            service.AddScoped<IProductTypeService, ProductTypeService>();
            service.AddScoped<IProductAlbertService, ProductAlbertService>();
            service.AddScoped<IProductCoreService, ProductCoreService>();
            service.AddScoped<IProductGlassService, ProductGlassService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IPaymentMethodService, PaymentMethodService>();
            service.AddScoped<GoogleHelperService>();
        }
    }
}
