using MessangerServerApp.DTOs.Chat;
using MessangerServerApp.DTOs.Message;

namespace MessangerServerApp.Services.Interfaces
{
    public interface IChatService
    {
        Task<ChatDTO> CreateChatAsync(CreateChatDTO createChatDTO);
        Task<ChatDTO> GetChatByIdAsync(int id);
        Task<ChatDTO> UpdateChatAsync(UpdateChatDTO updateChatDTO);
        Task DeleteChatAsync(int id);
        Task AddUsersToChatAsync(int chatId, IEnumerable<int> userIds);
        Task RemoveUsersFromChatAsync(int chatId, IEnumerable<int> userIds);
    }
}
