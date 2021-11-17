using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        public uint Id { get; set; }
        
        [MaxLength(50)]
        public uint GenderName { get; set; }
    }
}