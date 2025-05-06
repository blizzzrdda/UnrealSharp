using System;
using System.Reflection;
using UnrealSharp.Core.Marshallers;
using UnrealSharp.GameplayAbilities;

namespace UnrealSharp.Extensions.GameplayAttributes;

/// <summary>
/// Marshaller for FGameplayAttribute to convert between native and managed representations.
/// </summary>
public static class GameplayAttributeMarshaller
{
    // Field info for reflection access to the generated fields
    private static readonly FieldInfo PropertyField = typeof(FGameplayAttribute).GetField("Property");
    private static readonly FieldInfo AttributeOwnerField = typeof(FGameplayAttribute).GetField("AttributeOwner");
    private static readonly FieldInfo AttributeNameField = typeof(FGameplayAttribute).GetField("AttributeName");

    public static void ToNative(IntPtr nativeBuffer, int arrayIndex, FGameplayAttribute obj)
    {
        // Calculate the offset for this array index
        IntPtr offset = nativeBuffer + arrayIndex * GetStructSize();

        // Marshal the Property field (TFieldPath<FProperty>)
        if (PropertyField != null)
        {
            FFieldPath property = (FFieldPath)PropertyField.GetValue(obj);
            FieldPathMarshaller.ToNative(offset, 0, property);
        }

        // Marshal the AttributeOwner field (TSubclassOf<UAttributeSet>)
        if (AttributeOwnerField != null)
        {
            var attributeOwner = (TSubclassOf<UAttributeSet>)AttributeOwnerField.GetValue(obj);
            SubclassOfMarshaller<UAttributeSet>.ToNative(IntPtr.Add(offset, IntPtr.Size), 0, attributeOwner);
        }

        // Marshal the AttributeName field (FName)
        if (AttributeNameField != null)
        {
            var attributeName = (FName)AttributeNameField.GetValue(obj);
            BlittableMarshaller<FName>.ToNative(IntPtr.Add(offset, IntPtr.Size * 2), 0, attributeName);
        }
    }

    public static FGameplayAttribute FromNative(IntPtr nativeBuffer, int arrayIndex)
    {
        // Calculate the offset for this array index
        IntPtr offset = nativeBuffer + arrayIndex * GetStructSize();

        FGameplayAttribute result = new FGameplayAttribute();

        // Marshal the Property field (TFieldPath<FProperty>)
        if (PropertyField != null)
        {
            FFieldPath property = FieldPathMarshaller.FromNative(offset, 0);
            PropertyField.SetValue(result, property);
        }

        // Marshal the AttributeOwner field (TSubclassOf<UAttributeSet>)
        if (AttributeOwnerField != null)
        {
            var attributeOwner = SubclassOfMarshaller<UAttributeSet>.FromNative(IntPtr.Add(offset, IntPtr.Size), 0);
            AttributeOwnerField.SetValue(result, attributeOwner);
        }

        // Marshal the AttributeName field (FName)
        if (AttributeNameField != null)
        {
            var attributeName = BlittableMarshaller<FName>.FromNative(IntPtr.Add(offset, IntPtr.Size * 2), 0);
            AttributeNameField.SetValue(result, attributeName);
        }

        return result;
    }

    private static int GetStructSize()
    {
        // Size of FGameplayAttribute = size of IntPtr (for Property) + size of IntPtr (for AttributeOwner) + size of FName
        // FName size is either 2 or 3 uint fields depending on the PACKAGE define
#if PACKAGE
        int fNameSize = sizeof(uint) * 2; // ComparisonIndex + Number
#else
        int fNameSize = sizeof(uint) * 3; // ComparisonIndex + DisplayIndex + Number
#endif
        return IntPtr.Size * 2 + fNameSize;
    }
}
