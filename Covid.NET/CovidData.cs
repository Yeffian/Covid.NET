namespace Covid;

using Models;
using System.Text;
using System.Text.Json;

public static class CovidData
{
    private static readonly HttpClient _client = new();
    private static readonly Encoding _encoding = new UTF8Encoding(false, true);


    public static async Task<GlobalData?> GetGlobalDataAsync()
    {
        return await GetAsync<GlobalData>(Endpoints.GlobalDataEndpoint);
    }

    public static async Task<CountryData?> GetCountryDataAsync(string country)
    {
        return await GetAsync<CountryData>(Endpoints.GetCountryDataEndpoint(country));
    }

    public static async Task<IEnumerable<CountryData>?> GetAllCountriesDataAsync()
    {
        return await GetAsync<IEnumerable<CountryData>>(Endpoints.CountryDataEndpoint);
    }
    
    private static async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        try
        {
            var data = await response.Content.ReadAsStringAsync();
            await using var stream = new MemoryStream(_encoding.GetBytes(data));
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }
}