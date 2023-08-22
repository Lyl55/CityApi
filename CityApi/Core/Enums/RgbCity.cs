using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityApi.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RgbCity
    {
        Baku = 1,
        Istanbul = 2,
        London = 3,
        Paris = 4
    }
}
