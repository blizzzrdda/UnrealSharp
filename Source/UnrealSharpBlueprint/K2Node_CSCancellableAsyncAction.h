// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "CoreMinimal.h"
#include "K2Node_CSAsyncAction.h"
#include "UObject/ObjectMacros.h"
#include "UObject/UObjectGlobals.h"

#include "K2Node_CSCancellableAsyncAction.generated.h"

class FBlueprintActionDatabaseRegistrar;
class UObject;

UCLASS()
class UK2Node_CSCancellableAsyncAction : public UK2Node_CSAsyncAction
{
	GENERATED_BODY()

public:

	UK2Node_CSCancellableAsyncAction();
	
	// UK2Node interface
	virtual void GetMenuActions(FBlueprintActionDatabaseRegistrar& ActionRegistrar) const override;
	virtual void ExpandNode(class FKismetCompilerContext& CompilerContext, UEdGraph* SourceGraph) override;
	// End of UK2Node interface
};
