using FluentValidation;

namespace Service.DTOs.Admin.VariantTypes
{
    public class VariantTypeCreateDto
    {
        public string Name { get; set; }
    }

    public class VariantTypeCreateDtoValidator : AbstractValidator<VariantTypeCreateDto>
    {
        public VariantTypeCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
