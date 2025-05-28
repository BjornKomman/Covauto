using Covauto.Applicatie.DTO.Auto;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Applicatie.Interfaces
{
    public interface IAutoService
    {
        Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync();
        Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto);
        Task<FullAuto?> GeefAutoAsync(int id);
        Task<int> CreateAutoAsync(CreateAuto auto);
        Task UpdateAutoAsync(int id);
        Task DeleteAutoAsync(int id);
    }
}
