using MenuDto = Service.DTOs.UI.Menus.MenuDto;

namespace Service.DTOs.UI.Checkouts
{
    public class CheckoutDto
    {
        public int Id { get; set; }
        public MenuDto Menu { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
