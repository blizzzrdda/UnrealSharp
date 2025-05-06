using System.Runtime.InteropServices;
using UnrealSharp.CoreUObject;
using UnrealSharp.Extensions.GameplayAttributes;
using UnrealSharp.UnrealSharpCore;

namespace UnrealSharp.GameplayAbilities;

[StructLayout(LayoutKind.Sequential)]
public partial struct FGameplayAttribute
{
    // Note: The actual fields (Property, AttributeOwner, AttributeName) are defined in the generated code

    public FGameplayAttribute(Type parentClass, FName propertyName)
    {
        this = UCSGameplayAttributeExtensions.FindGameplayAttributeFromClassAndPropertyNameChecked(parentClass,
            propertyName);
        if (!IsValid)
        {
            string parentClassName = parentClass.IsVisible ? parentClass.ToString() : "CLASS_INVALID";
            throw new Exception(
                $"Failed to create GameplayAttribute: {parentClassName}.{propertyName}");
        }
    }

    public static FGameplayAttribute None => new(typeof(UAttributeSet), FName.None);

    public bool IsValid => UCSGameplayAttributeExtensions.IsGameplayAttributeValid(this);

    public bool Equals(FGameplayAttribute other)
    {
        return AttributeOwner == other.AttributeOwner && AttributeName == other.AttributeName;
    }

    public override bool Equals(object? obj)
    {
        return obj is FGameplayAttribute other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AttributeOwner, AttributeName);
    }

    public override string ToString()
    {
        if (AttributeOwner.IsValid)
        {
            return $"{AttributeOwner.ToString()}.{AttributeName}";
        }

        return $"Invalid.{AttributeName}";
    }

    public static bool operator ==(FGameplayAttribute left, FGameplayAttribute right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(FGameplayAttribute left, FGameplayAttribute right)
    {
        return !(left == right);
    }
}