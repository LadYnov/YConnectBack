using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlCampusRepository : ICampusRepository
    {
        private readonly YConnectContextDB _contextDb;

        public SqlCampusRepository(YConnectContextDB contextDb)
        {
            this._contextDb = contextDb;
        }

        public async Task<IEnumerable<Campus>> GetCampuses()
        {
            return await this._contextDb.Campus.ToListAsync();
        }

        public async Task DeleteCampus(int iCampusId)
        {
            Campus aCampus = await this._contextDb.Campus.FindAsync(iCampusId);

            if (aCampus != null)
            {
                this._contextDb.Campus.Remove(aCampus);
                await this._contextDb.SaveChangesAsync();
            }
        }

        public async Task UpdateCampus(int iCampusId, string iNewCampusName)
        {
            Campus aCampus = await this._contextDb.Campus.FindAsync(iCampusId);

            aCampus.Name = iNewCampusName;

            this._contextDb.Campus.Update(aCampus);

            await this._contextDb.SaveChangesAsync();
        }
    }
}