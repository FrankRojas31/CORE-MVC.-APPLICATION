using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca82.Models.Domain
{
    public abstract class BaseEntity
    {
        [Key, Column(Order = 0)]
        public Guid Id { get; set; }
        public bool EsBorrado { get; set; }
    }
}
