using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public uint Id { get; set; }
        
        public string Content { get; set; }
        
        public DateTime DateTime { get; set; }
        
        [ForeignKey("User")]
        public uint AuthorId { get; set; }
        
        public uint ReactionCount { get; set; }
        
        [ForeignKey("Group")]
        public uint GroupId { get; set; }
    }
}