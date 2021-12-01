using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
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