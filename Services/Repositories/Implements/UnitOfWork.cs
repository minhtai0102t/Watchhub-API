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
        private IProductTypeRepository _productTypeRepository;
        private IProductAlbertRepository _productAlbertRepository;
        private IProductCoreRepository _productCoreRepository;
        private IProductGlassRepository _productGlassRepository;
        private IProductRepository _product;

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
        public IProductTypeRepository ProductTypes
        {
            get
            {
                if (_productTypeRepository == null)
                {
                    _productTypeRepository = new ProducTypeRepository(_dbContext);
                }
                return _productTypeRepository;
            }
        }
        public IProductAlbertRepository ProductAlberts
        {
            get
            {
                if (_productAlbertRepository == null)
                {
                    _productAlbertRepository = new ProductAlbertRepository(_dbContext);
                }
                return _productAlbertRepository;
            }
        }
        public IProductCoreRepository ProductCores
        {
            get
            {
                if (_productCoreRepository == null)
                {
                    _productCoreRepository = new ProductCoreRepository(_dbContext);
                }
                return _productCoreRepository;
            }
        }
        public IProductGlassRepository ProductGlasses
        {
            get
            {
                if (_productGlassRepository == null)
                {
                    _productGlassRepository = new ProductGlassRepository(_dbContext);
                }
                return _productGlassRepository;
            }
        }
        public IProductRepository Products
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_dbContext);
                }
                return _product;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
