using APIGrandstream.V1.Models;
using System.Collections.Generic;

namespace APIGrandstream.Models
{
    public class Andares
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomePainel { get; set; }
        public string Console { get; set; }
        public Locations Locations { get; set; } 
        public List<Locations> Leitos { get; set; } = new List<Locations>();
    }
}
