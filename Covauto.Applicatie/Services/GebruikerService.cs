using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Applicatie.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<GebruikerDTO?> GeefGebruikerByIdAsync(int id)
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
    }
}
