

using FluentValidation;
using GarageManager.Data.Repositorio.Formatadores;
using GarageManager.Database.Contexto;
using GarageManager.Models;
using GarageManagerAPI.Data.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Database.Repositorio
{
        
    public class ClienteRepositorio
    {
        public ParametrizacaoRepositorio ParametrizacaoRepositorio = new ParametrizacaoRepositorio();
        

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
               
            
            using (var banco = new GarageManagerContext())
            {
                var configuracao = ParametrizacaoRepositorio.ObterParametros();

                if (configuracao.HomologacaoDireta == true)
                {
                    cliente.Situacao = "Normal";
                }
                if(configuracao.HomologacaoDireta == false)
                {

                cliente.Situacao = "Pendente";
                }


                cliente.Nome = Formatador.TitleCase(cliente.Nome);
                await banco.CLIENTES.AddAsync(cliente);
                await banco.SaveChangesAsync();
            }
            return cliente;
        }

        public async Task<Cliente> EditAsync(Cliente cliente)
        {
            using (var banco = new GarageManagerContext())
            {
               
                cliente.Nome = Formatador.TitleCase(cliente.Nome);
                banco.CLIENTES.Update(cliente);
                await banco.SaveChangesAsync();
            }
            return cliente;
        }

        public async Task DelAsync(int id)
        {
            using (var banco = new GarageManagerContext())
            {
                var cliente = await banco.CLIENTES.FindAsync(id);
                if (cliente != null)
                {
                    banco.Remove(cliente);
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            using (var banco = new GarageManagerContext())
            {
                var listaClientes = await banco.CLIENTES.ToListAsync();
                return listaClientes;
            }
        }
        public async Task<List<Cliente>> ObterTodosPendentesAsync()
        {
            using (var banco = new GarageManagerContext())
            {
                var listaClientes = await banco.CLIENTES.Where(cliente => cliente.Situacao == "Pendente").ToListAsync();
                return listaClientes;
            }
        }
        public async Task<List<Cliente>> ObterTodosBloqueadosAsync()
        {
            using (var banco = new GarageManagerContext())
            {
                var listaClientes = await banco.CLIENTES.Where(cliente => cliente.Situacao == "Bloqueado").ToListAsync();
                return listaClientes;
            }
        }

        public async Task<Cliente> ObterPorIdAsync(int id)
        {
            using (var banco = new GarageManagerContext())
            {
                var cliente = await banco.CLIENTES
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

                return cliente;
            }
        }
       
    }
}
