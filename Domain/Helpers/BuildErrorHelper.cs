using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class BuildErrorHelper
    {
        public static string BuildError(Enum ValidateError, string propertyName)
        {
            string? description = GetEnumDescription(ValidateError);

            return description.Replace("[PROPERTY_NAME]", propertyName);
        }

        private static string GetEnumDescription(Enum ValidateError)
        {
            string? description = EnumHelper.GetDesc(ValidateError);

            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("Description não definido no Enum: " + ValidateError.ToString());
            }

            return description;
        }
    }
}
