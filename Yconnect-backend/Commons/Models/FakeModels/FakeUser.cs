using System;

namespace Yconnect_backend.database.models.FakeModels
{
    public class FakeUser
    {
        public uint Id { get; set; }

        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        
        public string Email { get; set; }
        
        public string ImagePath { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        public uint FacultyId { get; set; }
        
        public uint CampusId { get; set; }
        
        public uint GenderId { get; set; }
        
        public uint RoleId { get; set; }

        public int Year { get ; set; }
    }
}