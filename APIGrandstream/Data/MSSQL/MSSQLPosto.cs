using APIGrandstream.Models;
using APIGrandstream.V1.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGrandstream.Data.MSSQL
{
    public class MSSQLPosto : IPostoDb
    {
        private readonly GrandstreamContext _context;

        public MSSQLPosto(GrandstreamContext context)
        {
            _context = context;
        }

        public async Task<List<Andares>> Posto_Andares_Locais()
        {
            var sql = @"SELECT 
                              A.Id
                             ,A.Nome
                             ,A.NomePainel
                             ,A.Console 
                             ,LC.Id 
                             ,LC.IdElise
                             ,LC.IdAndar
                             ,LC.Nome
                             ,LC.Ramal                             
                            FROM Locations LC
                            JOIN Andares A ON A.Id = LC.IdAndar
                            WHERE
                            a.Console = '12'
                            ORDER BY
                            A.Nome";

            using (SqlConnection banco = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {

                try
                {


                    var lista = (await banco.QueryAsync<Andares, Locations, Andares>(sql, (andares, locations) =>
                    {

                        andares.Locations = locations;


                        return andares;

                    }, splitOn: "Id")).ToList();


                    return lista;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return new List<Andares>();
                }



            }


        }

        public async Task<List<Andares>> Posto_Andares_Locais_Por_Console(string console)
        {
            var sql = $@"SELECT 
                              A.Id
                             ,A.Nome
                             ,A.NomePainel
                             ,A.Console 
                             ,LC.Id 
                             ,LC.IdElise
                             ,LC.IdAndar
                             ,LC.Nome
                             ,LC.Ramal                             
                            FROM Locations LC
                            JOIN Andares A ON A.Id = LC.IdAndar
                            WHERE
                            a.Console = '{console}'
                            ORDER BY
                            A.Nome";

            using (SqlConnection banco = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {

                try
                {


                    var lista = (await banco.QueryAsync<Andares, Locations, Andares>(sql, (andares, locations) =>
                    {
                        andares.Locations = locations;
                        andares.Leitos.Add(locations);
                       
                        return andares;

                    }, splitOn: "Id")).ToList();

                    
                    return lista;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return new List<Andares>();
                }



            }
        }

        public async Task<List<Eventos>> Posto_Eventos_ConfigEventos_Botoes()
        {
            var sql = @"SELECT
       EV.Id
      ,EV.IdElise
      ,EV.HoraInicio
	  ,EV.HoraFim	   
	  ,EV.HoraInsert	   
	  ,EV.Dispositivo	   	   
	  ,EV.Local
	  ,EV.TextoEvento
	  ,EV.Usuario
	  ,EV.MotivoFim
	  ,EV.Tracelogid
      ,EV.Tipo
	  ,BT.Id
	  ,BT.IdConfigEvento
	  ,BT.Texto
	  ,BT.Icone
	  ,BT.Acao	 
	  ,CE.IdConfigEvento	   
      ,CE.Prioridade
      ,CE.Evento
	  ,CE.NomeExibicao
      ,CE.CorPainel
      ,CE.CorTexto
      ,CE.Icone
      ,CE.Som
FROM Eventos EV
JOIN ConfigEventos CE ON CE.Evento = EV.Tipo
JOIN Botoes BT ON BT.IdConfigEvento = CE.IdConfigEvento
WHERE
HoraFim IS NULL";


            /*WHERE
                    HoraFim IS NULL  AND EV.HoraInicio >  DATEADD(HOUR, -15, GETDATE())
             */


            using (SqlConnection banco = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {


                try
                {


                    var lista = (await banco.QueryAsync<Eventos, Botao, ConfigEventos, Eventos >(sql, (eventos,botao, configEventos) =>
                     {

                         eventos.Botao = botao;
                         eventos.Botao.ConfigEventos = configEventos;
                        
                         return eventos;

                     },splitOn: "Tipo,IdConfigEvento")).ToList();

                    return lista;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return new List<Eventos>();
                    
                }


            }
        }
    }
}
