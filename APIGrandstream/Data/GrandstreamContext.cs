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


            #region Carga Inicial Banco de Dados
            builder.Entity<Andares>().HasData
                (
                    new Andares { Id = 1, Console = null, Nome = "4 Andar", NomePainel = "Posto 4" },
                    new Andares { Id = 2, Console = null, Nome = "3 Andar", NomePainel = "Posto 3" },
                    new Andares { Id = 3, Console = "12", Nome = "2 Andar", NomePainel = "Posto 2" },
                    new Andares { Id = 4, Console = null, Nome = "5 Andar", NomePainel = "Posto 5" }
                );


            builder.Entity<Locations>().HasData
               (
                   new Locations { Id = 1, IdAndar = 3, IdElise = 1, Nome = "Leito 201", Ramal = 2201 },
                   new Locations { Id = 2, IdAndar = 3, IdElise = 1, Nome = "Leito 202", Ramal = 2201 },
                   new Locations { Id = 3, IdAndar = 3, IdElise = 1, Nome = "Leito 203", Ramal = 2201 },
                   new Locations { Id = 4, IdAndar = 3, IdElise = 1, Nome = "Leito 204", Ramal = 2201 },
                   new Locations { Id = 5, IdAndar = 3, IdElise = 1, Nome = "Leito 205", Ramal = 2201 },
                   new Locations { Id = 6, IdAndar = 3, IdElise = 1, Nome = "Leito 206", Ramal = 2201 },
                   new Locations { Id = 7, IdAndar = 3, IdElise = 1, Nome = "Leito 207", Ramal = 2201 },
                   new Locations { Id = 8, IdAndar = 3, IdElise = 1, Nome = "Leito 208", Ramal = 2201 },
                   new Locations { Id = 9, IdAndar = 3, IdElise = 1, Nome = "Leito 209", Ramal = 2201 },
                   new Locations { Id = 10, IdAndar = 3, IdElise = 1, Nome = "Leito 210", Ramal = 2201 },
                   new Locations { Id = 11, IdAndar = 3, IdElise = 1, Nome = "Leito 211", Ramal = 2201 },
                   new Locations { Id = 12, IdAndar = 3, IdElise = 1, Nome = "Leito 212", Ramal = 2201 },
                   new Locations { Id = 13, IdAndar = 3, IdElise = 1, Nome = "Leito 213", Ramal = 2201 },
                   new Locations { Id = 14, IdAndar = 3, IdElise = 1, Nome = "Leito 214", Ramal = 2201 },
                   new Locations { Id = 15, IdAndar = 3, IdElise = 1, Nome = "Leito 215", Ramal = 2201 },
                   new Locations { Id = 16, IdAndar = 3, IdElise = 1, Nome = "Leito 216", Ramal = 2201 },
                   new Locations { Id = 17, IdAndar = 3, IdElise = 1, Nome = "Leito 217", Ramal = 2201 },
                   new Locations { Id = 18, IdAndar = 3, IdElise = 1, Nome = "Leito 218", Ramal = 2201 },
                   new Locations { Id = 19, IdAndar = 3, IdElise = 1, Nome = "Leito 219", Ramal = 2201 },
                   new Locations { Id = 20, IdAndar = 3, IdElise = 1, Nome = "Leito 220", Ramal = 2201 },
                   new Locations { Id = 21, IdAndar = 3, IdElise = 1, Nome = "Leito 221", Ramal = 2201 }
               );


            builder.Entity<ConfigEventos>().HasData
              (
                  new ConfigEventos { IdConfigEvento = 1, Evento = "CH Paciente", NomeExibicao = "Paciente", CorPainel = "rgba(255,41,5,1)", CorTexto = "rgba(255,255,255,1)", Icone = "fas fa-user-alt", Som = "", Prioridade = 1 },
                  new ConfigEventos { IdConfigEvento = 2, Evento = "CH Auxilio", NomeExibicao = "Auxilio", CorPainel = "rgba(255,255,13,1)", CorTexto = "rgba(255,255,255,1)", Icone = "fas fa-user-friends", Som = "", Prioridade = 2 },
                  new ConfigEventos { IdConfigEvento = 3, Evento = "CH Azul", NomeExibicao = "Cod. Azul", CorPainel = "rgba(64,189,255,1)", CorTexto = "rgba(255,255,255,1)", Icone = "fas fa-heartbeat", Som = "", Prioridade = 5 },
                  new ConfigEventos { IdConfigEvento = 4, Evento = "Ch Toilete", NomeExibicao = "Banheiro", CorPainel = "rgba(255,69,0,1)", CorTexto = "rgba(255,255,255,1)", Icone = "fab fa-accessible-icon", Som = "", Prioridade = 1 },
                  new ConfigEventos { IdConfigEvento = 5, Evento = "Presenca", NomeExibicao = "Presenca", CorPainel = "rgba(0,255,0,1)", CorTexto = "rgba(255,255,255,1)", Icone = "fas fa-user-alt", Som = "", Prioridade = 1 }
              );




            builder.Entity<Eventos>().HasData
             (
                new Eventos { Id = 8, IdElise = 1, HoraInicio = Convert.ToDateTime("2021-10-22 05:00:07.387"), HoraFim = DateTime.MinValue, HoraInsert = DateTime.MinValue, Dispositivo = "1", Local = "Leito 201", TextoEvento = "CH Paciente", Usuario = "Victor", MotivoFim = null, Tracelogid = null, Tipo = "CH Paciente" },
                new Eventos { Id = 9, IdElise = 1, HoraInicio = Convert.ToDateTime("2021-10-22 05:00:07.387"), HoraFim = DateTime.MinValue, HoraInsert = DateTime.MinValue, Dispositivo = "2", Local = "Leito 202", TextoEvento = "Presenca", Usuario = "Artur", MotivoFim = null, Tracelogid = null, Tipo = "CH Paciente" },
                new Eventos { Id = 10, IdElise = 1, HoraInicio = Convert.ToDateTime("2021-10-22 05:00:00.000"), HoraFim = DateTime.MinValue, HoraInsert = DateTime.MinValue, Dispositivo = "2", Local = "Leito 202", TextoEvento = "Presenca", Usuario = "Andre", MotivoFim = null, Tracelogid = null, Tipo = "CH Paciente" }

                );



            builder.Entity<Botao>().HasData
             (

                new Botao { Id = 1, IdConfigEvento = 1, Texto = "Ligar", Icone = "Ligar", Acao = "Ligar" },
                new Botao { Id = 2, IdConfigEvento = 2, Texto = "Ligar", Icone = "Ligar", Acao = "Ligar" },
                new Botao { Id = 3, IdConfigEvento = 3, Texto = "Ligar", Icone = "Ligar", Acao = "Ligar" },
                new Botao { Id = 4, IdConfigEvento = 4, Texto = "Ligar", Icone = "Ligar", Acao = "Ligar" },
                new Botao { Id = 5, IdConfigEvento = 1, Texto = "Guest", Icone = "Guest", Acao = "Guest" },
                new Botao { Id = 6, IdConfigEvento = 2, Texto = "TRR", Icone = "TRR", Acao = "TRR" }

                );







            #endregion


        }

    }
}
