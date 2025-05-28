using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Applicatie.DTO.Gebruiker;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Application.Services;


namespace Covauto.Applicatie.Interfaces
{
    public interface IGebruikerService
    {
        Task<int> MaakGebruikerAsync(CreateGebruiker gebruiker);
        Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync();
        Task<IEnumerable<GebruikerListItem>> ZoekGebruikersAsync(string naam);

        //Task<GebruikerDTO?> GeefGebruikerByIdAsync(int id);
        Task<GebruikerListItem?> GeefGebruikerByIdAsync(int id);
    }
}
