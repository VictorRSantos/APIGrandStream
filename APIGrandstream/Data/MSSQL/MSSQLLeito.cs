using APIGrandstream.Data.Interface;
using APIGrandstream.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGrandstream.Data.MSSQL
{
    public class MSSQLLeito : ILeitoDb
    {
        private readonly GrandstreamContext _context;

        public MSSQLLeito(GrandstreamContext context)
        {
            _context = context;
        }


        public async Task<List<Leito>> Leitos(string console)
        {
            using (var banco = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {


                var sql = @"SELECT 
                                  LC.Id
                                 ,LC.IdElise
                                 ,LC.IdAndar
                                 ,LC.Nome
                                 ,LC.Ramal
                                 ,A.Id,
                                  A.NomePainel
                                 ,A.Console
                                 ,VV.Id
                                 ,VV.HoraInicio
                                 ,ISNULL(VV.CorPainel,'#104FD') AS CorPainel
                                 ,ISNULL(VV.CorTexto,'#252525') AS CorTexto
                                 ,VV.NomeExibicao
                                 ,VV.Icone
                                 ,VV.Som
                                 ,VV.Prioridade
                                 ,VV.TextoBotao
                                 ,VV.IconeBotao
                                 ,VV.AcaoBotao
                            FROM Locations LC
                            JOIN Andares A ON A.Id = LC.IdAndar
                            LEFT JOIN (
                            SELECT EV.HoraInicio
                            	  ,EV.HoraFim
                            	  ,EV.Local
                            	  ,EV.Usuario
                            	  ,EV.Tipo
                            	  ,CE.NomeExibicao
                                  ,CE.CorPainel
                                  ,CE.CorTexto
                                  ,CE.Icone
                                  ,CE.Som
                                  ,CE.Prioridade
                            	  ,CE.IdConfigEvento	   
                            	  ,BT.Id
                            	  ,BT.Texto AS TextoBotao
                            	  ,BT.Icone AS IconeBotao
                            	  ,BT.Acao AS AcaoBotao
                            FROM Eventos EV
                            JOIN ConfigEventos CE ON CE.Evento = EV.Tipo
                            JOIN Botoes BT ON BT.IdConfigEvento = CE.IdConfigEvento
                            WHERE
                            HoraFim IS NULL AND EV.HoraInicio >  DATEADD(HOUR, -15, GETDATE())) VV ON VV.Local = LC.Nome
                            WHERE
                            a.Console = '12'
                            ORDER BY
                            VV.Prioridade DESC,A.Nome,VV.HoraInicio DESC";
                            
                               
                try
                {

                    var listaLeito = (await banco.QueryAsync<Leito, Evento, Botao, Leito>(sql, (leito, evento, botao) =>
                     {
                         leito.Evento = evento;
                         leito.Botao = botao;
                         return leito;
                     }, splitOn: "LC.Id,A.Id,VV.Id")).ToList();

                                 
                    


                    return listaLeito;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new List<Leito>();
                }

            }
        }
    }
}
