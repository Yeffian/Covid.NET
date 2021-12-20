using Newtonsoft.Json;

namespace Covid.NET.Models
{
    public class CountryData
    {
        [JsonProperty("country")]
        public string Country { get; init; }
        
        [JsonProperty("cases")]
        public int Cases { get; init; }
        
        [JsonProperty("todayCases")]
        public int TodayCases { get; init; }
        
        [JsonProperty("deaths")]
        public int Deaths { get; init; }
        
        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; init; }
        
        [JsonProperty("recovered")]
        public int Recovered { get; init; }
        
        [JsonProperty("active")]
        public int Active { get; init; }
        
        [JsonProperty("critical")]
        public int Critical { get; init; }
        
        [JsonProperty("casesPerOneMillion")]
        public int CasesPerOneMillion { get; init; }
        
        [JsonProperty("deathsPerOneMillion")]
        public int DeathsPerOneMillion { get; init; }
        
        [JsonProperty("totalTests")]
        public int TotalTests { get; init; }
        
        [JsonProperty("testsPerOneMillion")]
        public int TestsPerOneMillion { get; init; }
    }
}

