
using FluentValidation;
using GarageManagerAPI.Data.Repositorio;
using GarageManagerAPI.Data.Repositorio.Validadores.Metodos;
using System.Text.RegularExpressions;

namespace GarageManager.Models.Validators
{
    
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ParametrizacaoRepositorio ParametrizacaoRepositorio = new ParametrizacaoRepositorio();
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("O nome não foi informado")
                .MaximumLength(200).WithMessage("O nome não pode ter mais de 200 caracteres")
                .MinimumLength(5).WithMessage("O nome não tem caracteres suficientes")
                .Must(MetodosDeValidacao.ValidarNomeCompleto).WithMessage("Informe um nome completo válido")
                .Must(MetodosDeValidacao.ContemApenasLetras).WithMessage("O nome deve conter apenas caracteres alfabéticos")
                .Must(MetodosDeValidacao.ContemApenasCaracteresPermitidos).WithMessage("O nome deve conter apenas caracteres alfanuméricos e espaços em branco")
                .Must(MetodosDeValidacao.EvitarEspacosEmBrancoExtras).WithMessage("Evite espaços em branco extras no início ou no final do nome");

            RuleFor(cliente => cliente.DataNascimento)
            .NotNull().WithMessage("A data de nascimento não pode ser nula.")
            .Must(MetodosDeValidacao.ValidarDataNascimento).WithMessage("A data de nascimento não é válida.")
            .Must(IdadeDefinidaValida).WithMessage("A data de nascimento não é válida.");

            RuleFor(cliente => cliente.Cpf)
           .NotEmpty().WithMessage("O CPF é obrigatório.")
           .Must(MetodosDeValidacao.ValidarCpf).WithMessage("CPF inválido.");

            RuleFor(cliente => cliente.Email)
                .EmailAddress().WithMessage("Digite um E-mail válido.");

            RuleFor(cliente => cliente.Celular)
                .Must(MetodosDeValidacao.SomenteNumeros).WithMessage("Celular inválido.")
                .Length(11).WithMessage("Celular inválido.");

            RuleFor(cliente => cliente.Situacao)
                .Must(MetodosDeValidacao.SomenteSituacoesValidas).WithMessage("Situação inválida.");
                



        }

        public bool IdadeDefinidaValida(DateTime data)
        {
            int idade = DateTime.Now.Year - data.Year;
            if (DateTime.Now < data.AddYears(idade))
            {
                idade--;
            }
            var parametros = ParametrizacaoRepositorio.ObterParametros();
            if (idade >= parametros.IdadeMinimaCadastro && parametros.IdadeMaximaCadastro >= idade)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
