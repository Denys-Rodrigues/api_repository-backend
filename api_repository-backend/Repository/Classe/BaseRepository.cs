using api_repository_backend.Context;
using api_repository_backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_repository_backend.Repository.Classe
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext context = null;

        public BaseRepository(AppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task Insert(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, T obj)
        {
            context.Set<T>().Update(obj);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
