using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using MessangerServerApp.DTOs.Chat;
using MessangerServerApp.Services.Interfaces;

namespace MessangerServerApp.Services.Data
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ChatService> _logger;

        public ChatService(
            IChatRepository chatRepository,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<ChatService> logger)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ChatDTO> CreateChatAsync(CreateChatDTO createChatDTO)
        {
            try
            {
                var chat = _mapper.Map<ChatEntity>(createChatDTO);

                // Добавление пользователей в чат
                chat.ChatUsers = createChatDTO.UserIds.Select(userId => new ChatUserEntity
                {
                    UserId = userId
                }).ToList();

                await _chatRepository.CreateAsync(chat);
                return _mapper.Map<ChatDTO>(chat);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании чата");
                throw;
            }
        }

        public async Task<ChatDTO> GetChatByIdAsync(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Чат с ID {id} не найден");
            }
            return _mapper.Map<ChatDTO>(chat);
        }

        public async Task<ChatDTO> UpdateChatAsync(UpdateChatDTO updateChatDTO)
        {
            var chat = await _chatRepository.GetByIdAsync(updateChatDTO.Id);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Чат с ID {updateChatDTO.Id} не найден");
            }

            _mapper.Map(updateChatDTO, chat);
            await _chatRepository.UpdateAsync(chat);
            return _mapper.Map<ChatDTO>(chat);
        }

        public async Task DeleteChatAsync(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Чат с ID {id} не найден");
            }
            await _chatRepository.DeleteAsync(chat);
        }

        public async Task AddUsersToChatAsync(int chatId, IEnumerable<int> userIds)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Чат с ID {chatId} не найден");
            }

            foreach (var userId in userIds)
            {
                if (!chat.ChatUsers.Any(cu => cu.UserId == userId))
                {
                    chat.ChatUsers.Add(new ChatUserEntity { UserId = userId });
                }
            }

            await _chatRepository.UpdateAsync(chat);
        }

        public async Task RemoveUsersFromChatAsync(int chatId, IEnumerable<int> userIds)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId);
            if (chat == null)
            {
                throw new KeyNotFoundException($"Чат с ID {chatId} не найден");
            }

            foreach (var userId in userIds)
            {
                var chatUser = chat.ChatUsers.FirstOrDefault(cu => cu.UserId == userId);
                if (chatUser != null)
                {
                    chat.ChatUsers.Remove(chatUser);
                }
            }

            await _chatRepository.UpdateAsync(chat);
        }
    }
}
