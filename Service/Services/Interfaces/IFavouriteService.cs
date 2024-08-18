using Domain.Entities;
using Service.DTOs.UI.Favourites;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface IFavouriteService
    {
        Task CreateAsync(FavouriteCreateDto model);
        Task DeleteAsync(string userId, int? restaurantId);
        Task<IEnumerable<FavouriteDto>> GetAllByUserIdAsync(string userId);
        Task<FavouriteDto> GetFirstWithExpressionAsync(Expression<Func<Favourite, bool>> predicate);
    }
}
