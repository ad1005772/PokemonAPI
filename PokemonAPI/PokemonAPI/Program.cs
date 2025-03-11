using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using PokemonAPI;


class Program
{
    private static List<Pokemon> requestedPokemon = new List<Pokemon>();
    static async Task Main(string[] arg)
    {
        var client = new PokeAPIClient();
        while (true)
        { 
            Console.WriteLine("Enter Pokemon Name or ID: ");
            var input = Console.ReadLine();
            try
            {
                var pokemon = await PokeAPIClient.GetPokemonAsync(input);
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
        Console.WriteLine($"Name: {pokemon.Name}");
        Console.WriteLine($"Height: {pokemon.Height}");
        Console.WriteLine($"Weight: {pokemon.Weight}");
    }
    static void DisplayRequestedPokemon()
    {
        Console.WriteLine("\nRequested Pokemon");
        foreach (var pokemon in requestedPokemon)
        {
            Console.WriteLine($"- {pokemon.Name}");
        }
    }
}
