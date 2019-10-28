using AutoMapper;

namespace MSRegistry.Model
{
    public class UserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public User ToEntity()
        {
            var user = new User();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<UserDto, User>(); });
            IMapper iMapper = config.CreateMapper();

            user = iMapper.Map<UserDto, User>(this);

            return user;
        }
    }
}
