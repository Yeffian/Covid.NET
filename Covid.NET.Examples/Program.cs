using Covid.Models;

namespace Covid.Examples;

public static class Program
{
    public static async Task<int> Main()
    { 
        // Get global data 
        GlobalData globalData = await CovidData.GetGlobalDataAsync() ?? throw new Exception("unable to get global data");

        Console.WriteLine("------------------------ GLOBAL DATA -----------------------");
        Console.WriteLine($"Cases: {globalData.Cases}");
        Console.WriteLine($"Deaths: {globalData.Deaths}");
        Console.WriteLine($"Recovered: {globalData.Recovered}");
        Console.WriteLine();
            
        // Get data about a specific country
        // CountryData countryData = await Covid.GetCountryData("Bangladesh") ?? throw new Exception("unable to get country data");
        CountryData countryData = await CovidData.GetCountryDataAsync("USA") ?? throw new Exception("unable to get country data");
        
        Console.WriteLine($"------------------------ {countryData.Country} -----------------------");
        Console.WriteLine($"Cases: {countryData.Cases}");
        Console.WriteLine($"Deaths: {countryData.Deaths}");
        Console.WriteLine($"Recovered: {countryData.Recovered}");
        Console.WriteLine();
            
        // Get data about all the countries the library supports
        IEnumerable<CountryData> allCountriesData = await CovidData.GetAllCountriesDataAsync() ?? throw new Exception("unable to get all countries data");

        foreach (CountryData c in allCountriesData)
        {
            Console.WriteLine($"------------------------ {c.Country} -----------------------");
            Console.WriteLine($"Cases: {c.Cases}");
            Console.WriteLine($"Deaths: {c.Deaths}");
            Console.WriteLine($"Recovered: {c.Recovered}");
        }

        return 0;
    }
}