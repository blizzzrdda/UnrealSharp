using UnrealSharp.Binds;
using UnrealSharp.GameplayAbilities;

namespace UnrealSharp.Interop;

[NativeCallbacks]
public static unsafe partial class FGameplayEffectSpecHandleExporter
{
    public static delegate* unmanaged<IntPtr, FGameplayEffectSpecHandle> CreateFromSpec;
    public static delegate* unmanaged<FGameplayEffectSpecHandle, IntPtr> GetSpecFromHandle;
    public static delegate* unmanaged<FGameplayEffectSpecHandle, NativeBool> IsValid;
    public static delegate* unmanaged<FGameplayEffectSpecHandle, int> GetReferenceCount;
    public static delegate* unmanaged<FGameplayEffectSpecHandle> CreateInvalidHandle;
    public static delegate* unmanaged<FGameplayEffectSpecHandle, FGameplayEffectSpecHandle> CopyHandle;
    public static delegate* unmanaged<FGameplayEffectSpecHandle*, FGameplayEffectSpecHandle, void> AssignHandle;
    public static delegate* unmanaged<FGameplayEffectSpecHandle, IntPtr> GetRawSpecPointer;
}