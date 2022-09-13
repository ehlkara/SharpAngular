using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using SharpAngular.BussinessLogic.Abstract;
using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Shared.Responses;
using SharpAngular.Shared.SharpDTOs;
using AutoMapper;
using SharpAngular.BussinessLogic.Abstract.IUserBLL;
using SharpAngular.DataAccess.Abstract;
using Microsoft.Extensions.Options;
using SharpAngular.Core.Helpers;

namespace SharpAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityBLL _cityBLL;
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;
        private readonly IAppRepository _appRepository;
        private readonly ILogger<CitiesController> _logger;

        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;

        private readonly Cloudinary _cloudinary;

        public CitiesController(ICityBLL cityBLL, ILogger<CitiesController> logger, IAppRepository apprepository, IMapper mapper, IUserBLL userBLL, Cloudinary cloudinary, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cityBLL = cityBLL;
            _logger = logger;
            _appRepository = apprepository;
            _mapper = mapper;
            _userBLL = userBLL;
            _cloudinary = cloudinary;

            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(_cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey, _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
            _cloudinaryConfig = cloudinaryConfig;
        }

        [HttpGet("get_cities")]
        public Response<List<CityForListDto>> GetCities()
        {
            try
            {
                var responseDto = _cityBLL.GetCities();
                return Response<List<CityForListDto>>.Success(StatusCodes.Status200OK, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Response<List<CityForListDto>>.Fail(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status404NotFound });
            }
        }

        [HttpPost("add_city")]
        public async Task<Response<CityDto>> AddCity(CityDto cityDto)
        {
            try
            {
                var responseDto = await _cityBLL.AddCity(cityDto);
                return await Response<CityDto>.SuccessAsync(StatusCodes.Status200OK,responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<CityDto>.FailAsync(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status400BadRequest });
            }
        }

        [HttpGet("get_city/{id}")]
        public Response<CityForDetailDto> GetCityById(int id)
        {
            try
            {
                var responseDto = _cityBLL.GetCityById(id);
                return Response<CityForDetailDto>.Success(StatusCodes.Status200OK, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Response<CityForDetailDto>.Fail(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status404NotFound });
            }
        }

        [HttpGet("get_photo_city/{id}")]
        public Response<List<PhotoDto>> GetPhotosByCity(int id)
        {
            try
            {
                var responseDto = _cityBLL.GetPhotosByCity(id);
                return Response<List<PhotoDto>>.Success(StatusCodes.Status200OK, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Response<List<PhotoDto>>.Fail(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status404NotFound });
            }
        }

        [HttpPost(template: "add_photo_city")]
        public IActionResult AddPhotoForCity(int cityId, [FromBody] PhotoCreationDto photoCreationDto)
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
                return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
            }

            return BadRequest("Could not add the photo");
        }

        [HttpGet("get_photo/{id}")]
        public Response<Photo> GetPhoto(int id)
        {
            try
            {
                var responseDto = _cityBLL.GetPhoto(id);
                return Response<Photo>.Success(StatusCodes.Status200OK, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Response<Photo>.Fail(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status404NotFound });
            }
        }
    }
}
