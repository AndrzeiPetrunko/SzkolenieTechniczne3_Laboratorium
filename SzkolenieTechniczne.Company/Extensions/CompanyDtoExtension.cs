using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyDtoExtension
    {
        public static Storage.Entities.Company ToEntity(this CompanyDto dto)
        {
            return new Storage.Entities.Company
            {
                Name = dto.Name,
                PhoneDirectional = dto.PhoneDirectional,
                PhoneNumber = dto.PhoneNumber,
                NIP = dto.NIP,
                REGON = dto.REGON,
                Address = dto.Address.ToEntity(),
                JobPositions = dto.JobPositions?.Select(jp => jp.ToEntity()).ToList() ?? new List<JobPosition>()
            };
        }
    }
}
