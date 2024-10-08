﻿using Service.DTOs.Admin.Checkouts;
using Service.DTOs.UI.Checkouts;
using Service.Helpers;
using CheckoutDto = Service.DTOs.UI.Checkouts.CheckoutDto;

namespace Service.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task CreateAsync(CheckoutCreateDto model);
        Task EditAsync(int? id, CheckoutEditDto model);
        Task<IEnumerable<CheckoutDto>> GetAllByUserIdAsync(string userId);
        Task<CheckoutDetailDto> GetByIdAsync(int? id);
        Task<PaginationResponse<DTOs.Admin.Checkouts.CheckoutDto>> GetPaginateAsync(int? page, int? take);

    }
}
