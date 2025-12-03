using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIHComicViewer.Infrastructure.Entities;

namespace NIHComicViewer.Infrastructure.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(long id);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(long id);
    }
}
