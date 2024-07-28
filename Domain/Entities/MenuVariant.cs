using Domain.Common;

namespace Domain.Entities
{
    public class MenuVariant : BaseEntity
    {
        public string Option { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int VariantTypeId { get; set; }
        public VariantType VariantType { get; set; }
    }
}
