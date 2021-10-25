using APIGrandstream.Data;
using APIGrandstream.Models;
using AutoMapper;
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


            foreach (var item in andar.Leitos)
            {
                var resultado = (await _postoDb.Posto_Eventos_ConfigEventos_Botoes()).Where(x => x.Local.ToUpper().Trim().Equals(item.Nome.ToUpper().Trim())).FirstOrDefault();

                item.Hora = resultado == null ? null : resultado.HoraInicio;
                item.CorPainel = resultado == null ? "" : resultado.Botao.ConfigEventos.CorPainel;
                item.CorTexto = resultado == null ? "" : resultado.Botao.ConfigEventos.CorTexto;
                if (resultado != null)
                {
                    item.Eventos.Add(ConvertEventos(resultado));
                    item.Botoes.Add(ConvertBotoes(resultado));
                  
                }

            };


            return Ok(andar);
        }

        private Dtos.Botao ConvertBotoes(Eventos resultado)
        {
            Dtos.Botao botao = new Dtos.Botao()
            {
                Id = resultado == null ? null : resultado.Botao.Id,
                Texto = resultado == null ? "" : resultado.Botao.Texto,
                Icone = resultado == null ? "" : resultado.Botao.Icone,
                Acao = resultado == null ? "" : resultado.Botao.Acao

            };

            return botao;

        }

        private Dtos.Eventos ConvertEventos(Eventos resultado)
        {
            Dtos.Eventos dto = new Dtos.Eventos()
            {

                TextoEvento = resultado == null ? null : resultado.TextoEvento,
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
