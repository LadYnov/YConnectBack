using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("Campus")]
    public class Campus
    {
        [Key]
        public uint Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
    }
}