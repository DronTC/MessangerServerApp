using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.Chat
{
    public class UpdateChatDTO
    {
        [Key]
        [Required(ErrorMessage = "ID чата обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "ID чата должен быть положительным числом")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Название чата обязательно")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Название чата должно содержать от 1 до 100 символов")]
        public string Name { get; set; }

        public List<int> UserIdsToAdd { get; set; } = new List<int>();
        public List<int> UserIdsToRemove { get; set; } = new List<int>();
    }
}
