using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ResetPasswordTokenDto
    {
        [EmailAddress]
        [RegularExpression(@"^UG_\d{5,}@ics\.tanta\.edu\.eg$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
