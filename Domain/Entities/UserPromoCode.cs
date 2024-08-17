using Domain.Common;

namespace Domain.Entities
{
    public class UserPromoCode : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int PromoCodeId { get; set; }
        public PromoCode PromoCode { get; set; }
        public bool IsActive { get; set; }
    }
}
