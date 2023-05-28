using Ecom_API.DBHelpers;

namespace Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiDbContextHosting _dbContext;
        public UnitOfWork(ApiDbContextHosting context)
        {
            _dbContext = context;
        }

        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private IBrandRepository _brandRepository;
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }
        public ICategoryRepository Categories
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbContext);
                }
                return _categoryRepository;
            }
        }
        public ISubCategoryRepository SubCategories
        {
            get
            {
                if (_subCategoryRepository == null)
                {
                    _subCategoryRepository = new SubCategoryRepository(_dbContext);
                }
                return _subCategoryRepository;
            }
        }
        public IBrandRepository Brands
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_dbContext);
                }
                return _brandRepository;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
