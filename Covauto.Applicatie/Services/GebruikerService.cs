using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Applicatie.Interfaces;
using Covauto.Application.Repositories;
using Covauto.Shared.DTO.Gebruiker;



namespace Covauto.Application.Services
{
    public class GebruikerService : IGebruikerService
    {
        private readonly IGebruikerRepository gebruikerRepository;
        public GebruikerService(IGebruikerRepository gebruikerRepository)
        {
            this.gebruikerRepository = gebruikerRepository;
        }

        public async Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync()
        {
            return await gebruikerRepository.GeefAlleGebruikersAsync();
        }

        public async Task<GebruikerListItem?> GeefGebruikerByIdAsync(int id)
        {
            return await gebruikerRepository.GeefGebruikerByIdAsync(id);
        }

        public async Task<int> MaakGebruikerAsync(CreateGebruiker gebruiker)
        {
            return await gebruikerRepository.MaakGebruikerAsync(gebruiker);
        }

        public async Task<IEnumerable<GebruikerListItem>> ZoekGebruikerAsync(string naam)
        {
            return await gebruikerRepository.ZoekGebruikersAsync(naam);
        }

        public Task<IEnumerable<GebruikerListItem>> ZoekGebruikersAsync(string naam)
        {
            throw new NotImplementedException();
        }
    }
}
