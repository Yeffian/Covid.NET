namespace Covid.Models;

using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class GlobalData
{
    [JsonPropertyName("cases"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Cases { get; init; }
        
    [JsonPropertyName("deaths"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Deaths { get; init; }

    [JsonPropertyName("recovered"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Recovered { get; init; }
}