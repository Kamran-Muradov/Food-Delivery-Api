using FluentValidation;

namespace Service.DTOs.Admin.PromoCodes
{
    public class PromoCodeEditDto
    {
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class PromoCodeEditDtoValidator : AbstractValidator<PromoCodeEditDto>
    {
        public PromoCodeEditDtoValidator()
        {
            RuleFor(m => m.Discount)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(100);

            RuleFor(m => m.ExpiryDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now);

            RuleFor(m => m.IsActive)
                .NotNull();
        }
    }
}
