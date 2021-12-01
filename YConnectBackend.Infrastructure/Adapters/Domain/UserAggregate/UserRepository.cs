using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YConnectBackend.Domain.Commons.Database;
using YConnectBackend.Domain.Commons.UserAggregates;
using YConnectBackend.Domain.Commons.UserAggregates.Port;
using YConnectBackend.Infrastructure.Adapters.database;

namespace YConnectBackend.Infrastructure.Adapters.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User, YDbContext> _repository;

        public UserRepository(IRepository<User, YDbContext> repository) => _repository = repository;

        public async Task<User> GetUser(uint id)
        {
            return await _repository.FindAsync(_ => _.Id == id).ConfigureAwait(false);
        }

    }
}