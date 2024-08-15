using Service.DTOs.Admin.Contacts;
using Service.DTOs.UI.Contacts;
using Service.Helpers;

namespace Service.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreateDto model);
        Task DeleteAsync(int? id);
        Task<PaginationResponse<ContactDto>> GetPaginateAsync(int? page, int? take);
        Task<ContactDetailDto> GetByIdAsync(int? id);
    }
}
