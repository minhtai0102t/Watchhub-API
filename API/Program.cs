using Ecom_API.Config;
using Ecom_API.DBHelpers;
using Ecom_API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.CommonConfig;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var services = builder.Services;

        services.AddCors();
        services.AddControllers().AddJsonOptions(jsonOption =>
        {
            //Config for present enum as string in swagger, it also convert enum to json file as string type instead of default is int type
            jsonOption.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }); ;
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Watchhub API", Version = "v1" });

            // Add a security definition for JWT authentication
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter a valid token for authorizing",
            });

            // Configure Swagger to use the JWT bearer authentication scheme
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                // Configure JWT authentication options
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Set your token validation parameters
                };
            });
        services.AddAuthorization();

        // configure automapper with all automapper profiles from this assembly
        services.AddAutoMapper(typeof(Program));

        // configure strongly typed settings object
        services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        // configure DI for application services
        services.DIConfiguration();

        services.AddMemoryCache();

        services.AddHttpContextAccessor();

        //connection string
        services.AddDbContext<ApiDbContextHosting>(opt =>
            opt.UseNpgsql(
            builder.Configuration.GetConnectionString("Connection-Hosting"),
                b => b.MigrationsAssembly("Ecom-API")
                    .CommandTimeout(30) // Set the retry timeout to 60 seconds
                    .EnableRetryOnFailure()
                )
        );
        //services.AddDbContext<ApiDbContextHostingNew>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Connection-Hosting-New"), b => b.MigrationsAssembly("Ecom-API")));

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
        });
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();
        }
        app.Run();
    }
}
