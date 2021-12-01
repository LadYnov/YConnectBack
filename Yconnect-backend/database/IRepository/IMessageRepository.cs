using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IMessageRepository
    {
        public Task<IEnumerable<Message>> GetAllMessages();
        public Task<Message> GetMessage(int id);
        public Task AddMessage(Message message);
        public Task UpdateMessage(int iPostId, string message, uint iReactionCount);
        public Task DeleteMessage(int id);
    }
}