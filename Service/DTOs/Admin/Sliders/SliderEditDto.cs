using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Sliders
{
    public class SliderEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }

    public class SliderEditDtoValidator : AbstractValidator<SliderEditDto>
    {
        public SliderEditDtoValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(s => s.Description)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(s => s.Image)
                .Must(i => i.ContentType.Contains("image/"))
                .WithMessage("File must be image type")
                .Must(i => i.Length / 1024 < 500)
                .WithMessage("Image size cannot exceed 500Kb")
                .When(s => s.Image is not null);
        }
    }
}
