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
            modelBuilder.Entity<User>();
            modelBuilder.Entity<ProductFeedback>();
            modelBuilder.Entity<PaymentMethod>();
            modelBuilder.Entity<Payment>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<ProductAlbert>();
            modelBuilder.Entity<ProductCore>();
            modelBuilder.Entity<ProductGlass>();
            modelBuilder.Entity<VNPay>();

            modelBuilder.Entity<SubCategory>().UseTpcMappingStrategy()
                .HasMany(c => c.productTypes)
                .WithOne(c => c.subCategory)
                .HasForeignKey(c => c.sub_category_id);
            modelBuilder.Entity<Brand>().UseTpcMappingStrategy()
                .HasMany(c => c.productTypes)
                .WithOne(c => c.brand)
                .HasForeignKey(c => c.brand_id);

            // Config foreign key one to many
            //modelBuilder.Entity<ProductType>()
            //    .HasOne(c => c.subCategory)
            //    .WithMany(c => c.productTypes)
            //    .HasForeignKey(c => c.sub_category_id);

            //modelBuilder.Entity<ProductType>()
            //    .HasOne(c => c.brand)
            //    .WithMany(c => c.productTypes)
            //    .HasForeignKey(c => c.brand_id);

            modelBuilder.Entity<ProductType>().UseTpcMappingStrategy()
               .HasOne(c => c.albert)
               .WithOne(c => c.productType)
               .HasForeignKey<ProductAlbert>(c => c.product_type_id);

            modelBuilder.Entity<ProductType>().UseTpcMappingStrategy()
               .HasOne(c => c.core)
               .WithOne(c => c.productType)
               .HasForeignKey<ProductCore>(c => c.product_type_id);

            modelBuilder.Entity<ProductType>().UseTpcMappingStrategy()
               .HasOne(c => c.glass)
               .WithOne(c => c.productType)
               .HasForeignKey<ProductGlass>(c => c.product_type_id);

            modelBuilder.Entity<ProductType>().UseTpcMappingStrategy()
                .HasMany(c => c.products)
                .WithOne(c => c.productType)
                .HasForeignKey(c => c.product_type_id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}