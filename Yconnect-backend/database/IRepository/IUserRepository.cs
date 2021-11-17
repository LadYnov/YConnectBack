namespace Yconnect_backend.database.models
{
    public interface IUserRepository
    {
        public User GetUser(int id);
        public User AddUser(User user);
        public User DeleteUser(int id);
    }
}
