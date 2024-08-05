using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.UI.Checkouts;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IMapper _mapper;

        public CheckoutService(ICheckoutRepository checkoutRepository,
                               IMapper mapper)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CheckoutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            await _checkoutRepository.CreateAsync(_mapper.Map<Checkout>(model));
        }

        public async Task<IEnumerable<CheckoutDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CheckoutDto>>(await _checkoutRepository.GetAllWithMenusAsync());
        }
    }
}
