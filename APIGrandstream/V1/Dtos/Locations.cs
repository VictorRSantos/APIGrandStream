using System;
using System.Collections.Generic;
using System.Linq;

namespace APIGrandstream.V1.Dtos
{
    public class Locations
    {
        public string Nome { get; set; }
        public DateTime? Hora { get; set; }
        public string CorPainel { get; set; }
        public string CorTexto { get; set; }
        public List<Eventos> Eventos { get; set; } = new List<Eventos>();
        public List<Botao> Botoes { get; set; } = new List<Botao>();

    }
}
