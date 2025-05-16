using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covauto.Applicatie.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Boeken;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Covauto.Applicatie.Repositories.AutosRepository;

namespace Covauto.Applicatie.Repositories
{
    public class AutosRepository
    {
        public class AutosRepository : IAutosRepository
        {
            private readonly CovautoContext covautoContext;

            public AutosRepository(CovautoContext covautoContext)
            {
                this.covautoContext = covautoContext;
            }

            public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
            {
                return await covautoContext
                    .Autos
                    .Select(static a => new AutoListItem
                    {
                        ID = a.Id,
                        NaamAuto = a.naamAuto,
                        Beschikbaarheid = a.beschikbaarheid
                    }).ToListAsync();
            }

            public async Task<IEnumerable<AutoListItem>> ZoekAutosAsync(string naamAuto)
            {
                return await covautoContext
                    .Autos
                    .Where(a => a.NaamAuto.Contains(naamAuto, StringComparison.CurrentCultureIgnoreCase))
                    .Select(a => new AutoListItem()
                    {
                        ID = a.Id,
                        NaamAuto = a.naamAuto,
                        Beschikbaarheid = a.beschikbaarheid
                    }).ToListAsync();
            }

            public async Task<FullAuto?> GeefAuto(int id)
            {
                Auto? auto = await covautoContext.Autos.Include(a => a.Geberuiker).SingleOrDefaultAsync(n => n.Id == id);
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
                    Publicatiejaar = auto.Publicatiejaar,
                    startAdres = auto.startAdres,
                    eindAdres = auto.eindAdres,
                    beschikbaarheid = auto.beschikbaarheid,
                };

                await covautoContext.Boeken.AddAsync(autoEnt);

                await covautoContext.SaveChangesAsync();
                return autoEnt.Id;
            }

            public async Task UpdateBoekAsync(int id, UpdateAuto auto)
            {
                if (id != auto.Id)
                {
                    throw new ValidationException("Ids are not corresponding");
                }

                if (!await covautoContext.Schrijvers.AnyAsync(n => n.Id == auto.GebruikerId))
                {
                    throw new Exception("Not a correct GebruikerId");
                }

                Auto? autoEnt = await covautoContext.Boeken.SingleOrDefaultAsync(n => n.Id == id);

                if (autoEnt == null)
                {
                    throw new Exception("No Boek found");
                }
                MapBoek(autoEnt, auto);

                await covautoContext.SaveChangesAsync();
            }

            public async Task DeleteBoekAsync(int id)
            {
                var auto = await covautoContext.Boeken.FindAsync(id);
                if (auto == null)
                    throw new Exception("No Auto found");
                covautoContext.Autos.Remove(auto);
                await covautoContext.SaveChangesAsync();
            }

            private static void MapBoek(Auto autoEnt, UpdateAuto auto)
            {
                autoEnt.naamAuto = auto.naamAuto,
                autoEnt.kilometerstand = auto.kilometerstand,
                autoEnt.Publicatiejaar = auto.Publicatiejaar,
                autoEnt.startAdres = auto.startAdres,
                autoEnt.eindAdres = auto.eindAdres,
                autoEnt.beschikbaarheid = auto.beschikbaarheid,
            }

            private static FullAuto? MapAuto(Auto? auto)
            {
                if (auto == null) return null;
                return new FullAuto()
                {
                    naamAuto = auto.naamAuto,
                    kilometerstand = auto.kilometerstand,
                    Publicatiejaar = auto.Publicatiejaar,
                    startAdres = auto.startAdres,
                    eindAdres = auto.eindAdres,
                    beschikbaarheid = auto.beschikbaarheid,
                };
            }
        }
    }
}
