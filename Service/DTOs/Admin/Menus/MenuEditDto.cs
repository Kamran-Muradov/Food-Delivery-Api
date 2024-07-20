using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Menus
{
    public class MenuEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public IFormFile? Image { get; set; }
    }

    public class MenuEditDtoValidator : AbstractValidator<MenuEditDto>
    {
        public MenuEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");

            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(200)
                .WithMessage("Description cannot exceed 200 characters");

            RuleFor(m => m.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(m => m.RestaurantId)
                .NotEmpty()
                .WithMessage("Restaurant id is required")
                .GreaterThan(0)
                .WithMessage("Restaurant id must be greater than 0");

            RuleFor(m => m.Image)
                .Must(m => m.ContentType.Contains("image/"))
                .WithMessage("File must be image type")
                .Must(item => item.Length / 1024 < 500)
                .WithMessage("Image size cannot exceed 500Kb")
                .When(m => m.Image is not null);
        }
    }
}
