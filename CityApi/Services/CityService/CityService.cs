using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityApi.Core.Dtos;
using CityApi.Core.Entities;
using CityApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CityService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ServiceResponse<List<GetCity>> GetCities()
        {
            var response = new ServiceResponse<List<GetCity>>();
            var dbCities = _context.CityEntities.ToList();
            response.Data = dbCities.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return response;
        }

        public ServiceResponse<GetCity> GetCity(int id)
        {
            var response = new ServiceResponse<GetCity>();
            var dbCities = _context.CityEntities.FirstOrDefault(x=>x.Id==id);
            response.Data =  _mapper.Map<GetCity>(dbCities);
            return response;
        }

        public ServiceResponse<List<GetCity>> AddCity(AddCity city)
        {
            var response = new ServiceResponse<List<GetCity>>();
            var newCity=_mapper.Map<CityEntity>(city);
            _context.CityEntities.Add(newCity);
            _context.SaveChanges();
            response.Data = _context.CityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return response;
        }

        public ServiceResponse<GetCity> UpdateCity(UpdateCity updatedCity)
        {
            var response = new ServiceResponse<GetCity>();
            var city = _context.CityEntities.FirstOrDefault(x => x.Id == updatedCity.Id);
            city.Name = updatedCity.Name;
            city.Population = updatedCity.Population;
            city.RgbCity = updatedCity.RgbCity;
            _context.SaveChanges();
            response.Data = _mapper.Map<GetCity>(city);
            return response;
        }

        public ServiceResponse<List<GetCity>> DeleteCity(int id)
        {
            var response = new ServiceResponse<List<GetCity>>();
            var city = _context.CityEntities.First(x => x.Id == id);
            _context.CityEntities.Remove(city);
            _context.SaveChanges();
            response.Data = _context.CityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return response;
        }
    }
}
