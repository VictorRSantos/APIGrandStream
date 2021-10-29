using Microsoft.AspNetCore.Mvc;
using PainelWeb.Data.Interface;
using PainelWeb.Models;
using System.Linq;

namespace PainelWeb.Controllers
{
    public class HomeController : Controller
    {

        private IPainelViewModel _painelViewModel;
        Evento eventoAtual;

        public HomeController(IPainelViewModel painelViewModel)
        {

            _painelViewModel = painelViewModel;
            eventoAtual = new Evento();
        }

        public IActionResult Index()
        {
            _painelViewModel.Leitos = _painelViewModel.ListaDeLocaisAndares();


            return View(_painelViewModel);
        }


        [HttpPost]
        public IActionResult Paciente(string local, string evento)
        {

            eventoAtual = Resultado(local);


            _painelViewModel.SalvarEventos(eventoAtual, evento);


            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Auxilio(string local, string evento)
        {
            eventoAtual = Resultado(local);
            _painelViewModel.SalvarEventos(eventoAtual, evento);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult CodigoAzul(string local, string evento)
        {
            eventoAtual = Resultado(local);
            _painelViewModel.SalvarEventos(eventoAtual, evento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Banheiro(string local, string evento)
        {
            eventoAtual = Resultado(local);
            _painelViewModel.SalvarEventos(eventoAtual, evento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Presenca1(string local, string evento)
        {
            eventoAtual = Resultado(local);
            eventoAtual.Usuario = "Artur";

            _painelViewModel.PresencaEventos(eventoAtual, evento);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Presenca2(string local, string evento)
        {
            eventoAtual = Resultado(local);
            eventoAtual.Usuario = "Hugo";
            _painelViewModel.PresencaEventos(eventoAtual, evento);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cancelar(string local, string evento)
        {
            _painelViewModel.Cancelar(local);

            return RedirectToAction("Index");
        }


        private Evento Resultado(string local)
        {


            var resultado = _painelViewModel.ListaDeLocaisAndares().Where(x => x.Nome == local).FirstOrDefault();

            var evento = resultado.ListaDeEventos.OrderByDescending(x => x.HoraInicio).FirstOrDefault(x => x.Local == local);

            if (evento is null)
            {
                evento = new Evento() { Local = local };

            }


            return evento;
        }
    }
}
