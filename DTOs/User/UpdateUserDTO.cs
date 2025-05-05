using System.ComponentModel.DataAnnotations;

namespace MessangerServerApp.DTOs.User
{
    public class UpdateUserDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Login { get; set; }

        [EmailAddress] 
        public string? Email { get; set; }
    }
}
