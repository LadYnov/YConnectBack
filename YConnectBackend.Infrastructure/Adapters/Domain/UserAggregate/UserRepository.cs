using System.Collections.Generic;
using System.Threading.Tasks;
using YConnectBackend.Domain.Commons.Database;
using YConnectBackend.Domain.Commons.UserAggregates;
using YConnectBackend.Domain.Commons.UserAggregates.Port;
using YConnectBackend.Infrastructure.Adapters.database;

namespace YConnectBackend.Infrastructure.Adapters.Domain.UserAggregate
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User, YDbContext> _repository;
        public UserRepository(IRepository<User, YDbContext> repository) 
            => _repository = repository;

        public async Task<IEnumerable<User>> GetUsers() => await _repository.FilterAsync(_ => true);
        public async Task<User> GetUserAsync(uint id)
        {
            return await _repository.FindAsync(_ => _.Id == id);
        }
        public async Task<User> AddUserAsync(User user) =>
           await _repository
                .AddAsync(user).ConfigureAwait(false);
    }
}