using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace PokemonAPI
{
    public class PokeAPIClient
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task<Pokemon> GetPokemonAsync(string nameOrId)
        {
            var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nameOrId}");
            return JsonConvert.DeserializeObject<Pokemon>(response);
        }
    }
}
