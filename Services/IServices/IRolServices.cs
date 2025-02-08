using Biblioteca82.Models.Domain;

namespace Biblioteca82.Services.IServices
{
    public interface IRolServices : IBaseServices<RolEntity>
    {
        Task<List<RolEntity>> GetRoles();
    }
}
