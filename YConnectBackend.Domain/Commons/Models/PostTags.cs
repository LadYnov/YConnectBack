using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
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

