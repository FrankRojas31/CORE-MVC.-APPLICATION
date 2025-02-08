using Biblioteca82.Data.Repositories.Context;
using Biblioteca82.Data.Repositories.Contracts;
using Biblioteca82.Models.Domain;
using Biblioteca82.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca82.Services.Services
{
    public class RolServices : BaseServices<RolEntity>, IRolServices
    {
        private ApplicationDbContext _context;
        private IRolRepository _repository;
        public RolServices(ApplicationDbContext context, IRolRepository rolRepository) :base(rolRepository)
        { 
            _context = context;
            _repository = rolRepository;
        }

        public async Task<List<RolEntity>> GetRoles()
        {
            List<RolEntity> roles = await _context.Roles.ToListAsync();

            return [..roles];
        } 
    }
}
