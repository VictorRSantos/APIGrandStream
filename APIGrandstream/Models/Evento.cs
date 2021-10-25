using System;

namespace APIGrandstream.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public int IdElise { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime HoraInsert { get; set; }
        public string Dispositivo { get; set; }
        public string Leito { get; set; }
        public string TextoEvento { get; set; }
        public string Usuario { get; set; }
        public string MotivoFim { get; set; }
        public string Tracelogic { get; set; }
        public string Tipo { get; set; }
    }
}
