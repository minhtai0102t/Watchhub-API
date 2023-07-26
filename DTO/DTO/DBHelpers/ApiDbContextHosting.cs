using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Ecom_API.DBHelpers
{
    public class ApiDbContextHosting : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                   .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                   .AddFilter(DbLoggerCategory.Database.Transaction.Name, LogLevel.Warning)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
                   .AddConsole();
        }
        );
        public ApiDbContextHosting(DbContextOptions<ApiDbContextHosting> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductFeedback>();
            modelBuilder.Entity<PaymentMethod>();
            modelBuilder.Entity<Payment>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<ProductAlbert>();
            modelBuilder.Entity<ProductCore>();
            modelBuilder.Entity<ProductGlass>();
            modelBuilder.Entity<VNPay>();
            modelBuilder.Entity<Product>();
            #region Relation
            modelBuilder.Entity<User>().UseTpcMappingStrategy()
                .HasMany(c => c.productFeedbacks)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.user_id);

            modelBuilder.Entity<SubCategory>().UseTpcMappingStrategy()
                .HasOne(c => c.category)
                .WithMany(c => c.subCategories)
                .HasForeignKey(c => c.category_id);

            modelBuilder.Entity<Brand>().UseTpcMappingStrategy()
                .HasMany(c => c.productTypes)
                .WithOne(c => c.brand)
                .HasForeignKey(c => c.brand_id);

            modelBuilder.Entity<ProductAlbert>().UseTpcMappingStrategy()
                .HasMany(c => c.productTypes)
                .WithOne(c => c.albert)
                .HasForeignKey(c => c.product_albert_id);

            modelBuilder.Entity<ProductCore>().UseTpcMappingStrategy()
                .HasMany(c => c.productTypes)
                .WithOne(c => c.core)
                .HasForeignKey(c => c.product_core_id);

            modelBuilder.Entity<ProductGlass>().UseTpcMappingStrategy()
                .HasMany(c => c.productTypes)
                .WithOne(c => c.glass)
                .HasForeignKey(c => c.product_glass_id);

            modelBuilder.Entity<ProductType>().UseTpcMappingStrategy()
                .HasMany(c => c.products)
                .WithOne(c => c.productType)
                .HasForeignKey(c => c.product_type_id);

            modelBuilder.Entity<ProductType>().UseTpcMappingStrategy()
                .HasMany(c => c.productFeedbacks)
                .WithOne(c => c.ProductType)
                .HasForeignKey(c => c.product_type_id);

            modelBuilder.Entity<ProductSubCategory>()
                .HasKey(pc => new { pc.product_type_id, pc.sub_category_id });

            modelBuilder.Entity<ProductSubCategory>()
                .HasOne(pc => pc.productType)
                .WithMany(p => p.productSubCategories)
                .HasForeignKey(pc => pc.product_type_id);

            modelBuilder.Entity<ProductSubCategory>()
               .HasOne(pc => pc.subCategory)
               .WithMany(p => p.productSubCategories)
               .HasForeignKey(pc => pc.sub_category_id); 
            #endregion
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}