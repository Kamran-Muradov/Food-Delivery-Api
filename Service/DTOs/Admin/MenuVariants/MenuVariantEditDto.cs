using FluentValidation;

namespace Service.DTOs.Admin.MenuVariants
{
    public class MenuVariantEditDto
    {
        public int MenuId { get; set; }
        public int VariantTypeId { get; set; }
        public string Option { get; set; }
        public decimal AdditionalPrice { get; set; }
        public bool IsSingleChoice { get; set; }
    }

    public class MenuVariantEditDtoValidator : AbstractValidator<MenuVariantEditDto>
    {
        public MenuVariantEditDtoValidator()
        {
            RuleFor(m => m.Option)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.AdditionalPrice)
                .NotNull();

            RuleFor(m => m.VariantTypeId)
                .NotEmpty();

            RuleFor(m => m.MenuId)
                .NotEmpty();

            RuleFor(m => m.IsSingleChoice)
                .NotNull();
        }
    }
}
