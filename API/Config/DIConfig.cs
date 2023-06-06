using Ecom_API.Authorization;
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
        }
    }
}
