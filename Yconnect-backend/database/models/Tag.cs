using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    public class Tag
    {
        [Key]
        public uint Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("Faculty")]
        public uint FacultyId { get; set; }
    }
}