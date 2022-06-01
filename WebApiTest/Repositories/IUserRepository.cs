using System;
using System.Collections.Generic;
using WebApiTest.Entities;

namespace WebApiTest.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}
