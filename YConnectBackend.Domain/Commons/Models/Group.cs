using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
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
        
        //TODO faire une table groupTags à la place
    }
}