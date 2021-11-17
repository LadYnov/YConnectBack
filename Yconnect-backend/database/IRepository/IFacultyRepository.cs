using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IFacultyRepository
    {
        public Task<Faculty> GetFaculty(string id);
        public Task<IEnumerable<Faculty>> GetAllFaculty();
        public Task UpdateFaculty(int iFacultyId, string name);
        public Task DeleteFaculty(string id);
    }
}