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
                NaamAuto = "BMW",
                Kilometerstand = 2023,
                Beschikbaarheid = true,
            });
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 2,
                NaamAuto = "BMW2",
                Kilometerstand = 2022223,
                Beschikbaarheid = true,
            });

            modelBuilder.Entity<Rit>().HasData(new Rit
            {
                Id = 1,
                AutoId = 1,
                GebruikerId = 1,
                BeginAdres = "Hoofdstraat 1, Amsterdam",
                EindAdres = "Laan van Meerdervoort 2, Den Haag",
                BeginKmStand = 10000,
                EindKmStand = 10500,
                Datum = new DateTime(2023, 10, 1)
             


   

    });
        }
    }
}