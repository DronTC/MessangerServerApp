using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.Message
{
    public class UpdateMessageDTO
    {
        [Key]
        [Required(ErrorMessage = "ID сообщения обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "ID сообщения должен быть положительным числом")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Содержание сообщения обязательно")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Сообщение должно содержать от 1 до 2000 символов")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Время отправки обязательно")]
        public TimeOnly SendingTime { get; set; }
    }
}
