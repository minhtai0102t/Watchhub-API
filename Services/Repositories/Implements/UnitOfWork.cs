using Ecom_API.DBHelpers;

namespace Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiDbContextHosting _dbContext;
        public UnitOfWork(ApiDbContextHosting context) {
            _dbContext = context;
        }

        private IUserRepository _userRepository;
        public IUserRepository Users
        {
            get
            {
                if(_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
