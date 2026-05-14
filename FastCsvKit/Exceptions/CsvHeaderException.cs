using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Exceptions
{
    public sealed class CsvHeaderException : CsvException
    {
        public CsvHeaderException(string column) : base($"Coluna '{column}' não encontrada.") { }
    }
}
