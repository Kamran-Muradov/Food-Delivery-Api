﻿using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class RestaurantImageRepository : BaseRepository<RestaurantImage>, IRestaurantImageRepository
    {
        public RestaurantImageRepository(AppDbContext context) : base(context) { }
    }
}
