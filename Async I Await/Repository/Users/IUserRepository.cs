using Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopRepository.Users
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task AddUser(User user);
        Task EditUser(User user);
        Task DeleteUser(int id);
    }
}
