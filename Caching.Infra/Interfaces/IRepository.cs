using Caching.Domain;

namespace Caching.Infra.Interfaces
{
    public interface IRepository
    {
        Task<TaskItem> GetById(int id);
       Task<IEnumerable<TaskItem>> GetAll();
    }
}
