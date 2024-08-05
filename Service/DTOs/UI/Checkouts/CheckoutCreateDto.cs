using FluentValidation;

namespace Service.DTOs.UI.Checkouts
{
    public class CheckoutCreateDto
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CheckoutCreateDtoValidator : AbstractValidator<CheckoutCreateDto>
    {
        public CheckoutCreateDtoValidator()
        {
            RuleFor(m => m.TotalPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(m => m.MenuId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(m => m.UserId)
                .NotEmpty();
        }
    }
}
