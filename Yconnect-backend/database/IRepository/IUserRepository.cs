using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IUserRepository
    {
        public User GetUser(int id);
        public User AddUser(User user);
        public User DeleteUser(int id);
    }
}
