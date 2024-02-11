using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDto
    {
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Invalid SSN")]
        public string SSN { get; set; }

        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [EmailAddress]
        [RegularExpression(@"^UG_\d{5,}@ics\.tanta\.edu\.eg$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
