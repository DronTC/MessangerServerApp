using Data.Entities;
using Data.Interfaces;

namespace MessangerServerApp.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly AppDbContext _dbContext;
        public ChatRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ChatEntity chat)
        {
            await _dbContext.Chats.AddAsync(chat);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ChatEntity chat)
        {
            _dbContext.Chats.Remove(chat);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ChatEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Chats.FindAsync(id);
        }

        public async Task UpdateAsync(ChatEntity chat)
        {
            _dbContext.Chats.Update(chat);
            await _dbContext.SaveChangesAsync();
        }
    }
}
