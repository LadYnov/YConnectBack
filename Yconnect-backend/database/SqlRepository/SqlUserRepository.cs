using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly YConnectContextDB _connectContextDb;

        public SqlUserRepository(YConnectContextDB connectContextDb) => _connectContextDb = connectContextDb;

        public async Task<User> GetUser(int id)
        {
            CheckIfUserIsNull(id);
            return await _connectContextDb.Users.FindAsync(id);
        }

        public async Task<EntityEntry<User>> AddUser(User user) => await _connectContextDb.Users.AddAsync(user);

        public async Task DeleteUser(int id)
        {
            CheckIfUserIsNull(id);
            _connectContextDb.Users.Remove(await GetUser(id));
        }

        private void CheckIfUserIsNull(int id)
        {
            if (GetUser(id).Result is null)
            {
                throw new ArgumentNullException(nameof(id), "No user Was Found !");
            }
        }
        
        
    }
}