using FluentValidation;
using GarageManager.Models;
using GarageManagerAPI.Models;

namespace GarageManagerAPI.Data.Repositorio.Validadores
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {

        public ProdutoValidator()
        {
            RuleFor(produto => produto.Codigo)
                .NotEmpty().WithMessage("O código não foi informado");
            RuleFor(produto => produto.Descricao)
                .NotEmpty().WithMessage("A descrição não foi informada");
            RuleFor(produto => produto.Preco)
               .NotEmpty().WithMessage("O preço não foi informado");

            

        }




}
}
