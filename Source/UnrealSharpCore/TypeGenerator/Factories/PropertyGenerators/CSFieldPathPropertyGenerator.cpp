#include "CSFieldPathPropertyGenerator.h"
#include "TypeGenerator/Register/MetaData/CSFieldPathPropertyMetaData.h"

FProperty* UCSFieldPathPropertyGenerator::CreateProperty(UField* Outer, const FCSPropertyMetaData& PropertyMetaData)
{
	FFieldPathProperty* NewProperty = static_cast<FFieldPathProperty*>(Super::CreateProperty(Outer, PropertyMetaData));

	// If needed, set the property class
	// const TSharedPtr<FCSFieldPathPropertyMetaData> FieldPathPropertyMetaData = PropertyMetaData.GetTypeMetaData<FCSFieldPathPropertyMetaData>();
	// NewProperty->PropertyClass = FindClass(FieldPathPropertyMetaData->PropertyClass);

	return NewProperty;
}

TSharedPtr<FCSUnrealType> UCSFieldPathPropertyGenerator::CreateTypeMetaData(ECSPropertyType PropertyType)
{
	return MakeShared<FCSFieldPathPropertyMetaData>();
}
