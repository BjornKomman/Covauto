using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Applicatie.Interfaces
{
    public interface IAutosRepository
    {
        Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync();
        Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto);
        Task<FullAuto?> GeefAuto(int id);
        Task<int> CreateAutoAsync(CreateBoek auto);
        Task UpdateAutoAsync(int id, UpdateBoek auto);
        Task DeleteAutoAsync(int id);
    }
}
