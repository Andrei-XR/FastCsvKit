using FastCsvKit.Reading;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Tests.Reading
{
    public sealed class CsvReaderTests
    {
        [Fact]
        public void Read_Should_Map_Objects_Correctly()
        {
            //Arrange
            var path = Path.GetTempFileName();

            File.WriteAllText(
                path, 
                """
                Name,Age
                João,30
                Maria,25
                """);

            var reader = new CsvReader(new Configuration.CsvOptions { Separator = ',' });

            //Act
            var result = reader.Read<Person>(path).ToList();

            //Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be("João");
            result[0].Age.Should().Be(30);

            result[1].Name.Should().Be("Maria");
            result[1].Age.Should().Be(25);
        }

        [Fact]
        public void Read_Should_Handle_Nullable()
        {
            //Arrange
            var path = Path.GetTempFileName();

            File.WriteAllText(
                path,
                """
                Name,Age
                João,30
                Maria,
                """);

            var reader = new CsvReader(new Configuration.CsvOptions());

            //Act
            var result = reader.Read<Person>(path).ToList();

            //Asert
            result[1].Age.Should().BeNull();
        }
    }
}
