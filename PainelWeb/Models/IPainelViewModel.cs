using PainelWeb.Data.Interface;
using System.Collections.Generic;

namespace PainelWeb.Models
{
    public interface IPainelViewModel : IEventoDb
    {
        List<Locations> Leitos { get; set; }
        long Tempo { get; set; }      

        public string UsuarioAleatorios();
    }
}