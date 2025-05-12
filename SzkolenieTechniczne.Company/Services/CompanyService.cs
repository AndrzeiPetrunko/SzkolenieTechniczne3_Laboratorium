using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Api.Common.Service;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Storage;

using SzkolenieTechniczne.Company.Resolvers;

namespace SzkolenieTechniczne.Company.Services
{
    namespace SzkolenieTechniczne.Company.Services
    {
        public class CompanyService : CrudServiceBase<CompanyDbContext,
            Storage.Entities.Company, CompanyDto>
        {
            private readonly CountryIntegrationDataResolver _countryResolver;
            private CompanyDbContext _companyDbContext;

            public CompanyService(CompanyDbContext companyDbContext, CountryIntegrationDataResolver countryResolver) : base(companyDbContext)
            {
                _companyDbContext = companyDbContext;
                _countryResolver = countryResolver;
            }

            public async Task<CompanyDto> GetById(Guid id)
            {
                var city = await base.GetById(id);
                return city.ToDto();
            }

            protected override IQueryable<Storage.Entities.Company> ConfigureFormIncludes(IQueryable<Storage.Entities.Company> linq)
            {
                return linq.Include(c => c.Address);
            }

            public async Task<IEnumerable<CompanyDto>> Get()
            {
                var companies = await base.Get();
                return companies.Select(e => e.ToDto());
            }

            protected override async Task OnBeforeRecordCreatedAsync(CompanyDbContext dbContext, Storage.Entities.Company entity)
            {
                if (entity.Address != null)
                {
                    await _countryResolver.ResolveFor(entity.Address.CountryId);
                }
            }
        }
    }

}
