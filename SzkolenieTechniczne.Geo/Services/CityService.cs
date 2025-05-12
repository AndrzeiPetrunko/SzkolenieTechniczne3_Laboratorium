using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Geo.Extensions;
using SzkolenieTechniczne.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Api.Common.Service;

namespace SzkolenieTechniczne.Geo.Services
{
    public class CityService : CrudServiceBase<GeoDbContext, City, CityDto>
    {
        private readonly GeoDbContext _geoDbContext;

        public CityService(GeoDbContext geoDbContext) : base(geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CityDto> GetById(Guid id)
        {
            var city = await base.GetById(id);

            return city.ToDto();
        }

        public async Task<IEnumerable<CityDto>> Get()
        {
            var cities = await base.Get();

            return cities.Select(e => e.ToDto());
        }


        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);

            await _geoDbContext.SaveChangesAsync();

            var newDto = await GetById(entityId);

            return new CrudOperationResult<CityDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
            
        }
        public async Task<CrudOperationResult<CityDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }
        public async Task<CrudOperationResult<CityDto>> Update(CityDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
        
    }
}
