namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ICategoryRepository Categories { get; }
        public ISubCategoryRepository SubCategories { get; }
        public IBrandRepository Brands { get; }
        public Task<int> SaveChangesAsync();
    }
}
