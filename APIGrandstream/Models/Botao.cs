namespace APIGrandstream.Models
{
    public class Botao
    {
        public int? Id { get; set; }
        public int? IdConfigEvento { get; set; }
        public string Texto { get; set; }
        public string Icone { get; set; }
        public string Acao { get; set; }
        public int Complemento { get; set; }
        public ConfigEventos ConfigEventos { get; set; }
    }
}
