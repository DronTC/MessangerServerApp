using Data.Entities;
using Data.Interfaces;

namespace MessangerServerApp.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _dbContext;
        public MessageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(MessageEntity message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MessageEntity message)
        {
            _dbContext.Messages.Remove(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MessageEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Messages.FindAsync(id);
        }

        public async Task UpdateAsync(MessageEntity message)
        {
            _dbContext.Messages.Update(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}
