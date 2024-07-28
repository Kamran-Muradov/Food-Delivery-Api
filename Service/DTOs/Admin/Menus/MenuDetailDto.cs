using Service.DTOs.Admin.MenuVariants;

namespace Service.DTOs.Admin.Menus
{
    public class MenuDetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Restaurant { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
