using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ResetPasswordTokenDto
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
