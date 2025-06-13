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
        

        public DbSet<Auto> Autos { get; set; }
        
       




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 1,
                naamAuto = "BMW",
                kilometerstand = 2023,
                beschikbaarheid = true,
            });
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 2,
                naamAuto = "BMW2",
                kilometerstand = 2022223,
                beschikbaarheid = true,
            });
        }
    }
}