using System.Collections.Generic;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// Base type for JavaScript typed arrays.
/// </summary>
[JsObject]
[NumericProperty("byteLength", "ByteLength", "int", Comments = "The length in bytes of the array.")]
[NumericProperty("byteOffset", "ByteOffset", "int", Comments = "The offset in bytes of the array.")]
public partial class ArrayBufferView : JsObject
{

}

/// <summary>
/// Not implemented but referenced by some documentation here.
/// </summary>
[JsObject]
public partial class DataView : JsObject
{

}

/// <summary>
/// The <see cref="Int8Array"/> typed array represents an array of twos-complement 8-bit signed integers.
/// The contents are initialized to 0. Once established, you can reference elements in the
/// array using the object's methods, or using standard array index syntax
/// (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("sbyte")]
public partial class Int8Array : ArrayBufferView, IReadOnlyList<sbyte>
{
}

/// <summary>
/// The <see cref="Uint8Array"/> typed array represents an array of 8-bit unsigned integers. 
/// The contents are initialized to 0. Once established, you can reference elements in the
/// array using the object's methods, or using standard array index syntax
/// (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("byte")]
public partial class Uint8Array : ArrayBufferView, IReadOnlyList<byte>
{
}

/// <summary>
/// The <see cref="Int16Array"/> typed array represents an array of twos-complement 16-bit signed integers
/// in the platform byte order. If control over byte order is needed, use <see cref="DataView"/> instead.
/// The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods,
/// or using standard array index syntax (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("short")]
public partial class Int16Array : ArrayBufferView, IReadOnlyList<short>
{
}

/// <summary>
/// The <see cref="Uint16Array"/> typed array represents an array of 16-bit unsigned integers 
/// in the platform byte order. If control over byte order is needed, use <see cref="DataView"/> instead.
/// The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods,
/// or using standard array index syntax (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("ushort")]
public partial class Uint16Array : ArrayBufferView, IReadOnlyList<ushort>
{
}

/// <summary>
/// The <see cref="Int32Array"/> typed array represents an array of twos-complement 32-bit signed integers
/// in the platform byte order. If control over byte order is needed, use <see cref="DataView"/> instead.
/// The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods,
/// or using standard array index syntax (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("int")]
public partial class Int32Array : ArrayBufferView, IReadOnlyList<int>
{
}

/// <summary>
/// The <see cref="Uint32Array"/> typed array represents an array of 32-bit unsigned integers 
/// in the platform byte order. If control over byte order is needed, use <see cref="DataView"/> instead.
/// The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods,
/// or using standard array index syntax (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("uint")]
public partial class Uint32Array : ArrayBufferView, IReadOnlyList<uint>
{
}

/// <summary>
/// The <see cref="Float32Array"/> typed array represents an array of 32-bit floating point numbers
/// (corresponding to the C float data type) in the platform byte order. If control over byte order is 
/// needed, use <see cref="DataView"/> instead. The contents are initialized to 0. Once established, 
/// you can reference elements in the array using the object's methods, or using standard array index syntax 
/// (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("float")]
public partial class Float32Array : ArrayBufferView, IReadOnlyList<float>
{
}

/// <summary>
/// The <see cref="Float64Array"/> typed array represents an array of 64-bit floating point numbers
/// (corresponding to the C double data type) in the platform byte order. If control over byte order is 
/// needed, use <see cref="DataView"/> instead. The contents are initialized to 0. Once established, 
/// you can reference elements in the array using the object's methods, or using standard array index syntax 
/// (that is, using bracket notation).
/// </summary>
[JsObject]
[TypedArray("double")]
public partial class Float64Array : ArrayBufferView, IReadOnlyList<double>
{
}
