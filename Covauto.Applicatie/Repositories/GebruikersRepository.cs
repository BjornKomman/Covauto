using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Infrastructure;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.EntityFrameworkCore;
using Covauto.Infrastructure.Data;
using Covauto.Applicatie.Interfaces;

namespace Covauto.Infrastructure
{
    public class GebruikersRepository : IGebruikerRepository
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
        /// Geeft een gebruiker inclusief de auto's van deze gebruiker  
        /// </summary>  
        /// <param name="id">GebruikerId</param>  
        /// <returns></returns>  
        public Gebruiker? GeefGebruikerById(int id)
        {
            // Assuming 'Gebruiker' does not have a direct property 'Autos',  
            // you need to fetch related data from the 'Autos' DbSet.  
            var gebruiker = autosContext.Gebruikers.SingleOrDefault(n => n.Id == id);
            if (gebruiker == null)
                return null;

            //var autos = autosContext.Autos.Where(a => a.GebruikerId == id).ToList();

            return new Gebruiker()
            {
                Id = gebruiker.Id,
                Naam = gebruiker.Naam,
                // Assuming you want to map the related 'Autos' data to a property in the returned object.  
                //Autos = autos
            };
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

        Task<int> IGebruikerRepository.MaakGebruikerAsync(CreateGebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<GebruikerListItem>> IGebruikerRepository.GeefAlleGebruikersAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<GebruikerListItem>> IGebruikerRepository.ZoekGebruikersAsync(string naam)
        {
            throw new NotImplementedException();
        }

        Task<GebruikerListItem> IGebruikerRepository.GeefGebruikerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
