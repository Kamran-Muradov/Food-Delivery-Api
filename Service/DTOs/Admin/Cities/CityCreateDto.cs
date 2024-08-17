using FluentValidation;

namespace Service.DTOs.Admin.Cities
{
    public class CityCreateDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CityCreateDtoValidator : AbstractValidator<CityCreateDto>
    {
        public CityCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.CountryId)
                .NotEmpty();
        }
    }
}
