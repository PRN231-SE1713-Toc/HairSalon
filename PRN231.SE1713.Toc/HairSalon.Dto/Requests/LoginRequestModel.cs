namespace HairSalon.Dto.Requests
{
    /// <summary>
    /// Login request model
    /// </summary>
    public class LoginRequestModel
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
