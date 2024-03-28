using Caching.Domain;
using Caching.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caching.Infra
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _context.TaskItens
               .AsNoTracking()
               .OrderBy(x => x.Deadline)
               .ToListAsync();
        }

        public async Task<TaskItem> GetById(int id)
        {
            return await _context.TaskItens.FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
