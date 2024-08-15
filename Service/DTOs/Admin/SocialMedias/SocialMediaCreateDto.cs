using FluentValidation;

namespace Service.DTOs.Admin.SocialMedias
{
    public class SocialMediaCreateDto
    {
        public string Platform { get; set; }
        public string Url { get; set; }
    }

    public class SocialMediaCreateDtoValidator : AbstractValidator<SocialMediaCreateDto>
    {
        public SocialMediaCreateDtoValidator()
        {
            RuleFor(m => m.Platform)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.Url)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
