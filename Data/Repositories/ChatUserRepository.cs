using Data.Entities;
using Data.Interfaces;

namespace MessangerServerApp.Data.Repositories
{
    public class ChatUserRepository : IChatUserRepository
    {
        private readonly AppDbContext _dbContext;
        public ChatUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ChatUserEntity chatUser)
        {
            await _dbContext.ChatUsers.AddAsync(chatUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ChatUserEntity chatUser)
        {
            _dbContext.ChatUsers.Remove(chatUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ChatUserEntity> GetByIdAsync(int id)
        {
            return await _dbContext.ChatUsers.FindAsync(id);
        }

        public async Task UpdateAsync(ChatUserEntity chatUser)
        {
            _dbContext.ChatUsers.Update(chatUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
