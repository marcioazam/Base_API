using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class RegexHelper
    {
        public static string OnlyNumber(string value) => Regex.Replace(value, @"[^\d]", string.Empty);

        public static string CleanTypeName(string value) => Regex.Replace(value, @"`\d+", string.Empty);
    }
}
