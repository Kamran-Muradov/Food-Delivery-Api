using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Restaurants;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class RestaurantImageService : IRestaurantImageService
    {
        private readonly IRestaurantImageRepository _restaurantImageRepository;
        private readonly IMapper _mapper;

        public RestaurantImageService(IRestaurantImageRepository restaurantImageRepository, 
                                      IMapper mapper)
        {
            _restaurantImageRepository = restaurantImageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantImageDto>> GetAllByRestaurantId(int? restaurantId)
        {
           ArgumentNullException.ThrowIfNull(restaurantId);

           return _mapper.Map<IEnumerable<RestaurantImageDto>>(await _restaurantImageRepository.GetAllByRestaurantIdAsync((int)restaurantId));
        }
    }
}
