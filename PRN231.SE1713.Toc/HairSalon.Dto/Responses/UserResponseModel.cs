namespace HairSalon.Dto.Responses
{
    /// <summary>
    /// User response model after login successfully
    /// </summary>
    public class UserResponseModel
    {
        public LoggedInUserModel? User { get; set; }

        public string AccessToken { get; set; } = null!;
    }

    public class LoggedInUserModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Email { get; set; } = null!;

        public string Role { get; set; } = string.Empty;
    }
}
