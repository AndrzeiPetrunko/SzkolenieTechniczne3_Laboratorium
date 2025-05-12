using SzkolenieTechniczne.Company.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyExtension
    {
        public static CompanyDto ToDto(this Storage.Entities.Company entity)
        {
            
            return new CompanyDto
            {
                Name = entity.Name,
                PhoneDirectional = entity.PhoneDirectional,
                PhoneNumber = entity.PhoneNumber,
                NIP = entity.NIP,
                REGON = entity.REGON,
                Address = entity.Address.ToDto(),
                JobPositions = entity.JobPositions?.Select(jp => jp.ToDto()).ToList() ?? new List<JobPositionDto>()
            };
        }
    }
}
