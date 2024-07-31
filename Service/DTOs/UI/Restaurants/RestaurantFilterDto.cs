namespace Service.DTOs.UI.Restaurants
{
    public class RestaurantFilterDto
    {
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 6;
        public string Sorting { get; set; } = "recent";
        public List<int>? CategoryIds { get; set; }
    }
}
