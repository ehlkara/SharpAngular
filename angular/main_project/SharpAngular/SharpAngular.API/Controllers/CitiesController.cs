using Microsoft.AspNetCore.Mvc;
using SharpAngular.BussinessLogic.Abstract;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Shared.Responses;
using SharpAngular.Shared.SharpDTOs;

namespace SharpAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityBLL _cityBLL;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ICityBLL cityBLL, ILogger<CitiesController> logger, IAppRepository apprepository)
        {
            _cityBLL = cityBLL;
            _logger = logger;
        }

        [HttpGet("get_cities")]
        public Task<List<CityForListDto>> GetCities()
        {
            var responseDto = _cityBLL.GetCities();
            return Task.FromResult(responseDto);
        }

        [HttpPost("add_city")]
        public async Task<Response<CityDto>> AddCity(CityDto cityDto)
        {
            try
            {
                var responseDto = await _cityBLL.AddCity(cityDto);
                return await Response<CityDto>.SuccessAsync(StatusCodes.Status200OK, responseDto);
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
