using FastCsvKit.Converters;
using FastCsvKit.Exceptions;
using FastCsvKit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Mapping
{
    internal sealed class CsvMapper<T> where T : new()
    {
        private readonly CsvPropertyMap[] _maps;
        private readonly ConverterCollection _converters;

        public CsvMapper(ConverterCollection converters)
        {
            _maps = ReflectionCache.GetProperties(typeof(T));
            _converters = converters;
        }

        public T Map(string[] headers, string[] values)
        {
            var obj = new T();

            foreach(var map in _maps)
            {
                var index = Array.FindIndex(
                    headers,
                    h => string.Equals(
                        h,
                        map.ColumnName,
                        StringComparison.OrdinalIgnoreCase
                    )
                );

                if (index < 0) continue;

                if (index >= values.Length) continue;

                var converter = _converters.GetConverter(map.PropertyType);

                try
                {
                    var converted = converter.ConvertFromString(values[index], map.PropertyType);
                    map.Property.SetValue(obj, converted);
                }
                catch (Exception ex)
                {
                    throw new CsvConversionException(map.ColumnName, values[index], ex);
                }
            }

            return obj;
        }
    }
}
