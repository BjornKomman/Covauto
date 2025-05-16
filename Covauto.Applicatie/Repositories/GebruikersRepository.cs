using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Application.Repositories
{
    public class GebruikersRepository
    {
        private readonly CovautoContext covautoContext;

        public GebruikersRepository(CovautoContext covautoContext)
        {
            this.covautoContext = covautoContext;
        }

        /// <summary>
        /// Maakt een Gebruiker aan en geeft de aangemaakte Id terug
        /// </summary>
        /// <param name="gebruiker"></param>
        /// <returns>GebruikerId</returns>
        public int MaakGebruiker(CreateGebruiker gebruiker)
        {
            Domain.Entities.Gebruiker gebruikerEntity = new Domain.Entities.Gebruiker()
            {
                Naam = gebruiker.Naam
            };
            covautoContext.Schrijvers.Add(gebruikerEntity);
            covautoContext.SaveChanges();
            return gebruikerEntity.Id;
        }

        /// <summary>
        /// Geeft alle Gebruikers namen uit de database met daarbij de id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GebruikerItem> GeefAlleGebruikers()
        {
            return covautoContext.Gebruikers.Select(
                n => new GebruikerItem()
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
        public IEnumerable<GebruikerItem> ZoekSchrijvers(string naam)
        {
            return covautoContext.Gebruikers.Where(
                n => n.Naam.ToLower().Contains(naam.ToLower()))
                .Select(n => new GebruikerItem()
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
            return MapSchrijver(covautoContext.Gebruikers.Include(n => n.Autos).SingleOrDefault(n => n.Id == id));
        }


        private Gebruiker? MapSchrijver(Domain.Entities.Gebruiker? gebruiker)
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
