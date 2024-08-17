using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, 
                              IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!await _countryRepository.ExistAsync(model.Name))
            {
                await _countryRepository.CreateAsync(_mapper.Map<Country>(model));
            }
        }

        public async Task EditAsync(int? id, CountryEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var country = await _countryRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _countryRepository.ExistAsync(model.Name, id))
            {
                country.UpdatedDate = DateTime.Now;
                await _countryRepository.EditAsync(_mapper.Map(model, country));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var country = await _countryRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _countryRepository.DeleteAsync(country);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepository.GetAllAsync());
        }

        public async Task<IEnumerable<CountrySelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var countries = await _countryRepository.GetAllWithExpressionAsync(r => r.Cities.All(m => m.Id != excludeId));

            return _mapper.Map<IEnumerable<CountrySelectDto>>(countries.OrderBy(m => m.Name));
        }

        public async Task<PaginationResponse<CountryDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var countries = await _countryRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)countries.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<CountryDto>>(await _countryRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<CountryDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<CountryDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<CountryDto>(await _countryRepository.GetByIdAsync((int)id));
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);
            return await _countryRepository.ExistAsync(name, excludeId);
        }
    }
}
