using SharpAngular.Models.Entities.SharpAngular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAngular.DataAccess.Abstract
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();

        List<City> GetCities();
        List<Photo> GetPhotosByCity(int id);
        City GetCityById(int cityId);
        Photo GetPhoto(int id);
    }
}
