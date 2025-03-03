﻿using SzkolenieTechniczne.CrossCutting.Dtos;
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
                Alpha3Code = dto.Alpha3Code
            };
        }
    }
}
