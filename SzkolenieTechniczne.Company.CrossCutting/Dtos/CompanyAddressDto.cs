using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class CompanyAddressDto
    {
        public Guid CountryId { get; set; }

        public string? Post { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Community { get; set; }

        public string City { get; set; }
        public string Street { get; set; }

        public string FlatNumber { get; set; }
        public string HouseNumber { get; set; }
    }

}
