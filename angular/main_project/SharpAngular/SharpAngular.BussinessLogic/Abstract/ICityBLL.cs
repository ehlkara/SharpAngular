using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Shared.SharpDTOs;

namespace SharpAngular.BussinessLogic.Abstract
{
    public interface ICityBLL
    {
        List<CityForListDto> GetCities();

        CityForDetailDto GetCityById(int cityId);

        Task<CityDto> AddCity(CityDto cityDto);

        List<PhotoDto> GetPhotosByCity(int id);

        Photo GetPhoto(int id);
    }
}
