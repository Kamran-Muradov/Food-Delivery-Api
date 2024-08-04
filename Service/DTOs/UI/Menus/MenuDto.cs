using Service.DTOs.UI.Categories;

namespace Service.DTOs.UI.Menus
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public string Image { get; set; }
        public CategoryDto Category { get; set; }
    }
}
