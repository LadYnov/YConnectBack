using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public uint Id { get; set; }
        
        [ForeignKey(("User"))]
        public uint AuthorId { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [MaxLength(255)]
        public string Media { get; set; }
        
        public uint ReactionCount { get; set; }
    }
}