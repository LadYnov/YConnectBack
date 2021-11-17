using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Yconnect_backend.database.models.FakeModels;
using Yconnect_backend.database.SqlRepository;

namespace Yconnect_backend.test.SqlRepositoryTest
{
    public class SqlFakeRepositoryTest
    {
        private readonly SqlFakeRepository _sqlFakeRepository = new ();

        [Fact]
        public void SqlFakeRepository_GetUser_ShouldReturnUser()
        {
            FakeUser user = _sqlFakeRepository.GetUser(0);

            user.Should().NotBeNull();
        }

        [Fact]
        public void SqlFakeRepository_GetUserNotExist_ShouldReturnNullReferenceException()
        {
            Func<FakeUser> action = () => _sqlFakeRepository.GetUser(5);

            action.Should().Throw<NullReferenceException>();
        }
        
        
        [Fact]
        public void SqlFakeRepository_AddUser_ListShouldHave2Items()
        {
            _sqlFakeRepository.AddUser(new FakeUser()
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
            });

            _sqlFakeRepository.UsersLists.Count.Should().Be(2);
        }

        [Fact]
        public void SqlFakeRepository_DeleteUser_ListShouldHave1Item()
        {
            _sqlFakeRepository.AddUser(new FakeUser()
            {
                FirstName = "toto",
                LastName = "tata",
                Birthdate = new DateTime(2020, 1, 1),
                Email = "toto@gmail.com",
                Id = 1,
                Year = 2001,
                CampusId = 0,
                FacultyId = 0,
                GenderId = 0,
                ImagePath = "fkkjkvkvknvfkv",
                RoleId = 0
            });

            _sqlFakeRepository.UsersLists.Count.Should().Be(2);

            _sqlFakeRepository.DeleteUser(1);
            
            _sqlFakeRepository.UsersLists.Count.Should().Be(1);
        }
        
        [Fact]
        public void SqlFakeRepository_DeleteUser_NoUserFound_ShouldReturnNullReferenceException()
        {
            _sqlFakeRepository.AddUser(new FakeUser()
            {
                FirstName = "toto",
                LastName = "tata",
                Birthdate = new DateTime(2020, 1, 1),
                Email = "toto@gmail.com",
                Id = 1,
                Year = 2001,
                CampusId = 0,
                FacultyId = 0,
                GenderId = 0,
                ImagePath = "fkkjkvkvknvfkv",
                RoleId = 0
            });

            _sqlFakeRepository.UsersLists.Count.Should().Be(2);

            Action action = () => _sqlFakeRepository.DeleteUser(5);

            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void SqlFakeRepository_ModifyPhoto()
        {
            const int id = 0;
            const string path = "path2";
            _sqlFakeRepository.ModifyProfilePicture(path, id);

            _sqlFakeRepository.UsersLists.FirstOrDefault(_ => _.Id == id)?.ImagePath.Should().Be(path);
        }
        
        [Fact]
        public void SqlFakeRepository_ModifyGenre()
        {
            const int id = 0;
            const int genre = 1;
            _sqlFakeRepository.ModifyGenre(genre, id);

            _sqlFakeRepository.UsersLists.FirstOrDefault(_ => _.Id == id)?.GenderId.Should().Be(genre);
        }
        
        [Fact]
        public void SqlFakeRepository_ModifyFaculty()
        {
            const int id = 0;
            const int faculty = 1;
            _sqlFakeRepository.ModifyFaculty(faculty, id);

            _sqlFakeRepository.UsersLists.FirstOrDefault(_ => _.Id == id)?.FacultyId.Should().Be(faculty);
        }
        
        [Fact]
        public void SqlFakeRepository_ModifyCampus()
        {
            const int id = 0;
            const int campus = 1;
            _sqlFakeRepository.ModifyCampus(campus, id);

            _sqlFakeRepository.UsersLists.FirstOrDefault(_ => _.Id == id)?.CampusId.Should().Be(campus);
        }
        
        [Fact]
        public void SqlFakeRepository_ModifyYear()
        {
            const int id = 0;
            const int year = 1;
            _sqlFakeRepository.ModifyYear(year, id);

            _sqlFakeRepository.UsersLists.FirstOrDefault(_ => _.Id == id)?.Year.Should().Be(year);
        }
    }
}