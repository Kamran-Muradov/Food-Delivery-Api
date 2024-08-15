using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Settings;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository settingRepository,
                              IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task EditAsync(int? id, SettingEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var setting = await _settingRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _settingRepository.EditAsync(_mapper.Map(model, setting));
        }

        public async Task<Dictionary<string, string>> GetAllDictionaryAsync()
        {
            var settings = await _settingRepository.GetAllAsync();
            return settings.ToDictionary(s => s.Key, s => s.Value);
        }

        public async Task<IEnumerable<SettingDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SettingDto>>(await _settingRepository.GetAllAsync());
        }

        public async Task<SettingDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<SettingDto>(await _settingRepository.GetByIdAsync((int)id));
        }
    }
}
