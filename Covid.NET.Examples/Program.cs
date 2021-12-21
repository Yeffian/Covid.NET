using Covid.NET.Models;

namespace Covid.NET.Examples
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        { 
            // Get global data 
            GlobalData globalData = await Covid.GetGlobalData();
            
            Console.WriteLine($"Cases: {globalData.Cases}");
            Console.WriteLine($"Deaths: {globalData.Deaths}");
            Console.WriteLine($"Recovered: {globalData.Recovered}");
            
            // Get data about a specific country
            CountryData? countryData = await Covid.GetCountryData("Bangladesh");
            
            Console.WriteLine($"Cases: {countryData.Cases}");
            Console.WriteLine($"Deaths: {countryData.Deaths}");
            Console.WriteLine($"Recovered: {countryData.Recovered}");
            
            
            // Get data about all the countries the library supports
            IEnumerable<CountryData> allCountriesData = await Covid.GetAllCountriesData();

            foreach (CountryData c in allCountriesData)
            {
                Console.WriteLine($"------------------------ {c.Country} -----------------------");
                Console.WriteLine($"Cases: {c.Cases}");
                Console.WriteLine($"Deaths: {c.Deaths}");
                Console.WriteLine($"Recovered: {c.Recovered}");
                Console.WriteLine($"----------------------------------------------------------");
            }

            return 0;
        }
    }
}

