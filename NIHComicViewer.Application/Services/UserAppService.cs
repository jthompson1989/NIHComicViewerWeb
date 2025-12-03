using NIHComicViewer.Application.Models;
using NIHComicViewer.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services
{
    public class UserAppService : IUserAppService
    {
        public async Task<bool> CreateUserAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel?> GetUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserAdminAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
