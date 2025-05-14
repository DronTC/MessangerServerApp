using MessangerServerApp.DTOs.Message;
using MessangerServerApp.DTOs.User;

namespace MessangerServerApp.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<MessageDTO> CreateMessageAsync(CreateMessageDTO createMessageDTO);
        public Task<MessageDTO> GetMessageByIdAsync(int id);
        public Task DeleteMessageAsync(int id);
        public Task<MessageDTO> UpdateMessageAsync(UpdateMessageDTO updateMessageDTO);
    }
}
