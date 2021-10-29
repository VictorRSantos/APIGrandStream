using System.Collections.Generic;

namespace PainelWeb.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdElise { get; set; }
        public int IdAndar { get; set; }
        public int Ramal { get; set; }
        public Evento Evento { get; set; }
        public Andares Andares { get; set; }
        public List<Evento> ListaDeEventos { get; set; } = new List<Evento>();

    }
}
