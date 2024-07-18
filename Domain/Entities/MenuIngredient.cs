using Domain.Common;

namespace Domain.Entities
{
    public class MenuIngredient : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
