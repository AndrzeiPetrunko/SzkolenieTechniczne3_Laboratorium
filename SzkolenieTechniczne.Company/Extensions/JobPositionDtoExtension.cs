using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class JobPositionDtoExtension
    {
        public static JobPosition ToEntity(this JobPositionDto dto)
        {
            return new JobPosition
            {
                Name = dto.Name,
                WorkingHours = dto.WorkingHours,
                GrossSalary = dto.GrossSalary,
                WorkingWeekHours = dto.WorkingWeekHours
            };
        }
    }
}
