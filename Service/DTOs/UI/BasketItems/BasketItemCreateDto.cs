using FluentValidation;

namespace Service.DTOs.UI.BasketItems
{
    public class BasketItemCreateDto
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int MenuId { get; set; }
        public string UserId { get; set; }
        public Dictionary<string, List<string>>? BasketVariants { get; set; }
    }

    public class BasketItemCreateDtoValidator : AbstractValidator<BasketItemCreateDto>
    {
        public BasketItemCreateDtoValidator()
        {
            RuleFor(m => m.Price)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(m => m.Count)
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
