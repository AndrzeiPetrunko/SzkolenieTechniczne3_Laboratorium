using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage;

namespace SzkolenieTechniczne.Company.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext _companyDbContext;

        public CompanyService(CompanyDbContext geoDbContext)
        {
            _companyDbContext = geoDbContext;
        }

        public async Task<CompanyDto> GetById(Guid id)
        {
            var company = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .AsNoTracking()
                .Where(e => e.Id.Equals(id))
                .SingleOrDefaultAsync();

            return company?.ToDto();
        }

        public async Task<IEnumerable<CityDto>> Get()
        {
            var cities = await _companyDbContext
                .Set<City>()
                .Include(x => x.Translations)
                .AsNoTracking()
                .Select(e => e.ToDto())
                .ToListAsync();

            return cities;
        }


        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();

            _companyDbContext
                .Set<City>()
                .Add(entity);

            await _companyDbContext.SaveChangesAsync();

            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CityDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            }
}
