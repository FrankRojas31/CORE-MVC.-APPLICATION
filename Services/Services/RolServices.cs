using Biblioteca82.Context;
using Biblioteca82.Models.Domain;
using Biblioteca82.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca82.Services.Services
{
    public class RolServices : BaseServices<RolEntity>, IRolServices
    {
        private ApplicationDbContext _context;
        public RolServices(ApplicationDbContext context) :base(context)
        { 
            _context = context;
        }

        public async Task<List<RolEntity>> GetRoles()
        {
            List<RolEntity> roles = await _context.Roles.ToListAsync();

            return [..roles];
        } 
    }
}
