namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
    }
}
