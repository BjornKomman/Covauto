using Covauto.Applicatie.DTO.Auto;
using Covauto.Application.Repositories;
using Covauto.Domain.Entities;
using Covauto.Infrastructure.Data;
using Covauto.Shared.DTO.Auto;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Covauto.Infrastructure.Repositories
{
    public class AutoRepository : IAutoRepository
    {
        private readonly AutosContext _context;

        public AutoRepository(AutosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
        {
            return await _context.Autos
                .Select(a => new AutoListItem
                {
                    Id = a.Id,
                    naamAuto = a.naamAuto,
                    beschikbaarheid = a.beschikbaarheid
                }).ToListAsync();
        }

        public async Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto)
        {
            return await _context.Autos
                .Where(a => a.naamAuto.Contains(naamAuto))
                .Select(a => new AutoListItem
                {
                    Id = a.Id,
                    naamAuto = a.naamAuto,
                    beschikbaarheid = a.beschikbaarheid
                }).ToListAsync();
        }

        public async Task<FullAuto?> GeefAutoOpIdAsync(int id)
        {
            var auto = await _context.Autos.FirstOrDefaultAsync(a => a.Id == id);
            if (auto == null) return null;

            return new FullAuto
            {
                naamAuto = auto.naamAuto,
                kilometerstand = auto.kilometerstand,
                Publicatiejaar = auto.publicatieJaar,
                startAdres = auto.startAdres,
                eindAdres = auto.eindAdres,
                beschikbaarheid = auto.beschikbaarheid,
            };
        }

        public async Task<int> CreateAutoAsync(CreateAuto auto)
        {
            var autoEnt = new Auto
            {
                naamAuto = auto.naamAuto,
                kilometerstand = auto.kilometerstand,
                publicatieJaar = auto.publicatieJaar,
                startAdres = auto.startAdres,
                eindAdres = auto.eindAdres,
                beschikbaarheid = auto.beschikbaarheid,
                GebruikerId = auto.GebruikerId
            };

            await _context.Autos.AddAsync(autoEnt);
            await _context.SaveChangesAsync();
            return autoEnt.Id;
        }

        public async Task UpdateAutoAsync(int id, UpdateAuto auto)
        {
            if (id != auto.Id)
                throw new ValidationException("Ids are not corresponding");

            var autoEnt = await _context.Autos.FindAsync(id);
            if (autoEnt == null) throw new Exception("No Auto found");

            autoEnt.naamAuto = auto.naamAuto;
            autoEnt.kilometerstand = auto.kilometerstand;
            autoEnt.publicatieJaar = auto.publicatieJaar;
            autoEnt.startAdres = auto.startAdres;
            autoEnt.eindAdres = auto.eindAdres;
            autoEnt.beschikbaarheid = auto.beschikbaarheid;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutoAsync(int id)
        {
            var auto = await _context.Autos.FindAsync(id);
            if (auto == null) throw new Exception("No Auto found");

            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();
        }
    }
}
