using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Converters
{
    public sealed class NullableConverter : ICsvTypeConverter
    {
        public bool CanConvert(Type type)
        {
            return Nullable.GetUnderlyingType(type) is not null;
        }

        public object? ConvertFromString(string value, Type targetType)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var innerType = Nullable.GetUnderlyingType(targetType)!;
            return Convert.ChangeType(value, targetType);
        }
    }
}
