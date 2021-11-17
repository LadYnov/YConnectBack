using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("Icon")]
    public class Icon
    {
        [Key]
        public int Id { get; set; }
        
        public string PathIcon { get; set; }
    }
}