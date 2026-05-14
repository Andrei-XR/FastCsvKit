using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Mapping
{
    public abstract class CsvClassMap<T>
    {
        internal readonly Dictionary<string, string> Maps = [];

        protected void Map(string propertyName, string columnName)
        {
            Maps[propertyName] = columnName;
        }
    }
}
