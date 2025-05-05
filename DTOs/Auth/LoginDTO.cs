using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        public string UsernameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
