using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public MenuImage MenuImage { get; set; }
        public ICollection<MenuIngredient> MenuIngredients { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<MenuVariant> MenuVariants { get; set; }
    }
}
