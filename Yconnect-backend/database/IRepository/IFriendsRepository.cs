using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IFriendsRepository
    {
        public Task<IEnumerable<uint>> GetFriendsId(int iUserId);
        public Task AddFriend(uint iUserId, uint iFriendId);
        public Task DeleteFriend(uint iUserId, uint iFriendId);
        public Task<IEnumerable<uint>> GetSharedFriendsId(uint iUserId, uint iOtherUserId);
    }
}