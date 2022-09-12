﻿using AutoMapper;
using SharpAngular.BussinessLogic.Abstract;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Shared.SharpDTOs;

namespace SharpAngular.BussinessLogic.SharpService
{
    public class CityBLL : ICityBLL
    {
        private readonly IAppRepository _appRepository;
        private readonly ICityDAL _cityDAL;
        private readonly IMapper _mapper;

        public CityBLL(IAppRepository appRepository, IMapper mapper, ICityDAL cityDAL)
        {
            _appRepository = appRepository;
            _mapper = mapper;
            _cityDAL = cityDAL;
        }

        public async Task<CityDto> AddCity(CityDto cityDto)
        {
            var mappedCity = _mapper.Map<City>(cityDto);
            var cityResult = await _cityDAL.AddCity(mappedCity);
            return _mapper.Map<CityDto>(cityResult);
        }

        public List<CityForListDto> GetCities()
        {
            var cities = _appRepository.GetCities();
            var cityToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return cityToReturn;
        }

        public CityForDetailDto GetCityById(int cityId)
        {
            var city = _appRepository.GetCityById(cityId);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return cityToReturn;
        }

        public List<PhotoDto> GetPhotosByCity(int id)
        {
            var photo = _appRepository.GetPhotosByCity(id);
            var photoToReturn = _mapper.Map<List<PhotoDto>>(photo);
            return photoToReturn;
        }
    }
}
