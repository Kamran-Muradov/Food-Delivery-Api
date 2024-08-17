using FluentValidation;

namespace Service.DTOs.Admin.Cities
{
    public class CityEditDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CityEditDtoValidator : AbstractValidator<CityEditDto>
    {
        public CityEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.CountryId)
                .NotEmpty();
        }
    }
}
