using APIGrandstream.Data;
using APIGrandstream.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APIGrandstream.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostoController : ControllerBase
    {
        private readonly IPostoDb _postoDb;
        public PostoController(IPostoDb postoDb)
        {
            _postoDb = postoDb;

        }

      
        [HttpGet("{console}")]
        public async Task<IActionResult> Get(string console)
        {
            Andar andar = new Andar();


            var posto_Andares_Locais_Por_Console = await _postoDb.Posto_Andares_Locais_Por_Console(console);

            foreach (var item in posto_Andares_Locais_Por_Console)
            {
                andar.Console = item.Console;

                andar.Leitos.Add(ConverterLista(item.Locations));
            }

            var listaEvento = (await _postoDb.Posto_Eventos_ConfigEventos_Botoes());
            var listaBotao = await _postoDb.Posto_Eventos_ConfigEventos_Botoes();

            foreach (var item in andar.Leitos)
            {
                var resultado = (await _postoDb.Posto_Eventos_ConfigEventos_Botoes()).Where(x => x.Local.ToUpper().Trim().Equals(item.Nome.ToUpper().Trim())).FirstOrDefault();
                var ramal = posto_Andares_Locais_Por_Console.Where(x => x.Locations.Nome.ToUpper().Trim().Equals(item.Nome.ToUpper().Trim())).Select(x => x.Locations.Ramal).FirstOrDefault();
                item.Hora = resultado == null ? null : resultado.HoraInicio;
                item.CorPainel = resultado == null ? "" : resultado.Botao.ConfigEventos.CorPainel;
                item.CorTexto = resultado == null ? "" : resultado.Botao.ConfigEventos.CorTexto;

                if (resultado != null)
                {
                    var lista = listaEvento.Where(x => x.Local.ToUpper().Trim() == item.Nome.ToUpper().Trim()).ToList();
                    var botaoLista = listaBotao.Where(x => x.Botao.IdConfigEvento == resultado.Botao.IdConfigEvento).ToList();

                    var idEvento = 0;
                    var idBotao = 0;

                    foreach (var dto in lista)
                    {
                        if (idEvento != dto.Id)
                        {
                            idEvento = dto.Id;

                            item.Eventos.Add(ConvertEventos(dto));
                        }



                    }

                    foreach (var botao in botaoLista)
                    {
                        if (idBotao != botao.Botao.Id)
                        {
                            idBotao = Convert.ToInt32(botao.Botao.Id);

                            item.Botoes.Add(ConvertBotoes(botao, ramal));

                        }


                    }

                }
                else
                {

                    item.Botoes.Add(ConvertBotoesNull(ramal));

                }

            };


            return Ok(andar);
        }

        [HttpPost]//Console, Acao, Leito
        public async Task<IActionResult> Post([FromBody] EnviarAcao enviarAcao)
        {
            

            return Ok(enviarAcao);
        }

        private Dtos.Botao ConvertBotoesNull(int ramal)
        {
            Dtos.Botao btn = new Dtos.Botao()
            {
                //Id = resultado == null ? null : resultado.Botao.Id,
                Texto = "Ligar",
                Icone = "Ligar",
                Acao = "Ligar",
                Complemento = ramal

            };

            return btn;
        }
                
        private Dtos.Botao ConvertBotoes(Eventos resultado, int ramal)
        {


            Dtos.Botao botao = new Dtos.Botao()
            {
                //Id = resultado == null ? null : resultado.Botao.Id,
                Texto = resultado == null ? "" : resultado.Botao.Texto,
                Icone = resultado == null ? "" : resultado.Botao.Icone,
                Acao = resultado == null ? "" : resultado.Botao.Acao,
                Complemento = ramal

            };

            return botao;

        }

        private Dtos.Eventos ConvertEventos(Eventos resultado)
        {

            Dtos.Eventos dto = new Dtos.Eventos()
            {

                TextoEvento = resultado == null ? null : resultado.Usuario == null ? resultado.TextoEvento : resultado.Usuario,
                Icone = resultado == null ? null : resultado.Botao.ConfigEventos.Icone
            };

            return dto;
        }

        private Dtos.Locations ConverterLista(Models.Locations locations)
        {
            Dtos.Locations dto = new Dtos.Locations()
            {
                Nome = locations.Nome

            };

            return dto;
        }


    }
}
