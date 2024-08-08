using FluentValidation;

namespace Service.DTOs.UI.Account
{
    public class LoginDto
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(m => m.EmailOrUserName)
                .NotEmpty()
                .WithMessage("User name or email is required");

            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
