using FluentValidation;

namespace Service.DTOs.UI.Reviews
{
    public class ReviewCreateDto
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int CheckoutId { get; set; }
    }

    public class ReviewCreateDtoValidator : AbstractValidator<ReviewCreateDto>
    {
        public ReviewCreateDtoValidator()
        {
            RuleFor(m => m.CheckoutId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(m => m.Rating)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5);
        }
    }
}
