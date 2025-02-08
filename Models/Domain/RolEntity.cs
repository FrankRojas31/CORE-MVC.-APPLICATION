using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca82.Models.Domain
{
    [Table("Tbl_Rol")]
    public class RolEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<UserEntity> Usuarios { get; set; }
    }
}
