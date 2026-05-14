using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Exceptions
{
    public sealed class CsvParseException : Exception
    {
        public CsvParseException(string message) : base(message) { }
    }
}
