using Domain.Common;

namespace Domain.Entities
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SliderImage SliderImage { get; set; }
    }
}
