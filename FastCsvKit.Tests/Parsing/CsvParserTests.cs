using FastCsvKit.Configuration;
using FastCsvKit.Parsing;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Tests.Parsing
{
    public sealed class CsvParserTests
    {
        [Fact]
        public void Parse_Should_Read_Rows_Correctly()
        {
            //Arrange
            var csv = """
                name,age
                João,30
                Maria,25
                """;

            var parser = new CsvParser(new CsvOptions { Separator = ','});

            using var reader = new StringReader(csv);

            //Act
            var rows = parser.Parse(reader).ToList();

            //Assert
            rows.Should().HaveCount(3);

            rows[0][0].Should().Be("name");
            rows[1][0].Should().Be("João");
            rows[1][1].Should().Be("30");
        }
    }
}
