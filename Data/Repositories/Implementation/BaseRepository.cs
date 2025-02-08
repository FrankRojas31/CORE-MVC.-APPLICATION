using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Biblioteca82.Data.Repositories.Context;

namespace Biblioteca82.Data.Repositories.Implementation
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            var affectedRows = await _context.SaveChangesAsync();

            bool result = affectedRows > 0;

            return result;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            var affectedRows = await _context.SaveChangesAsync();

            bool result = affectedRows > 0;

            return result;

        }

        public virtual async Task<bool> RemovePhysicAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            var affectedRows = await _context.SaveChangesAsync();

            bool result = affectedRows > 0;

            return result;
        }

        public virtual async Task RemoveLogicalAsync(TEntity entity)
        {
            var property = entity.GetType().GetProperty("EsBorrado");
            property.SetValue(entity, true);
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            if (expression != null)
            {
                return await _context.Set<TEntity>().CountAsync(expression);
            }
            else
            {
                return await _context.Set<TEntity>().CountAsync();
            }
        }
    }
}