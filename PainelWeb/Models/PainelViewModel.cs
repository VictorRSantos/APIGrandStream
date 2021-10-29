using PainelWeb.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PainelWeb.Models
{
    public class PainelViewModel : IPainelViewModel
    {
        private readonly IEventoDb _eventoDb;
        public PainelViewModel(IEventoDb eventoDb)
        {
            _eventoDb = eventoDb;
        }


        public Evento Evento { get; set; }
        public List<Locations> Leitos { get; set; }

        public long Tempo { get; set; }
      



        #region Metodos


        public List<Evento> Eventos()
        {
            return _eventoDb.Eventos();
        }

        public List<Locations> ListaDeLocaisAndares()
        {
            return _eventoDb.ListaDeLocaisAndares(); ;
        }

        public List<Locations> ListaDeLocaisAndaresEventos()
        {
            return _eventoDb.ListaDeLocaisAndaresEventos();
        }

        public bool SalvarEventos(Evento evento, string eventoSelecionado)
        {
            return _eventoDb.SalvarEventos(evento, eventoSelecionado);
        }

        public bool Cancelar(string local)
        {
            return _eventoDb.Cancelar(local);
        }

        public string UsuarioAleatorios()
        {

            Random random = new Random();

            string[] usuarios =
            {
                "Artur","Hugo"

            };
                      

            var usuarioSelecionado = random.Next(usuarios.Length);
                      

            return usuarios[usuarioSelecionado];


        }

        public bool PresencaEventos(Evento evento, string eventoSelecionado)
        {
            return _eventoDb.PresencaEventos(evento, eventoSelecionado);
        }


        #endregion
    }
}
