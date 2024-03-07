using System.Globalization;
using System.Text.RegularExpressions;

namespace GarageManager.Data.Repositorio.Formatadores
{
    public class Formatador
    {
        public static string FormatarPlaca(string placa)
        {
            placa = Regex.Replace(placa, "[^a-zA-Z0-9 ]", "").ToUpper().Insert(3, "-");


            return placa;


        }
        public static string RemoverCaracteres(string nome)
        {
            return nome = Regex.Replace(nome, @"[^a-zA-Z0-9\s]", "");
        }

        public static string TitleCase(string nome)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return nome = textInfo.ToTitleCase(nome);
        }

        public static bool EmailValido(string email)
        {
            try
            {
                var endemail = new System.Net.Mail.MailAddress(email);
                return endemail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string FormatarTelefone(string telefone)
        {
            return telefone = telefone.Insert(0, "(").Insert(3, ")").Insert(9, "-");
        }


    }
}
