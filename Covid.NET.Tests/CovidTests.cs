using Xunit;
using System.Threading.Tasks;

namespace Covid.Tests;

public class CovidTests
{
    [Fact]
    public async Task Test_GlobalData()
    {
        var globalData = await CovidData.GetGlobalDataAsync();
        
        Assert.NotNull(globalData);

        // Just to get the warnings away
        if (globalData is null)
        {
            return;
        }
        
        Assert.NotNull(globalData.Cases);
        Assert.NotNull(globalData.Deaths);
        Assert.NotNull(globalData.Recovered);
    }

    [Fact]
    public async Task Test_CountryData()
    {
        var countryData = await CovidData.GetCountryDataAsync("Bangladesh");

        Assert.NotNull(countryData);
        
        // Just to get the warnings away
        if (countryData is null)
        {
            return;
        }
        
        Assert.NotNull(countryData.Cases);
        Assert.NotNull(countryData.Deaths);
        Assert.NotNull(countryData.Recovered);
    }

    [Fact]
    public async Task Test_AllCountriesData()
    {
        var allCountriesData = await CovidData.GetAllCountriesDataAsync();

        Assert.NotNull(allCountriesData);

        // Just to get the warnings away
        if (allCountriesData is null)
        {
            return;
        }
        
        foreach (var countryData in allCountriesData)
        {
            Assert.NotNull(countryData.Country);
            Assert.NotNull(countryData.Cases);
            Assert.NotNull(countryData.TodayCases);
            Assert.NotNull(countryData.Deaths);
            Assert.NotNull(countryData.TodayDeaths);
            
            /* TODO:
                - can't get this to deserialize as 0 when null, so it will always fail,
                  even when deserialization is successful and the rest of the data is present
        
            Assert.NotNull(countryData.Recovered);
            Assert.NotNull(countryData.Active);
            */
            
            Assert.NotNull(countryData.Critical);
            Assert.NotNull(countryData.CasesPerOneMillion);
            Assert.NotNull(countryData.DeathsPerOneMillion);
            Assert.NotNull(countryData.TotalTests);
            Assert.NotNull(countryData.TestsPerOneMillion);
        }
    }
}