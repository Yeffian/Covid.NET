namespace Covid;

public static class Endpoints
{
	public const string BaseEndpoint = "https://coronavirus-19-api.herokuapp.com";
	public const string GlobalDataEndpoint = $"{BaseEndpoint}/all";
	public const string CountryDataEndpoint = $"{BaseEndpoint}/countries";
	
	public static string GetCountryDataEndpoint(string country) => $"{CountryDataEndpoint}/{country}";
}