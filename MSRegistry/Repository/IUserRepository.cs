using System.Collections.Generic;
using MSRegistry.Model;

namespace MSRegistry.Repository
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);

        IEnumerable<User> GetUsers();

        User Login(string userName, string password);

        void Register(User user);

        void Save();
    }
}
