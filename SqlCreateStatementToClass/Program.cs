using System.Text;

string createStatement = Console.ReadLine() ?? "";

if (createStatement != "")
{
    createStatement = createStatement["CREATE TABLE".Length..];

    string tableName = ExtractFromQuotesAndUpdate(ref createStatement);

    using var writer = new StreamWriter(File.Create(UnderscoredToCamelCase(tableName) + ".cs"));

    writer.WriteLine("using SQLite;\n");
    writer.WriteLine($"[Table(\"{tableName}\")]");
    writer.WriteLine($"public class {UnderscoredToCamelCase(tableName)}");
    writer.WriteLine("{");

    createStatement = createStatement[(createStatement.IndexOf('(') + 1)..];

    while (true)
    {
        string columnName = ExtractFromQuotesAndUpdate(ref createStatement);

        createStatement = createStatement[1..];

        int spaceIndex = createStatement.IndexOf(' ');
        if (spaceIndex < 0) break;

        string type = createStatement[..spaceIndex];
        createStatement = createStatement[(type.Length + 1)..];
        createStatement = createStatement[(createStatement.IndexOf(',') + 1)..];

        type = type switch
        {
            "INTEGER" => "int",
            "TEXT" => "string",
            _ => "object",
        };
        writer.Write("    ");
        writer.WriteLine($"[Column(\"{columnName}\")]");
        writer.Write("    ");
        writer.Write($"public {type} {UnderscoredToCamelCase(columnName)} ");

        if (type == "string")
            writer.WriteLine("{ get; set; } = \"\";");
        else
            writer.WriteLine("{ get; set; }");

        int lastCommaIndex = createStatement.LastIndexOf(',');

        if (lastCommaIndex >= 0)
            writer.WriteLine();
    }

    writer.WriteLine("}");
}

string ExtractFromQuotesAndUpdate(ref string source)
{
    source = source[(source.IndexOf('\'') + 1)..];
    string value = source[..source.IndexOf('\'')];
    source = source[(value.Length + 1)..];

    return value;
}

string UnderscoredToCamelCase(string value)
{
    string[] words = value.Split('_');

    StringBuilder newString = new();

    foreach (var word in words)
    {
        newString.Append(char.ToUpper(word[0]));
        newString.Append(word[1..]);
    }

    return newString.ToString();
}