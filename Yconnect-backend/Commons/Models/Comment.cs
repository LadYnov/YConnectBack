using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public uint Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public uint AuthorId { get; set; }
        
        [Required]
        public uint ReactionCount { get; set; }
        
        [Required]
        [ForeignKey("Post")]
        public uint PostId { get; set; }
    }
}