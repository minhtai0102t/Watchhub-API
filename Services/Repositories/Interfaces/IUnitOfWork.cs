namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ICategoryRepository Categories { get; }
        public ISubCategoryRepository SubCategories { get; }
        public IBrandRepository Brands { get; }
        public IProductTypeRepository ProductTypes { get; }
        // public IProductAlbertRepository ProductAlberts { get; }
        public IProductCoreRepository ProductCores { get; }
        public IProductGlassRepository ProductGlasses { get; }
        public Task<int> SaveChangesAsync();
    }
}
