using AutoMapper;
using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Contacts;
using Service.DTOs.UI.Contacts;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository,
                              IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ContactCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            await _contactRepository.CreateAsync(_mapper.Map<Contact>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var contact = await _contactRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _contactRepository.DeleteAsync(contact);
        }

        public async Task<PaginationResponse<ContactDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var categories = await _contactRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)categories.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<ContactDto>>(await _contactRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<ContactDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<ContactDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<ContactDetailDto>(await _contactRepository.GetByIdAsync((int)id));
        }
    }
}
