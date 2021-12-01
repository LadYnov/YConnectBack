using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("Campus")]
    public class Campus
    {
        [Key]
        public uint Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
    }
}