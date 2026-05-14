using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Converters
{
    public sealed class ConverterCollection
    {
        private readonly List<ICsvTypeConverter> _converters = [];

        public ConverterCollection()
        {
            _converters.Add(new NullableConverter());
            _converters.Add(new EnumConverter());
            _converters.Add(new DateTimeConverter());
            _converters.Add(new DefaultConverter());
        }

        public void Add(ICsvTypeConverter converter)
        {
            _converters.Insert(0, converter);
        }

        public ICsvTypeConverter GetConverter(Type type)
        {
            return _converters.First(c => c.CanConvert(type));
        }
    }
}
