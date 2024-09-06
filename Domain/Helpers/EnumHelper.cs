using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class EnumHelper
    {
        public static string? GetDescription(Enum value)
        {
            if (value == null) return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static bool ValidaEnum<TEnum>(this int enumValue, TEnum retValue)
        {
            if (retValue == null) return false;

            retValue = default(TEnum);

            bool success = Enum.IsDefined(typeof(TEnum), enumValue);

            if (success)
            {
                retValue = (TEnum)Enum.ToObject(typeof(TEnum), enumValue);
            }

            return success;
        }
    }
}
