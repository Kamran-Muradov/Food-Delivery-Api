using Service.DTOs.Admin.Settings;

namespace Service.Services.Interfaces
{
    public interface ISettingService
    {
        Task EditAsync(int? id, SettingEditDto model);
        Task<Dictionary<string, string>> GetAllDictionaryAsync();
        Task<IEnumerable<SettingDto>> GetAllAsync();
        Task<SettingDto> GetByIdAsync(int? id);
    }
}
