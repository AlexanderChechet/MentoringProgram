using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Users
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task AddUser(User user);
        Task EditUser(User user);
        Task DeleteUser(int id);
    }
}
