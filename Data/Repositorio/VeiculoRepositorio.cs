using GarageManager.Data.Repositorio.Formatadores;
using GarageManager.Database.Contexto;
using GarageManager.Models;
using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageManagerAPI.Data.Repositorio
{
    public class VeiculoRepositorio
    {
        public async Task<Veiculo>AdicionarVeiculo(Veiculo veiculo)
        {
            using(var banco =new GarageManagerContext())
            {
                veiculo.Modelo = Formatador.TitleCase(veiculo.Modelo);
                veiculo.Marca = Formatador.TitleCase(veiculo.Marca);
                veiculo.Cor = Formatador.TitleCase(veiculo.Cor);

                await banco.VEICULOS.AddAsync(veiculo);
                await banco.SaveChangesAsync();

                var cliente = await banco.CLIENTES.FindAsync(veiculo.ClienteId);
                cliente.Veiculos.Add(veiculo);
                await banco.SaveChangesAsync();
            }
            return veiculo;
        }
        public async Task<Veiculo> EditarVeiculo(Veiculo veiculo)
        {
            using (var banco = new GarageManagerContext())
            {
                veiculo.Modelo = Formatador.TitleCase(veiculo.Modelo);
                veiculo.Marca = Formatador.TitleCase(veiculo.Marca);
                veiculo.Cor = Formatador.TitleCase(veiculo.Cor);
                banco.VEICULOS.Update(veiculo);
                await banco.SaveChangesAsync();
            }
            return veiculo ;
        }
        public async Task ApagarVeiculo(int id)
        {
            using (var banco = new GarageManagerContext())
            {
                var veiculo = await banco.VEICULOS.FindAsync(id);
                if (veiculo != null)
                {
                    banco.Remove(veiculo);
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Veiculo>> ObterTodosVeiculos()
        {
            using (var banco = new GarageManagerContext())
            {
                var listaVeiculos = await banco.VEICULOS.ToListAsync();
                return listaVeiculos;
            }
        }
        public async Task<Veiculo> ObterPorVeiculoId(int id)
        {
            using (var banco = new GarageManagerContext())
            {
                var veiculo = await banco.VEICULOS
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

                return veiculo;
            }
        }
















    }
}
