using FluentValidation;

namespace Service.DTOs.Admin.Ingredients
{
    public class IngredientCreateDto
    {
        public string Name { get; set; }
    }

    public class IngredientCreateDtoValidator : AbstractValidator<IngredientCreateDto>
    {
        public IngredientCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");
        }
    }
}
