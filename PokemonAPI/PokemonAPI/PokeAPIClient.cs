using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PokeApiClient
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<Pokemon> GetPokemonAsync(string nameOrId)
    {
        var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nameOrId}");
        return JsonConvert.DeserializeObject<Pokemon>(response);
    }
}