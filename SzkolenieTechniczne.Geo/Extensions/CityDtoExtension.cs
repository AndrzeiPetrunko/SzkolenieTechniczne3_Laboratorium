﻿using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Extensions
{
    public static class CityDtoExtension
    {
        public static City ToEntity(this CityDto dto)
        {
            return new City
            {
                CountryId = dto.CountryId,
                Id = dto.Id,
            };
        }
    }
}
