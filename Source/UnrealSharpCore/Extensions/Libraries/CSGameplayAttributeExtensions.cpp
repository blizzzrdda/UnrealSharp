// Fill out your copyright notice in the Description page of Project Settings.


#include "CSGameplayAttributeExtensions.h"

#include "AbilitySystemComponent.h"
#include "AttributeSet.h"


FGameplayAttribute UCSGameplayAttributeExtensions::FindGameplayAttributeFromClassAndPropertyNameChecked(
	const UClass* staticClass, FName FieldName)
{
	FProperty* Prop = FindFieldChecked<FProperty>( staticClass, FieldName);

	if (Prop == nullptr)
	{
		UE_LOG(LogTemp, Error, TEXT("Failed to find attribute %s"), *FieldName.ToString());
		return FGameplayAttribute();
	}

	FGameplayAttribute Attribute;
	Attribute.SetUProperty(Prop);
	return Attribute;
}

bool UCSGameplayAttributeExtensions::IsGameplayAttributeValid(const FGameplayAttribute& Attribute)
{
	return Attribute.IsValid();
}

float UCSGameplayAttributeExtensions::FindGameplayAttributeValue(UAbilitySystemComponent* ASC,
	const FGameplayAttribute& Attribute)
{
	if (ASC == nullptr)
	{
		return 0.0f;
	}

	if (!Attribute.IsValid())
	{
		return 0.0f;
	}

	for (const UAttributeSet* Set : ASC->GetSpawnedAttributes())
	{
		if (Set && Set->IsA(Attribute.GetAttributeSetClass()))
		{
			return Attribute.GetNumericValue(Set);
		}
	}

	return 0.0f;
}
