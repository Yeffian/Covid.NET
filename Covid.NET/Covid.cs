using Covid.NET.Models;
using Newtonsoft.Json;

namespace Covid.NET
{
    public class Covid
    {
        private static HttpClient m_Client = new HttpClient();

        private const string m_GlobalDataEndpoint = "https://coronavirus-19-api.herokuapp.com/all";
        private const string m_CountryDataEndpoint = "https://coronavirus-19-api.herokuapp.com/countries";

        private static string GetCountryDataEndpoint(string country) => $"{m_CountryDataEndpoint}/{country}";

        public static async Task<GlobalData> GetGlobalData()
        {
            string resp = await m_Client.GetStringAsync(m_GlobalDataEndpoint);

            return JsonConvert.DeserializeObject<GlobalData>(resp);
        }

        public static async Task<CountryData> GetCountryData(string country)
        {
            string resp = await m_Client.GetStringAsync(GetCountryDataEndpoint(country));

            return JsonConvert.DeserializeObject<CountryData>(resp);
        }

        public static async Task<IEnumerable<CountryData>> GetAllCountriesData()
        {
            string resp = await m_Client.GetStringAsync(m_CountryDataEndpoint);

            return JsonConvert.DeserializeObject<IEnumerable<CountryData>>(resp);
        }
    }
}

