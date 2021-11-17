using PainelWeb.Data.Enums;
using PainelWeb.Data.Interface;
using PainelWeb.Data.MSSQL;
using PainelWeb.Data.MYSQL;
using System;

namespace PainelWeb.Data.Factory
{
    public static class EventosFactoryDb
    {
        public static IEventoDb GetEventoDb(ConexaoBanco conexaoBanco)
        {
            switch (conexaoBanco.TipoBanco)
            {
                case TipoBanco.MSSQL:
                    return new MSSQLEventos(conexaoBanco);
                case TipoBanco.MYSQL:
                    return new MYSQLEventos(conexaoBanco);
                default:
                    throw new ArgumentNullException("Não existe configuração para este tipo de banco");
            }
        }
    }
}
