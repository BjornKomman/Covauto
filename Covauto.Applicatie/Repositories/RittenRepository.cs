using Covauto.Application.Interfaces;
using Covauto.Domain.Entities;
using Covauto.Infrastructure.Data;
using Covauto.Shared.DTO.Rit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Application.Repositories
{

namespace Covauto.Application.Repositories
    {
        public class RittenRepository : IRittenRepository
        {
            private readonly AutosContext _context;

            public RittenRepository(AutosContext context)
            {
                _context = context;
            }

            public async Task<int> MaakRitAsync(CreateRit dto)
            {
                var rit = new Rit
                {
                    AutoId = dto.AutoId,
                    GebruikerId = dto.GebruikerId,
                    BeginAdres = dto.BeginAdres,
                    EindAdres = dto.EindAdres,
                    BeginKmStand = dto.BeginKmStand,
                    EindKmStand = dto.EindKmStand,
                    Datum = dto.Datum
                };

                _context.Ritten.Add(rit);
                await _context.SaveChangesAsync();
                return rit.Id;
            }

            public async Task<IEnumerable<RitDTO>> GeefAlleRittenAsync()
            {
                return await _context.Ritten
                    .Include(r => r.Auto)
                    .Include(r => r.Gebruiker)
                    .Select(r => new RitDTO
                    {
                        Id = r.Id,
                        AutoNaam = r.Auto.naamAuto,
                        GebruikerNaam = r.Gebruiker.Naam,
                        BeginAdres = r.BeginAdres,
                        EindAdres = r.EindAdres,
                        BeginKmStand = r.BeginKmStand,
                        EindKmStand = r.EindKmStand,
                        Datum = r.Datum
                    })
                    .ToListAsync();
            }
        }
    }

}
}
