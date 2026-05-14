<h1>FastCsvKit</h1>

A lightweight and extensible .NET library for reading and writing CSV files with support for strongly-typed object mapping, custom converters, and flexible configuration.

Designed for simplicity, performance, and real-world usage.
#

<h3>✨ Features</h3>

- Streaming CSV reading (low memory usage)
- Strongly-typed object mapping (`IEnumerable<T>`)
- Attribute-based mapping
- Fluent mapping support
- Custom type converters
- Nullable, Enum and DateTime support
- Configurable CSV options (delimiter, encoding, headers)
- Exception handling with context
- Built for extensibility
#

<h3>📦 Installation</h3>

> dotnet add package FastCsvKit
#

🚀 Quick Start

1. Create a model

```bash

public sealed class Person
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public DateTime BirthDate { get; set; }

    public Status Status { get; set; }
}

public enum Status
{
    Active,
    Inactive
}
```

2. Create a CSV file

```bash
Name,Age,BirthDate,Status
João,30,1994-05-10,Active
```

3. Read CSV

```bash
using FastCsvKit.Configuration;
using FastCsvKit.Reading;

var reader = new CsvReader();

var people = reader.Read<Person>("people.csv");

foreach (var person in people)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}
Maria,25,1999-02-15,Inactive
```
#

<h3>⚙️ Configuration</h3>

```bash
var options = new CsvOptions
{
    Delimiter = ',',
    HasHeader = true,
    Encoding = Encoding.UTF8,
    BufferSize = 4096
};

var reader = new CsvReader(options);
```
#

<h3>🧠 Attribute Mapping</h3>
Map CSV columns explicitly using attributes:

```bash
using FastCsvKit.Mapping.Attributes;

public sealed class Person
{
    [CsvColumn("full_name")]
    public string Name { get; set; } = string.Empty;

    [CsvColumn("age")]
    public int Age { get; set; }
}
```
#

Ignore properties:

```bash
[CsvIgnore]
public string InternalId { get; set; }
```
#

<h3>🔄 Custom Type Converters</h3>

```bash
public sealed class CustomDateConverter : ICsvTypeConverter
{
    public bool CanConvert(Type type) => type == typeof(DateTime);

    public object? ConvertFromString(string value, Type targetType)
    {
        return DateTime.ParseExact(value, "yyyy-MM-dd", null);
    }
}
```
#

<h3>🧩 Fluent Mapping (Advanced)</h3>

```bash
public sealed class PersonMap : CsvClassMap<Person>
{
    public PersonMap()
    {
        Map(nameof(Person.Name), "full_name");
        Map(nameof(Person.Age), "age");
    }
}
```
#

Register mapping:

```bash
reader.RegisterMap<PersonMap>();
```
#

<h3>⚠️ Exceptions</h3>

The library provides structured exceptions:
- CsvConversionException
- CsvMappingException
- CsvHeaderException

Example:

```bash
try
{
    var people = reader.Read<Person>("people.csv").ToList();
}
catch (CsvConversionException ex)
{
    Console.WriteLine(ex.Message);
}
```
#

<h3>🧵 Async Support</h3>

```bash
await foreach (var person in reader.ReadAsync<Person>("people.csv"))
{
    Console.WriteLine(person.Name);
}
```
#

<h3>🧪 Design Principles</h3
                         
This library was built following:
- SOLID principles
- Separation of concerns
- Streaming-first design
- Minimal allocations
- Extensibility over complexity
- Testability as a core requirement
#

<h3>📊 Performance</h3>

FastCsvKit is designed for:
- Large CSV files
- Streaming processing
- Low memory footprint
- High throughput parsing
Benchmarks coming soon.
#

<h3>🏗️ Roadmap</h3>

- CsvWriter implementation
- Source Generators (zero reflection mapping)
- Span-based parsing
- PipeReader support
- Performance benchmarks vs CsvHelper
- Native AOT support improvements
- Fluent validation API
#

<h3>📌 Example Use Cases</h3>

- ETL pipelines
- Data import/export systems
- Background processing jobs
- Reporting systems
- Integration layers
#

<h3>🤝 Contributing</h3>

Contributions are welcome!
- Fork the project
- Create a feature branch
- Add tests
- Open a PR
#

<h3>📄 License</h3>

MIT License
#

<h3>⭐ Motivation</h3>

This project was created as a learning and portfolio project to explore:
- High-performance parsing in .NET
- Reflection and expression trees
- Streaming APIs
- Clean architecture in libraries
- Real-world NuGet design patterns
