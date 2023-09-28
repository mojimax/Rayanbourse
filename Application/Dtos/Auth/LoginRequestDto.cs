namespace Application.Dtos.Auth
{
    public class LoginRequestDto : IBaseAuthDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
