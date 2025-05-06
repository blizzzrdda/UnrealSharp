#pragma once

#include "CSTypeReferenceMetaData.h"
#include "CSUnrealType.h"

struct FCSFieldPathPropertyMetaData : FCSUnrealType
{
	virtual ~FCSFieldPathPropertyMetaData() = default;

	FCSTypeReferenceMetaData PropertyClass;

	// FUnrealType interface implementation
	virtual void SerializeFromJson(const TSharedPtr<FJsonObject>& JsonObject) override;
	virtual bool IsEqual(TSharedPtr<FCSUnrealType> Other) const override;
	// End of implementation
};
