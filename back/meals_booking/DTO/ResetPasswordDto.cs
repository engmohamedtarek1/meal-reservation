using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ResetPasswordDto
    {
        [EmailAddress]
        [RegularExpression(@"^UG_\d{5,}@ics\.tanta\.edu\.eg$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}