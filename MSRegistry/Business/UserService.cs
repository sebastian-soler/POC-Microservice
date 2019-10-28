using System;
using MSRegistry.Model;
using MSRegistry.Repository;

namespace MSRegistry.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public void Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) throw new Exception("Los datos no estan completos, valide los campos.");

            var loggedUser = _userRepository.Login(userName, password);

            if (loggedUser == null) throw new UnauthorizedAccessException("Credenciales incorrectas");
        }

        public void Register(User user)
        {
            if(user == null) throw new Exception("El usuario no puede ser nulo.");
            
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password)) throw new Exception("Los datos del usuario no pueden ser nulos o vacios.");

            if (_userRepository.GetUserByUserName(user.UserName) != null) throw new Exception("El nombre de usuario que intenta registrar, ya se encuentra en uso.");

            _userRepository.Register(user);
        }
    }
}
