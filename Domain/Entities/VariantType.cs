using Domain.Common;

namespace Domain.Entities
{
    public class VariantType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MenuVariant> MenuVariants { get; set; }
    }
}
