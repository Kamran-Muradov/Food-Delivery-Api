using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Brands
{
    public class BrandCreateDto
    {
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
    }

    public class BrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
    {
        public BrandCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");

            RuleFor(m => m.Logo)
                .NotEmpty()
                .WithMessage("Logo is required");

            RuleFor(m => m.Logo)
                .Must(m => m.ContentType.Contains("image/"))
                .WithMessage("File must be image type")
                .Must(item => item.Length / 1024 < 500)
                .WithMessage("Logo size cannot exceed 500Kb")
                .When(m => m.Logo is not null);
        }
    }
}
