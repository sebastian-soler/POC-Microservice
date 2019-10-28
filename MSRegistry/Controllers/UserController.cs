using System;
using Microsoft.AspNetCore.Mvc;
using MSRegistry.Business;
using MSRegistry.Model;

namespace MSRegistry.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        // POST: api/User
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string userName, string password)
        {
            try{
                _userService.Login(userName, password);
            }
            catch (Exception){
                return new UnauthorizedResult();
            }

            return new OkResult();
        }

        // POST: api/user/registry
        [HttpPost]
        [Route("registry")]
        public IActionResult Register([FromBody] UserDto registryUser)
        {
            try{
                var user = registryUser.ToEntity();

                _userService.Register(user);
	        }
	        catch (Exception ex){
                return new BadRequestObjectResult(ex.Message);
	        }

            return new OkResult();
        }
    }
}