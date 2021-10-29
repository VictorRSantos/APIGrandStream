using Dapper;
using PainelWeb.Data.Interface;
using PainelWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PainelWeb.Data.MSSQL
{
    public class MSSQLEventos : IEventoDb
    {
        private readonly string _conexao;

        public MSSQLEventos(ConexaoBanco conexaoBanco)
        {
            _conexao = conexaoBanco.Conexao;
        }

        public bool Cancelar(string local)
        {
            var sql = $@"UPDATE Eventos SET HoraFim = GETDATE() WHERE HoraFim IS NULL AND Local = @Local";

            using (var banco = new SqlConnection(_conexao))
            {

                try
                {

                    banco.Execute(sql, new {Local = local });

                    return true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }


        }

        public List<Evento> Eventos()
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
	  ,CE.IdConfigEvento	   
      ,CE.Prioridade
      ,CE.Evento
	  ,CE.NomeExibicao
      ,CE.CorPainel
      ,CE.CorTexto
      ,CE.Icone
      ,CE.Som
FROM Eventos EV
LEFT JOIN ConfigEventos CE ON CE.Evento = EV.Tipo
WHERE
HoraFim IS NULL";


            using (SqlConnection banco = new SqlConnection(_conexao))
            {

                try
                {

                    var lista = banco.Query<Evento, ConfigEventos, Evento>(sql, (eventos, configEventos) =>
                    {


                        eventos.Botao.ConfigEventos = configEventos;

                        return eventos;

                    }, splitOn: "Tipo,IdConfigEvento").ToList();

                    return lista;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return new List<Evento>();

                }


            }
        }

        public List<Locations> ListaDeLocaisAndares()
        {
            var sql = @"SELECT                              
                              LC.Id 
                             ,LC.IdElise
                             ,LC.IdAndar
                             ,LC.Nome
                             ,LC.Ramal
                             ,A.Id
                             ,A.Nome
                             ,A.NomePainel
                             ,A.Console		 
                            FROM Locations LC
                            JOIN Andares A ON A.Id = LC.IdAndar                          				
                            ORDER BY A.Nome";

            using (var banco = new SqlConnection(_conexao))
            {

                try
                {
                    var lista = banco.Query<Locations, Andares, Locations>(sql, (locations, andares) =>
                    {
                        locations.Andares = andares;

                        return locations;

                    }).ToList();




                    foreach (var item in lista)
                    {
                       
                        var listaDeEventos = Eventos().Where(x => x.Local.ToUpper().Trim().Equals(item.Nome.ToUpper().Trim())).ToList();

                        if (listaDeEventos.Count > 0)
                        {
                            foreach (var evento in listaDeEventos)
                            {

                                item.ListaDeEventos.Add(evento);
                            }


                        }


                    }



                    return lista;
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    return new List<Locations>();

                }
            }
        }

        public List<Locations> ListaDeLocaisAndaresEventos()
        {
            var sql = @"SELECT                              
                              LC.Id 
                             ,LC.IdElise
                             ,LC.IdAndar
                             ,LC.Nome
                             ,LC.Ramal
                             ,A.Id
                             ,A.Nome
                             ,A.NomePainel
                             ,A.Console 
							 ,E.[Id]
							 ,E.[IdElise]
							 ,E.[HoraInicio]
							 ,E.[HoraFim]
							 ,E.[Dispositivo]
							 ,E.[Local]
							 ,E.[TextoEvento]
							 ,E.[Usuario]
							 ,E.[HoraInsert]
							 ,E.[MotivoFim]
							 ,E.[tracelogid]
							 ,E.[Tipo]							 
                            FROM Locations LC
                            JOIN Andares A ON A.Id = LC.IdAndar
                            LEFT JOIN Eventos E ON E.Local = LC.Nome						
                            ORDER BY
                            A.Nome";


            using (var banco = new SqlConnection(_conexao))
            {

                try
                {
                    var lista = banco.Query<Locations, Andares, Evento, Locations>(sql, (locations, andares, eventos) =>
                            {
                                locations.Andares = andares;
                                locations.Evento = eventos;
                                return locations;

                            }).ToList();


                    return lista;
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    return new List<Locations>();

                }
            }
        }

        public bool PresencaEventos(Evento evento, string eventoSelecionado)
        {
            var sqlUpdate = $@"UPDATE Eventos SET HoraFim = GETDATE() WHERE HoraFim IS NULL AND Local = @Local AND Usuario = @Usuario OR Usuario is NULL ";

            var sqlInsert = $@"INSERT INTO EVENTOS (IdElise, HoraInicio, Dispositivo, Local, TextoEvento, Usuario, HoraInsert, Tipo)
                               VALUES
                               (1, GetDate(), 1, @Local, @TextoEvento, @Usuario, GetDate(), @Tipo)";


            using (var banco = new SqlConnection(_conexao))
            {
                try
                {
                    if (evento != null)
                    {
                        var resultadoUpdate = banco.Execute(sqlUpdate, new { Local = evento.Local, Usuario = evento.Usuario });

                    }

                    var resultadoInsert = banco.Execute(sqlInsert, new { Local = evento.Local, TextoEvento = eventoSelecionado, Usuario = evento is null ? null : evento.Usuario is null ? "" : evento.Usuario, Tipo = eventoSelecionado });

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return false;

                }
            }
        }

        public bool SalvarEventos(Evento evento, string eventoSelecionado)
        {
            var sqlUpdate = $@"UPDATE Eventos SET HoraFim = GETDATE() WHERE HoraFim IS NULL AND Local = @Local";

            var sqlInsert = $@"INSERT INTO EVENTOS (IdElise, HoraInicio, Dispositivo, Local, TextoEvento, HoraInsert, Tipo)
                               VALUES
                               (1, GetDate(), 1, @Local, @TextoEvento, GetDate(), @Tipo)";


            using (var banco = new SqlConnection(_conexao))
            {
                try
                {

                    if (evento != null)
                    {
                        var resultadoUpdate = banco.Execute(sqlUpdate, new { Local = evento.Local});

                    }



                    var resultadoInsert = banco.Execute(sqlInsert, new {Local = evento.Local, TextoEvento = eventoSelecionado, Tipo = eventoSelecionado });



                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return false;

                }
            }




        }
    }
}
