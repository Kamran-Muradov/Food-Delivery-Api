using Domain.Common;

namespace Domain.Entities
{
    public class MenuCategory : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
