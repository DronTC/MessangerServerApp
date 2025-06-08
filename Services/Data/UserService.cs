using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using MessangerServerApp.DTOs.Auth;
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
        public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            try
            {
                if (await _userRepository.ExistsByEmailAsync(createUserDTO.Email))
                    throw new ArgumentException($"Пользователь с Email {createUserDTO.Email} уже существует");
                if (await _userRepository.ExistsByLoginAsync(createUserDTO.Login))
                    throw new ArgumentException($"Пользователь с логином {createUserDTO.Login} уже существует");

                var user = _mapper.Map<UserEntity>(createUserDTO);

                

                await _userRepository.CreateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания пользователя");
                throw;
            }
        }

        public async Task<UserDTO> LoginUserAsync(LoginDTO loginDTO)
        {
            UserEntity user;
            try
            {
                if(loginDTO.Email != null)
                {
                    if (!await _userRepository.ExistsByEmailAsync(loginDTO.Email))
                        throw new ArgumentException($"Пользователя с Email {loginDTO.Email} не существует");
                    else
                        user = _userRepository.GetByEmail(loginDTO.Email);
                }
                if (!await _userRepository.ExistsByEmailAsync(loginDTO.Login))
                    throw new ArgumentException($"Пользователя с логином {loginDTO.Login} не существует");
                else
                    user = _userRepository.GetByLogin(loginDTO.Login);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка авторизации пользователя");
                throw;
            }
        }

        
    }
}
