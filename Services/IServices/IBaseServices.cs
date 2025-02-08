using Biblioteca82.Models;
using System.Linq.Expressions;

namespace Biblioteca82.Services.IServices
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        ResponseHelper GetResponseHelper(bool success, string message, object data);
        Task<ResponseHelper> GetAllAsync(Expression<Func<TEntity, bool>>? expresion = null);
    }
}
