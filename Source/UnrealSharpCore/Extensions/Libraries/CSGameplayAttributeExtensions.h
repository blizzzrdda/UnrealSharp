// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "AttributeSet.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "CSGameplayAttributeExtensions.generated.h"

class UAbilitySystemComponent;
/**
 * 
 */
UCLASS()
class UNREALSHARPCORE_API UCSGameplayAttributeExtensions : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintPure, meta = (ExtensionMethod))
	static struct FGameplayAttribute FindGameplayAttributeFromClassAndPropertyNameChecked(
		const UClass* staticClass, FName FieldName);

	UFUNCTION(BlueprintPure, meta = (ExtensionMethod))
	static bool IsGameplayAttributeValid(const FGameplayAttribute& Attribute);

	UFUNCTION(BlueprintCallable, meta = (ExtensionMethod))
	static float FindGameplayAttributeValue(UAbilitySystemComponent* ASC, const FGameplayAttribute& Attribute);
};
