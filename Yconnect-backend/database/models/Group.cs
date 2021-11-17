using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public uint Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
        
        [ForeignKey("User")]
        public uint AdminId { get; set; }
        
        [ForeignKey("Tag")]
        public uint TagListId { get; set; }
    }
}