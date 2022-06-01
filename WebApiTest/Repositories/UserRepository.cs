using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Entities;

namespace WebApiTest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> Users = new()
        {
            new User { Id = Guid.NewGuid(), Name = "Piet" },
            new User { Id = Guid.NewGuid(), Name = "Jan" },
            new User { Id = Guid.NewGuid(), Name = "Gerben" }
        };

        public void CreateUser(User user)
        {
           Users.Add(user);
        }

        public void DeleteUser(Guid id)
        {
            Users.Remove(GetUser(id));
        }

        public User GetUser(Guid id)
        {
            return Users.Where(ticket => ticket.Id == id).SingleOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }

        public void UpdateUser(User user)
        {
            var index = Users.FindIndex(existinguser => existinguser.Id == user.Id);
            Users[index] = user;
        }
    }
}
