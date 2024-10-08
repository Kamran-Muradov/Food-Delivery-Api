﻿using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> GetALlWithUsersAsync();
        Task<IEnumerable<Review>> GetALlByRestaurantIdAsync(int restaurantId);
    }
}
