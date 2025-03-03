using System;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.CommonCrossCutting.ValidationAttributes;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.CrossCutting.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }  

        [LocalizedStringRequired]
        [LocalizedStringLength(64)]
        public LocalizedString? Name { get; set; }  

        [Required]
        public Guid CountryId { get; set; }  
        public Country? Country { get; set; }  
    }
}
