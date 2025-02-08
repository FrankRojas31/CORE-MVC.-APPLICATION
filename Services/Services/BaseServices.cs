using Biblioteca82.Data.Repositories.Context;
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

        
    }
}
