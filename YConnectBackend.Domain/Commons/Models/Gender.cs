using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        public uint Id { get; set; }
        
        [MaxLength(50)]
        public string GenderName { get; set; }
    }
}