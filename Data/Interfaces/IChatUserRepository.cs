using Data.Entities;

namespace Data.Interfaces
{
    public interface IChatUserRepository
    {
        Task<ChatUserEntity> GetByIdAsync(int id);
        Task CreateAsync(ChatUserEntity chatUser);
        Task UpdateAsync(ChatUserEntity chatUser);
        Task DeleteAsync(ChatUserEntity chatUser);
    }
}
