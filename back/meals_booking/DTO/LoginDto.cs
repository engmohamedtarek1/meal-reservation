using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}