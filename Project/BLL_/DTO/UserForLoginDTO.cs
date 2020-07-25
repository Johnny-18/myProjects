using System.ComponentModel.DataAnnotations;

namespace BLL_.DTO
{
    public class UserForLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "password length from 4 to 16")]
        public string Password { get; set; }
    }
}
