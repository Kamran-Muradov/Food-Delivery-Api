using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.Reviews;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public ReviewService(IReviewRepository reviewRepository,
                             IMapper mapper,
                             ICheckoutRepository checkoutRepository, 
                             IRestaurantRepository restaurantRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _checkoutRepository = checkoutRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task CreateAsync(ReviewCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var checkout = await _checkoutRepository.GetByIdWithAllDatasAsync(model.CheckoutId) ??
                           throw new NotFoundException(ResponseMessages.NotFound);

            await _reviewRepository.CreateAsync(_mapper.Map<Review>(model));

            var restaurant = checkout.Restaurant;

            var reviewCount = _reviewRepository
                .GetAllWithExpressionAsync(r => r.Checkout.RestaurantId == restaurant.Id)
                .Result
                .Count();

            restaurant.AverageRating = (restaurant.AverageRating * (reviewCount - 1) + model.Rating) / reviewCount;
            await _restaurantRepository.EditAsync(restaurant);
        }
    }
}
