using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApi.Core.Dtos;
using CityApi.Core.Entities;

namespace CityApi.Services.CityService
{
    public interface ICityService
    {
        ServiceResponse<List<GetCity>> GetCities();
        ServiceResponse<GetCity> GetCity(int id);
        ServiceResponse<List<GetCity>> AddCity(AddCity city);
        ServiceResponse<GetCity> UpdateCity(UpdateCity city);
        ServiceResponse<List<GetCity>> DeleteCity(int id);

    }
}
