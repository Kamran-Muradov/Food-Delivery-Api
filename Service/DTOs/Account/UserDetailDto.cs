namespace Service.DTOs.Account
{
    public class UserDetailDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
