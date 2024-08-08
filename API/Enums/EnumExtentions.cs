using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FluxoCaixa.Enums
{
    public static class EnumExtentions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }

        public static List<EnumDisplayInfo<T>> GetEnumDisplayValues<T>() where T : Enum
        {
            var enumType = typeof(T);
            var enumValues = Enum.GetValues(enumType).Cast<T>();

            var resultado = new List<EnumDisplayInfo<T>>();

            foreach (var enumValue in enumValues)
            {
                var fieldInfo = enumType.GetField(enumValue.ToString());
                var displayAttribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();
                var displayName = displayAttribute?.Name ?? enumValue.ToString();
                resultado.Add(new EnumDisplayInfo<T> { Value = enumValue, DisplayName = displayName });
            }

            return resultado;
        }
    }
}

