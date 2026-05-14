using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Configuration
{
    public sealed class CsvOptions
    {
        public char Separator { get; init; } = ';';
        public char Quote { get; init; } = '"';
        public Encoding Encoding { get; init; } = Encoding.UTF8;
        public int BufferSize { get; init; } = 4096;
        public bool HasHeader { get; set; } = true;
    }
}
