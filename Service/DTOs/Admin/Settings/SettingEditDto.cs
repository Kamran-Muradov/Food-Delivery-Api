using FluentValidation;

namespace Service.DTOs.Admin.Settings
{
    public class SettingEditDto
    {
        public string Value { get; set; }
    }

    public class SettingEditDtoValidator : AbstractValidator<SettingEditDto>
    {
        public SettingEditDtoValidator()
        {
            RuleFor(m => m.Value)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
