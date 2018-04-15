using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Entities;
using ShopRepository.Users;
using System;

namespace Service.Users
{
    public class UserService : IUserService
    {
        private string dbName = "ShopDb.sqlite";
        private IUserRepository repository;
        public UserService()
        {
            repository = new SQLiteUserRepository(dbName);
        }

        public async Task AddUser(User user)
        {
            if (!user.IsValid())
                throw new ArgumentException("User is invalid");
            await repository.AddUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await repository.DeleteUser(id);
        }

        public async Task EditUser(User user)
        {
            if (!user.IsValid())
                throw new ArgumentException("User is invalid");
            await repository.EditUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await repository.GetUsers().ConfigureAwait(false);
        }

    }
}
