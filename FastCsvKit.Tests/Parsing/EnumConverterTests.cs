using FastCsvKit.Reading;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Tests.Parsing
{
    public sealed class EnumConverterTests
    {
        [Fact]
        public void Read_Should_Parse_Enum()
        {
            //Arrange
            var path = Path.GetTempFileName();

            File.WriteAllText(
                path,
                """
                Name,Status
                João,Active
                """);

            var reader = new CsvReader();

            //Act
            var result = reader.Read<Employee>(path).First();


            //Assert
            result.Status.Should().Be(Status.Active);
        }
    }
}
