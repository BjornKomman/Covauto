using Covauto.Applicatie.Interfaces;
using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Covauto.Applicatie.Repositories.AutosRepository;
using Covauto.Applicatie.DTO.Auto;
using Covauto.Shared.DTO.Auto;
using Covauto.Infrastructure.Data;

namespace Covauto.Applicatie.Repositories
{
        public class AutosRepository : IAutosRepository
        {
            private readonly AutosContext covautoContext;

            public AutosRepository(AutosContext covautoContext)
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
            Auto? auto = await covautoContext.Autos.SingleOrDefaultAsync(n => n.Id == id);
            return MapAuto(auto);
        }

        public async Task<int> CreateAutoAsync(CreateAuto auto)
        {
            // Ensure the 'Gebruikers' DbSet exists in the AutosContext class.  
            if (!await covautoContext.Set<Gebruiker>().AnyAsync(b => b.Id == auto.GebruikerId))
            {
                throw new Exception("Not a correct GebruikerId");
            }

            var autoEnt = new Auto
            {
                naamAuto = auto.naamAuto,
                kilometerstand = auto.kilometerstand,
                publicatieJaar = auto.publicatieJaar,
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
                    beschikbaarheid = auto.beschikbaarheid,
                };
            }
        }
}
