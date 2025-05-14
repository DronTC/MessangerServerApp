using Data.Entities;

namespace Data.Interfaces
{
    public interface IChatRepository
    {
        Task<ChatEntity> GetByIdAsync(int id);
        Task CreateAsync(ChatEntity chat);
        Task UpdateAsync(ChatEntity chat);
        Task DeleteAsync(ChatEntity chat);
    }
}
