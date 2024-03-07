using GarageManager.Models;
using System.Text.RegularExpressions;

namespace GarageManagerAPI.Data.Repositorio.Validadores.Metodos
{
    public static class MetodosDeValidacao
    {
        public static bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (!long.TryParse(cpf, out _))
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);

        }

        public static bool ValidarNomeCompleto(string nome)
        {
            return !string.IsNullOrWhiteSpace(nome) && nome?.Contains(" ") == true;
        }

        public static bool ContemApenasLetras(string nome)
        {
            return !string.IsNullOrWhiteSpace(nome) && nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public static bool ContemApenasCaracteresPermitidos(string nome)
        {
            return nome.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        }

        public static bool EvitarEspacosEmBrancoExtras(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return false;
            }


            return !Regex.IsMatch(nome, @"\s{2,}") && nome == nome.Trim();
        }





        public static bool ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento >= DateTime.Now)
            {
                return false;
            }

            // Calcula a idade da pessoa
            int idade = DateTime.Now.Year - dataNascimento.Year;

            // Se o aniversário ainda não ocorreu este ano, subtrai 1 da idade
            if (DateTime.Now < dataNascimento.AddYears(idade))
            {
                idade--;
            }

            // Verifica se a idade é menor que 120 anos
            if (idade >= 120 && idade <= 12)
            {
                return false;
            }

            // Todas as validações passaram
            return true;
        }

        public static bool SomenteNumeros(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SomenteSituacoesValidas(string situacao)
        {

            switch (situacao.ToLower())
            {
                case "normal":
                case "bloqueado":
                case "pendente":
                    return true;
                default:
                    return false;
            }
        }
    }



}






