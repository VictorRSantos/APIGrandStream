using APIGrandstream.Data.Enums;
using APIGrandstream.Data.MSSQL;
using APIGrandstream.Data.MYSQL;
using APIGrandstream.Models;
using System;

namespace APIGrandstream.Data.Factories
{
    public static class PostoFactoryDb
    {
        public static IPostoDb GetPostoDb(Configuracao configuracao, GrandstreamContext context)
        {

            switch (configuracao.TipoBanco)
            {
                case TipoBanco.MSSQL:
                    return new MSSQLPosto(context);
                case TipoBanco.MYSQL:
                    return new MYSQLPosto(configuracao);
                default:
                    throw new ArgumentNullException("Não existe configuração para este tipo de banco");
            }

        }
    }
}
