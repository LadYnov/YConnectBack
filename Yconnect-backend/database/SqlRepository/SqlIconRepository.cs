using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlIconRepository : IIconRepository
    {
        private readonly YConnectContextDB _context;

        public SqlIconRepository(YConnectContextDB context)
        {
            this._context = context;
        }
        
        public async Task<Icon> GetUser(int id)
        {
            return await this._context.Icon.FindAsync(id);
        }

        public async Task AddUser(Icon iIcon)
        {
            await this._context.Icon.AddAsync(iIcon);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            Icon icon = await this._context.Icon.FindAsync(id);
            
            this._context.Icon.Remove(icon);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Icon>> GetAllIcon()
        {
            return await this._context.Icon.ToListAsync();
        }
    }
}