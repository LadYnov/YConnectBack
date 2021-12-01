using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int id);
        public Task<EntityEntry<User>> AddUser(User user);
        public Task DeleteUser(int id);
    }
}
