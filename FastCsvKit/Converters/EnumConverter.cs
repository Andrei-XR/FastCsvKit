using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Converters;

public sealed class EnumConverter : ICsvTypeConverter
{
    public bool CanConvert(Type type)
    {
        return type.IsEnum;
    }

    public object? ConvertFromString(string value, Type targetType)
    {
        return Enum.Parse(targetType, value, true);
    }
}