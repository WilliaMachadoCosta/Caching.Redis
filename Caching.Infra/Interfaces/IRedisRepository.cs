using Caching.Domain;

namespace Caching.Infra.Interfaces
{
    public interface IRedisRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task SetAsync(string id, T entity);
        Task SetAllAsync(IEnumerable<TaskItem> entities);
    }
}
