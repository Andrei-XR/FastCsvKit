using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Converters
{
    public interface ICsvTypeConverter
    {
        bool CanConvert(Type type);
        object? ConvertFromString(string value, Type targetType);
    }
}
