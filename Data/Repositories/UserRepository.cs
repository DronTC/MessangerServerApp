using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessangerServerApp.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Users.AnyAsync(u => u.Id == id);
        }
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<bool> ExistsByLoginAsync(string login)
        {
            return await _dbContext.Users.AnyAsync(u => u.Login == login);
        }
        public async Task DeleteAsync(UserEntity user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
        public UserEntity GetByLogin(string login)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Login == login);
        }
        public UserEntity GetByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email);
        }
        public async Task UpdateAsync(UserEntity user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
