using Caching.Domain;

namespace Caching.Infra.Interfaces
{
    public interface IRepository
    {
        TaskItem GetById(int id);
        IEnumerable<TaskItem> GetAll();
    }
}
