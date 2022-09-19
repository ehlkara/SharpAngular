using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharpAngular.BussinessLogic.Abstract.IUserBLL;
using SharpAngular.Core.Helpers;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Shared.SharpDTOs;

namespace SharpAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;
        private readonly IAppRepository _appRepository;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly Cloudinary _cloudinary;

        public PhotosController(IUserBLL userBLL, IMapper mapper, IAppRepository appRepository, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _userBLL = userBLL;
            _mapper = mapper;
            _appRepository = appRepository;
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(_cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey, _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
            _cloudinaryConfig = cloudinaryConfig;
        }

        [HttpPost(template: "add_photo_city")]
        public IActionResult AddPhotoForCity(int cityId, [FromBody] PhotoCreationDto photoCreationDto)
        {
            var city = _appRepository.GetCityById(cityId);

            if (city == null)
            {
                return BadRequest("Could not find the city");
            }

            int currentUserId = int.Parse(_userBLL.GetUserById(city.UserId).ToString());

            if (currentUserId != city.UserId)
            {
                return Unauthorized();
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
                return CreatedAtRoute("get_photo", new { id = photo.Id }, photoToReturn);
            }

            return BadRequest("Could not add the photo");
        }
    }
}
