using System.Linq.Expressions;

namespace Biblioteca82.Data.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<TEntity?> GetByIdAsync(int id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> RemovePhysicAsync(TEntity entity);
        Task RemoveLogicalAsync(TEntity entity);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}
