using Domain.Common;

namespace Domain.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Platform { get; set; }
        public string Url { get; set; }
    }
}
