using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yconnect_backend.database.models
{
    [Table("User")]
    public class User
    {
        [Key]
        public uint Id { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string Email { get; set; }
        
        [MaxLength(255)]
        public string ImagePath { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        [ForeignKey("Faculty")]
        public uint FacultyId { get; set; }
        
        [ForeignKey("Campus")]
        public uint CampusId { get; set; }
        
        [ForeignKey("Gender")]
        public uint GenderId { get; set; }
        
        [ForeignKey("Role")]
        public uint RoleId { get; set; }

        public int Year { get ; set; }
    }
}