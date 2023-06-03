namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ICategoryRepository Categories { get; }
        public ISubCategoryRepository SubCategories { get; }
        public IBrandRepository Brands { get; }
        public IProductTypeRepository ProductTypes { get; }
        public IProductImageRepository ProductImages { get; }
        public Task<int> SaveChangesAsync();
    }
}
