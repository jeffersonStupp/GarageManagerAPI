using GarageManager.Data.Repositorio.Formatadores;
using GarageManager.Database.Contexto;
using GarageManager.Models;
using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace GarageManagerAPI.Data.Repositorio
{
    public class ParametrizacaoRepositorio
    {
        public Parametrizacao AlterarParametros(Parametrizacao parametros)
        {
            using (var banco = new GarageManagerContext())
            {


                banco.PARAMETRIZACAO.Update(parametros);
                banco.SaveChangesAsync();
            }
            return parametros;
        }

        public Parametrizacao ObterParametros()
        {
            using (var banco = new GarageManagerContext())
            {
                var parametros = banco.PARAMETRIZACAO
                    .Where(p => p.Id == 1)
                    .FirstOrDefault();
                              

                

                    return parametros;
            }
        }
        



    }
}
