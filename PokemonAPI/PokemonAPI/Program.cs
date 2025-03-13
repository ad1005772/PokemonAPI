using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static List<Pokemon> requestedPokemon = new List<Pokemon>();

    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var client = new PokeApiClient(httpClient);

        while (true)
        {
            Console.Write("Enter Pokémon name or ID: ");
            var input = Console.ReadLine();

            try
            {
                var pokemon = await client.GetPokemonAsync(input);
                requestedPokemon.Add(pokemon);
                DisplayPokemon(pokemon);
                DisplayRequestedPokemon();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void DisplayPokemon(Pokemon pokemon)
    {
        Console.WriteLine($"Id: {pokemon.Id}");
        Console.WriteLine($"Name: {pokemon.Name}");
        Console.WriteLine($"Height: {pokemon.Height}");
        Console.WriteLine($"Weight: {pokemon.Weight}");
    }

    static void DisplayRequestedPokemon()
    {
        Console.WriteLine("\nRequested Pokémon:");
        foreach (var pokemon in requestedPokemon)
        {
            Console.WriteLine($"- {pokemon.Name}");
        }
    }
}