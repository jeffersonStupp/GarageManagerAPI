using GarageManager.Models.Validators;
using GarageManager.Models;
using GarageManagerAPI.Data.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GarageManagerAPI.Data.Repositorio.Validadores;
using GarageManagerAPI.Models;

namespace GarageManagerAPI.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoRepositorio Repositorio = new ProdutoRepositorio();

        [HttpPost]
        [Route("produto/adicionar")]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
        {
            var validator = new ProdutoValidator();
            var validationResult = await validator.ValidateAsync(produto);

            if (validationResult.IsValid)
            {
                try
                {
                    await Repositorio.AdicionarProduto(produto);
                    return Created("", produto);

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
        [Route("produto/atualizar")]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AtualizarProduto([FromBody] Produto produto)
        {
            var validator = new ProdutoValidator();
            var validationResult = await validator.ValidateAsync(produto);

            try
            {
                var produtoAtualizar = await Repositorio.ObterProdutoPorIdAsync(produto.Id);
                if (produtoAtualizar == null)
                    return NotFound("Não foi possível encontrar o produto");

                produtoAtualizar.Codigo = produto.Codigo ?? produtoAtualizar.Codigo;
                produtoAtualizar.Descricao = produto.Descricao ?? produtoAtualizar.Descricao; 
                produtoAtualizar.Grupo = produto.Grupo ?? produtoAtualizar.Grupo;
                produtoAtualizar.Tipo = produto.Tipo ?? produtoAtualizar.Tipo;
                produtoAtualizar.Fabricante = produto.Fabricante ?? produtoAtualizar.Fabricante;
                produtoAtualizar.Fornecedor = produto.Fornecedor ?? produtoAtualizar.Fornecedor;
                produtoAtualizar.Preco = produto.Preco;
                produtoAtualizar.Garantia = produto.Garantia;

                if (validationResult.IsValid)
                {
                    await Repositorio.EditarProduto(produtoAtualizar);

                    return Ok(produtoAtualizar);
                }
                else { return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage).ToList()); }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        [HttpGet]
        [Route("produto/obterporid/{id}")]
        [ProducesResponseType(typeof(Produto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterProdutoPorId(int id)
        {
            try
            {
                var produto = await Repositorio.ObterProdutoPorIdAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(produto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        [HttpGet]
        [Route("produto/obtertodos")]
        [ProducesResponseType(typeof(List<Produto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTodosProdutos()
        {
            try
            {
                var listaProdutos = await Repositorio.ObterTodoProdutosAsync();
                return Ok(listaProdutos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        [HttpDelete]
        [Route("produto/excluir/{id}")]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            try
            {
                var produto = await Repositorio.ObterProdutoPorIdAsync(id);
                if (produto == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                await Repositorio.ApagarProduto(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
