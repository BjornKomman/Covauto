using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Domain.Entities;

namespace Covauto.Applicatie.Interfaces
{
    public interface IGebruikerRepository
    {
        Task<int> MaakGebruikerAsync(CreateGebruiker gebruiker);
        Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync();
        Task<IEnumerable<GebruikerListItem>> ZoekGebruikersAsync(string naam);
        Task<GebruikerListItem> GeefGebruikerByIdAsync(int id);
       
    }
}
