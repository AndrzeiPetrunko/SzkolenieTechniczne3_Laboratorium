﻿using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Extensions
{
    public static class CountryExtension
    {
        public static CountryDto ToDto(this Country entity)
        {
            var result = new CountryDto
            {
                Id = entity.Id,
                Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                Alpha3Code = entity.Alpha3Code
            };
            return result;
        }
    }
}
