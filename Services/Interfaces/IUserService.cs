using MessangerServerApp.DTOs.User;

namespace MessangerServerApp.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDTO);
        public Task<UserDTO> GetUserByIdAsync(int id);
        public Task DeleteUserAsync(int id);
        public Task<UserDTO> UpdateUserAsync(UpdateUserDTO updateUserDTO);
    }
}
