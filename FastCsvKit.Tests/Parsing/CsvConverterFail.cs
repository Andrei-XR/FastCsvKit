using FastCsvKit.Exceptions;
using FastCsvKit.Reading;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Tests.Parsing
{
    public sealed class CsvConverterFail
    {
        [Fact]
        public void Read_Should_Throw_When_Conversion_Fails()
        {
            //Arrange
            var path = Path.GetTempFileName();

            File.WriteAllText(
                path,
                """
                Name,Age
                João,ABC
                """);

            var reader = new CsvReader();

            //Act
            var action = () => reader.Read<Person>(path).First();

            //Assert
            action.Should()
                .Throw<CsvConversionException>()
                .WithMessage("*Age*");
        }
    }
}
