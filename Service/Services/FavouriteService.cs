using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.Favourites;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public FavouriteService(IFavouriteRepository favouriteRepository,
                                IRestaurantRepository restaurantRepository,
                                UserManager<AppUser> userManager,
                                IMapper mapper)
        {
            _favouriteRepository = favouriteRepository;
            _restaurantRepository = restaurantRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(FavouriteCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var restaurant = await _restaurantRepository.GetByIdAsync(model.RestaurantId);
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || restaurant is null) throw new NotFoundException(ResponseMessages.NotFound);

            var existFavourite = await _favouriteRepository.GetFirstWithExpressionAsync(f => f.UserId == model.UserId && f.RestaurantId == model.RestaurantId);
            if (existFavourite is null) await _favouriteRepository.CreateAsync(_mapper.Map<Favourite>(model));
        }

        public async Task DeleteAsync(string userId, int? restaurantId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(restaurantId);

            var existFavourite = await _favouriteRepository.GetFirstWithExpressionAsync(f => f.UserId == userId && f.RestaurantId == restaurantId);
            if (existFavourite is not null) await _favouriteRepository.DeleteAsync(existFavourite);
        }

        public async Task<IEnumerable<FavouriteDto>> GetAllByUserIdAsync(string userId)
        {
            return _mapper.Map<IEnumerable<FavouriteDto>>(await _favouriteRepository.GetAllByUserIdAsync(userId));
        }

        public async Task<FavouriteDto> GetFirstWithExpressionAsync(Expression<Func<Favourite, bool>> predicate)
        {
            return _mapper.Map<FavouriteDto>(await _favouriteRepository.GetFirstWithExpressionAsync(predicate));
        }
    }
}
