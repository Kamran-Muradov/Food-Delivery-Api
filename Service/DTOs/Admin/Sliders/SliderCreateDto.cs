using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Sliders
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }

    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(s => s.Description)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(m => m.Image)
                .NotEmpty();

            RuleFor(m => m.Image)
                .Must(m => m.ContentType.Contains("image/"))
                .WithMessage("File must be image type")
                .Must(item => item.Length / 1024 < 1024)
                .WithMessage("Image size cannot exceed 1MB")
                .When(m => m.Image is not null);
        }
    }
}
