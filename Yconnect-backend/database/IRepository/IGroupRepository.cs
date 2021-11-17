using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models; 

namespace Yconnect_backend.database.IRepository
{
    public interface IGroupRepository
    {
        public Task UpdateGroup(string iNewName = default, uint iNewAdminId = default);

        public Task DeleteGroup(uint iGroupId);
        
        public Task<IEnumerable<Group>> GetUserGroups(uint iUserId);
        
        public Task<IEnumerable<Group>> GetAdminGroups(uint iAdminId);

        public Task<IEnumerable<Tag>> GetGroupTags(uint iGroupId);
        
        public Task<IEnumerable<Tag>> AddGroupTags(uint iGroupId, uint iTagId);

        public Task RemoveGroupTag(uint iGroupId, uint iTagId);

        public Task AddMember(uint iGroupId, uint iNewUserId);

        public Task RemoveMember(uint iGroupId, uint iRemovedUser);

        public Task<IEnumerable<Member>> GetGroupMembers(uint iGroupId);
    }
}