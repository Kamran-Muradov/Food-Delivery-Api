using FluentValidation;

namespace Service.DTOs.UI.Favourites
{
    public class FavouriteCreateDto
    {
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
    }

    public class FavouriteCreateDtoValidator : AbstractValidator<FavouriteCreateDto>
    {
        public FavouriteCreateDtoValidator()
        {
            RuleFor(m => m.UserId)
                .NotEmpty();

            RuleFor(m => m.RestaurantId)
                .NotEmpty();
        }
    }
}
