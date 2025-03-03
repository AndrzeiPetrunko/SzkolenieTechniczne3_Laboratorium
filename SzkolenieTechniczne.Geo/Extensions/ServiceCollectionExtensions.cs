using SzkolenieTechniczne.Geo.Services;
using SzkolenieTechniczne.Geo.Storage;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGeoServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CountryService>();
        serviceCollection.AddTransient<CityService>();
        serviceCollection.AddDbContext<GeoDbContext, GeoDbContext>();
        return serviceCollection;
    }
}
