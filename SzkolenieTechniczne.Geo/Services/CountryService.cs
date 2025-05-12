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
using SzkolenieTechniczne.Api.Common.Service;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Geo.Services
{
    public class CountryService : CrudServiceBase<GeoDbContext, Country, CountryDto>
    {
        private readonly GeoDbContext _geoDbContext;

        public CountryService(GeoDbContext geoDbContext) : base(geoDbContext) 
        {
            _geoDbContext = geoDbContext;
        }
        protected override IQueryable<Country> ConfigureFormIncludes(IQueryable<Country> linq)
        {
            return linq.Include(x => x.Translations);
        }


        public async Task<CountryDto> GetById(Guid id)
        {
            var country = await base.GetById(id);

            return country.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {
            var countries = await base.Get();

            return countries.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<CountryDto>> Create(CountryDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);

            await _geoDbContext.SaveChangesAsync();

            var newDto = await GetById(entityId);

            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<CountryDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }
        public async Task<CrudOperationResult<CountryDto>> Update(CountryDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
