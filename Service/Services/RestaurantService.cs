using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Restaurants;
using Service.DTOs.UI.Restaurants;
using Service.DTOs.UI.Reviews;
using Service.Helpers;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using RestaurantDetailDto = Service.DTOs.Admin.Restaurants.RestaurantDetailDto;
using RestaurantDto = Service.DTOs.Admin.Restaurants.RestaurantDto;

namespace Service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IRestaurantImageRepository _restaurantImageRepository;
        private readonly IRestaurantTagRepository _restaurantTagRepository;
        private readonly IReviewRepository _reviewRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository,
                                 IMapper mapper,
                                 IPhotoService photoService,
                                 IRestaurantImageRepository restaurantImageRepository,
                                 IRestaurantTagRepository restaurantTagRepository,
                                 IReviewRepository reviewRepository)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
            _photoService = photoService;
            _restaurantImageRepository = restaurantImageRepository;
            _restaurantTagRepository = restaurantTagRepository;
            _reviewRepository = reviewRepository;
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

            List<RestaurantTag> restaurantTags = model.TagIds.Select(tagId => new RestaurantTag
            {
                RestaurantId = restaurant.Id,
                TagId = tagId
            }).ToList();

            restaurant.RestaurantTags = restaurantTags;

            await _restaurantRepository.CreateAsync(restaurant);
        }

        public async Task EditAsync(int? id, RestaurantEditDto model)
        {
            ArgumentNullException.ThrowIfNull(id);

            ArgumentNullException.ThrowIfNull(model);

            var restaurant = await _restaurantRepository.GetByIdWithImagesAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            var removedTags = restaurant.RestaurantTags
                .Where(rt => !model.TagIds.Contains(rt.TagId));

            foreach (var restaurantTag in removedTags)
            {
                await _restaurantTagRepository.DeleteAsync(restaurantTag);
            }

            foreach (var tagId in model.TagIds.Where(tagId => restaurant.RestaurantTags.All(m => m.TagId != tagId)))
            {
                await _restaurantTagRepository.CreateAsync(new RestaurantTag
                {
                    RestaurantId = (int)id,
                    TagId = tagId
                });
            }

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

                await _restaurantImageRepository.CreateRangeAsync(images);
            }

            restaurant.UpdatedDate = DateTime.Now;
            await _restaurantRepository.EditAsync(_mapper.Map(model, restaurant));
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var allRestaurants = await _restaurantRepository.GetAllAsync();

            if (allRestaurants.Count() <= 12)
            {
                throw new BadRequestException("Restaurant count cannot be less tha 12");
            }

            var restaurant = await _restaurantRepository.GetByIdWithImagesAsync((int)id) ?? throw new NotFoundException(ResponseMessages.NotFound);

            List<string> publicIds = restaurant.RestaurantImages.Select(m => m.PublicId).ToList();
            await _restaurantRepository.DeleteAsync(restaurant);

            foreach (var publicId in publicIds)
            {
                await _photoService.DeletePhoto(publicId);
            }
        }

        public async Task<PaginationResponse<RestaurantDto>> GetPaginateAsync(int? page, int? take, string? searchText)
        {
            ArgumentNullException.ThrowIfNull(page);
            ArgumentNullException.ThrowIfNull(take);

            IEnumerable<Restaurant> restaurants;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                restaurants = await _restaurantRepository.GetAllAsync();
            }
            else
            {
                restaurants = await _restaurantRepository.GetAllWithExpressionAsync(m => m.Name.Contains(searchText));
            }

            int totalPage = (int)Math.Ceiling((decimal)restaurants.Count() / (int)take);

            var mappedDatas = _mapper.Map<IEnumerable<RestaurantDto>>(await _restaurantRepository.GetPaginateDatasAsync((int)page, (int)take, searchText));

            return new PaginationResponse<RestaurantDto>(mappedDatas, totalPage, (int)page);
        }

        public async Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllWithImagesAsync()
        {
            var restaurants =
                _mapper.Map<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>>(await _restaurantRepository.GetAllWithImagesAsync()).ToList();

            foreach (var restaurant in restaurants)
            {
                restaurant.ReviewCount = _reviewRepository
                    .GetAllWithExpressionAsync(r => r.Checkout.RestaurantId == restaurant.Id)
                    .Result
                    .Count();
            }

            return restaurants;
        }

        public async Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllByTagIdAsync(int? tagId)
        {
            ArgumentNullException.ThrowIfNull(tagId);

            var restaurants =
                _mapper.Map<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>>(await _restaurantRepository.GetAllByTagIdAsync((int)tagId)).ToList();

            foreach (var restaurant in restaurants)
            {
                restaurant.ReviewCount = _reviewRepository
                    .GetAllWithExpressionAsync(r => r.Checkout.RestaurantId == restaurant.Id)
                    .Result
                    .Count();
            }

            return restaurants;
        }

        public async Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> GetAllByBrandIdAsync(int brandId)
        {
            ArgumentNullException.ThrowIfNull(brandId);

            var restaurants =
                _mapper.Map<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>>(await _restaurantRepository.GetAllByBrandIdAsync(brandId)).ToList();

            foreach (var restaurant in restaurants)
            {
                restaurant.ReviewCount = _reviewRepository
                    .GetAllWithExpressionAsync(r => r.Checkout.RestaurantId == restaurant.Id)
                    .Result
                    .Count();
            }

            return restaurants;
        }

        public async Task<PaginationResponse<DTOs.UI.Restaurants.RestaurantDto>> GetAllFilteredAsync(RestaurantFilterDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            List<Restaurant> restaurants;

            if (model.TagIds is not null && model.TagIds.Any())
            {
                restaurants = (List<Restaurant>)await _restaurantRepository
                    .GetAllWithExpressionAsync(m => m.RestaurantTags.Any(rc => model.TagIds.Contains(rc.TagId)));
            }
            else
            {
                restaurants = (List<Restaurant>)await _restaurantRepository.GetAllAsync();
            }

            int totalPage = (int)Math.Ceiling((decimal)restaurants.Count / model.Take);

            var mappedDatas = _mapper.Map<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>>(
                await _restaurantRepository.GetAllFilteredAsync(model.Page, model.Take, model.Sorting, model.TagIds));

            foreach (var restaurant in mappedDatas)
            {
                restaurant.ReviewCount = _reviewRepository
                    .GetAllWithExpressionAsync(r => r.Checkout.RestaurantId == restaurant.Id)
                    .Result
                    .Count();
            }

            var test=new PaginationResponse<DTOs.UI.Restaurants.RestaurantDto>(mappedDatas, totalPage, model.Page);

            return new PaginationResponse<DTOs.UI.Restaurants.RestaurantDto>(mappedDatas, totalPage, model.Page);
        }

        public async Task<IEnumerable<RestaurantSelectDto>> GetAllForSelectAsync(int? excludeId = null)
        {
            var restaurants = await _restaurantRepository.GetAllWithExpressionAsync(r => r.Menus.All(m => m.Id != excludeId));

            return _mapper.Map<IEnumerable<RestaurantSelectDto>>(restaurants.OrderBy(m => m.Name));
        }

        public async Task<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>> SearchByNameAndCategory(string searchText)
        {
            ArgumentNullException.ThrowIfNull(searchText);

            var restaurants =
                _mapper.Map<IEnumerable<DTOs.UI.Restaurants.RestaurantDto>>(await _restaurantRepository.SearchByNameAndCategory(searchText)).ToList();

            foreach (var restaurant in restaurants)
            {
                restaurant.ReviewCount = _reviewRepository
                    .GetAllWithExpressionAsync(r => r.Checkout.RestaurantId == restaurant.Id)
                    .Result
                    .Count();
            }

            return restaurants;
        }

        public async Task<RestaurantDetailDto> GetByIdDetailAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            return _mapper.Map<RestaurantDetailDto>(await _restaurantRepository.GetByIdWithAllDatasAsync((int)id));
        }

        public async Task<DTOs.UI.Restaurants.RestaurantDetailDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            var restaurant = _mapper.Map<DTOs.UI.Restaurants.RestaurantDetailDto>(await _restaurantRepository.GetByIdWithAllDatasAsync((int)id));
            if (restaurant is null) throw new NotFoundException(ResponseMessages.NotFound);

            var restaurantReviews = _mapper.Map<IEnumerable<ReviewDto>>(await _reviewRepository.GetALlByRestaurantIdAsync((int)id));

            restaurant.Reviews = restaurantReviews;

            return restaurant;
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
