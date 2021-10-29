using PainelWeb.Models;
using System.Collections.Generic;

namespace PainelWeb.Data.Interface
{
    public interface IEventoDb
    {
        List<Locations> ListaDeLocaisAndaresEventos();
        List<Locations> ListaDeLocaisAndares();
        List<Evento> Eventos();
        bool SalvarEventos(Evento locations, string eventoSelecionado);
        bool PresencaEventos(Evento evento, string eventoSelecionado);
        bool Cancelar(string local);
        
    }
}
