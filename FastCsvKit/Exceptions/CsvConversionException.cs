using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Exceptions
{
    public sealed class CsvConversionException : CsvException
    {
        public CsvConversionException(string column, string value, Exception inner) 
            : base($"Erro ao converter coluna '{column}' com valor '{value}'.")
        { }
    }
}
