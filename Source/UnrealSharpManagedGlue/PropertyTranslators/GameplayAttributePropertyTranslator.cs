using EpicGames.UHT.Types;
using UnrealSharpScriptGenerator.Utilities;

namespace UnrealSharpScriptGenerator.PropertyTranslators;

/// <summary>
/// Property translator for FGameplayAttribute type.
/// </summary>
public class GameplayAttributePropertyTranslator : BlittableTypePropertyTranslator
{
    public GameplayAttributePropertyTranslator() : base(typeof(UhtStructProperty), "FGameplayAttribute")
    {
    }

    public override bool CanExport(UhtProperty property)
    {
        if (property is not UhtStructProperty structProperty)
        {
            return false;
        }

        return structProperty.Struct.EngineName == "GameplayAttribute";
    }

    public override string GetMarshaller(UhtProperty property)
    {
        return "GameplayAttributeMarshaller";
    }

    public override string ExportMarshallerDelegates(UhtProperty property)
    {
        return "GameplayAttributeMarshaller.ToNative, GameplayAttributeMarshaller.FromNative";
    }

    public override string GetNullValue(UhtProperty property)
    {
        return "FGameplayAttribute.None";
    }
}
