using FluentValidation;

namespace Service.DTOs.Admin.Countries
{
    public class CountryCreateDto
    {
        public string Name { get; set; }
    }

    public class CountryCreateDtoValidator : AbstractValidator<CountryCreateDto>
    {
        public CountryCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
