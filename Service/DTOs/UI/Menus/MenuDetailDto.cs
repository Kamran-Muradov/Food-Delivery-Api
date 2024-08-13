using Service.DTOs.UI.MenuVariants;

namespace Service.DTOs.UI.Menus
{
    public class MenuDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public string Image { get; set; }
        public int MenuId { get; set; }
        public int RestaurantId { get; set; }
        public string Restaurant { get; set; }
        public Dictionary<string,IEnumerable<MenuVariantDto>> MenuVariants { get; set; }
    }
}
