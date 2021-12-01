using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("ReactionsComment")]
    public class ReactionsComment
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        
        [ForeignKey("User")]
        public int AuthorId { get; set; }
        
        [ForeignKey("Icon")]
        public int IconId { get; set; }
    }
}