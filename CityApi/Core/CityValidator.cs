using CityApi.Core.Entities;
using FluentValidation;

namespace CityApi.Core
{
    public class CityValidator : AbstractValidator<CityEntity>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().MaximumLength(5);
            RuleFor(c => c.Population).NotNull().NotEmpty();
            RuleFor(c => c.RgbCity).NotNull().NotEmpty();
        }
    }
}
