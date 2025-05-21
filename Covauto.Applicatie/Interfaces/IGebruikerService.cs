using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Shared.DTO.Gebruiker;
namespace Covauto.Applicatie.Interfaces
{
    public interface IGebruikerService
    {
        Task<int> MaakGebruikerAsync(CreateGebruiker gebruiker);
        Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync();
        Task<IEnumerable<GebruikerListItem>> ZoekGebruikersAsync(string naam);
        Task<GeberuikerDTO?> GeefGebruikerByIdAsync(int id);
    }
}
