﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.CommonCrossCutting.Interfaces;

namespace SzkolenieTechniczne.Common.Storage.Entities
{
    [Index(nameof(LanguageCode), IsUnique = false)]
    public class BaseTranslation : BaseEntity, IEntityTranslation
    {
        [MaxLength(16)]
        [Required]
        public string LanguageCode { get; set; } = null!;
    }
}
