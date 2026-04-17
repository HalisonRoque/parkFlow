namespace webApi.Features.User.Dtos
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
