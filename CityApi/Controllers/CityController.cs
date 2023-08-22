using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApi.Core.Dtos;
using CityApi.Core.Entities;
using CityApi.Services;
using CityApi.Services.CityService;

namespace CityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<CityEntity>>> Get()
        {
            return Ok(_cityService.GetCities());
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<CityEntity>> Get(int id)
        {
            return Ok(_cityService.GetCity(id));
        }

        [HttpPost]
        public ActionResult<ServiceResponse<List<CityEntity>>> AddCity(AddCity city)
        {
            return Ok(_cityService.AddCity(city));
        }

        [HttpPut]
        public ActionResult<ServiceResponse<CityEntity>> UpdateCity(UpdateCity city)
        {
            return Ok(_cityService.UpdateCity(city));
        }
        [HttpDelete]
        public ActionResult<ServiceResponse<List<CityEntity>>> DeleteCity(int id)
        {
            return Ok(_cityService.DeleteCity(id));
        }
    }
}
