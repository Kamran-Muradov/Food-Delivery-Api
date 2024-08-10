using Domain.Common;

namespace Domain.Entities
{
    public class BrandLogo : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int BrandId { get; set; }
    }
}
