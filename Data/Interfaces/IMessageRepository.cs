using Data.Entities;

namespace Data.Interfaces
{
    public interface IMessageRepository
    {
        Task<MessageEntity> GetByIdAsync(int id);
        Task CreateAsync(MessageEntity message);
        Task UpdateAsync(MessageEntity message);
        Task DeleteAsync(MessageEntity message);
    }
}
