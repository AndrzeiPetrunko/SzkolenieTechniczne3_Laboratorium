using SzkolenieTechniczne.Company.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyDtoExtension
    {
        public static SzkolenieTechniczne.Company.Storage.Entities.Company ToEntity(this CompanyDto dto)
        {
            return new SzkolenieTechniczne.Company.Storage.Entities.Company
            {
                Address = dto.Address,
                Name = dto.Name,
                JobPositions = dto.JobPositions,
                NIP = dto.NIP,
                PhoneDirectional = dto.PhoneDirectional,
                PhoneNumber = dto.PhoneNumber,
                REGON = dto.REGON,
            };
        }
    }
}
