using Biblioteca82.Models;
using System.Linq.Expressions;

namespace Biblioteca82.Services.IServices
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        ResponseHelper GetResponse(bool success, string message, object? data);
        Task<ResponseHelper> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<ResponseHelper> GetByIdAsync(int id);
        Task<ResponseHelper> AddAsync(TEntity entity);
        Task<ResponseHelper> UpdateAsync(TEntity entity);
        Task<ResponseHelper> RemovePhysicAsync(int id);
        Task<ResponseHelper> RemoveLogicalAsync(int id);
        Task<ResponseHelper> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<ResponseHelper> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}
