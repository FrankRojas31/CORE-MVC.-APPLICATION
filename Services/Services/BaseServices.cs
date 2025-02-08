using Biblioteca82.Data.Repositories.Contracts;
using Biblioteca82.Models;
using Biblioteca82.Services.IServices;
using System.Linq.Expressions;

namespace Biblioteca82.Services.Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repositoryBase;

        public BaseServices(IBaseRepository<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual ResponseHelper GetResponse(bool success, string message, object? data)
        {
            return new ResponseHelper
            {
                Success = success,
                Message = message,
                Data = data
            };
        }

        public virtual async Task<ResponseHelper> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            List<TEntity> list = (expression != null)
                ? await _repositoryBase.GetAllAsync(expression)
                : await _repositoryBase.GetAllAsync();

            return GetResponse(true, $"Lista de {typeof(TEntity).Name} obtenida correctamente", list);
        }

        public virtual async Task<ResponseHelper> GetByIdAsync(int id)
        {
            var entity = await _repositoryBase.GetByIdAsync(id);

            if (entity != null)
            {
                return GetResponse(true, $"{typeof(TEntity).Name} obtenido correctamente", entity);
            }
            else
            {
                return GetResponse(false, $"{typeof(TEntity).Name} no encontrado", null);
            }
        }

        public virtual async Task<ResponseHelper> AddAsync(TEntity entity)
        {
            try
            {
                await _repositoryBase.AddAsync(entity);
                return GetResponse(true, $"{typeof(TEntity).Name} agregado correctamente", entity);
            }
            catch (Exception ex)
            {
                return GetResponse(false, $"Error al agregar {typeof(TEntity).Name}: {ex.Message}", null);
            }
        }

        public virtual async Task<ResponseHelper> UpdateAsync(TEntity entity)
        {
            try
            {
                await _repositoryBase.UpdateAsync(entity);
                return GetResponse(true, $"{typeof(TEntity).Name} actualizado correctamente", entity);
            }
            catch (Exception ex)
            {
                return GetResponse(false, $"Error al actualizar {typeof(TEntity).Name}: {ex.Message}", null);
            }
        }

        public virtual async Task<ResponseHelper> RemovePhysicAsync(int id)
        {
            try
            {
                var entity = await _repositoryBase.GetByIdAsync(id);
                if (entity != null)
                {
                    await _repositoryBase.RemovePhysicAsync(entity);
                    return GetResponse(true, $"{typeof(TEntity).Name} eliminado correctamente", null);
                }
                else
                {
                    return GetResponse(false, $"{typeof(TEntity).Name} no encontrado", null);
                }
            }
            catch (Exception ex)
            {
                return GetResponse(false, $"Error al eliminar {typeof(TEntity).Name}: {ex.Message}", null);
            }
        }

        public virtual async Task<ResponseHelper> RemoveLogicalAsync(int id)
        {
            try
            {
                var entity = await _repositoryBase.GetByIdAsync(id);
                if (entity != null)
                {
                    await _repositoryBase.RemoveLogicalAsync(entity);
                    return GetResponse(true, $"{typeof(TEntity).Name} desactivado correctamente", null);
                }
                else
                {
                    return GetResponse(false, $"{typeof(TEntity).Name} no encontrado", null);
                }
            }
            catch (Exception ex)
            {
                return GetResponse(false, $"Error al desactivar {typeof(TEntity).Name}: {ex.Message}", null);
            }
        }

        public virtual async Task<ResponseHelper> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                bool exists = await _repositoryBase.ExistsAsync(expression);
                return GetResponse(true, "Verificación exitosa", exists);
            }
            catch (Exception ex)
            {
                return GetResponse(false, $"Error al verificar existencia: {ex.Message}", false);
            }
        }

        public virtual async Task<ResponseHelper> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            try
            {
                int count = await _repositoryBase.CountAsync(expression);
                return GetResponse(true, "Conteo exitoso", count);
            }
            catch (Exception ex)
            {
                return GetResponse(false, $"Error al contar registros: {ex.Message}", 0);
            }
        }
    }
}