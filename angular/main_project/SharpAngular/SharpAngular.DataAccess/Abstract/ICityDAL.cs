using SharpAngular.Models.Entities.SharpAngular;

namespace SharpAngular.DataAccess.Abstract
{
    public interface ICityDAL
    {
        Task<City> AddCity(City city);
        Task<Photo> AddPhotoForCity(Photo photo);
    }
}
