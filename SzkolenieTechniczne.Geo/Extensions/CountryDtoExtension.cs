using SzkolenieTechniczne.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Extensions
{
    public static class CountryDtoExtension
    {
        public static Country ToEntity(this CountryDto dto)
        {
            return new Country
            {
                Id = dto.Id,
                Alpha3Code = dto.Alpha3Code,
                Translations =  dto.Name.Select(x => new CountryTranslation()
                {
                    Name = x.Value,
                    LanguageCode = x.Key,
                    Id = Guid.NewGuid(),
                }).ToList(),

            };
    }
    }
}
  
