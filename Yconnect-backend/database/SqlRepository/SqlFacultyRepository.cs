using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlFacultyRepository : IFacultyRepository
    {
        private readonly YConnectContextDB _context;

        public SqlFacultyRepository(YConnectContextDB context)
        {
            this._context = context;
        }

        public async Task<Faculty> GetFaculty(string id)
        {
            return await this._context.Faculties.FindAsync(id);
        }

        public async  Task<IEnumerable<Faculty>> GetAllFaculty()
        {
            return await this._context.Faculties.ToListAsync();
        }

        public async Task UpdateFaculty(int iFacultyId, string name)
        {
            Faculty aFaculty = await this._context.Faculties.FindAsync(iFacultyId);

            if (aFaculty is not null)
            {
                aFaculty.Name = name;
                this._context.Faculties.Update(aFaculty);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task DeleteFaculty(string id)
        {
            Faculty aFaculty = await this._context.Faculties.FindAsync(id);
            
            if (aFaculty is not null)
            {
                this._context.Faculties.Remove(aFaculty);
                await this._context.SaveChangesAsync();
            }
        }
    }
}