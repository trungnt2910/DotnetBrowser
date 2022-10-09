using Microsoft.Build.Framework;
using Mono.Cecil;
using Mono.Collections.Generic;
using BuildTask = Microsoft.Build.Utilities.Task;

namespace Trungnt2910.Browser.PostProcessing;

public class GeneratorCleanup : BuildTask
{
    [Required]
    public string AssemblyPath { get; set; } = string.Empty;

    public string SnkPath { get; set; } = string.Empty;

    public override bool Execute()
    {
        try
        {
            using var asmDef = AssemblyDefinition.ReadAssembly(AssemblyPath, new ReaderParameters()
            {
                ReadSymbols = true,
                ThrowIfSymbolsAreNotMatching = true,
                InMemory = true,
            });
            CleanAttributes(asmDef.CustomAttributes);

            var keptTypes = new Collection<TypeDefinition>();

            foreach (var type in asmDef.MainModule.Types)
            {
                if (type.Namespace.StartsWith("Trungnt2910.Browser.Generators")
                    || type.Namespace.StartsWith("Gobie"))
                {
                    Log.LogMessage($"Removing type: {type.FullName}");
                    continue;
                }

                if (type.HasCustomAttributes)
                {
                    CleanAttributes(type.CustomAttributes);
                }

                keptTypes.Add(type);
            }

            asmDef.MainModule.Types.Clear();

            foreach (var type in keptTypes)
            {
                asmDef.MainModule.Types.Add(type);
            }

            asmDef.Write(AssemblyPath, new WriterParameters()
            {
                WriteSymbols = true,
                StrongNameKeyBlob = File.Exists(SnkPath) ? File.ReadAllBytes(SnkPath) : null
            });
        }
        catch (Exception e)
        {
            Log.LogErrorFromException(e);
            return false;
        }

        return true;
    }

    void CleanAttributes(IList<CustomAttribute> customAttributes)
    {
        var clonedList = new List<CustomAttribute>();

        for (int i = 0; i < customAttributes.Count; ++i)
        {
            var currentAttr = customAttributes[i];

            if ((currentAttr.AttributeType.FullName == "System.Runtime.Versioning.RequiresPreviewFeaturesAttribute")
                || currentAttr.AttributeType.Namespace.StartsWith("Trungnt2910.Browser.Generators")
                || currentAttr.AttributeType.Namespace.StartsWith("Gobie"))
            {
                Log.LogMessage($"Removing attribute: {currentAttr.AttributeType.FullName}");
                continue;
            }
            clonedList.Add(currentAttr);
        }

        while (customAttributes.Count > clonedList.Count)
        {
            customAttributes.RemoveAt(customAttributes.Count - 1);
        }

        for (int i = 0; i < clonedList.Count; ++i)
        {
            customAttributes[i] = clonedList[i];
        }
    }
}