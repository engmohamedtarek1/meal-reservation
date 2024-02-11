using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ResetPasswordDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}