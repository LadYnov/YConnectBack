using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("ReactionsMessage")]
    public class ReactionsMessage
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Message")]
        public int MessageId { get; set; }
        
        [ForeignKey("User")]
        public int AuthorId { get; set; }
        
        [ForeignKey("Icon")]
        public int IconId { get; set; }
    }
}