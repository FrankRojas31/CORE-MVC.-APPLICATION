﻿using Biblioteca82.Data.Repositories.Context;
using Biblioteca82.Data.Repositories.Contracts;
using Biblioteca82.Models.Domain;

namespace Biblioteca82.Data.Repositories.Implementation
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
