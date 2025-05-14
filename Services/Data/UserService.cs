using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using MessangerServerApp.DTOs.User;
using MessangerServerApp.Services.Interfaces;

namespace MessangerServerApp.Services.Data
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepository, 
            IMapper mapper,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            try
            {
                if (await _userRepository.ExistsByEmailAsync(createUserDTO.Email))
                    throw new ArgumentException($"Пользователь с Email {createUserDTO.Email} не найден");

                var user = _mapper.Map<UserEntity>(createUserDTO);

                //Должно быть хеширование пароля

                await _userRepository.CreateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания пользователя");
                throw;
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"Пользователь с ID {id} не найден");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"Пользователь с ID {id} не найден");
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDTO> UpdateUserAsync(UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(updateUserDTO.Id);

            if (user == null)
                throw new KeyNotFoundException($"Пользователь с ID {updateUserDTO.Id} не найден");
            _mapper.Map(updateUserDTO, user);

            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
