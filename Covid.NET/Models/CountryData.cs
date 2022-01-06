namespace Covid.Models;

using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class CountryData
{
    [JsonPropertyName("country"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string? Country { get; init; }

    [JsonPropertyName("cases"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Cases { get; init; }

    [JsonPropertyName("todayCases"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? TodayCases { get; init; }

    [JsonPropertyName("deaths"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Deaths { get; init; }

    [JsonPropertyName("todayDeaths"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? TodayDeaths { get; init; }

    [JsonPropertyName("recovered"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Recovered { get; init; }

    [JsonPropertyName("active"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Active { get; init; }

    [JsonPropertyName("critical"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Critical { get; init; }

    [JsonPropertyName("casesPerOneMillion"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? CasesPerOneMillion { get; init; }

    [JsonPropertyName("deathsPerOneMillion"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? DeathsPerOneMillion { get; init; } 

    [JsonPropertyName("totalTests"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? TotalTests { get; init; }

    [JsonPropertyName("testsPerOneMillion"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? TestsPerOneMillion { get; init; }

    [JsonIgnore]
    private string DebuggerDisplay
    {
        get
        {
            using var stream = new MemoryStream();
            JsonSerializer.Serialize(stream, this, new JsonSerializerOptions{WriteIndented = true});
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}