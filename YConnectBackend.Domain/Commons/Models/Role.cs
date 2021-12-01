using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public uint Id { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
    }
}