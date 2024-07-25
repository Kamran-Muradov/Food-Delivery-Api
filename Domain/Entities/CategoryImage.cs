using Domain.Common;

namespace Domain.Entities
{
    public class CategoryImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
