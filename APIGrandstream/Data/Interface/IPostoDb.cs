using APIGrandstream.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGrandstream.Data
{
    public interface IPostoDb
    {
        Task<List<Andares>> Posto_Andares_Locais();
        Task<List<Andares>> Posto_Andares_Locais_Por_Console(string console);
        Task<List<Eventos>> Posto_Eventos_ConfigEventos_Botoes();
        
    }
}
