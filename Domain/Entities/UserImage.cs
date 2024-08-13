using Domain.Common;

namespace Domain.Entities
{
    public class UserImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
