using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IGenderRepository
    {
        public Task AddGender(Gender iGender);
        public Task UpdateGender(uint iGenderId, string iGenderName);
        public Task<Gender> GetGender(uint iGenderId);
    }
}