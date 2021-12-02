using System.Collections.Generic;
using System.Threading.Tasks;

namespace YConnectBackend.Domain.Commons.UserAggregates.Port
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserAsync(uint id);
        Task<User> AddUserAsync(User user);
    }
}