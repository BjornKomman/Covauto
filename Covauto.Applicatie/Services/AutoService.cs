using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Applicatie.DTO.Auto;
using Covauto.Applicatie.Interfaces;

using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Services
{
    public class AutoService : IAutoService
    {
        private readonly IAutoRepository AutosRepository;

        public AutoService(IAutoRepository autosRepository)
        {
            this.AutosRepository = autosRepository;
        }

        public async Task<int> CreateAutoAsync(CreateAuto auto)
        {
            return await AutosRepository.CreateAutoAsync(auto);
        }

        public async Task DeleteAutoAsync(int id)
        {
            await AutosRepository.DeleteAutoAsync(id);
        }

        public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
        {
            return await AutosRepository.GeefAlleAutosAsync();
        }

        public async Task<FullAuto?> GeefAutoAsync(int id)
        {
            return await AutosRepository.GeefAuto(id);
        }

        public async Task UpdateAutoAsync(int id, UpdateAuto auto)
        {
            await AutosRepository.UpdateAutoAsync(id, auto);
        }

        public async Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto)
        {
            return await AutosRepository.ZoekAutosAsync(naamAuto);
        }

        Task IAutoService.UpdateAutoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
