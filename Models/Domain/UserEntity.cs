using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca82.Models.Domain
{
    [Table("Tbl_Usuarios")]
    public class UserEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [ForeignKey(nameof(Rol))]
        public Guid IdRol { get; set; }
        public virtual RolEntity Rol { get; set; }
    }
}
