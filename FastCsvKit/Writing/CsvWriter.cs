using FastCsvKit.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Writing
{
    public sealed class CsvWriter
    {
        private readonly CsvFormatter _formatter;
        private readonly CsvOptions _options;

        public CsvWriter(CsvOptions? options = null)
        {
            _options = options ?? new CsvOptions();
            _formatter = new CsvFormatter(_options);
        }

        public void Write(string path, IEnumerable<string[]> rows)
        {
            using var writer = new StreamWriter(path, false, _options.Encoding, _options.BufferSize);

            foreach (var row in rows)
            {
                var line = _formatter.Format(row);
                writer.WriteLine(line);
            }
        }
    }
}
