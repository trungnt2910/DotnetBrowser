//using System.Text.RegularExpressions;

//var reader = File.OpenText("lib.dom.d.ts")!;
//string? line;
//string? currentComments;

//while ((line = reader.ReadLine()) != null)
//{
//    line = line.Trim();
//    if (line == "")
//    {
//        currentComments = null;
//        continue;
//    }

//    if (line.StartsWith("/**"))
//    {
//        currentComments = line.Substring("/**".Length).Trim().TrimEnd(new[] {'/', '*'}).Trim();

//        while (!line.Contains("*/"))
//        {
//            line = reader.ReadLine()!.Trim().TrimStart(new[] { '/', '*' }).Trim();
//            currentComments += Environment.NewLine;
//            currentComments += line;
//        }

//        continue;
//    }

//    // Read a block
//    if (line.EndsWith("{"))
//    {
//        var lines = new List<string>() { line };
//        while (lines.Last() != "}")
//        {
//            line = reader.ReadLine()!.Trim();
//            lines.Add(line);
//        }

//        // interface something {
//        // declare var someclassname: {

//        if (lines[0].StartsWith("interface"))
//        {
//            var match = Regex.Match(lines[0], "interface ([A-Za-z0-9_]+) (?:extends (?:([A-Za-z0-9_]+)(?:, ){0,1})+ )*{", RegexOptions.Compiled);
//            var interfaceName = match.Groups[1].Value;
//            var interfaceExtends = match.Groups[2].Captures.Select(c => c.Value).ToList();

//            Console.WriteLine($"interface {interfaceName} extends {string.Join(',', interfaceExtends)}");
//        }

//        continue;
//    }

//    if (line.StartsWith("declare"))
//    {
//        // Declare some function or variable.
//    }

//    if (line.StartsWith("type"))
//    {
//        // Declare some types
//    }
//}