using FastCsvKit.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Writing
{
    public sealed class CsvFormatter
    {
        private readonly CsvOptions _options;

        public CsvFormatter(CsvOptions options)
        {
            _options = options;
        }

        public string Format(string[] values)
        {
            return string.Join(_options.Separator, values.Select(Escape));
        }

        private string Escape(string value)
        {
            bool mustQuote =
                value.Contains(_options.Separator) ||
                value.Contains('\n') ||
                value.Contains('\r') ||
                value.Contains(_options.Quote);

            if (!mustQuote) return value;

            value = value.Replace(
                _options.Quote.ToString(),
                $"{_options.Quote}{_options.Quote}");

            return $"{_options.Quote}{value}{_options.Quote}";
        }
    }
}
