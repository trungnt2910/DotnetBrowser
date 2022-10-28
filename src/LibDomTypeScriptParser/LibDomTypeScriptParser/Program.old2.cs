//using Zu.TypeScript;
//using Zu.TypeScript.TsTypes;

//string[] keywords = new[] { "namespace", "event", "string", "object", "ref", "lock" }!;

//string ProcessName(string name)
//{
//    if (keywords.Contains(name))
//    {
//        return "@" + name;
//    }

//    return name;
//}

//string ProcessNameAndCase(string name)
//{
//    name = char.ToUpperInvariant(name[0]) + name[1..];

//    return ProcessName(name);
//}

//string ProcessReturnType(string type)
//{
//    switch (type)
//    {
//        case "any":
//            return "object";
//        case "void":
//            return "void";
//        case "number":
//            return "double";
//        case "boolean":
//            return "bool";
//        case "string":
//            return "string";
//        default:
//            if (type.EndsWith("| null"))
//            {
//                return ProcessReturnType(type.Substring(0, type.Length - "| null".Length).Trim()) + "?";
//            }
//            if (type.Contains("|"))
//            {
//                return "object";
//            }
//            return $"I{type}";
//    }
//}

//var ast = new TypeScriptAST(File.ReadAllText("lib.dom.d.ts"), "lib.dom.d.ts");

//using var outputfile = File.CreateText("output.cs");
//outputfile.WriteLine("#nullable enable");
//outputfile.WriteLine("using Trungnt2910.Browser.Generators;");

//outputfile.WriteLine("namespace Trungnt2910.Browser.Dom;");

//foreach (InterfaceDeclaration interfaceDeclaration in ast.OfKind(SyntaxKind.InterfaceDeclaration))
//{
//    if (interfaceDeclaration.JsDoc?.Any() ?? false)
//    {
//        outputfile.WriteLine("/// <summary>");
//        foreach (var doc in interfaceDeclaration.JsDoc)
//        {
//            outputfile.WriteLine($"/// {doc.Comment}");
//        }
//        outputfile.WriteLine("/// </summary>");
//    }

//    var identifier = interfaceDeclaration.IdentifierStr;
//    var typeParams =
//        interfaceDeclaration.TypeParameters?.Select(t => t.IdentifierStr);
//    var extendParams =
//        interfaceDeclaration.HeritageClauses?.FirstOrDefault()?.Children?.Select(t => $"I{t.IdentifierStr}");

//    var typeParamsStr = (typeParams?.Any() ?? false) ? $"<{string.Join(", ", typeParams!)}>" : "";
//    var extendParamsStr = (extendParams?.Any() ?? false) ? $" : {string.Join(", ", extendParams!)}" : "";

//    outputfile.WriteLine("[JsObject]");
//    outputfile.WriteLine($"interface I{identifier}{typeParamsStr}{extendParamsStr}");

//    outputfile.WriteLine("{");
//    outputfile.WriteLine("}");
//}
