using FastCsvKit.Mapping;
using FastCsvKit.Mapping.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Internal
{
    internal static class ReflectionCache
    {
        private static readonly ConcurrentDictionary<Type, CsvPropertyMap[]> Cache = new();

        public static CsvPropertyMap[] GetProperties(Type type)
        {
            return Cache.GetOrAdd(type, CreateMaps);
        }

        private static CsvPropertyMap[] CreateMaps(Type type)
        {
            return type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite)
                .Where(p => p.GetCustomAttribute<CsvIgnoreAttribute>() is null)
                .Select(p =>
                {
                    var attr = p.GetCustomAttribute<CsvColumnAttribute>();

                    return new CsvPropertyMap
                    {
                        ColumnName = attr?.Name ?? p.Name,
                        Property = p,
                        PropertyType = p.PropertyType
                    };
                })
                .ToArray();
        }
    }
}
