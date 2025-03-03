using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.CommonCrossCutting.ValidationAttributes;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using System.ComponentModel.DataAnnotations;


namespace SzkolenieTechniczne.CrossCutting.Dtos
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        [LocalizedStringRequiredAttribute]
        [LocalizedStringLengthAttribute(32)]
        public LocalizedString? Name { get; set; }
        [MaxLength(3)]
        [MinLength(2)]
        [Required]
        public string? Aplha3Code { get; set; }
    }
}
