using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Applicatie.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Covauto.Applicatie.Repositories.AutosRepository;
using Covauto.Applicatie.DTO.Auto;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Applicatie.Repositories
{
    public class AutosRepository
    {
        public class AutoRepository : IAutosRepository
        {
            private readonly AutosContext covautoContext;

            public AutoRepository(AutosContext covautoContext)
            {
                this.covautoContext = covautoContext;
            }

            public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
            {
                return await covautoContext
                    .Autos
                    .Select(static a => new AutoListItem
                    {
                        Id = a.Id,
                        naamAuto = a.naamAuto,
                        beschikbaarheid = a.beschikbaarheid
                    }).ToListAsync();
            }

            public async Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto)
            {
                return await covautoContext
                    .Autos
                    .Where(a => a.naamAuto.Contains(naamAuto, StringComparison.CurrentCultureIgnoreCase))
                    .Select(a => new AutoListItem()
                    {
                        Id = a.Id,
                        naamAuto = a.naamAuto,
                        beschikbaarheid = a.beschikbaarheid
                    }).ToListAsync();
            }

            public async Task<FullAuto?> GeefAuto(int id)
            {
                Auto? auto = await covautoContext.Autos.Include(a => a.GebruikerId).SingleOrDefaultAsync(n => n.Id == id);
                return MapAuto(auto);
            }

            public async Task<int> CreateAutoAsync(CreateAuto auto)
            {
                if (!await covautoContext.Gebruikers.AnyAsync(b => b.Id == auto.GebruikerId))
                {
                    throw new Exception("Not a correct GebruikerId");
                }

                var autoEnt = new Auto
                {
                    naamAuto = auto.naamAuto,
                    kilometerstand = auto.kilometerstand,
                    publicatieJaar = auto.publicatieJaar,
                    startAdres = auto.startAdres,
                    eindAdres = auto.eindAdres,
                    beschikbaarheid = auto.beschikbaarheid,
                };

                await covautoContext.Autos.AddAsync(autoEnt);

                await covautoContext.SaveChangesAsync();
                return autoEnt.Id;
            }

            public async Task UpdateAutoAsync(int id, UpdateAuto auto)
            {
                if (id != auto.Id)
                {
                    throw new ValidationException("Ids are not corresponding");
                }

                if (!await covautoContext.Autos.AnyAsync(n => n.Id == auto.GebruikerId))
                {
                    throw new Exception("Not a correct GebruikerId");
                }

                Auto? autoEnt = await covautoContext.Autos.SingleOrDefaultAsync(n => n.Id == id);

                if (autoEnt == null)
                {
                    throw new Exception("No Auto found");
                }
                MapAuto(autoEnt, auto);

                await covautoContext.SaveChangesAsync();
            }

            public async Task DeleteAutoAsync(int id)
            {
                var auto = await covautoContext.Autos.FindAsync(id);
                if (auto == null)
                    throw new Exception("No Auto found");
                covautoContext.Autos.Remove(auto);
                await covautoContext.SaveChangesAsync();
            }

            public void MapAuto(Auto autoEnt, UpdateAuto auto)
            {
                autoEnt.naamAuto = auto.naamAuto;
                autoEnt.kilometerstand = auto.kilometerstand;
                autoEnt.publicatieJaar = auto.publicatieJaar;
                autoEnt.startAdres = auto.startAdres;
                autoEnt.eindAdres = auto.eindAdres;
                autoEnt.beschikbaarheid = auto.beschikbaarheid;
            }

            public FullAuto? MapAuto(Auto? auto)
            {
                if (auto == null) return null;
                return new FullAuto()
                {
                    naamAuto = auto.naamAuto,
                    kilometerstand = auto.kilometerstand,
                    Publicatiejaar = auto.publicatieJaar,
                    startAdres = auto.startAdres,
                    eindAdres = auto.eindAdres,
                    beschikbaarheid = auto.beschikbaarheid,
                };
            }
        }
    }
}
