namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public Task<int> SaveChangesAsync();
    }
}
