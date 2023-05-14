using Ecom_API.DBHelpers;

namespace Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiDbContext _dbContext;
        public UnitOfWork(ApiDbContext context) {
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

        
    }
}
