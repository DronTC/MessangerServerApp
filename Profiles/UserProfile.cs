using AutoMapper;
using Data.Entities;
using MessangerServerApp.DTOs.User;

namespace MessangerServerApp.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDTO>();
            CreateMap<CreateUserDTO, UserEntity>();
        }
    }
}
