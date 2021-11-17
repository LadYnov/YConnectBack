using System;
using System.Collections.Generic;
using Yconnect_backend.database.models.FakeModels;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlFakeRepository
    {
        public List<FakeUser> UsersLists { get; set; } = new List<FakeUser>()
        {
            new FakeUser()
            {
                FirstName = "toto",
                LastName = "tata",
                Birthdate = new DateTime(2020, 1, 1),
                Email = "toto@gmail.com",
                Id = 0,
                Year = 2001,
                CampusId = 0,
                FacultyId = 0,
                GenderId = 0,
                ImagePath = "fkkjkvkvknvfkv",
                RoleId = 0
            }
        };

        public FakeUser? GetUser(int id)
        {
            CheckIfUserExist(id);
            return UsersLists.Find(_ => _.Id == id);
        }

        public void AddUser(FakeUser fakeUser)
        {
            UsersLists.Add(fakeUser);
        }

        public void DeleteUser(int id)
        {
            UsersLists.Remove(GetUser(id));
        }

        public void ModifyProfilePicture(string path, int id)
        {
            GetUser(id).ImagePath = path;
        }
        
        public void ModifyGenre(uint genreId, int id)
        {
            GetUser(id).GenderId = genreId;
        }
        
        public void ModifyFaculty(uint facultyId, int id)
        {
            GetUser(id).FacultyId = facultyId;
        }
        
        public void ModifyCampus(uint campusId, int id)
        {
            GetUser(id).CampusId = campusId;
        }
        
        public void ModifyYear(int year, int id)
        {
            GetUser(id).Year = year;
        }

        private void CheckIfUserExist(int id)
        {
            if (UsersLists.Find(_ => _.Id == id) is null)
            {
                throw new NullReferenceException("No User Found!");
            }
        }
    }
}