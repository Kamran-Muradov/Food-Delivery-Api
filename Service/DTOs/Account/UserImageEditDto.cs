using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Account
{
    public class UserImageEditDto
    {
        public IFormFile ProfilePicture { get; set; }
    }
}
