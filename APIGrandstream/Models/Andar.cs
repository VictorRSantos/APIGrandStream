using APIGrandstream.V1.Dtos;
using System.Collections.Generic;

namespace APIGrandstream.Models
{
    public class Andar
    {
        public string NomePosto { get; set; }
        public string Console { get; set; }
        public int Led { get; set; }
        public string Audio { get; set; }

        public List<Locations> Leitos { get; set; } = new List<Locations>();
    }
}
