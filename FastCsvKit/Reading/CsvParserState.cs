using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Reading
{
    public enum CsvParserState
    {
        FieldStart,
        InField,
        InQuotedField,
        QuoteEscape
    }
}
