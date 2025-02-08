using Biblioteca82.Models.Domain;

namespace Biblioteca82.Services.IServices
{
    public interface IUserServices : IBaseServices<UserEntity>
    {
        Task<List<UserEntity>> GetUsuarios();
        Task<bool> CreateUser(UserEntity userNew);
    }
}
