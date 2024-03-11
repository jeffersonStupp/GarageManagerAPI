using GarageManagerAPI.Data.Repositorio;
using GarageManagerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagerAPI.Controllers
{
    
    [ApiController]
    public class ParametrizacaoController : ControllerBase
    {
        public ParametrizacaoRepositorio Repositorio = new ParametrizacaoRepositorio();

        [HttpGet]
        [Route("parametros/obter")]

        public IActionResult ObterParametros()
        {
            var parametros =Repositorio.ObterParametros();
            return(Ok(parametros));
        }


        [HttpPut]
        [Route("parametros/alterar")]
        public IActionResult AlterarParametros([FromBody]Parametrizacao parametros)
        {
            var novosParametros = Repositorio.ObterParametros();

            novosParametros.HomologacaoDireta = parametros.HomologacaoDireta;
            novosParametros.IdadeMinimaCadastro = parametros.IdadeMinimaCadastro;
            novosParametros.IdadeMaximaCadastro = parametros.IdadeMaximaCadastro;



            Repositorio.AlterarParametros(novosParametros);
            return Ok(novosParametros);





        }


























    }
}
