using FluentValidation;

namespace Service.DTOs.UI.Checkouts
{
    public class CheckoutCreateDto
    {
        public string UserId { get; set; }
        public string? Comments { get; set; }
        public string Address { get; set; }
    }

    public class CheckoutCreateDtoValidator : AbstractValidator<CheckoutCreateDto>
    {
        public CheckoutCreateDtoValidator()
        {
            RuleFor(m => m.UserId)
                .NotEmpty();

            RuleFor(m => m.Address)
                .NotEmpty();
        }
    }
}
