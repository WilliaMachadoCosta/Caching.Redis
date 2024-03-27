using Caching.Domain;
using Caching.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caching.Infra
{
    internal class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _context.TaskItens
               .AsNoTracking()
               .OrderBy(x => x.Deadline);
        }

        public TaskItem GetById(int id)
        {
            return _context
                 .TaskItens
                 .FirstOrDefault(x => x.Id == id );
        }
    }
}
