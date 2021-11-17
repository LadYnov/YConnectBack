using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlMessageRepository : IMessageRepository
    {
        private readonly YConnectContextDB _context;

        public SqlMessageRepository(YConnectContextDB context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            return await this._context.Message.ToListAsync();
        }

        public async Task<Message> GetMessage(int iMessageId)
        {
            return await this._context.Message.FindAsync(iMessageId);
        }

        public async Task AddMessage(Message message)
        {
            await this._context.Message.AddAsync(message);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateMessage(int iPostId, string message, uint iReactionCount)
        {
            Message aMessageToUpdate = await this._context.Message.FindAsync(iPostId);

            if (aMessageToUpdate is not null)
            {
                aMessageToUpdate.Content = message;
                aMessageToUpdate.ReactionCount = iReactionCount;
                this._context.Message.Update(aMessageToUpdate);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task DeleteMessage(int id)
        {
            Message aMessageToDelete = await this._context.Message.FindAsync(id);
            
            if (aMessageToDelete is not null)
            {
                this._context.Message.Remove(aMessageToDelete);
                await this._context.SaveChangesAsync();
            }
        }
    }
}