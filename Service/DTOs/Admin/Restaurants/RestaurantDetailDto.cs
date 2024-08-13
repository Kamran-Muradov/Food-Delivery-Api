﻿namespace Service.DTOs.Admin.Restaurants
{
    public class RestaurantDetailDto
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
        public string? Brand { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<RestaurantImageDto> RestaurantImages { get; set; }
    }
}
