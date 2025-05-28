using Covauto.Applicatie.DTO.Auto;
using Covauto.Applicatie.DTO.Gebruiker;

using System.Net.Http.Json;

namespace Covauto.Client
{
    public class Program
    {
        static string baseUrl = "https://localhost:7190/api";

        static async Task Main(string[] args)
        {
            await PrintAutos();
            int gebruikerId = await MaakGebruiker();
            await MaakAuto(gebruikerId);

            Console.WriteLine("*****Done*****");
            Console.ReadLine();
        }

        private static async Task MaakAuto(int gebruikerId)
        {
            var newAuto = new CreateAuto
            {
                naamAuto = "Volkswagen Golf",
                kilometerstand = 123456,
                startAdres = "Stationsstraat 1, Utrecht",
                eindAdres = "Marktplein 5, Amsterdam",
                beschikbaarheid = true,
                GebruikerId = gebruikerId
            };

            var autoId = await CreateAutoAsync(newAuto);
            Console.WriteLine("------Auto-----");
            Console.WriteLine($"Gemaakte Auto met ID: {autoId}");
        }

        private static async Task<int> MaakGebruiker()
        {
            var newGebruiker = new CreateGebruiker
            {
                Naam = "Appi de Gebruiker"
            };

            var gebruikerId = await CreateGebruikerAsync(newGebruiker);
            Console.WriteLine("------Gebruiker-----");
            Console.WriteLine($"Gemaakte Gebruiker met ID: {gebruikerId}");
            return gebruikerId;
        }

        private static async Task PrintAutos()
        {
            var autos = await GetAutosAsync();
            Console.WriteLine("------Alle Autos-----");
            foreach (var auto in autos)
            {
                Console.WriteLine($"Id: {auto.Id}, Naam: {auto.naamAuto}, KM-stand: {auto.kilometerstand}, Van: {auto.startAdres}, Naar: {auto.eindAdres}, Beschikbaar: {auto.beschikbaarheid}");
            }
        }

        private static async Task<int> CreateGebruikerAsync(CreateGebruiker newGebruiker)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Gebruikers");

            var response = await client.PostAsJsonAsync("", newGebruiker);
            response.EnsureSuccessStatusCode();

            var createdGebruikerId = await response.Content.ReadFromJsonAsync<int>();
            return createdGebruikerId;
        }

        private static async Task<int> CreateAutoAsync(CreateAuto newAuto)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Autos");

            var response = await client.PostAsJsonAsync("", newAuto);
            response.EnsureSuccessStatusCode();

            var createdAutoId = await response.Content.ReadFromJsonAsync<int>();
            return createdAutoId;
        }

        private static async Task<IEnumerable<AutoListItem>> GetAutosAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Autos");

            var response = await client.GetAsync("");
            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<AutoListItem>();

            var autos = await response.Content.ReadFromJsonAsync<IEnumerable<AutoListItem>>();
            return autos ?? Enumerable.Empty<AutoListItem>();
        }
    }
}
