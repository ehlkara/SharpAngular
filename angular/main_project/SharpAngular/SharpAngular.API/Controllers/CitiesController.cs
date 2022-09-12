using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpAngular.BussinessLogic.Abstract;
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

        public CitiesController(ICityBLL cityBLL, ILogger<CitiesController> logger)
        {
            _cityBLL = cityBLL;
            _logger = logger;
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

        [HttpGet("get_photo/{id}")]
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
    }
}
