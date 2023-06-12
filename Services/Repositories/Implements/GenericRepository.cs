using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            T _entity = await GetByIdAsync(id);
            if (_entity != null)
            {
                dbSet.Remove(_entity);
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            T _entity = await GetByIdAsync(id);
            if (_entity != null)
            {
                _entity.is_deleted = true;
                await UpdateAsync(_entity);
            }
        }
        public async Task<T> FindWithCondition(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.id == id);
            return entity;
        }
        public T GetById(int id)
        {
            var entity = dbSet.AsNoTracking().FirstOrDefault(e => e.id == id);
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
        }
        public async Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;
            var query = dbSet.AsQueryable();
            foreach (var property in navigationProperties)
            {
                query = query.Include(property);
            }
            list = await query.Where(predicate).AsNoTracking().ToListAsync();
            return list;
        }
        public async Task<T> FindByIdAsync(int id, params string[] navigationProperties)
        {
            var query = ApplyNavigation(navigationProperties);
            T entity = await query.FirstOrDefaultAsync(e => e.id.Equals(id));
            return entity;
        }
        private IQueryable<T> ApplyNavigation(params string[] navigationProperties)
        {
            var query = dbSet.AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);
            return query;
        }
        public async Task<IEnumerable<T>> FindAllWithCondition(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await dbSet.AsNoTracking().ToListAsync();
            }
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllActiveAsync()
        {
            return await dbSet.AsNoTracking().Where(x => x.is_deleted == false).ToListAsync();
        }
        public async Task<T> GetByIdActiveAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.id.Equals(id) && x.is_deleted == false);
        }

        public DbSet<T> GetDbSet()
        {
            return dbSet;
        }
        public async Task<PagedList<T>> GetWithPaging(IQueryable<T> dataQuery, QueryStringParameters pagingParams)
        {
            PagedList<T> pagedRequests = new PagedList<T>();

            if (pagingParams.PageSize == 0)
            {
                await pagedRequests.LoadData(dataQuery);
            }
            else
            {
                await pagedRequests.LoadData(dataQuery, pagingParams.PageNumber, pagingParams.PageSize);
            }

            return pagedRequests;

        }
        public async Task<PagedList<T>> GetWithPaging(IQueryable<T> dataQuery, QueryStringParameters pagingParams, Expression<Func<T, bool>> predicate)
        {
            PagedList<T> pagedRequests = new PagedList<T>();

            if (pagingParams.PageSize == 0)
            {
                await pagedRequests.LoadData(dataQuery, predicate);
            }
            else
            {
                await pagedRequests.LoadData(dataQuery, pagingParams.PageNumber, pagingParams.PageSize, predicate);
            }

            return pagedRequests;

        }
    }
}
