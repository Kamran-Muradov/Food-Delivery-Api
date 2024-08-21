using FluentValidation;

namespace Service.DTOs.Admin.PromoCodes
{
    public class PromoCodeCreateDto
    {
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class PromoCodeCreateDtoValidator : AbstractValidator<PromoCodeCreateDto>
    {
        public PromoCodeCreateDtoValidator()
        {
            RuleFor(m => m.Discount)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(100);

            RuleFor(m => m.ExpiryDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now);
        }
    }
}
