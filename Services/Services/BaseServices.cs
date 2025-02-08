using Biblioteca82.Context;
using Biblioteca82.Models;
using Biblioteca82.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Biblioteca82.Services.Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual ResponseHelper GetResponseHelper(bool success, string message, object data)
        {
            return new ResponseHelper
            {
                success = success,
                message = message,
                data = data
            };
        }

        public virtual async Task<ResponseHelper> GetAllAsync(Expression<Func<TEntity, bool>>? expresion)
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();

                if (expresion != null) 
                {
                    query = query.Where(expresion);
                }

                List<TEntity> result = await query.ToListAsync();

                ResponseHelper verificacion = (result.Count > 0) ? GetResponseHelper(true, $"Lista de {typeof(TEntity)} mostrando correctamente", result) : GetResponseHelper(false, $"La lista de {typeof(TEntity)} se encuentra vacia", new());

                return verificacion;
            }
            catch (Exception ex)
            {
                return GetResponseHelper(false, $"Ha ocurrido un error: {ex.Message}", ex.Source);   
            }
        }
    }
}
