namespace Application.Dtos.Auth
{
    public class RegisterationRequestDto : IBaseAuthDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
