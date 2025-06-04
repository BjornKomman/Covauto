using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Covauto.Domain;
using Microsoft.EntityFrameworkCore;




namespace Covauto.Infrastructure.Data
{
    public class AutosContext : DbContext
    {
        public AutosContext(DbContextOptions<AutosContext> options) : base(options) { }

        public Auto Auto { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Rit> Ritten { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gebruiker>().HasData(new Gebruiker { Id = 1, Naam = "Mark J. Prijs" });
            modelBuilder.Entity<Gebruiker>().HasData(new Gebruiker { Id = 2, Naam = "Joseph Albahari" });
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 1,
                GebruikerId = 1,
                naamAuto = "BMW",
                kilometerstand = 2023,
                startAdres = "Koeweide",
                eindAdres = "alweer koeweide",
                beschikbaarheid = true,
            });
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 2,
                GebruikerId = 2,
                naamAuto = "BMW2",
                kilometerstand = 2022223,
                startAdres = "Schaapweide",
                eindAdres = "alweer Schaapweide",
                beschikbaarheid = true,
            });
        }
    }
}