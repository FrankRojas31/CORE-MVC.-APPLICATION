using Biblioteca82.Models.Domain;

namespace Biblioteca82.Models
{
    public class UserWithRolVM
    {
        public UserEntity User { get; set; }
        public IEnumerable<RolEntity> Roles { get; set; }
    }
}
