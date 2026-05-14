using FastCsvKit.Configuration;
using FastCsvKit.Exceptions;
using FastCsvKit.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCsvKit.Parsing
{
    public sealed class CsvParser
    {
        private readonly CsvOptions _options;

        public CsvParser(CsvOptions options)
        {
            _options = options;
        }

        public IEnumerable<string[]> Parse(TextReader reader)
        {
            var field = new StringBuilder();
            var row = new List<string>();

            var state = CsvParserState.FieldStart;

            while (true)
            {
                int value = reader.Read();

                if(value == -1)
                {
                    if (state == CsvParserState.InQuotedField)
                        throw new CsvParseException("Unterminated quoted field.");

                    if(field.Length > 0 || row.Count > 0)
                    {
                        row.Add(field.ToString());
                        yield return row.ToArray();
                    }

                    yield break;
                }

                char current = (char)value;

                switch (state)
                {
                    case CsvParserState.FieldStart:

                        if(current == _options.Quote)
                        {
                            state = CsvParserState.InQuotedField;
                        }
                        else if (current == _options.Separator)
                        {
                            row.Add(string.Empty);
                        }
                        else if (current == '\n')
                        {
                            row.Add(string.Empty);
                            yield return row.ToArray();

                            row.Clear();
                        }
                        else if (current != '\r')
                        {
                            field.Append(current);
                            state = CsvParserState.InField;
                        }

                        break;

                    case CsvParserState.InField:

                        if (current == _options.Separator)
                        {
                            row.Add(field.ToString());
                            field.Clear();
                            state = CsvParserState.FieldStart;
                        }
                        else if (current == '\n')
                        {
                            row.Add(field.ToString());

                            yield return row.ToArray();

                            row.Clear();
                            field.Clear();

                            state = CsvParserState.FieldStart;
                        }
                        else if(current != '\r')
                        {
                            field.Append(current);
                        }

                        break;

                    case CsvParserState.InQuotedField:

                        if(current == _options.Quote)
                        {
                            if(reader.Peek() == _options.Quote)
                            {
                                reader.Read();
                                field.Append(_options.Quote);
                            }
                            else
                            {
                                state = CsvParserState.QuoteEscape;
                            }
                        }
                        else
                        {
                            field.Append(current);
                        }

                        break;

                    case CsvParserState.QuoteEscape:

                        if (current == _options.Separator)
                        {
                            row.Add(field.ToString());
                            field.Clear();
                            state = CsvParserState.FieldStart;
                        }
                        else if(current == '\n')
                        {
                            row.Add(field.ToString());

                            yield return row.ToArray();

                            row.Clear();
                            field.Clear();

                            state = CsvParserState.FieldStart;
                        }
                        else if (current != '\r')
                        {
                            throw new CsvParseException($"Invalid character '{current}' after closing quote.");
                        }

                        break;
                }
            }
        }
    }
}
