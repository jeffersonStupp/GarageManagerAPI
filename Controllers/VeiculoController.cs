using GarageManager.Models.Validators;
using GarageManager.Models;
using GarageManagerAPI.Data.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using GarageManagerAPI.Data.Repositorio.Validadores;
using GarageManagerAPI.Models;

namespace GarageManagerAPI.Controllers
{
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        public VeiculoRepositorio Repositorio = new VeiculoRepositorio();

        [HttpPost]
        [Route("veiculo/adicionar")]
        [ProducesResponseType(typeof(Veiculo), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AdicionarVeiculo([FromBody] Veiculo veiculo)
        {

            var validator = new VeiculoValidator();
            var validationResult = await validator.ValidateAsync(veiculo);



            if (validationResult.IsValid)
            {
                try
                {

                    await Repositorio.AdicionarVeiculo(veiculo);
                    return Created("", veiculo);

                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
                }
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }



        }

        [HttpPut]
        [Route("veiculo/atualizar")]
        [ProducesResponseType(typeof(Veiculo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Atualizar([FromBody] Veiculo veiculo)
        {
            var validator = new VeiculoValidator();
            var validationResult = await validator.ValidateAsync(veiculo);

            try
            {
                var veiculoAtualizar = await Repositorio.ObterPorVeiculoId(veiculo.Id);
                if (veiculoAtualizar == null)
                    return NotFound("Não foi possível encontrar o cliente");




                veiculoAtualizar.Marca = veiculo.Marca;
                veiculoAtualizar.Modelo = veiculo.Modelo;
                veiculoAtualizar.Ano = veiculo.Ano;
                veiculoAtualizar.Placa = veiculo.Placa;
                veiculoAtualizar.Cor= veiculo.Cor;



                if (validationResult.IsValid)
                {
                    await Repositorio.EditarVeiculo(veiculoAtualizar);

                    return Ok(veiculoAtualizar);
                }
                else { return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage).ToList()); }


            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("veiculo/obterVeiculoId/{id}")]
        [ProducesResponseType(typeof(Veiculo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var veiculo = await Repositorio.ObterPorVeiculoId(id);
                if (veiculo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("veiculo/obterTodos")]
        [ProducesResponseType(typeof(List<Veiculo>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosVeiculos()
        {
            try
            {
                var lista = await Repositorio.ObterTodosVeiculos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

             
       



        [HttpDelete]
        [Route("veiculo/excluir/{id}")]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ExcluirVeiculo(int id)
        {
            try
            {
                var veiculo = await Repositorio.ObterPorVeiculoId(id);
                if (veiculo == null)
                {
                    return NotFound("Veiculo não encontrado");
                }

                await Repositorio.ApagarVeiculo(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
            



    }
}
