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
            modelBuilder.Entity<User>().Property(c => c.created_date).HasDefaultValue(DateTime.Now.ToUniversalTime());
            modelBuilder.Entity<SubCategory>();
            modelBuilder.Entity<ProductType>();
            modelBuilder.Entity<ProductFeedback>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<PaymentMethod>();
            modelBuilder.Entity<Payment>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Brand>();
            modelBuilder.Entity<ProductAlbert>();
            modelBuilder.Entity<ProductCore>();
            modelBuilder.Entity<ProductGlass>();
            modelBuilder.Entity<VNPay>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}