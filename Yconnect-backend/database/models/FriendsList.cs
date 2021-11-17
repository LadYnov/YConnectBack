using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("FriendsList")]
    public class FriendsList
    {
        [Key]
        public uint Id { get; set; }
        
        [ForeignKey("User")]
        public uint FriendId { get; set; }
        
        [ForeignKey("User")]
        public uint CurrentUserId { get; set; }
    }
}