using FastCsvKit.Configuration;
using FastCsvKit.Converters;
using FastCsvKit.Mapping;
using FastCsvKit.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Reading
{
    public sealed class CsvReader
    {
        private readonly CsvParser _parser;
        private readonly CsvOptions _options;
        private readonly ConverterCollection _converters;

        public CsvReader(CsvOptions? options = null)
        {
            _options = options ?? new CsvOptions();
            _parser = new CsvParser(_options);
            _converters = new ConverterCollection();
        }

        public IEnumerable<string[]> Read(string path)
        {
            using var reader = new StreamReader(
                path,
                _options.Encoding,
                detectEncodingFromByteOrderMarks: true,
                bufferSize: _options.BufferSize);

            foreach(var row in _parser.Parse(reader))
            {
                yield return row;
            }
        }

        public IEnumerable<T> Read<T>(string path) where T : new()
        {
            using var reader = new StreamReader(path, _options.Encoding, true, _options.BufferSize);

            using var enumerator = _parser.Parse(reader).GetEnumerator();

            if (!enumerator.MoveNext())
                yield break;

            string[] headers;

            if (_options.HasHeader)
            {
                headers = enumerator.Current;
            }
            else
            {
                throw new InvalidOperationException("Mapping sem header ainda não suportado.");
            }

            var mapper = new CsvMapper<T>(_converters);

            while (enumerator.MoveNext())
            {
                yield return mapper.Map(headers, enumerator.Current);
            }
        }
    }
}
