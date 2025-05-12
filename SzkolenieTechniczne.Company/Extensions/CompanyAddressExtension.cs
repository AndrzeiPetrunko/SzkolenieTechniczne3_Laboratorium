using Microsoft.Extensions.Hosting;
using System.IO;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.Company.CrossCutting;
namespace SzkolenieTechniczne.Company.Extensions
{
     public static class CompanyAddressExtension
    {
        public static CompanyAddress ToEntity(this Company.CrossCutting.Dtos.CompanyAddressDto dto)
        {
            return new CompanyAddress
            {
                CountryId = dto.CountryId,
                Post = dto.Post,
                Province = dto.Province,
                District = dto.District,
                Community = dto.Community,
                City = dto.City,
                Street = dto.Street,
                FlatNumber = dto.FlatNumber,
                HouseNumber = dto.HouseNumber
            };
        }
    }
}
