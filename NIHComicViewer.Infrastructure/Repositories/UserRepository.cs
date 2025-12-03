using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories.Interface;

namespace NIHComicViewer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NihcomicContext _context;

        public UserRepository(NihcomicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) return null;

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => EF.Functions.ILike(u.Username, userName));
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => EF.Functions.ILike(u.EmailAddress, email));
        }

        public async Task<bool> AddUserAsync(User user)
        {
            if (user == null) return false;

            try
            {
                await _context.Users.AddAsync(user);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user == null) return false;

            try
            {
                _context.Users.Update(user);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            try
            {
                var entity = await _context.Users.FindAsync(id);
                if (entity == null) return false;

                _context.Users.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}