using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PokeApiClient
{
    private readonly HttpClient _httpClient;

    public PokeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Pokemon> GetPokemonAsync(string nameOrId)
    {
        var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nameOrId}");
        return JsonConvert.DeserializeObject<Pokemon>(response);
    }
}