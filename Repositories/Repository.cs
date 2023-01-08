using GlobalMessageBoard.Data;
using GlobalMessageBoard.Interfaces;
using GlobalMessageBoard.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalMessageBoard.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Base
    {
        protected readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
