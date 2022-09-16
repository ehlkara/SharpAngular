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

        public CitiesController(ICityBLL cityBLL)
        {
            _cityBLL = cityBLL;
        }

        [HttpGet("get_cities")]
        public Task<List<CityForListDto>> GetCities()
        {
            var responseDto = _cityBLL.GetCities();
            return Task.FromResult(responseDto);
        }

        [HttpPost("add_city")]
        public async Task<CityDto> AddCity(CityDto cityDto)
        {
            var responseDto = await _cityBLL.AddCity(cityDto);
            return await Task.FromResult(responseDto);

        }

        [HttpGet("get_city/{id}")]
        public Task<CityForDetailDto> GetCityById(int id)
        {
            var responseDto = _cityBLL.GetCityById(id);
            return Task.FromResult(responseDto);
        }

        [HttpGet("get_photo_city/{id}")]
        public Task<List<PhotoDto>> GetPhotosByCity(int id)
        {
            var responseDto = _cityBLL.GetPhotosByCity(id);
            return Task.FromResult(responseDto);
        }

        [HttpGet("get_photo/{id}")]
        public Task<Photo> GetPhoto(int id)
        {
            var responseDto = _cityBLL.GetPhoto(id);
            return Task.FromResult(responseDto);
        }
    }
}
