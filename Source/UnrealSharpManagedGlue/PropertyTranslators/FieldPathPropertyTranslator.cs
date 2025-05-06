using EpicGames.UHT.Types;
using UnrealSharpScriptGenerator.Utilities;

namespace UnrealSharpScriptGenerator.PropertyTranslators;

/// <summary>
/// Property translator for TFieldPath<FProperty> type.
/// </summary>
public class FieldPathPropertyTranslator : BlittableTypePropertyTranslator
{
    public FieldPathPropertyTranslator() : base(typeof(UhtStructProperty), "FFieldPath")
    {
    }

    public override bool CanExport(UhtProperty property)
    {
        if (property is not UhtStructProperty structProperty)
        {
            return false;
        }

        return structProperty.Struct.EngineName == "FieldPath" || structProperty.Struct.EngineName == "FieldPathProperty";
    }

    public override string GetMarshaller(UhtProperty property)
    {
        return "FieldPathMarshaller";
    }

    public override string ExportMarshallerDelegates(UhtProperty property)
    {
        return "FieldPathMarshaller.ToNative, FieldPathMarshaller.FromNative";
    }

    public override string GetNullValue(UhtProperty property)
    {
        return "new FFieldPath(IntPtr.Zero)";
    }
}
