using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class JobPositionDto
    {
        public string Name { get; set; }

        public short? WorkingHours { get; set; }

        public decimal GrossSalary { get; set; }

        public short WorkingWeekHours { get; set; }
    }

}
