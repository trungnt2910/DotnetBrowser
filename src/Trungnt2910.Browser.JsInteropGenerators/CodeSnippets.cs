namespace Trungnt2910.Browser.JsInteropGenerators;

internal static class CodeSnippets
{
    public static string JsObjectBoilerplate(string? namespaceName, string? accessibility, string? className, string? classNameWithoutGenericParams, string? baseClassList, string? constraintsList)
    {
        return
$@"{(string.IsNullOrEmpty(namespaceName) ? "" : $"namespace {namespaceName};\n")}
{accessibility} partial class {className}{baseClassList}{constraintsList}
{{
    private static readonly global::System.Collections.Generic.Dictionary<global::System.IntPtr, global::System.WeakReference<{className}>> _objectCache = new();

    /// <summary>
    /// Constructs a <see cref=""{classNameWithoutGenericParams}""/> from a JavaScript handle.
    /// </summary>
    /// <param name=""handle"">The JavaScript handle</param>
    [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    protected {classNameWithoutGenericParams}(global::System.IntPtr handle) : base(handle) {{}}

    /// <summary>
    /// Creates a <see cref=""{classNameWithoutGenericParams}""/> from a <see cref=""global::System.Runtime.InteropServices.JavaScript.JSObject""/>.
    /// </summary>
    /// <param name=""obj"">The <see cref=""global::System.Runtime.InteropServices.JavaScript.JSObject""/>.</param>
    /// <returns>A <see cref=""{classNameWithoutGenericParams}""/> representing an equivalent object, or <see langword=""null""/> if the passed object is invalid.</returns>
    new public static {className} FromSystemJSObject(global::System.Runtime.InteropServices.JavaScript.JSObject obj)
    {{
        if (obj.IsDisposed)
        {{
            return null;
        }}
        var objectHandle = global::Trungnt2910.Browser.JsObject.CreateHandle(obj);
        if (objectHandle == null)
        {{
            return null;
        }}
        return FromHandle((global::System.IntPtr)objectHandle);
    }}

    /// <summary>
    /// Creates a <see cref=""{classNameWithoutGenericParams}""/> from a raw JavaScript expression.
    /// </summary>
    /// <param name=""jsExpression"">The JavaScript expression as a <see langword=""string""/>.</param>
    /// <returns>A <see cref=""{classNameWithoutGenericParams}""/> representing the expression's result, or <see langword=""null""/> if the expression evaluates to <c>null</c> or <c>undefined</c>.</returns>
    new public static {className} FromExpression(string jsExpression)
    {{
        var objectHandle = __Int32OrNullFromJs($""Trungnt2910.Browser.JsObject.CreateHandle({{jsExpression}})"");
        if (objectHandle == null)
        {{
            return null;
        }}
        return FromHandle((global::System.IntPtr)objectHandle);
    }}

    /// <summary>
    /// Returns a <see cref=""{classNameWithoutGenericParams}""/> from a JavaScript handle.
    /// </summary>
    /// <param name=""objectHandle"">The JavaScript handle.</param>
    /// <returns>A <see cref=""{classNameWithoutGenericParams}""/> or <see langword=""null""/> if the handle is invalid.</returns>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    new public static {className} FromHandle(global::System.IntPtr objectHandle)
    {{
        {className} obj;
        if (_objectCache.TryGetValue(objectHandle, out var weakReference))
        {{
            if (_objectCache[objectHandle].TryGetTarget(out obj))
            {{
                return obj;
            }}
            obj = new {className}(objectHandle);
            weakReference.SetTarget(obj);
            return obj;
        }}
        obj = new {className}(objectHandle);
        _objectCache.Add(objectHandle, new global::System.WeakReference<{className}>(obj));
        return obj;
    }}

    partial void FinalizerPartial();

    /// <inheritdoc/>
    ~{classNameWithoutGenericParams}()
    {{
        if (_objectCache.TryGetValue(Handle, out var reference) && 
            reference.TryGetTarget(out {className} obj) && 
            ReferenceEquals(obj, this))
        {{
            _objectCache.Remove(Handle);
        }}

        FinalizerPartial();
    }}
}}";    
    }

    public static string JsMethodBoilerplate(string? namespaceName, string? className, string? accessibility, string? virtualOverrideSealedNew,
        string? returnTypeFullName, string? name, string? typeParametersList, string? parameterList, string? constraintsList,
        string? objectArrayCreation, string? returnValueHandling)
    {
        if (!string.IsNullOrEmpty(virtualOverrideSealedNew))
        {
            virtualOverrideSealedNew += " ";
        }

        return
$@"{(string.IsNullOrEmpty(namespaceName) ? "" : $"namespace {namespaceName};\n")}
partial class {className}
{{
    {accessibility} {virtualOverrideSealedNew}partial {returnTypeFullName} {name}{typeParametersList}({parameterList}){constraintsList}
    {{
        {objectArrayCreation}
        {returnValueHandling}
    }}
}}";
    }

    public static string TypeParameters(IEnumerable<string> names)
    {
        if (!names.Any())
        {
            return "";
        }
        return $"<{string.Join(", ", names.Select(n => 
            $"[global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembers(global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods)] {n}"))}>";
    }
}
