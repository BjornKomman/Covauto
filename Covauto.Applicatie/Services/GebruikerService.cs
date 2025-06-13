using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Applicatie.Interfaces;
using Covauto.Shared.DTO.Gebruiker;



namespace Covauto.Application.Services
{
    public class GebruikerService : IGebruikerService
    {
        private readonly IGebruikerRepository _repo;
        public GebruikerService(IGebruikerRepository repo) => _repo = repo;

        public Task<int> MaakGebruikerAsync(CreateGebruiker g)
            => _repo.MaakGebruikerAsync(g);

        public Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync()
            => _repo.GeefAlleGebruikersAsync();

        public Task<IEnumerable<GebruikerListItem>> ZoekGebruikersAsync(string naam)
            => _repo.ZoekGebruikersAsync(naam);

        public Task<GebruikerListItem?> GeefGebruikerByIdAsync(int id)
            => _repo.GeefGebruikerByIdAsync(id);
    }
}
