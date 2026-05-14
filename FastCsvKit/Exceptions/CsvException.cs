using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Exceptions
{
    public abstract class CsvException : Exception
    {
        protected CsvException(string message) : base(message) { }
    }
}
