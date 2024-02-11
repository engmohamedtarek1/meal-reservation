namespace API.DTO
{
    public class AppUserDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Role { get; set; }
    }
}
