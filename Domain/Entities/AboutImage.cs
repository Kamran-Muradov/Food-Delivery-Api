using Domain.Common;

namespace Domain.Entities
{
    public class AboutImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
