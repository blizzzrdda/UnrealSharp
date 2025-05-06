using System;
using System.Runtime.InteropServices;
using UnrealSharp.Core.Marshallers;

namespace UnrealSharp;

/// <summary>
/// Represents a TFieldPath to an FProperty in Unreal Engine.
/// This is a wrapper around a pointer to an FProperty.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FFieldPath
{
    // The native pointer to the FProperty
    internal IntPtr PropertyPtr;

    public FFieldPath(IntPtr propertyPtr)
    {
        PropertyPtr = propertyPtr;
    }

    public bool IsValid => PropertyPtr != IntPtr.Zero;

    public override bool Equals(object? obj)
    {
        if (obj is FFieldPath other)
        {
            return PropertyPtr == other.PropertyPtr;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return PropertyPtr.GetHashCode();
    }

    public static bool operator ==(FFieldPath left, FFieldPath right)
    {
        return left.PropertyPtr == right.PropertyPtr;
    }

    public static bool operator !=(FFieldPath left, FFieldPath right)
    {
        return !(left == right);
    }
}

/// <summary>
/// Marshaller for FFieldPath to convert between native and managed representations.
/// </summary>
public static class FieldPathMarshaller
{
    public static void ToNative(IntPtr nativeBuffer, int arrayIndex, FFieldPath obj)
    {
        BlittableMarshaller<IntPtr>.ToNative(nativeBuffer, arrayIndex, obj.PropertyPtr);
    }

    public static FFieldPath FromNative(IntPtr nativeBuffer, int arrayIndex)
    {
        IntPtr propertyPtr = BlittableMarshaller<IntPtr>.FromNative(nativeBuffer, arrayIndex);
        return new FFieldPath(propertyPtr);
    }
}
