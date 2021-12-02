using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using YConnectBackend.Domain.Commons.Database;
using YConnectBackend.Domain.Commons.UserAggregates;
using YConnectBackend.Domain.Commons.UserAggregates.Port;
using YConnectBackend.Infrastructure.Adapters.database;

namespace YConnectBackend.Infrastructure.Adapters.Domain.UserAggregate
{
    public class UserRepository : IUserRepository
    {
        private readonly YDbContext _dbContext;
        public UserRepository(YDbContext dbContext) 
            => _dbContext = dbContext;
        public async Task<IEnumerable<User>> GetUsers() 
            => await _dbContext.Users.ToListAsync();
        public async Task<User> GetUserAsync(uint id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
        public async Task<User> AddUserAsync(User user)
        {
            EntityEntry<User>? result = await _dbContext.Users
                .AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return result.Entity;
        }
    }
}