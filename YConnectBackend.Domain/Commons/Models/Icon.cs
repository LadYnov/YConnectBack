using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YConnectBackend.Domain.Commons.Models
{
    [Table("Icon")]
    public class Icon
    {
        [Key]
        public int Id { get; set; }
        
        public string PathIcon { get; set; }
    }
}