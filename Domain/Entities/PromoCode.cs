using Domain.Common;

namespace Domain.Entities
{
    public class PromoCode : BaseEntity
    {
        public string Code { get; set; } = Guid.NewGuid().ToString().Substring(0, 6);
        public DateTime ExpiryDate { get; set; }
        public double Discount { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserPromoCode> UserPromoCodes { get; set; }
    }
}
