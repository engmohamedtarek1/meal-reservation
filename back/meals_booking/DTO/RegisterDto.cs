using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDto
    {
        public string SSN { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
