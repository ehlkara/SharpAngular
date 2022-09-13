using SharpAngular.Core.Context;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Models.Entities.SharpAngular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAngular.DataAccess.Concrete
{
    public class CityDAL : ICityDAL
    {
        private readonly SharpAngularDbContext _context;

        public CityDAL(SharpAngularDbContext context)
        {
            _context = context;
        }

        public async Task<City> AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<Photo> AddPhotoForCity(Photo photo)
        {
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
            return photo;
        }
    }
}
