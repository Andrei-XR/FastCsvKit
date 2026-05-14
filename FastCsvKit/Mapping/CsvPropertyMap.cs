using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Mapping
{
    internal sealed class CsvPropertyMap
    {
        public required string ColumnName { get; init; }
        public required PropertyInfo Property { get; init; }
        public required Type PropertyType { get; init; }
    }
}
