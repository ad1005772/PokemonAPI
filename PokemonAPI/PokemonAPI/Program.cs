using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] arg)
    {
        string apiURL = "https://pokeapi.co/api/v2/";
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(apiURL);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        string data = JsonSerializer.Deserialize<string>(content);

    }
}
