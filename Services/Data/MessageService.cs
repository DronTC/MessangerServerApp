using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using MessangerServerApp.DTOs.Message;
using MessangerServerApp.DTOs.User;
using MessangerServerApp.Services.Interfaces;

namespace MessangerServerApp.Services.Data
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MessageService> _logger;

        public MessageService(
            IMessageRepository messageRepository,
            IMapper mapper,
            ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MessageDTO> CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            try
            {
                var message = _mapper.Map<MessageEntity>(createMessageDTO);


                await _messageRepository.CreateAsync(message);

                return _mapper.Map<MessageDTO>(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания");
                throw;
            }
        }

        public async Task<MessageDTO> GetMessageByIdAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);

            if (message == null)
                throw new KeyNotFoundException($"Сообщение с ID {id} не найдено");
            return _mapper.Map<MessageDTO>(message);
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);

            if (message == null)
                throw new KeyNotFoundException($"Сообщение с ID {id} не найдено");
            await _messageRepository.DeleteAsync(message);
        }

        public async Task<MessageDTO> UpdateMessageAsync(UpdateMessageDTO updateMessageDTO)
        {
            var message = await _messageRepository.GetByIdAsync(updateMessageDTO.Id);

            if (message == null)
                throw new KeyNotFoundException($"Сообщение с ID {updateMessageDTO.Id} не найдено");
            _mapper.Map(updateMessageDTO, message);

            await _messageRepository.UpdateAsync(message);
            return _mapper.Map<MessageDTO>(message);
        }
    }
}
