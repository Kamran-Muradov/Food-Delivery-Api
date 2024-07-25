namespace Service.Helpers.Account
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public bool IsEmailTaken { get; set; } = false;
        public bool IsUsernameTaken { get; set; } = false;
        public string UserId { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
