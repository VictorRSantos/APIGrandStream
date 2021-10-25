using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGrandstream.V1.Dtos
{
    public class Botao
    {
        public int? Id { get; set; }       
        public string Texto { get; set; }
        public string Icone { get; set; }
        public string Acao { get; set; }
        public string Complemento { get; set; }
    }
}
