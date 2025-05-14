using Data.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(int id);
        Task CreateAsync(UserEntity user);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByEmailAsync(string email);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(UserEntity user);
    }
}
