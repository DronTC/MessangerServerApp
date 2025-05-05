using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.User
{
    public class CreateUserDTO
    {
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
