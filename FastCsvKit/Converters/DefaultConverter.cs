using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Converters
{
    public sealed class DefaultConverter : ICsvTypeConverter
    {
        public bool CanConvert(Type type)
        {
            return true;
        }

        public object? ConvertFromString(string value, Type targetType)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            return Convert.ChangeType(value, targetType);
        }
    }
}
