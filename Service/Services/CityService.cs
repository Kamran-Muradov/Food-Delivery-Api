using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Cities;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CityService(ICityRepository cityRepository,
                           IMapper mapper,
                           ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task CreateAsync(CityCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var country = await _countryRepository.GetByIdAsync(model.CountryId);

            if (country is null) throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _cityRepository.ExistAsync(model.Name))
            {
                await _cityRepository.CreateAsync(_mapper.Map<City>(model));
            }
        }

        public async Task EditAsync(int? id, CityEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var city = await _cityRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var country = await _countryRepository.GetByIdAsync(model.CountryId);

            if (country is null) throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _cityRepository.ExistAsync(model.Name, id))
            {
                city.UpdatedDate = DateTime.Now;
                await _cityRepository.EditAsync(_mapper.Map(model, city));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var city = await _cityRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _cityRepository.DeleteAsync(city);
        }

        public async Task<IEnumerable<CitySelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var cities = await _cityRepository.GetAllWithExpressionAsync(r => r.Restaurants.All(m => m.Id != excludeId));

            return _mapper.Map<IEnumerable<CitySelectDto>>(cities.OrderBy(m => m.Name));
        }

        public async Task<PaginationResponse<CityDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var cities = await _cityRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)cities.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<CityDto>>(await _cityRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<CityDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<CityDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var city = await _cityRepository.GetByIdWithCountryAsync((int)id) ??
                                       throw new NotFoundException(ResponseMessages.NotFound);

            return _mapper.Map<CityDto>(city);
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);
            return await _cityRepository.ExistAsync(name, excludeId);
        }
    }
}
