using System.Threading.Tasks;

namespace YConnectBackend.Domain.Commons.UserAggregates.Port
{
    public interface IUserRepository
    {
        public Task<User> GetUser(uint id);
    }
}