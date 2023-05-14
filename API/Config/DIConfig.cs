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
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
