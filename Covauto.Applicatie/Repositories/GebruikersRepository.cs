using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.EntityFrameworkCore;


namespace Covauto.Application.Repositories
{
    public class GebruikersRepository
    {
        private readonly AutosContext autosContext;
        private readonly DbSet<Gebruiker> gebruikerEntity;

        public GebruikersRepository(AutosContext autosContext)
        {
            this.autosContext = autosContext;
        }

        /// <summary>
        /// Maakt een Gebruiker aan en geeft de aangemaakte Id terug
        /// </summary>
        /// <param name="gebruiker"></param>
        /// <returns>GebruikerId</returns>
        public int MaakGebruiker(CreateGebruiker gebruiker)
        {
            Gebruiker gebruikerEntity = new Gebruiker()
            {
                Naam = gebruiker.Naam
            };




            autosContext.Gebruikers.Add(gebruikerEntity);
            autosContext.SaveChanges();
            return gebruikerEntity.Id;
        }

        /// <summary>
        /// Geeft alle Gebruikers namen uit de database met daarbij de id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GebruikerListItem> GeefAlleGebruikers()
        {
            return autosContext.Gebruikers.Select(
                n => new GebruikerListItem()
                {
                    Id = n.Id,
                    Naam = n.Naam
                }
                );
        }

        /// <summary>
        /// Zoekt in een gedeelte van de naam, hoofdletter onafhankelijk
        /// </summary>
        /// <param name="naam"></param>
        /// <returns>Lijst van Gebruikers met daarbij behorende Ids</returns>
        public IEnumerable<GebruikerListItem> ZoekGebruikers(string naam)
        {
            return autosContext.Gebruikers.Where(
                n => n.Naam.ToLower().Contains(naam.ToLower()))
                .Select(n => new GebruikerListItem()
                {
                    Id = n.Id,
                    Naam = n.Naam
                });
        }

        public IEnumerable<GebruikerListItem> ZoekGebruikersAsyncs(string naam)
        {
            return autosContext.Gebruikers.Where(
                n => n.Naam.ToLower().Contains(naam.ToLower()))
                .Select(n => new GebruikerListItem()
                {
                    Id = n.Id,
                    Naam = n.Naam
                });
        }

        /// <summary>
        /// Geeft een schrijver inclusief de boeken van deze schrijver
        /// </summary>
        /// <param name="id">SchrijverId</param>
        /// <returns></returns>
        public Gebruiker? GeefGebruikerById(int id)
        {
            return MapGebruiker(autosContext.Gebruikers.Include(n => n.Autos).SingleOrDefault(n => n.Id == id));
        }


        private Gebruiker? MapGebruiker(Domain.Entities.Gebruiker? gebruiker)
        {
            if (gebruiker == null)
                return null;

            return new Gebruiker()
            {
                Id = gebruiker.Id,
                Naam = gebruiker.Naam,
            };
        }


    }
}
