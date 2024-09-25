using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class SecurityHelper
    {
        public static double GetExpiryToken(string? expiryInConfig)
        {
            double expiryHours;

            if (!double.TryParse(expiryInConfig , out expiryHours) || expiryHours <= 0)
            {
                expiryHours = 2;
            }

            return expiryHours;
        }
    }
}
