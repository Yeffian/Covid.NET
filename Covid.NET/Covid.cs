namespace Covid;

using Models;
using System.Text;
using System.Text.Json;

public static class Covid
{
    private static readonly HttpClient s_client = new();
    private static readonly Encoding s_encoding = new UTF8Encoding(false, true);
    private static readonly JsonSerializerOptions s_options = new()
    {
        // If we're in release there's no reason to write indented, otherwise we'll want to see the content in debug
#if DEBUG
        WriteIndented = true,
#elif RELEASE
        WriteIntended = false,
#endif
    };

    public static async Task<GlobalData?> GetGlobalData()
    {
        return await GetAsync<GlobalData>(Endpoints.GlobalDataEndpoint);
    }

    public static async Task<CountryData?> GetCountryData(string country)
    {
        return await GetAsync<CountryData>(Endpoints.GetCountryDataEndpoint(country));
    }

    public static async Task<IEnumerable<CountryData>?> GetAllCountriesData()
    {
        return await GetAsync<IEnumerable<CountryData>>(Endpoints.CountryDataEndpoint);
    }
    
    private static async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await s_client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        try
        {
            var data = await response.Content.ReadAsStringAsync();
            await using var stream = new MemoryStream(s_encoding.GetBytes(data));
            return await JsonSerializer.DeserializeAsync<T>(stream, s_options, CancellationToken.None);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }
}