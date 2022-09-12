using SharpAngular.Models.Entities.SharpAngular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAngular.DataAccess.Abstract
{
    public interface ICityDAL
    {
        Task<City> AddCity(City city);
    }
}
