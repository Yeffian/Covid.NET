using Newtonsoft.Json;

namespace Covid.NET.Models
{
    public class GlobalData
    {
        [JsonProperty("cases")]
        public int Cases { get; init; }
        
        [JsonProperty("deaths")]
        public int Deaths { get; init; }
        
        [JsonProperty("recovered")]
        public int Recovered { get; init; }
    }   
}

