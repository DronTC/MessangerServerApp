using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class MessageEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public TimeOnly SendingTime { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int ChatId { get; set; }
        public ChatEntity Chat { get; set; }
    }
}
