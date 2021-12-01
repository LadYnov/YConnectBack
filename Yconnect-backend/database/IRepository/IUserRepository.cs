<<<<<<<< HEAD:Yconnect-backend/database/IRepository/IUserRepository.cs
﻿using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
========
﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Yconnect_backend.database.models
>>>>>>>> realese/TRE4_API_POSTS:Yconnect-backend/database/models/IUserRepository.cs
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int id);
        public Task<EntityEntry<User>> AddUser(User user);
        public Task DeleteUser(int id);
    }
}
