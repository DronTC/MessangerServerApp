using Data.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(int id);
        UserEntity GetByLogin(string login);
        UserEntity GetByEmail(string email);
        Task CreateAsync(UserEntity user);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByLoginAsync(string login);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(UserEntity user);
    }
}
