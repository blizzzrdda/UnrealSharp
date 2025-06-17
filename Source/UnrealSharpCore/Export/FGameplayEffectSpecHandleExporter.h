#pragma once

#include "CoreMinimal.h"
#include "CSBindsManager.h"
#include "FGameplayEffectSpecHandleExporter.generated.h"

// Forward declarations
struct FGameplayEffectSpecHandle;
struct FGameplayEffectSpec;

UCLASS()
class UNREALSHARPCORE_API UFGameplayEffectSpecHandleExporter : public UObject
{
    GENERATED_BODY()

public:

    // Create a new FGameplayEffectSpecHandle from a TSharedPtr<FGameplayEffectSpec>
    UNREALSHARP_FUNCTION()
    static FGameplayEffectSpecHandle CreateFromSpec(TSharedPtr<FGameplayEffectSpec> Spec);

    // Get the TSharedPtr<FGameplayEffectSpec> from a FGameplayEffectSpecHandle
    UNREALSHARP_FUNCTION()
    static TSharedPtr<FGameplayEffectSpec> GetSpecFromHandle(const FGameplayEffectSpecHandle& Handle);

    // Check if the handle is valid (has a valid TSharedPtr)
    UNREALSHARP_FUNCTION()
    static bool IsValid(const FGameplayEffectSpecHandle& Handle);

    // Get the reference count of the underlying TSharedPtr
    UNREALSHARP_FUNCTION()
    static int32 GetReferenceCount(const FGameplayEffectSpecHandle& Handle);

    // Create an invalid/empty handle
    UNREALSHARP_FUNCTION()
    static FGameplayEffectSpecHandle CreateInvalidHandle();

    // Copy constructor equivalent - properly handles TSharedPtr reference counting
    UNREALSHARP_FUNCTION()
    static FGameplayEffectSpecHandle CopyHandle(const FGameplayEffectSpecHandle& Other);

    // Assignment operator equivalent - properly handles TSharedPtr reference counting
    UNREALSHARP_FUNCTION()
    static void AssignHandle(FGameplayEffectSpecHandle& Target, const FGameplayEffectSpecHandle& Source);

    // Get the raw pointer to the FGameplayEffectSpec (for advanced use cases)
    UNREALSHARP_FUNCTION()
    static FGameplayEffectSpec* GetRawSpecPointer(const FGameplayEffectSpecHandle& Handle);
};