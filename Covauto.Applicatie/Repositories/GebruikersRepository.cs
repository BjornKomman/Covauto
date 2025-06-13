using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Applicatie.Interfaces;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Infrastructure.Repositories
{
    public class GebruikersRepository : IGebruikerRepository
    {
        private readonly AutosContext autosContext;

        public GebruikersRepository(AutosContext autosContext)
            => this.autosContext = autosContext;

        /// <summary>
        /// Maakt een Gebruiker aan en geeft de nieuw aangemaakte Id terug.
        /// </summary>
        public async Task<int> MaakGebruikerAsync(CreateGebruiker dto)
        {
            var entiteit = new Gebruiker
            {
                Naam = dto.Naam
            };

            await autosContext.Gebruikers.AddAsync(entiteit);
            await autosContext.SaveChangesAsync();

            return entiteit.Id;
        }

        /// <summary>
        /// Haalt alle gebruikers (Id + Naam) op.
        /// </summary>
        public async Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync()
        {
            return await autosContext.Gebruikers
                .Select(g => new GebruikerListItem
                {
                    Id = g.Id,
                    Naam = g.Naam
                })
                .ToListAsync();
        }

        /// <summary>
        /// Zoekt gebruikers op naam (case-insensitive).
        /// </summary>
        public async Task<IEnumerable<GebruikerListItem>> ZoekGebruikersAsync(string naam)
        {
            return await autosContext.Gebruikers
                .Where(g => EF.Functions.Like(g.Naam, $"%{naam}%"))
                .Select(g => new GebruikerListItem
                {
                    Id = g.Id,
                    Naam = g.Naam
                })
                .ToListAsync();
        }

        /// <summary>
        /// Haalt één gebruiker op (Id + Naam).
        /// Gooit KeyNotFoundException als er geen gebruiker is met die Id.
        /// </summary>
        public async Task<GebruikerListItem> GeefGebruikerByIdAsync(int id)
        {
            var gebruiker = await autosContext.Gebruikers
                .Where(g => g.Id == id)
                .Select(g => new GebruikerListItem
                {
                    Id = g.Id,
                    Naam = g.Naam
                })
                .SingleOrDefaultAsync();

            if (gebruiker is null)
                throw new KeyNotFoundException($"Gebruiker met Id {id} niet gevonden.");

            return gebruiker;
        }
    }
}
