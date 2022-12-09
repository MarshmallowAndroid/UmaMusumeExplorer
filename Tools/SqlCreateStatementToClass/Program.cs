using System.Text;

string createStatement = args.Length > 1 ? args[0] : "";

if (createStatement == "")
    createStatement = Console.ReadLine() ?? "";

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

    Dictionary<string, string> properties = new();

    while (true)
    {
        bool hasPrimaryKey = false;
        if (createStatement.StartsWith(" PRIMARY KEY("))
            hasPrimaryKey = true;

        if (hasPrimaryKey)
        {
            while (true)
            {
                string columnName = ExtractFromQuotesAndUpdate(ref createStatement);
                properties[columnName] += " PRIMARY KEY";
                if (!createStatement.StartsWith(","))
                {
                    createStatement = createStatement[1..];
                    break;
                }
            }
        }
        else
        {

            int spaceIndex = createStatement.IndexOf(' ');
            if (spaceIndex < 0)
                break;

            string columnName = ExtractFromQuotesAndUpdate(ref createStatement);
            createStatement = createStatement[1..];

            string type = createStatement[..createStatement.IndexOf(',')];
            createStatement = createStatement[(type.Length + 1)..];

            properties.Add(columnName, type);
        }
    }

    int index = 0;
    foreach (var property in properties)
    {
        string type = property.Value[..property.Value.IndexOf(' ')];
        type = type switch
        {
            "INTEGER" => "int",
            "TEXT" => "string",
            _ => "object",
        };

        writer.Write("    ");
        writer.WriteLine($"[Column(\"{property.Key}\"){(property.Value.Contains("NOT NULL") ? ", NotNull" : "")}{(property.Value.Contains("PRIMARY KEY") ? ", PrimaryKey" : "")}]");
        writer.Write("    ");
        writer.Write($"public {type} {UnderscoredToCamelCase(property.Key)} ");

        if (type == "string")
            writer.WriteLine("{ get; set; } = \"\";");
        else
            writer.WriteLine("{ get; set; }");

        if (index < properties.Count - 1)
            writer.WriteLine();

        index++;
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