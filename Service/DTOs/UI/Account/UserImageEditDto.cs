using Microsoft.AspNetCore.Http;

namespace Service.DTOs.UI.Account
{
    public class UserImageEditDto
    {
        public IFormFile ProfilePicture { get; set; }
    }
}
