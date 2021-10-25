using APIGrandstream.Models;
using System;
using System.Collections.Generic;

namespace APIGrandstream.V1.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdElise { get; set; }
        public int IdAndar { get; set; }
        public int Ramal { get; set; }
        public Evento Evento { get; set; }
        public Botao Botao { get; set; }
        public List<Eventos> Eventos { get; set; } = new List<Eventos>();

       
       
    }
}
