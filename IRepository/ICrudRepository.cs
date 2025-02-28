
namespace IRepository
{
    public interface ICrudRepository<T>: IDisposable where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(object id);
        Task<int> DeleteMultipleItems(List<T> lista);
        Task<List<T>> InsertMultiple(List<T> lista);
        Task<List<T>> UpdateMultiple(List<T> lista);
    }
}