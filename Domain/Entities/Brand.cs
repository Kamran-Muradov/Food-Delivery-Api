using Domain.Common;

namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public BrandLogo BrandLogo { get; set; }
    }
}
