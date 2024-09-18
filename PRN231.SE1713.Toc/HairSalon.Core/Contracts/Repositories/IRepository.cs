using System.Linq.Expressions;

namespace HairSalon.Core.Contracts.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();

        Task<T?> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<T?> FindAsync(params object[] keyValues);

        void Add(T entity); 

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
