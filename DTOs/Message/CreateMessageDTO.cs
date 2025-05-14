using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.Message
{
    public class CreateMessageDTO
    {
        [Required(ErrorMessage = "Содержание сообщения обязательно")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Сообщение должно содержать от 1 до 2000 символов")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Время отправки обязательно")]
        public TimeOnly SendingTime { get; set; }

        [Required(ErrorMessage = "ID пользователя обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "ID пользователя должен быть положительным числом")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ID чата обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "ID чата должен быть положительным числом")]
        public int ChatId { get; set; }
    }
}
