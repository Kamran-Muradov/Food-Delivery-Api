namespace Service.Helpers.Account
{
    public class ForgotPasswordResponse
    {
        public bool Success { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PasswordResetToken { get; set; }
    }
}
