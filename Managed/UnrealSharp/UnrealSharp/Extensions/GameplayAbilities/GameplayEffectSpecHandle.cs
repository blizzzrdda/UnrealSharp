using System;
using UnrealSharp.Core.Marshallers;
using UnrealSharp.Interop;

namespace UnrealSharp.GameplayAbilities;

public partial struct FGameplayEffectSpecHandle
{
    // Internal data to track the TSharedPtr reference
    private IntPtr _sharedPtrData;
    
    public FGameplayEffectSpecHandle(IntPtr sharedPtrData)
    {
        _sharedPtrData = sharedPtrData;
    }
    
    /// <summary>
    /// Check if this handle is valid (has a valid TSharedPtr)
    /// </summary>
    public bool IsValid => GameplayEffectSpecHandleExporter.CallIsValid(this);
    
    /// <summary>
    /// Get the reference count of the underlying TSharedPtr
    /// </summary>
    public int ReferenceCount => GameplayEffectSpecHandleExporter.CallGetReferenceCount(this);
    
    /// <summary>
    /// Create an invalid/empty handle
    /// </summary>
    public static FGameplayEffectSpecHandle Invalid => GameplayEffectSpecHandleExporter.CallCreateInvalidHandle();
    
    /// <summary>
    /// Copy this handle (properly handles TSharedPtr reference counting)
    /// </summary>
    public FGameplayEffectSpecHandle Copy()
    {
        return GameplayEffectSpecHandleExporter.CallCopyHandle(this);
    }
    
    /// <summary>
    /// Get the raw pointer to the FGameplayEffectSpec (for advanced use cases)
    /// </summary>
    public IntPtr GetRawSpecPointer()
    {
        return GameplayEffectSpecHandleExporter.CallGetRawSpecPointer(this);
    }
    
    public static bool operator ==(FGameplayEffectSpecHandle left, FGameplayEffectSpecHandle right)
    {
        return left._sharedPtrData == right._sharedPtrData;
    }
    
    public static bool operator !=(FGameplayEffectSpecHandle left, FGameplayEffectSpecHandle right)
    {
        return !(left == right);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is FGameplayEffectSpecHandle other)
        {
            return this == other;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return _sharedPtrData.GetHashCode();
    }
}

/// <summary>
/// Custom marshaller for FGameplayEffectSpecHandle that properly handles TSharedPtr marshalling
/// </summary>
public static class GameplayEffectSpecHandleMarshaller
{
    public static void ToNative(IntPtr nativeBuffer, int arrayIndex, FGameplayEffectSpecHandle obj)
    {
        unsafe
        {
            // Copy the entire struct including the TSharedPtr data
            *(FGameplayEffectSpecHandle*)(nativeBuffer + arrayIndex * sizeof(FGameplayEffectSpecHandle)) = obj;
        }
    }
    
    public static FGameplayEffectSpecHandle FromNative(IntPtr nativeBuffer, int arrayIndex)
    {
        unsafe
        {
            // Copy the entire struct including the TSharedPtr data
            return *(FGameplayEffectSpecHandle*)(nativeBuffer + arrayIndex * sizeof(FGameplayEffectSpecHandle));
        }
    }
}