using System.Linq.Expressions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> Entities;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }
        
        public async Task CreateAsync(T entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(List<T> entities)
        {
            await Entities.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
            Entities.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<T> entities)
        {
            Entities.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entities.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> GetFirstWithExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entities.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
