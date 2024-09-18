using HairSalon.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HairSalon.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly HairSalonDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(HairSalonDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity) => _dbContext.Add(entity);

        public void AddRange(IEnumerable<T> entities)
            => _dbContext.AddRange(entities);

        public async Task<T?> FindAsync(params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public async Task<T?> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);

        public IQueryable<T> GetAll() => _dbSet.Where(x => true).AsQueryable();

        public void Remove(T entity) => _dbContext.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _dbContext.RemoveRange(entities);

        public void Update(T entity) => _dbContext.Update(entity);

        public void UpdateRange(IEnumerable<T> entities) => _dbContext.UpdateRange(entities);
    }
}
