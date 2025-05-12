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
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }

        public CompanyAddressDto Address { get; set; }

        public ICollection<JobPositionDto> JobPositions { get; set; } = new List<JobPositionDto>();
    }

}
