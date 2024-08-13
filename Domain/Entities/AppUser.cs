using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public ICollection<Checkout> Checkouts { get; set; }
        public UserImage UserImage { get; set; }
    }
}
