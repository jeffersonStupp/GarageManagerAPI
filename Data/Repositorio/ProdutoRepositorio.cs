using GarageManager.Database.Contexto;
using GarageManager.Models;
using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageManagerAPI.Data.Repositorio
{
    public class ProdutoRepositorio
    {
        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            using (var banco = new GarageManagerContext())
            {
                await banco.PRODUTOS.AddAsync(produto);
                await banco.SaveChangesAsync();
            }
            return produto;
        }
        public async Task<Produto> EditarProduto(Produto produto)
        {
            using (var banco = new GarageManagerContext())
            {

                banco.PRODUTOS.Update(produto);
                await banco.SaveChangesAsync();
            }
            return produto;
        }
        public async Task ApagarProduto(int id)
        {
            using (var banco = new GarageManagerContext())
            {
                var produto = await banco.PRODUTOS.FindAsync(id);
                if (produto != null)
                {
                    banco.Remove(produto);
                    await banco.SaveChangesAsync();
                }
            }
        }
        public async Task<List<Produto>> ObterTodoProdutosAsync()
        {
            using (var banco = new GarageManagerContext())
            {
                var listaProdutos = await banco.PRODUTOS.ToListAsync();
                return listaProdutos;
            }
        }
        public async Task<Produto> ObterProdutoPorIdAsync(int id)
        {
            using (var banco = new GarageManagerContext())
            {
                var produto = await banco.PRODUTOS
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                return produto;
            }
        }
    }
}
