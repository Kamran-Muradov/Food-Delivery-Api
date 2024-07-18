using FluentValidation;

namespace Service.DTOs.Admin.Ingredients
{
    public class IngredientEditDto
    {
        public string Name { get; set; }
    }

    public class IngredientEditDtoValidator : AbstractValidator<IngredientEditDto>
    {
        public IngredientEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");
        }
    }
}
