using MSRegistry.Model;

namespace MSRegistry.Business
{
    public interface IUserService
    {
        void Login(string userName, string password);

        void Register(User user);
    }
}
