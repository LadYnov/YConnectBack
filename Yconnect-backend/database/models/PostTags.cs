using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    public class PostTag
    {
        [Key]
        public uint Id { get; set; }
        
        [ForeignKey("Post")]
        public uint PostId { get; set; }
        
        [ForeignKey("Tag")]
        public uint TagId { get; set; }
    }
}

