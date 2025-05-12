using System.Linq;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Resolvers
{
    public class CountryIntegrationDataResolver
    {
        private readonly CompanyDbContext _dbContext;

        public CountryIntegrationDataResolver(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ResolveFor(Guid countryId)
        {
            var exist = await _dbContext.Countries.AnyAsync(x => x.Id == countryId);

            if (!exist)
            {
                var countryDto = await ResolveFromExternalDictionary(countryId);
                await CreateOrUpdateCountries(countryDto);
            }
        }

        private async Task<CountryDto?> ResolveFromExternalDictionary(Guid countryId)
        {
            string apiUrl = "http://localhost:4040/geo/";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
            }
        }
    }
}
