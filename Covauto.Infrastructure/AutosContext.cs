using Covauto.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Infrastructure
{
    public class AutosContext : DbContext
    {
        public AutosContext(DbContextOptions<AutosContext> options) : base(options)
        { }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Auto> Autos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Schrijver>().HasData(new Schrijver { Id = 1, Naam = "Mark J. Prijs" });
            modelBuilder.Entity<Schrijver>().HasData(new Schrijver { Id = 2, Naam = "Joseph Albahari" });
            modelBuilder.Entity<Boek>().HasData(new Boek { Id = 1, SchrijverId = 1, Titel = "C# 8.0 and .NET Core 3.0", Publicatiejaar = 2023, AantalBladzijden = 200 });
            modelBuilder.Entity<Boek>().HasData(new Boek { Id = 2, SchrijverId = 2, Titel = "C# 8.0 Pocket-referentie", Publicatiejaar = 2023, AantalBladzijden = 100 });


        }
    }
}