using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.Chat
{
    public class CreateChatDTO
    {
        [Required(ErrorMessage = "Название чата обязательно")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Название чата должно содержать от 1 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать хотя бы одного участника")]
        [MinLength(1, ErrorMessage = "Чат должен содержать минимум 1 участника")]
        public List<int> UserIds { get; set; } = new List<int>();
    }
}
