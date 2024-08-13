using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Admin.Restaurants
{
    public class RestaurantEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal DeliveryFee { get; set; }
        public bool IsActive { get; set; }
        public decimal MinimumOrder { get; set; }
        public int MinDeliveryTime { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public List<IFormFile>? Images { get; set; }
        public List<int> TagIds { get; set; }
        public int? BrandId { get; set; }
    }

    public class RestaurantEditDtoValidator : AbstractValidator<RestaurantEditDto>
    {
        public RestaurantEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");

            RuleFor(m => m.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .MaximumLength(50)
                .WithMessage("Address cannot exceed 50 characters");

            RuleFor(m => m.TagIds)
                .NotEmpty()
                .WithMessage("Tag id is required");

            RuleFor(m => m.TagIds)
                .ForEach(ingredientId => ingredientId
                    .GreaterThan(0)
                    .WithMessage("Ingredient id must be greater than 0"))
                .When(m => m.TagIds is not null);


            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(200)
                .WithMessage("Description cannot exceed 200 characters");

            RuleFor(m => m.Phone)
                .NotEmpty()
                .WithMessage("Phone is required")
                .MaximumLength(50)
                .WithMessage("Phone cannot exceed 50 characters");

            RuleFor(m => m.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email format is wrong")
                .MaximumLength(50)
                .WithMessage("Phone cannot exceed 50 characters");

            RuleFor(m => m.DeliveryFee)
                .NotEmpty()
                .WithMessage("Delivery fee is required")
                .GreaterThan(0)
                .WithMessage("Delivery fee must be greater than 0"); ;

            RuleFor(m => m.IsActive)
                .NotEmpty()
                .WithMessage("Status is required");

            RuleFor(m => m.MinimumOrder)
                .NotEmpty()
                .WithMessage("Minimum order is required")
                .GreaterThan(0)
                .WithMessage("Minimum order must be greater than 0");

            RuleFor(m => m.MinDeliveryTime)
                .NotEmpty()
                .WithMessage("Minimum delivery time is required")
                .GreaterThan(0)
                .WithMessage("Minimum delivery time must be greater than 0");

            RuleFor(m => m.Rating)
                .NotEmpty()
                .WithMessage("Rating is required")
                .GreaterThan(0)
                .WithMessage("Rating must be greater than 0")
                .LessThan(6)
                .WithMessage("Rating cannot exceed 5");

            RuleFor(m => m.Images)
                .ForEach(uploadImages => uploadImages
                    .Must(item => item.ContentType.Contains("image/"))
                    .WithMessage("File must be image type")
                    .Must(item => item.Length / 1024 < 500)
                    .WithMessage("Logo size cannot exceed 500Kb"))
                .When(m => m.Images is not null);
        }
    }
}
