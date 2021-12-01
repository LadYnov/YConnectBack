using System.Threading.Tasks;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlGenderRepository : IGenderRepository
    {
        private readonly YConnectContextDB _context;

        public SqlGenderRepository(YConnectContextDB context)
        {
            this._context = context;
        }

        public async Task AddGender(Gender iGender)
        {
            await this._context.Gender.AddAsync(iGender);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateGender(uint iGenderId, string iGenderName)
        {
            Gender aGender = await this._context.Gender.FindAsync(iGenderId);

            if (aGender is not null)
            {
                aGender.GenderName = iGenderName;
                this._context.Gender.Update(aGender);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<Gender> GetGender(uint iGenderId)
        {
            return await this._context.Gender.FindAsync(iGenderId);
        }
    }
}