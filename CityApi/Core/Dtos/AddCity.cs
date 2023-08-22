﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApi.Core.Enums;

namespace CityApi.Core.Dtos
{
    public class AddCity
    {
        public string Name { get; set; }
        public string Population { get; set; }
        public RgbCity RgbCity { get; set; }
    }
}
