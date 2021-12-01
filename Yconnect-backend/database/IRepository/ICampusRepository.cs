using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface ICampusRepository
    {
        public Task<IEnumerable<Campus>> GetCampuses();
        
        public Task DeleteCampus(int iCampusId);

        public Task UpdateCampus(int iCampusId, string iNewCampusName);
    }
}