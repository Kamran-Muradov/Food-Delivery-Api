using FluentValidation;

namespace Service.DTOs.UI.BasketItems
{
    public class BasketCountDto
    {
        public string UserId { get; set; }
        public int MenuId { get; set; }
        public int Count { get; set; }
    }

    public class BasketItemEditDtoValidator : AbstractValidator<BasketCountDto>
    {
        public BasketItemEditDtoValidator()
        {
            RuleFor(m => m.UserId)
                .NotEmpty();

            RuleFor(m => m.Count)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(m => m.MenuId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
