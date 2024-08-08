using Domain.Common;

namespace Domain.Entities
{
    public class SliderImage : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
