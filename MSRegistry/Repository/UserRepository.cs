using System.Collections.Generic;
using System.Linq;
using MSRegistry.DbContexts;
using MSRegistry.Model;
using MSRegistry.Repository;

namespace MSCars.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext) => this._dbContext = dbContext;
        
        public IEnumerable<User> GetUsers() => _dbContext.Users.ToList();

        public User Login(string userName, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
            return user;
        }

        public void Register(User user)
        {
            _dbContext.Users.Add(user);

            Save();
        }

        public User GetUserByUserName(string userName)
        {
            return _dbContext.Users.SingleOrDefault(x => x.UserName.Equals(userName));
        }

        public void Save() => _dbContext.SaveChanges();
    }
}
