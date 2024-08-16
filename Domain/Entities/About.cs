using Domain.Common;

namespace Domain.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AboutImage AboutImage { get; set; }
    }
}
