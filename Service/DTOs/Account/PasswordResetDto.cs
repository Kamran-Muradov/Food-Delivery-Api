using FluentValidation;

namespace Service.DTOs.Account
{
    public class PasswordResetDto
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }

    public class PasswordResetDtoValidator : AbstractValidator<PasswordResetDto>
    {
        public PasswordResetDtoValidator()
        {
            RuleFor(m => m.UserId)
                .NotEmpty()
                .WithMessage("User id is required");

            RuleFor(m => m.NewPassword)
                .NotEmpty()
                .WithMessage("NewPassword is required");

            RuleFor(m => m.Token)
                .NotEmpty()
                .WithMessage("Token is required");
        }
    }
}
