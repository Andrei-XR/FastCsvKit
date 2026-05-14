using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CsvColumnAttribute : Attribute
    {
        public string Name { get; }

        public CsvColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
