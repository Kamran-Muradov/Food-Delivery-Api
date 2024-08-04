namespace Service.DTOs.UI.MenuVariants
{
    public class MenuVariantDto
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public bool IsSingleChoice { get; set; }
        public string VariantType { get; set; }
    }
}
