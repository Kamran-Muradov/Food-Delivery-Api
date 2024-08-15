using FluentValidation;

namespace Service.DTOs.Admin.SocialMedias
{
    public class SocialMediaEditDto
    {
        public string Platform { get; set; }
        public string Url { get; set; }
    }

    public class SocialMediaEditDtoValidator : AbstractValidator<SocialMediaEditDto>
    {
        public SocialMediaEditDtoValidator()
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
