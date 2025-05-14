using Covauto.Shared.DTO.Boeken;
using Covauto.Shared.DTO.Schrijvers;
using System.Net.Http.Json;

namespace Covauto.Client
{
    internal class Program
    {
        static string baseUrl = "https://localhost:7190/api";
        static async Task Main(string[] args)
        {
            await PrintAutos();
            int gebruikerId = await MaakGebruiker();
            await MaakAuto(gebruikerId);
            //await PrintAutos();

            Console.WriteLine("*****Done*****");
            Console.ReadLine();

        }

        private static async Task MaakAuto(int gebruikerId)
        {
            var newAuto = new CreateAuto
            {
                Titel = "Hoe schrijf ik een API in c#",
                SchrijverId = gebruikerId,
                Publicatiejaar = DateTime.Now.Year
            };

            var autoId = await CreateAutoAsync(newAuto);
            Console.WriteLine("------Auto-----");
            Console.WriteLine($"Created Auto with ID: {autoId}");
        }

        private static async Task<int> MaakGebruiker()
        {
            var newGebruiker = new CreateGebruiker
            {
                Naam = "Appi de Gebruiker"
            };

            var gebruikerId = await CreateSchrijverAsync(newGebruiker);
            Console.WriteLine("------Gebruiker-----");
            Console.WriteLine($"Created Gebruiker with ID: {gebruikerId}");
            return gebruikerId;
        }

        private static async Task PrintAutos()
        {
            var autos = await GetAutosAsync();
            Console.WriteLine("------Alle Autos-----");
            foreach (var auto in autos)
            {
                Console.WriteLine($"Id: {auto.ID}, Naam: {auto.Titel}, Chauffeur: {auto.Gebruiker}");
            }


        }

        private static async Task<int> CreateGebruikerAsync(CreateGebruiker newGebruiker)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Gebruikers"); // Adjust the base address as needed

            var response = await client.PostAsJsonAsync("", newGebruiker);
            response.EnsureSuccessStatusCode();

            var createdGebruikerId = await response.Content.ReadFromJsonAsync<int>();
            return createdGebruikerId;
        }

        private static async Task<int> CreateAutoAsync(CreateAuto newAuto)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/Autos"); // Adjust the base address as needed

            var response = await client.PostAsJsonAsync("", newAuto);
            response.EnsureSuccessStatusCode();

            var createdAutoId = await response.Content.ReadFromJsonAsync<int>();
            return createdAutoId;
        }
        private static async Task<IEnumerable<AutosListItem>> GetAutosAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri($"{baseUrl}/auto");

            //Voer de werkelijke Get uit
            var response = await client.GetAsync("");
            if (!response.IsSuccessStatusCode)
                //geef een lege lijst terug(er is iets fout gegaan
                return Enumerable.Empty<AutosListItem>();

            //zet de json om in een lijst van BoekListItem
            var boeken = await response.Content.ReadFromJsonAsync<IEnumerable<AutosListItem>>();
            //geef de boeken terug als die er zijn, anders geef je een lege lijst
            return boeken ?? Enumerable.Empty<AutosListItem>();
        }
    }
}