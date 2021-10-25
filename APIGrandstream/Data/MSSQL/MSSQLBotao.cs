using APIGrandstream.Data.Interface;
using APIGrandstream.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGrandstream.Data.MSSQL
{
    public class MSSQLBotao : IBotaoDb
    {
        private readonly GrandstreamContext _grandstream;

        public MSSQLBotao(GrandstreamContext grandstream)
        {
            _grandstream = grandstream;
        }
        public async Task<List<Botao>> Botoes()
        {

            using (var banco = new SqlConnection(_grandstream.Database.GetDbConnection().ConnectionString))
            {
                var sql = "SELECT * FROM Botao";

                return (await banco.QueryAsync<Botao>(sql)).ToList();

            }

        }

        public Task<List<Botao>> BotoesPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Botao> Delete(Botao botao)
        {
            throw new NotImplementedException();
        }

        public Task<Botao> Insert(Botao botao)
        {
            throw new NotImplementedException();
        }

        public Task<Botao> Update(Botao botao)
        {
            throw new NotImplementedException();
        }
    }
}
