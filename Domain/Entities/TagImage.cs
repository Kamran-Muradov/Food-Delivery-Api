using Domain.Common;

namespace Domain.Entities
{
    public class TagImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
