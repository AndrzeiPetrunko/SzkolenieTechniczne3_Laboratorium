﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("CountryTranslations", Schema = "Dictionaries")]
    public class CountryTranslation : BaseTranslation
    {
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }
        [MinLength(2)]
        [MaxLength(64)]
        [Required]
        public string Name { get; set; } = null!;

    }
}
