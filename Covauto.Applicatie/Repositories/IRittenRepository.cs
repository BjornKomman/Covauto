using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Repositories
{
    public interface IRittenRepository
    {
        Task<IEnumerable<RitDTO>> GeefAlleRittenAsync();
        Task<int> MaakRitAsync(CreateRit rit);
    }
}
