using FluentValidation;

namespace Service.DTOs.Admin.Categories
{
    public class CategoryEditDto
    {
        public string Name { get; set; }
    }

    public class CategoryEditDtoValidator : AbstractValidator<CategoryEditDto>
    {
        public CategoryEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");
        }
    }
}
