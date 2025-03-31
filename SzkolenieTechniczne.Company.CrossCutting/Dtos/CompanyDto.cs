using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string PhoneDirectional { get; set; }
        public CompanyAddress Address { get; set; }

        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }

        public ICollection<JobPosition> JobPositions { get; set; } = new HashSet<JobPosition>();
    }
}
