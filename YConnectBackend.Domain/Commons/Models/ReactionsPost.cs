using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("ReactionsPost")]
    public class ReactionsPost
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Post")]
        public int PostId { get; set; }
        
        [ForeignKey("User")]
        public int AuthorId { get; set; }
        
        [ForeignKey("Icon")]
        public int IconId { get; set; }
    }
}