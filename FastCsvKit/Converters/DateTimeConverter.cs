using System.Globalization;

namespace FastCsvKit.Converters
{
    public sealed class DateTimeConverter : ICsvTypeConverter
    {
        public bool CanConvert(Type type)
        {
            return type == typeof(DateTime) || type == typeof(DateTime?);
        }

        public object? ConvertFromString(string value, Type targetType)
        {
            return DateTime.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
