using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICrudRepository<T> : IDisposable where T : class
    {
        // Métodos ASÍNCRONOS
        Task<T> GetByIdAsync(object id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> SaveChangesAsync();
    }
}