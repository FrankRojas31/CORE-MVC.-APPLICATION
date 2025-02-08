using Biblioteca82.Data.Repositories.Context;
using Biblioteca82.Models.Domain;
using Biblioteca82.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca82.Services.Services
{
    public class UserServices : BaseServices<UserEntity>, IUserServices
    {
        private readonly ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //Crear una lista para obtener a los usuarios.
        public async Task<List<UserEntity>> GetUsuarios()
        {
            try
            {
                List<UserEntity> usersList = await _context.Usuarios.ToListAsync();

                foreach (var userEntity in usersList)
                {

                    RolEntity rol = await _context.Roles.SingleOrDefaultAsync(x => x.Id == userEntity.IdRol);

                    var verificar = (rol != null) ? userEntity.Rol = rol : userEntity.Rol = null;

                }

                return [.. usersList];
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error: {ex.Message}");
            }
        }

        //Crear Usuario.
        public async Task<bool> CreateUser(UserEntity userNew)
        {
            try
            {
                await _context.Usuarios.AddAsync(userNew);
                var result = await _context.SaveChangesAsync();

                var seInserto = result > 0;

                return seInserto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error: {ex.Message}");
            }
        }

    }
}
