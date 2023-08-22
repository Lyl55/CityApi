using CityApi.Core.Enums;

namespace CityApi.Core.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public RgbCity RgbCity { get; set; }
    }
}
