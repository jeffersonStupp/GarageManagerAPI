using FluentValidation;
using GarageManager.Models;
using GarageManagerAPI.Data.Repositorio.Validadores.Metodos;
using GarageManagerAPI.Models;
using System.Text.RegularExpressions;

namespace GarageManagerAPI.Data.Repositorio.Validadores
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(veiculo => veiculo.Marca)
                 .NotEmpty().WithMessage("A marca não foi informada");
            RuleFor(veiculo => veiculo.Modelo)
                 .NotEmpty().WithMessage("O modelo não foi informado");
            RuleFor(veiculo => veiculo.Ano)
                .NotEmpty().WithMessage("O ano não foi informado").Must(MetodosDeValidacao.SomenteNumeros).WithMessage("Ano invalido")
                .MaximumLength(4).WithMessage("O ano deve conter 4 digitos").MinimumLength(4).WithMessage("O ano deve conter 4 digitos");
            RuleFor(veiculo => veiculo.Placa)
               .NotEmpty().WithMessage("A placa não foi informada").Must(ValidarPlaca).WithMessage("Placa invalida")
               .MaximumLength(7).WithMessage("A placa deve conter 7 digitos").MinimumLength(7).WithMessage("A placa deve conter 7 digitos");
            RuleFor(veiculo => veiculo.Cor)
                .NotEmpty().WithMessage("A cor não foi informada");
            RuleFor(veiculo => veiculo.ClienteId)
               .NotEmpty().WithMessage("O cliente não foi informado");
        }

        static bool ValidarPlaca(string placa)
        {
            
            string placaLimpa = Regex.Replace(placa, @"[^a-zA-Z0-9]", "").ToUpper();

            if (placaLimpa.Length != 7)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(placaLimpa[i]))
                {
                    return false;
                }
            }

            for (int i = 3; i < 7; i += 2)
            {
                if (!char.IsDigit(placaLimpa[i]))
                {
                    return false;
                }
            }

            if (!char.IsLetterOrDigit(placaLimpa[4]))
            {
                return false;
            }

            return true;
        }
    }


}

