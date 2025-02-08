using Biblioteca82.Data.Repositories.Context;
using Biblioteca82.Data.Repositories.Contracts;
using Biblioteca82.Data.Repositories.Implementation;
using Biblioteca82.Models.Domain;
using Biblioteca82.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca82.Services.Services
{
    public class UserServices : BaseServices<UserEntity>, IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IRolRepository _rolRepository;
        public UserServices(ApplicationDbContext context, IUserRepository userRepository, IRolRepository rolRepository) : base(userRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _rolRepository = rolRepository;
        }

        public async Task<List<UserEntity>> GetUsuarios()
        {
            try
            {
                List<UserEntity> usersList = await _userRepository.GetAllAsync();

                foreach (var userEntity in usersList)
                {

                    RolEntity rol = await _rolRepository.GetByIdAsync(userEntity.IdRol);

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
