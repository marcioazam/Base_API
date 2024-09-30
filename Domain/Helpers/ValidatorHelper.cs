using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static partial class ValidadorHelper
    {
        public static string? ValidaCPF(string cpfString)
        {
            if (string.IsNullOrEmpty(cpfString))
            {
                return cpfString;
            }

            cpfString = RegexHelper.OnlyNumber(cpfString);
            bool sucessConvert = decimal.TryParse(cpfString, out decimal cpf);

            if (sucessConvert == false || cpf == 0 || cpfString.Length != 11)
            {
                return null;
            }
            else
            {
                return cpfString;
            }
        }

        public static string? ValidaTelefone(string telefoneString)
        {
            if (string.IsNullOrEmpty(telefoneString))
            {
                return telefoneString;
            }

            telefoneString = RegexHelper.OnlyNumber(telefoneString);
            bool sucessConvert = decimal.TryParse(telefoneString, out decimal telefone);

            if (sucessConvert == false || telefone == 0 || telefoneString.Length != 11 && telefoneString.Length != 10)
            {
                return null;
            }
            else
            {
                return telefoneString;
            }
        }
    }
}
