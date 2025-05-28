using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Applicatie.DTO.Auto;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Applicatie.Interfaces
{
    public interface IAutosRepository
    {
        Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync();
        Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto);
        Task<FullAuto?> GeefAuto(int id);
        Task<int> CreateAutoAsync(CreateAuto auto);
        Task UpdateAutoAsync(int id, UpdateAuto auto);
        Task DeleteAutoAsync(int id);
       
    }
}
