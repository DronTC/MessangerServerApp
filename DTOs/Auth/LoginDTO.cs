using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.Auth
{
    public class LoginDTO
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
