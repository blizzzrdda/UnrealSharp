#include "FGameplayEffectSpecHandleExporter.h"
#include "GameplayEffectTypes.h"

FGameplayEffectSpecHandle UFGameplayEffectSpecHandleExporter::CreateFromSpec(TSharedPtr<FGameplayEffectSpec> Spec)
{
    return FGameplayEffectSpecHandle(Spec);
}

TSharedPtr<FGameplayEffectSpec> UFGameplayEffectSpecHandleExporter::GetSpecFromHandle(const FGameplayEffectSpecHandle& Handle)
{
    return Handle.Data;
}

bool UFGameplayEffectSpecHandleExporter::IsValid(const FGameplayEffectSpecHandle& Handle)
{
    return Handle.IsValid();
}

int32 UFGameplayEffectSpecHandleExporter::GetReferenceCount(const FGameplayEffectSpecHandle& Handle)
{
    if (Handle.Data.IsValid())
    {
        return Handle.Data.GetSharedReferenceCount();
    }
    return 0;
}

FGameplayEffectSpecHandle UFGameplayEffectSpecHandleExporter::CreateInvalidHandle()
{
    return FGameplayEffectSpecHandle();
}

FGameplayEffectSpecHandle UFGameplayEffectSpecHandleExporter::CopyHandle(const FGameplayEffectSpecHandle& Other)
{
    return FGameplayEffectSpecHandle(Other);
}

void UFGameplayEffectSpecHandleExporter::AssignHandle(FGameplayEffectSpecHandle& Target, const FGameplayEffectSpecHandle& Source)
{
    Target = Source;
}

FGameplayEffectSpec* UFGameplayEffectSpecHandleExporter::GetRawSpecPointer(const FGameplayEffectSpecHandle& Handle)
{
    return Handle.Data.Get();
}