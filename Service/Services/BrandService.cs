using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Brands;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandLogoRepository _brandLogoRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository,
                            IBrandLogoRepository brandLogoRepository,
                            IPhotoService photoService,
                            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _brandLogoRepository = brandLogoRepository;
            _photoService = photoService;
            _mapper = mapper;
        }

        public async Task CreateAsync(BrandCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!await _brandRepository.ExistAsync(model.Name))
            {
                Brand brand = _mapper.Map<Brand>(model);

                ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Logo);

                BrandLogo brandLogo = new()
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    BrandId = brand.Id
                };

                brand.BrandLogo = brandLogo;

                await _brandRepository.CreateAsync(brand);
            }
        }

        public async Task EditAsync(int? id, BrandEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(model);

            var brand = await _brandRepository.GetByIdWithLogoAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (!await _brandRepository.ExistAsync(model.Name, id))
            {
                if (model.Logo is not null)
                {
                    await _photoService.DeletePhoto(brand.BrandLogo.PublicId);
                    await _brandLogoRepository.DeleteAsync(brand.BrandLogo);

                    ImageUploadResult uploadResult = await _photoService.AddPhoto(model.Logo);

                    BrandLogo brandLogo = new()
                    {
                        Url = uploadResult.SecureUrl.ToString(),
                        PublicId = uploadResult.PublicId,
                        BrandId = brand.Id
                    };

                    brand.BrandLogo = brandLogo;
                }

                brand.UpdatedDate = DateTime.Now;
                await _brandRepository.EditAsync(_mapper.Map(model, brand));
            }
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var brand = await _brandRepository.GetByIdWithLogoAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            await _photoService.DeletePhoto(brand.BrandLogo.PublicId);

            await _brandRepository.DeleteAsync(brand);
        }

        public async Task<IEnumerable<DTOs.UI.Brands.BrandDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DTOs.UI.Brands.BrandDto>>(await _brandRepository.GetAllWithLogoAsync());
        }

        public async Task<IEnumerable<BrandSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var categories = await _brandRepository.GetAllWithExpressionAsync(r => r.Restaurants.All(m => m.Id != excludeId));
            return _mapper.Map<IEnumerable<BrandSelectDto>>(categories.OrderBy(m => m.Name));
        }

        public async Task<PaginationResponse<BrandDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var brands = await _brandRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)brands.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<BrandDto>>(await _brandRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<BrandDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<BrandDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _mapper.Map<BrandDto>(await _brandRepository.GetByIdWithLogoAsync((int)id));
        }

        public async Task<bool> ExistAsync(string name, int? excludeId = null)
        {
            ArgumentNullException.ThrowIfNull(name);
            return await _brandRepository.ExistAsync(name, excludeId);
        }
    }
}
