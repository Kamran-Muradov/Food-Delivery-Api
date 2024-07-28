using FluentValidation;

namespace Service.DTOs.Admin.MenuVariants
{
    public class MenuVariantEditDto
    {
        public int MenuId { get; set; }
        public int VariantTypeId { get; set; }
        public string Option { get; set; }
        public decimal? AdditionalPrice { get; set; }
    }

    public class MenuVariantEditDtoValidator : AbstractValidator<MenuVariantEditDto>
    {
        public MenuVariantEditDtoValidator()
        {
            RuleFor(m => m.Option)
                .NotEmpty()
                .WithMessage("Option is required")
                .MaximumLength(50)
                .WithMessage("Option cannot exceed 50 characters");
        }
    }
}
