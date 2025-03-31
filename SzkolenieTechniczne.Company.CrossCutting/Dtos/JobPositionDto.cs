using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    internal class JobPositionDto
    {
        public Guid CompanyId { get; set; }
        public SzkolenieTechniczne.Company.Storage.Entities.Company Company { get; set; }
        public string Name { get; set; }
        public short WorkingHours { get; set; }
        public decimal GrossSalary { get; set; }
        [Required]
        public short WorkingWeekHours { get; set; }
    }
}
