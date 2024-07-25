using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Restaurants;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IRestaurantImageRepository _restaurantImageRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository,
                                 IMapper mapper,
                                 IPhotoService photoService,
                                 IRestaurantImageRepository restaurantImageRepository)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
            _photoService = photoService;
            _restaurantImageRepository = restaurantImageRepository;
        }

        public async Task CreateAsync(RestaurantCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            Restaurant restaurant = _mapper.Map<Restaurant>(model);

            List<RestaurantImage> images = new();

            foreach (var image in model.Images)
            {
                ImageUploadResult uploadResult = await _photoService.AddPhoto(image);

                images.Add(new RestaurantImage
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl.ToString(),
                    RestaurantId = restaurant.Id
                });
            }

            restaurant.RestaurantImages = images;
            restaurant.RestaurantImages.FirstOrDefault().IsMain = true;

            await _restaurantRepository.CreateAsync(restaurant);
        }

        public async Task EditAsync(int? id, RestaurantEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var restaurant = await _restaurantRepository.GetByIdAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            if (model.Images is not null)
            {
                List<RestaurantImage> images = new();
                foreach (var image in model.Images)
                {
                    ImageUploadResult uploadResult = await _photoService.AddPhoto(image);

                    images.Add(new RestaurantImage
                    {
                        PublicId = uploadResult.PublicId,
                        Url = uploadResult.SecureUrl.ToString(),
                        RestaurantId = restaurant.Id
                    });
                }
                restaurant.RestaurantImages = images;
            }

            restaurant.UpdatedDate = DateTime.Now;
            await _restaurantRepository.EditAsync(_mapper.Map(model, restaurant));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var restaurant = await _restaurantRepository.GetByIdWithImagesAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            List<string> publicIds = restaurant.RestaurantImages.Select(m => m.PublicId).ToList();
            await _restaurantRepository.DeleteAsync(restaurant);

            foreach (var publicId in publicIds)
            {
                await _photoService.DeletePhoto(publicId);
            }
        }

        public async Task<PaginationResponse<RestaurantDto>> GetPaginateAsync(int? page, int? take)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            var restaurants = await _restaurantRepository.GetAllAsync();
            int totalPage = (int)Math.Ceiling((decimal)restaurants.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<RestaurantDto>>(await _restaurantRepository.GetPaginateDatasAsync((int)page, (int)take));

            return new PaginationResponse<RestaurantDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllWithMainImageAsync()
        {
            return _mapper.Map<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>>(await _restaurantRepository.GetAllWithImagesAsync());
        }

        public async Task<RestaurantDetailDto> GetByIdDetailAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<RestaurantDetailDto>(await _restaurantRepository.GetByIdWithAllDatasAsync((int)id));
        }

        public async Task SetMainImageAsync(MainAndDeleteImageDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var restaurant = await _restaurantRepository.GetByIdWithImagesAsync(model.RestaurantId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var restaurantImage = restaurant.RestaurantImages.FirstOrDefault(m => m.Id == model.ImageId);

            if (restaurantImage is null)
            {
                throw new NotFoundException("Image not found");
            }

            var mainImage = restaurant.RestaurantImages.FirstOrDefault(m => m.IsMain);
            mainImage.IsMain = false;
            mainImage.UpdatedDate = DateTime.Now;

            restaurantImage.IsMain = true;
            restaurantImage.UpdatedDate = DateTime.Now;

            await _restaurantRepository.EditAsync(restaurant);
        }

        public async Task DeleteImageAsync(MainAndDeleteImageDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var restaurant = await _restaurantRepository.GetByIdWithImagesAsync(model.RestaurantId) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var restaurantImage = restaurant.RestaurantImages.FirstOrDefault(m => m.Id == model.ImageId) ?? throw new NotFoundException("Image not found");

            if (restaurantImage.IsMain) throw new BadRequestException("Main image cannot be deleted");

            await _photoService.DeletePhoto(restaurantImage.PublicId);
            await _restaurantImageRepository.DeleteAsync(restaurantImage);
        }
    }
}
