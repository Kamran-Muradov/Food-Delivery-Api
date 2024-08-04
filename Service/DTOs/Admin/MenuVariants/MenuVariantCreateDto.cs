using FluentValidation;

namespace Service.DTOs.Admin.MenuVariants
{
    public class MenuVariantCreateDto
    {
        public int MenuId { get; set; }
        public int VariantTypeId { get; set; }
        public string Option { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public bool IsSingleChoice { get; set; }
    }

    public class MenuVariantCreateDtoValidator : AbstractValidator<MenuVariantCreateDto>
    {
        public MenuVariantCreateDtoValidator()
        {
            RuleFor(m => m.Option)
                .NotEmpty()
                .WithMessage("Option is required")
                .MaximumLength(50)
                .WithMessage("Option cannot exceed 50 characters");
        }
    }
}
