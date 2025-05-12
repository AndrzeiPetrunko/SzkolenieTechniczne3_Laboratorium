using System.Linq;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.CrossCutting.Dtos;
using Newtonsoft.Json;

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

                HttpResponseMessage response = await client.GetAsync("countries");
                string repsonseData = await response.Content.ReadAsStringAsync();
                List<CountryDto> countries = JsonConvert.DeserializeObject<List<CountryDto>>(repsonseData);
                return countries.FirstOrDefault(x => x.Id == countryId);

            }
        }

        private async Task<Country> CreateOrUpdateCountries(CountryDto dto)
        {
            var country = new Country
            {
                Id = dto.Id,
                Alpha3Code = dto.Alpha3Code,
                ExternalId = dto.Id.ToString(),
                ExternalSourceName = "Geo"
            };
            country.Translations = new List<CountryTranslation>();
            foreach (var item in dto.Name)
            {
                country.Translations.Add(new CountryTranslation
                {

                    CountryId = dto.Id,
                    LanguageCode = item.Key,
                    Name = item.Value,
                    Id = Guid.NewGuid()
                });
            }

            _dbContext.Countries.Add(country);
            return country;
        }

        public class CountryDto
        {
            public Guid Id { get; set; }
            public LocalizedString Name { get; set; }
            public string Alpha3Code { get; set; }
        }
    }
}
