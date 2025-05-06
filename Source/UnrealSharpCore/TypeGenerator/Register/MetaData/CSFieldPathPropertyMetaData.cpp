#include "CSFieldPathPropertyMetaData.h"

void FCSFieldPathPropertyMetaData::SerializeFromJson(const TSharedPtr<FJsonObject>& JsonObject)
{
	FCSUnrealType::SerializeFromJson(JsonObject);
	PropertyClass.SerializeFromJson(JsonObject->GetObjectField(TEXT("PropertyClass")));
}

bool FCSFieldPathPropertyMetaData::IsEqual(TSharedPtr<FCSUnrealType> Other) const
{
	if (!FCSUnrealType::IsEqual(Other))
	{
		return false;
	}

	TSharedPtr<FCSFieldPathPropertyMetaData> OtherFieldPath = SafeCast<FCSFieldPathPropertyMetaData>(Other);
	if (!OtherFieldPath.IsValid())
	{
		return false;
	}
	
	return PropertyClass == OtherFieldPath->PropertyClass;
}
