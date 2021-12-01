using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IIconRepository
    {
        public Task<Icon> GetUser(int id);
        public Task AddUser(Icon iIcon);
        public Task DeleteUser(int id);
        public Task<IEnumerable<Icon>> GetAllIcon();
    }
}