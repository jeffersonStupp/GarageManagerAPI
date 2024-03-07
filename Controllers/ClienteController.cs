
using GarageManager.Database.Repositorio;
using GarageManager.Models;
using GarageManager.Models.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GarageManager.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public ClienteRepositorio Repositorio = new ClienteRepositorio();

        [HttpPost]
        [Route("cliente/adicionar")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Adicionar([FromBody] Cliente cliente)
        {

            var validator = new ClienteValidator();
            var validationResult = await validator.ValidateAsync(cliente);

                    
            if (validationResult.IsValid)
            {
                try
                {
                    await Repositorio.AddAsync(cliente);
                    return Created("", cliente);

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
        [Route("cliente/atualizar")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Atualizar([FromBody] Cliente cliente)
        {
            var validator = new ClienteValidator();
            var validationResult = await validator.ValidateAsync(cliente);

            try
            {
                var clienteAtualizar = await Repositorio.ObterPorIdAsync(cliente.Id);
                if (clienteAtualizar == null)
                    return NotFound("Não foi possível encontrar o cliente");




                clienteAtualizar.Nome = cliente.Nome ?? clienteAtualizar.Nome;
                clienteAtualizar.DataNascimento = cliente.DataNascimento != default ? cliente.DataNascimento : clienteAtualizar.DataNascimento;
                clienteAtualizar.Cpf = cliente.Cpf ?? clienteAtualizar.Cpf;
                clienteAtualizar.Email = cliente.Email ?? clienteAtualizar.Email;
                clienteAtualizar.Celular = cliente.Celular ?? clienteAtualizar.Celular;
                clienteAtualizar.Telefone = cliente.Telefone ?? clienteAtualizar.Telefone;
                clienteAtualizar.Rua = cliente.Rua ?? clienteAtualizar.Rua;
                clienteAtualizar.Numero = cliente.Numero ?? clienteAtualizar.Numero;
                clienteAtualizar.Bairro = cliente.Bairro ?? clienteAtualizar.Bairro;
                clienteAtualizar.Cidade = cliente.Cidade ?? clienteAtualizar.Cidade;
                clienteAtualizar.Estado = cliente.Estado ?? clienteAtualizar.Estado;
                clienteAtualizar.Obs = cliente.Obs ?? clienteAtualizar.Obs;
                clienteAtualizar.Situacao = cliente.Situacao ?? clienteAtualizar.Situacao;
                if (validationResult.IsValid)
                {
                    await Repositorio.EditAsync(clienteAtualizar);

                    return Ok(clienteAtualizar);
                }
                else { return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage).ToList()); }


            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("cliente/obterporid/{id}")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var cliente = await Repositorio.ObterPorIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("cliente/obter")]
        [ProducesResponseType(typeof(List<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var lista = await Repositorio.ObterTodosAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }



        [HttpGet]
        [Route("cliente/obterPendentes")]
        [ProducesResponseType(typeof(List<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosPendentes()
        {
            try
            {
                var lista = await Repositorio.ObterTodosPendentesAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        [HttpGet]
        [Route("cliente/obterBloqueados")]
        [ProducesResponseType(typeof(List<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosBloqueados()
        {
            try
            {
                var lista = await Repositorio.ObterTodosBloqueadosAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }




        [HttpDelete]
        [Route("cliente/excluir/{id}")]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var cliente = await Repositorio.ObterPorIdAsync(id);
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                await Repositorio.DelAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("cliente/buscacep/{cep}")]
        public async Task<IActionResult> BuscaCep(string cep)
        {
            try
            {
                using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) })
                {
                    using (var message = new HttpRequestMessage())
                    {
                        message.RequestUri = new Uri($"https://viacep.com.br/ws/{cep}/json");
                        message.Method = new HttpMethod("get");

                        var response = await httpClient.SendAsync(message);

                        if (!response.IsSuccessStatusCode)
                        {
                            return NotFound("Não foi possível encontrar os dados com o CEP informado");
                        }

                        var jsonRetorno = await response.Content.ReadAsStringAsync();

                        var objetoViaCep = JsonConvert.DeserializeObject<ViaCep>(jsonRetorno);

                        return Ok(objetoViaCep);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        [HttpPut]
        [Route("cliente/atualizarObs")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AtualizarObs([FromBody] Cliente cliente)
        {


            try
            {
                var clienteAtualizar = await Repositorio.ObterPorIdAsync(cliente.Id);
                if (clienteAtualizar == null)
                    return NotFound("Não foi possível encontrar o cliente");


                clienteAtualizar.Obs = cliente.Obs ?? clienteAtualizar.Obs;


                await Repositorio.EditAsync(clienteAtualizar);

                return Ok(clienteAtualizar);



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }


        }

        [HttpPut]
        [Route("cliente/excluirObs")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> excluirOBS([FromBody] Cliente cliente)
        {
            try
            {
                var clienteAtualizar = await Repositorio.ObterPorIdAsync(cliente.Id);
                if (clienteAtualizar == null)
                    return NotFound("Não foi possível encontrar o cliente");
                clienteAtualizar.Obs = null;
                await Repositorio.EditAsync(clienteAtualizar);
                    return Ok(clienteAtualizar);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

       

        [HttpPut]
        [Route("cliente/homologarCliente")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> homologarCliente([FromBody] Cliente cliente)
        {
            

            try
            {
                var clienteAtualizar = await Repositorio.ObterPorIdAsync(cliente.Id);
                if (clienteAtualizar == null)
                    return NotFound("Não foi possível encontrar o cliente");

                clienteAtualizar.Situacao = "Normal";

                await Repositorio.EditAsync(clienteAtualizar);
                return Ok(clienteAtualizar);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPut]
        [Route("cliente/bloquearCliente")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> bloquearCliente([FromBody] Cliente cliente)
        {


            try
            {
                var clienteAtualizar = await Repositorio.ObterPorIdAsync(cliente.Id);
                if (clienteAtualizar == null)
                    return NotFound("Não foi possível encontrar o cliente");

                clienteAtualizar.Situacao = "Bloqueado";

                await Repositorio.EditAsync(clienteAtualizar);
                return Ok(clienteAtualizar);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }


















    }
}
