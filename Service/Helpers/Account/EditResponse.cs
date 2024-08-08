namespace Service.Helpers.Account
{
    public class EditResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public string? Token { get; set; }
    }
}
