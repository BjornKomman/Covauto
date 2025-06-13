using Covauto.Shared.DTO.Rit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Application.Interfaces
{
    

        public interface IRittenRepository
        {
            Task<IEnumerable<RitDTO>> GeefAlleRittenAsync();
            Task<int> MaakRitAsync(CreateRit rit);
        }
    }

