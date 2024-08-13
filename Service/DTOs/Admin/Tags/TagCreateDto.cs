using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Tags
{
    public class TagCreateDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }

    public class TagCreateDtoValidator : AbstractValidator<TagCreateDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");

            RuleFor(m => m.Image)
                .NotEmpty()
                .WithMessage("Logo is required");

            RuleFor(m => m.Image)
                .Must(m => m.ContentType.Contains("image/"))
                .WithMessage("File must be image type")
                .Must(item => item.Length / 1024 < 500)
                .WithMessage("Logo size cannot exceed 500Kb")
                .When(m => m.Image is not null);
        }
    }
}
