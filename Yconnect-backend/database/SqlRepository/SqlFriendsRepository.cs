using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;
namespace Yconnect_backend.database.SqlRepository
{
    public class SqlFriendsRepository : IFriendsRepository
    {
        private readonly YConnectContextDB _contextDb;

        public SqlFriendsRepository(YConnectContextDB contextDb)
        {
            this._contextDb = contextDb;
        }

        public async Task<IEnumerable<uint>> GetFriendsId(int iUserId)
        {
            List<FriendsList> friends = await this._contextDb.FriendsLists.Where(_ => _.Id == iUserId).ToListAsync();

            IEnumerable<uint> friendsId = new List<uint>();
            
            foreach (var friend in friends)
            {
                friendsId.Append(friend.FriendId);
            }

            return friendsId;
        }

        public async Task AddFriend(uint iUserId, uint iFriendId)
        {
            //TODO check si l ami existe deja
            this._contextDb.FriendsLists.Add(new FriendsList()
            {
                CurrentUserId = iUserId,
                FriendId = iFriendId
                
            });
            
            await this._contextDb.SaveChangesAsync();
        }

        public async Task DeleteFriend(uint iUserId, uint iFriendId)
        {
            FriendsList aFriendship = await this._contextDb.FriendsLists
                .Where(_ => _.FriendId == iFriendId && _.CurrentUserId == iUserId).FirstAsync();

            if (aFriendship != null)
            {
                this._contextDb.FriendsLists.Remove(aFriendship);
                await this._contextDb.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<uint>> GetSharedFriendsId(uint iUserId, uint iOtherUserId)
        {
            List<FriendsList> friends1 = await this._contextDb.FriendsLists.Where(_ => _.Id == iUserId).ToListAsync();
            List<FriendsList> friends2 = await this._contextDb.FriendsLists.Where(_ => _.Id == iOtherUserId).ToListAsync();
            
            IEnumerable<uint> SharedFriends = new List<uint>();

            int size;

            if (friends1.Count > friends2.Count)
            {
                size = friends2.Count;
            }
            else
            {
                size = friends1.Count;
            }

            for (int i = 0; i < size; i++)
            {
                if (friends1[i].FriendId == friends2[i].FriendId)
                {
                    SharedFriends.Append(friends1[i].FriendId);
                }
            }

            return SharedFriends;
        }
    }
}