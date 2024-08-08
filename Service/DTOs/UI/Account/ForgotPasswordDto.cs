using FluentValidation;

namespace Service.DTOs.UI.Account
{
    public class ForgotPasswordDto
    {
        public string EmailOrUserName { get; set; }
    }

    public class ForgotPasswordDtoValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordDtoValidator()
        {
            RuleFor(m => m.EmailOrUserName)
                .NotEmpty()
                .WithMessage("User name or email is required");
        }
    }
}
