using Domain.Common;

namespace Domain.Entities
{
    public class MenuImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
