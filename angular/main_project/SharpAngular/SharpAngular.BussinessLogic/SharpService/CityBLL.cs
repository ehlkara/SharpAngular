using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SharpAngular.BussinessLogic.Abstract;
using SharpAngular.BussinessLogic.Abstract.IUserBLL;
using SharpAngular.Core.Helpers;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Shared.SharpDTOs;

namespace SharpAngular.BussinessLogic.SharpService
{
    public class CityBLL : ICityBLL
    {
        private readonly IAppRepository _appRepository;
        private readonly ICityDAL _cityDAL;
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;

        private readonly Cloudinary _cloudinary;

        public CityBLL(IAppRepository appRepository, IMapper mapper, ICityDAL cityDAL, IOptions<CloudinarySettings> cloudinaryConfig, IUserBLL userBLL)
        {
            _appRepository = appRepository;
            _mapper = mapper;
            _cityDAL = cityDAL;
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(_cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey, _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
            _userBLL = userBLL;
        }

        public async Task<CityDto> AddCity(CityDto cityDto)
        {
            var mappedCity = _mapper.Map<City>(cityDto);
            var cityResult = await _cityDAL.AddCity(mappedCity);
            return _mapper.Map<CityDto>(cityResult);
        }

        public Task<Photo> AddPhotoForCity(int cityId, PhotoCreationDto photoCreationDto)
        {
            var city = _appRepository.GetCityById(cityId);

            if (city == null)
            {
                throw new NotImplementedException();
            }

            int currentUserId = int.Parse(_userBLL.GetUserById(city.UserId).ToString());

            if (currentUserId != city.UserId)
            {
                throw new NotImplementedException();
            }

            var file = photoCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoCreationDto.Url = uploadResult.Uri.ToString();
            photoCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoCreationDto);
            photo.City = city;

            if (!city.Photos.Any(p => p.IsMain))
            {
                photo.IsMain = true;
            }
            city.Photos.Add(photo);
            if (_appRepository.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
            }
            return null;
        }

        public List<CityForListDto> GetCities()
        {
            var cities = _appRepository.GetCities();
            var cityToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return cityToReturn;
        }

        public CityForDetailDto GetCityById(int cityId)
        {
            var city = _appRepository.GetCityById(cityId);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return cityToReturn;
        }

        public Photo GetPhoto(int id)
        {
            var photoFromDb = _appRepository.GetPhoto(id);
            var photo = _mapper.Map<Photo>(photoFromDb);
            return photo;
        }

        public List<PhotoDto> GetPhotosByCity(int id)
        {
            var photo = _appRepository.GetPhotosByCity(id);
            var photoToReturn = _mapper.Map<List<PhotoDto>>(photo);
            return photoToReturn;
        }
    }
}
