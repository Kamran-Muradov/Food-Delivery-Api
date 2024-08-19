using FluentValidation;

namespace Service.DTOs.Admin.VariantTypes
{
    public class VariantTypeEditDto
    {
        public string Name { get; set; }
    }

    public class VariantTypeEditDtoValidator : AbstractValidator<VariantTypeEditDto>
    {
        public VariantTypeEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
