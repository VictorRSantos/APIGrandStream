using APIGrandstream.Models;
using APIGrandstream.V1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIGrandstream.Data
{
    public class GrandstreamContext : DbContext
    {

        public GrandstreamContext(DbContextOptions<GrandstreamContext> option) : base(option) { }


        public DbSet<Andares> Andares { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<ConfigEventos> ConfigEventos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Botao> Botao { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Andares>().HasKey(x => x.Id);
            builder.Entity<Locations>().HasKey(x => x.Id);
            builder.Entity<ConfigEventos>().HasKey(x => x.IdConfigEvento);
            builder.Entity<Eventos>().HasKey(x => x.Id);
            builder.Entity<Botao>().HasKey(x => x.Id);         


        }

    }
}
