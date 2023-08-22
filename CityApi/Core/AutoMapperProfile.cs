using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityApi.Core.Dtos;
using CityApi.Core.Entities;

namespace CityApi.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CityEntity, GetCity>();
            CreateMap<AddCity, CityEntity>();
            CreateMap<GetCity,CityEntity>();
            CreateMap<UpdateCity, CityEntity>();
            CreateMap<CityEntity, UpdateCity>();
        }
    }
}
