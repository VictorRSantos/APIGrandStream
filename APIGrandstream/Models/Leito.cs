using System.Collections.Generic;

namespace APIGrandstream.Models
{
    public class Leito
    {
        public string Nome { get; set; }
        public string Ramal { get; set; }
        public Evento Evento { get; set; }
        public Botao Botao { get; set; }
        public List<Evento> Eventos { get; set; }
        public List<Botao> Botoes { get; set; }

    }
}
