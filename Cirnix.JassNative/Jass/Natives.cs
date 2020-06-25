using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Windows;
using Cirnix.JassNative.Runtime.Utilities;

using Cirnix.JassNative.WarAPI;
using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.JassAPI
{
    public static class Natives
    {
        private static List<NativeDeclaration> vanillaNatives = new List<NativeDeclaration>();
        private static List<NativeDeclaration> customNatives = new List<NativeDeclaration>();
        private static Dictionary<CTriggerWar3Ptr, JassTrigger> handles = new Dictionary<CTriggerWar3Ptr, JassTrigger>();
        private static InitNativesPrototype InitNatives;
        private static ConvertRacePrototype _ConvertRace;
        private static ConvertAllianceTypePrototype _ConvertAllianceType;
        private static ConvertRacePrefPrototype _ConvertRacePref;
        private static ConvertIGameStatePrototype _ConvertIGameState;
        private static ConvertFGameStatePrototype _ConvertFGameState;
        private static ConvertPlayerStatePrototype _ConvertPlayerState;
        private static ConvertPlayerScorePrototype _ConvertPlayerScore;
        private static ConvertPlayerGameResultPrototype _ConvertPlayerGameResult;
        private static ConvertUnitStatePrototype _ConvertUnitState;
        private static ConvertAIDifficultyPrototype _ConvertAIDifficulty;
        private static ConvertGameEventPrototype _ConvertGameEvent;
        private static ConvertPlayerEventPrototype _ConvertPlayerEvent;
        private static ConvertPlayerUnitEventPrototype _ConvertPlayerUnitEvent;
        private static ConvertWidgetEventPrototype _ConvertWidgetEvent;
        private static ConvertDialogEventPrototype _ConvertDialogEvent;
        private static ConvertUnitEventPrototype _ConvertUnitEvent;
        private static ConvertLimitOpPrototype _ConvertLimitOp;
        private static ConvertUnitTypePrototype _ConvertUnitType;
        private static ConvertGameSpeedPrototype _ConvertGameSpeed;
        private static ConvertPlacementPrototype _ConvertPlacement;
        private static ConvertStartLocPrioPrototype _ConvertStartLocPrio;
        private static ConvertGameDifficultyPrototype _ConvertGameDifficulty;
        private static ConvertGameTypePrototype _ConvertGameType;
        private static ConvertMapFlagPrototype _ConvertMapFlag;
        private static ConvertMapVisibilityPrototype _ConvertMapVisibility;
        private static ConvertMapSettingPrototype _ConvertMapSetting;
        private static ConvertMapDensityPrototype _ConvertMapDensity;
        private static ConvertMapControlPrototype _ConvertMapControl;
        private static ConvertPlayerColorPrototype _ConvertPlayerColor;
        private static ConvertPlayerSlotStatePrototype _ConvertPlayerSlotState;
        private static ConvertVolumeGroupPrototype _ConvertVolumeGroup;
        private static ConvertCameraFieldPrototype _ConvertCameraField;
        private static ConvertBlendModePrototype _ConvertBlendMode;
        private static ConvertRarityControlPrototype _ConvertRarityControl;
        private static ConvertTexMapFlagsPrototype _ConvertTexMapFlags;
        private static ConvertFogStatePrototype _ConvertFogState;
        private static ConvertEffectTypePrototype _ConvertEffectType;
        private static ConvertVersionPrototype _ConvertVersion;
        private static ConvertItemTypePrototype _ConvertItemType;
        private static ConvertAttackTypePrototype _ConvertAttackType;
        private static ConvertDamageTypePrototype _ConvertDamageType;
        private static ConvertWeaponTypePrototype _ConvertWeaponType;
        private static ConvertSoundTypePrototype _ConvertSoundType;
        private static ConvertPathingTypePrototype _ConvertPathingType;
        private static OrderIdPrototype _OrderId;
        private static OrderId2StringPrototype _OrderId2String;
        private static UnitIdPrototype _UnitId;
        private static UnitId2StringPrototype _UnitId2String;
        private static AbilityIdPrototype _AbilityId;
        private static AbilityId2StringPrototype _AbilityId2String;
        private static GetObjectNamePrototype _GetObjectName;
        private static Deg2RadPrototype _Deg2Rad;
        private static Rad2DegPrototype _Rad2Deg;
        private static SinPrototype _Sin;
        private static CosPrototype _Cos;
        private static TanPrototype _Tan;
        private static AsinPrototype _Asin;
        private static AcosPrototype _Acos;
        private static AtanPrototype _Atan;
        private static Atan2Prototype _Atan2;
        private static SquareRootPrototype _SquareRoot;
        private static PowPrototype _Pow;
        private static I2RPrototype _I2R;
        private static R2IPrototype _R2I;
        private static I2SPrototype _I2S;
        private static R2SPrototype _R2S;
        private static R2SWPrototype _R2SW;
        private static S2IPrototype _S2I;
        private static S2RPrototype _S2R;
        private static GetHandleIdPrototype _GetHandleId;
        private static SubStringPrototype _SubString;
        private static StringLengthPrototype _StringLength;
        private static StringCasePrototype _StringCase;
        private static StringHashPrototype _StringHash;
        private static GetLocalizedStringPrototype _GetLocalizedString;
        private static GetLocalizedHotkeyPrototype _GetLocalizedHotkey;
        private static SetMapNamePrototype _SetMapName;
        private static SetMapDescriptionPrototype _SetMapDescription;
        private static SetTeamsPrototype _SetTeams;
        private static SetPlayersPrototype _SetPlayers;
        private static DefineStartLocationPrototype _DefineStartLocation;
        private static DefineStartLocationLocPrototype _DefineStartLocationLoc;
        private static SetStartLocPrioCountPrototype _SetStartLocPrioCount;
        private static SetStartLocPrioPrototype _SetStartLocPrio;
        private static GetStartLocPrioSlotPrototype _GetStartLocPrioSlot;
        private static GetStartLocPrioPrototype _GetStartLocPrio;
        private static SetGameTypeSupportedPrototype _SetGameTypeSupported;
        private static SetMapFlagPrototype _SetMapFlag;
        private static SetGamePlacementPrototype _SetGamePlacement;
        private static SetGameSpeedPrototype _SetGameSpeed;
        private static SetGameDifficultyPrototype _SetGameDifficulty;
        private static SetResourceDensityPrototype _SetResourceDensity;
        private static SetCreatureDensityPrototype _SetCreatureDensity;
        private static GetTeamsPrototype _GetTeams;
        private static GetPlayersPrototype _GetPlayers;
        private static IsGameTypeSupportedPrototype _IsGameTypeSupported;
        private static GetGameTypeSelectedPrototype _GetGameTypeSelected;
        private static IsMapFlagSetPrototype _IsMapFlagSet;
        private static GetGamePlacementPrototype _GetGamePlacement;
        private static GetGameSpeedPrototype _GetGameSpeed;
        private static GetGameDifficultyPrototype _GetGameDifficulty;
        private static GetResourceDensityPrototype _GetResourceDensity;
        private static GetCreatureDensityPrototype _GetCreatureDensity;
        private static GetStartLocationXPrototype _GetStartLocationX;
        private static GetStartLocationYPrototype _GetStartLocationY;
        private static GetStartLocationLocPrototype _GetStartLocationLoc;
        private static SetPlayerTeamPrototype _SetPlayerTeam;
        private static SetPlayerStartLocationPrototype _SetPlayerStartLocation;
        private static ForcePlayerStartLocationPrototype _ForcePlayerStartLocation;
        private static SetPlayerColorPrototype _SetPlayerColor;
        private static SetPlayerAlliancePrototype _SetPlayerAlliance;
        private static SetPlayerTaxRatePrototype _SetPlayerTaxRate;
        private static SetPlayerRacePreferencePrototype _SetPlayerRacePreference;
        private static SetPlayerRaceSelectablePrototype _SetPlayerRaceSelectable;
        private static SetPlayerControllerPrototype _SetPlayerController;
        private static SetPlayerNamePrototype _SetPlayerName;
        private static SetPlayerOnScoreScreenPrototype _SetPlayerOnScoreScreen;
        private static GetPlayerTeamPrototype _GetPlayerTeam;
        private static GetPlayerStartLocationPrototype _GetPlayerStartLocation;
        private static GetPlayerColorPrototype _GetPlayerColor;
        private static GetPlayerSelectablePrototype _GetPlayerSelectable;
        private static GetPlayerControllerPrototype _GetPlayerController;
        private static GetPlayerSlotStatePrototype _GetPlayerSlotState;
        private static GetPlayerTaxRatePrototype _GetPlayerTaxRate;
        private static IsPlayerRacePrefSetPrototype _IsPlayerRacePrefSet;
        private static GetPlayerNamePrototype _GetPlayerName;
        private static CreateTimerPrototype _CreateTimer;
        private static DestroyTimerPrototype _DestroyTimer;
        private static TimerStartPrototype _TimerStart;
        private static TimerGetElapsedPrototype _TimerGetElapsed;
        private static TimerGetRemainingPrototype _TimerGetRemaining;
        private static TimerGetTimeoutPrototype _TimerGetTimeout;
        private static PauseTimerPrototype _PauseTimer;
        private static ResumeTimerPrototype _ResumeTimer;
        private static GetExpiredTimerPrototype _GetExpiredTimer;
        private static CreateGroupPrototype _CreateGroup;
        private static DestroyGroupPrototype _DestroyGroup;
        private static GroupAddUnitPrototype _GroupAddUnit;
        private static GroupRemoveUnitPrototype _GroupRemoveUnit;
        private static GroupClearPrototype _GroupClear;
        private static GroupEnumUnitsOfTypePrototype _GroupEnumUnitsOfType;
        private static GroupEnumUnitsOfPlayerPrototype _GroupEnumUnitsOfPlayer;
        private static GroupEnumUnitsOfTypeCountedPrototype _GroupEnumUnitsOfTypeCounted;
        private static GroupEnumUnitsInRectPrototype _GroupEnumUnitsInRect;
        private static GroupEnumUnitsInRectCountedPrototype _GroupEnumUnitsInRectCounted;
        private static GroupEnumUnitsInRangePrototype _GroupEnumUnitsInRange;
        private static GroupEnumUnitsInRangeOfLocPrototype _GroupEnumUnitsInRangeOfLoc;
        private static GroupEnumUnitsInRangeCountedPrototype _GroupEnumUnitsInRangeCounted;
        private static GroupEnumUnitsInRangeOfLocCountedPrototype _GroupEnumUnitsInRangeOfLocCounted;
        private static GroupEnumUnitsSelectedPrototype _GroupEnumUnitsSelected;
        private static GroupImmediateOrderPrototype _GroupImmediateOrder;
        private static GroupImmediateOrderByIdPrototype _GroupImmediateOrderById;
        private static GroupPointOrderPrototype _GroupPointOrder;
        private static GroupPointOrderLocPrototype _GroupPointOrderLoc;
        private static GroupPointOrderByIdPrototype _GroupPointOrderById;
        private static GroupPointOrderByIdLocPrototype _GroupPointOrderByIdLoc;
        private static GroupTargetOrderPrototype _GroupTargetOrder;
        private static GroupTargetOrderByIdPrototype _GroupTargetOrderById;
        private static ForGroupPrototype _ForGroup;
        private static FirstOfGroupPrototype _FirstOfGroup;
        private static CreateForcePrototype _CreateForce;
        private static DestroyForcePrototype _DestroyForce;
        private static ForceAddPlayerPrototype _ForceAddPlayer;
        private static ForceRemovePlayerPrototype _ForceRemovePlayer;
        private static ForceClearPrototype _ForceClear;
        private static ForceEnumPlayersPrototype _ForceEnumPlayers;
        private static ForceEnumPlayersCountedPrototype _ForceEnumPlayersCounted;
        private static ForceEnumAlliesPrototype _ForceEnumAllies;
        private static ForceEnumEnemiesPrototype _ForceEnumEnemies;
        private static ForForcePrototype _ForForce;
        private static RectPrototype _Rect;
        private static RectFromLocPrototype _RectFromLoc;
        private static RemoveRectPrototype _RemoveRect;
        private static SetRectPrototype _SetRect;
        private static SetRectFromLocPrototype _SetRectFromLoc;
        private static MoveRectToPrototype _MoveRectTo;
        private static MoveRectToLocPrototype _MoveRectToLoc;
        private static GetRectCenterXPrototype _GetRectCenterX;
        private static GetRectCenterYPrototype _GetRectCenterY;
        private static GetRectMinXPrototype _GetRectMinX;
        private static GetRectMinYPrototype _GetRectMinY;
        private static GetRectMaxXPrototype _GetRectMaxX;
        private static GetRectMaxYPrototype _GetRectMaxY;
        private static CreateRegionPrototype _CreateRegion;
        private static RemoveRegionPrototype _RemoveRegion;
        private static RegionAddRectPrototype _RegionAddRect;
        private static RegionClearRectPrototype _RegionClearRect;
        private static RegionAddCellPrototype _RegionAddCell;
        private static RegionAddCellAtLocPrototype _RegionAddCellAtLoc;
        private static RegionClearCellPrototype _RegionClearCell;
        private static RegionClearCellAtLocPrototype _RegionClearCellAtLoc;
        private static LocationPrototype _Location;
        private static RemoveLocationPrototype _RemoveLocation;
        private static MoveLocationPrototype _MoveLocation;
        private static GetLocationXPrototype _GetLocationX;
        private static GetLocationYPrototype _GetLocationY;
        private static GetLocationZPrototype _GetLocationZ;
        private static IsUnitInRegionPrototype _IsUnitInRegion;
        private static IsPointInRegionPrototype _IsPointInRegion;
        private static IsLocationInRegionPrototype _IsLocationInRegion;
        private static GetWorldBoundsPrototype _GetWorldBounds;
        private static CreateTriggerPrototype _CreateTrigger;
        private static DestroyTriggerPrototype _DestroyTrigger;
        private static ResetTriggerPrototype _ResetTrigger;
        private static EnableTriggerPrototype _EnableTrigger;
        private static DisableTriggerPrototype _DisableTrigger;
        private static IsTriggerEnabledPrototype _IsTriggerEnabled;
        private static TriggerWaitOnSleepsPrototype _TriggerWaitOnSleeps;
        private static IsTriggerWaitOnSleepsPrototype _IsTriggerWaitOnSleeps;
        private static GetFilterUnitPrototype _GetFilterUnit;
        private static GetEnumUnitPrototype _GetEnumUnit;
        private static GetFilterDestructablePrototype _GetFilterDestructable;
        private static GetEnumDestructablePrototype _GetEnumDestructable;
        private static GetFilterItemPrototype _GetFilterItem;
        private static GetEnumItemPrototype _GetEnumItem;
        private static GetFilterPlayerPrototype _GetFilterPlayer;
        private static GetEnumPlayerPrototype _GetEnumPlayer;
        private static GetTriggeringTriggerPrototype _GetTriggeringTrigger;
        private static GetTriggerEventIdPrototype _GetTriggerEventId;
        private static GetTriggerEvalCountPrototype _GetTriggerEvalCount;
        private static GetTriggerExecCountPrototype _GetTriggerExecCount;
        private static ExecuteFuncPrototype _ExecuteFunc;
        private static AndPrototype _And;
        private static OrPrototype _Or;
        private static NotPrototype _Not;
        private static ConditionPrototype _Condition;
        private static DestroyConditionPrototype _DestroyCondition;
        private static FilterPrototype _Filter;
        private static DestroyFilterPrototype _DestroyFilter;
        private static DestroyBoolExprPrototype _DestroyBoolExpr;
        private static TriggerRegisterVariableEventPrototype _TriggerRegisterVariableEvent;
        private static TriggerRegisterTimerEventPrototype _TriggerRegisterTimerEvent;
        private static TriggerRegisterTimerExpireEventPrototype _TriggerRegisterTimerExpireEvent;
        private static TriggerRegisterGameStateEventPrototype _TriggerRegisterGameStateEvent;
        private static TriggerRegisterDialogEventPrototype _TriggerRegisterDialogEvent;
        private static TriggerRegisterDialogButtonEventPrototype _TriggerRegisterDialogButtonEvent;
        private static GetEventGameStatePrototype _GetEventGameState;
        private static TriggerRegisterGameEventPrototype _TriggerRegisterGameEvent;
        private static GetWinningPlayerPrototype _GetWinningPlayer;
        private static TriggerRegisterEnterRegionPrototype _TriggerRegisterEnterRegion;
        private static GetTriggeringRegionPrototype _GetTriggeringRegion;
        private static GetEnteringUnitPrototype _GetEnteringUnit;
        private static TriggerRegisterLeaveRegionPrototype _TriggerRegisterLeaveRegion;
        private static GetLeavingUnitPrototype _GetLeavingUnit;
        private static TriggerRegisterTrackableHitEventPrototype _TriggerRegisterTrackableHitEvent;
        private static TriggerRegisterTrackableTrackEventPrototype _TriggerRegisterTrackableTrackEvent;
        private static GetTriggeringTrackablePrototype _GetTriggeringTrackable;
        private static GetClickedButtonPrototype _GetClickedButton;
        private static GetClickedDialogPrototype _GetClickedDialog;
        private static GetTournamentFinishSoonTimeRemainingPrototype _GetTournamentFinishSoonTimeRemaining;
        private static GetTournamentFinishNowRulePrototype _GetTournamentFinishNowRule;
        private static GetTournamentFinishNowPlayerPrototype _GetTournamentFinishNowPlayer;
        private static GetTournamentScorePrototype _GetTournamentScore;
        private static GetSaveBasicFilenamePrototype _GetSaveBasicFilename;
        private static TriggerRegisterPlayerEventPrototype _TriggerRegisterPlayerEvent;
        private static GetTriggerPlayerPrototype _GetTriggerPlayer;
        private static TriggerRegisterPlayerUnitEventPrototype _TriggerRegisterPlayerUnitEvent;
        private static GetLevelingUnitPrototype _GetLevelingUnit;
        private static GetLearningUnitPrototype _GetLearningUnit;
        private static GetLearnedSkillPrototype _GetLearnedSkill;
        private static GetLearnedSkillLevelPrototype _GetLearnedSkillLevel;
        private static GetRevivableUnitPrototype _GetRevivableUnit;
        private static GetRevivingUnitPrototype _GetRevivingUnit;
        private static GetAttackerPrototype _GetAttacker;
        private static GetRescuerPrototype _GetRescuer;
        private static GetDyingUnitPrototype _GetDyingUnit;
        private static GetKillingUnitPrototype _GetKillingUnit;
        private static GetDecayingUnitPrototype _GetDecayingUnit;
        private static GetConstructingStructurePrototype _GetConstructingStructure;
        private static GetCancelledStructurePrototype _GetCancelledStructure;
        private static GetConstructedStructurePrototype _GetConstructedStructure;
        private static GetResearchingUnitPrototype _GetResearchingUnit;
        private static GetResearchedPrototype _GetResearched;
        private static GetTrainedUnitTypePrototype _GetTrainedUnitType;
        private static GetTrainedUnitPrototype _GetTrainedUnit;
        private static GetDetectedUnitPrototype _GetDetectedUnit;
        private static GetSummoningUnitPrototype _GetSummoningUnit;
        private static GetSummonedUnitPrototype _GetSummonedUnit;
        private static GetTransportUnitPrototype _GetTransportUnit;
        private static GetLoadedUnitPrototype _GetLoadedUnit;
        private static GetSellingUnitPrototype _GetSellingUnit;
        private static GetSoldUnitPrototype _GetSoldUnit;
        private static GetBuyingUnitPrototype _GetBuyingUnit;
        private static GetSoldItemPrototype _GetSoldItem;
        private static GetChangingUnitPrototype _GetChangingUnit;
        private static GetChangingUnitPrevOwnerPrototype _GetChangingUnitPrevOwner;
        private static GetManipulatingUnitPrototype _GetManipulatingUnit;
        private static GetManipulatedItemPrototype _GetManipulatedItem;
        private static GetOrderedUnitPrototype _GetOrderedUnit;
        private static GetIssuedOrderIdPrototype _GetIssuedOrderId;
        private static GetOrderPointXPrototype _GetOrderPointX;
        private static GetOrderPointYPrototype _GetOrderPointY;
        private static GetOrderPointLocPrototype _GetOrderPointLoc;
        private static GetOrderTargetPrototype _GetOrderTarget;
        private static GetOrderTargetDestructablePrototype _GetOrderTargetDestructable;
        private static GetOrderTargetItemPrototype _GetOrderTargetItem;
        private static GetOrderTargetUnitPrototype _GetOrderTargetUnit;
        private static GetSpellAbilityUnitPrototype _GetSpellAbilityUnit;
        private static GetSpellAbilityIdPrototype _GetSpellAbilityId;
        private static GetSpellAbilityPrototype _GetSpellAbility;
        private static GetSpellTargetLocPrototype _GetSpellTargetLoc;
        private static GetSpellTargetXPrototype _GetSpellTargetX;
        private static GetSpellTargetYPrototype _GetSpellTargetY;
        private static GetSpellTargetDestructablePrototype _GetSpellTargetDestructable;
        private static GetSpellTargetItemPrototype _GetSpellTargetItem;
        private static GetSpellTargetUnitPrototype _GetSpellTargetUnit;
        private static TriggerRegisterPlayerAllianceChangePrototype _TriggerRegisterPlayerAllianceChange;
        private static TriggerRegisterPlayerStateEventPrototype _TriggerRegisterPlayerStateEvent;
        private static GetEventPlayerStatePrototype _GetEventPlayerState;
        private static TriggerRegisterPlayerChatEventPrototype _TriggerRegisterPlayerChatEvent;
        private static GetEventPlayerChatStringPrototype _GetEventPlayerChatString;
        private static GetEventPlayerChatStringMatchedPrototype _GetEventPlayerChatStringMatched;
        private static TriggerRegisterDeathEventPrototype _TriggerRegisterDeathEvent;
        private static GetTriggerUnitPrototype _GetTriggerUnit;
        private static TriggerRegisterUnitStateEventPrototype _TriggerRegisterUnitStateEvent;
        private static GetEventUnitStatePrototype _GetEventUnitState;
        private static TriggerRegisterUnitEventPrototype _TriggerRegisterUnitEvent;
        private static GetEventDamagePrototype _GetEventDamage;
        private static GetEventDamageSourcePrototype _GetEventDamageSource;
        private static GetEventDetectingPlayerPrototype _GetEventDetectingPlayer;
        private static TriggerRegisterFilterUnitEventPrototype _TriggerRegisterFilterUnitEvent;
        private static GetEventTargetUnitPrototype _GetEventTargetUnit;
        private static TriggerRegisterUnitInRangePrototype _TriggerRegisterUnitInRange;
        private static TriggerAddConditionPrototype _TriggerAddCondition;
        private static TriggerRemoveConditionPrototype _TriggerRemoveCondition;
        private static TriggerClearConditionsPrototype _TriggerClearConditions;
        private static TriggerAddActionPrototype _TriggerAddAction;
        private static TriggerRemoveActionPrototype _TriggerRemoveAction;
        private static TriggerClearActionsPrototype _TriggerClearActions;
        private static TriggerSleepActionPrototype _TriggerSleepAction;
        private static TriggerWaitForSoundPrototype _TriggerWaitForSound;
        private static TriggerEvaluatePrototype _TriggerEvaluate;
        private static TriggerExecutePrototype _TriggerExecute;
        private static TriggerExecuteWaitPrototype _TriggerExecuteWait;
        private static TriggerSyncStartPrototype _TriggerSyncStart;
        private static TriggerSyncReadyPrototype _TriggerSyncReady;
        private static GetWidgetLifePrototype _GetWidgetLife;
        private static SetWidgetLifePrototype _SetWidgetLife;
        private static GetWidgetXPrototype _GetWidgetX;
        private static GetWidgetYPrototype _GetWidgetY;
        private static GetTriggerWidgetPrototype _GetTriggerWidget;
        private static CreateDestructablePrototype _CreateDestructable;
        private static CreateDestructableZPrototype _CreateDestructableZ;
        private static CreateDeadDestructablePrototype _CreateDeadDestructable;
        private static CreateDeadDestructableZPrototype _CreateDeadDestructableZ;
        private static RemoveDestructablePrototype _RemoveDestructable;
        private static KillDestructablePrototype _KillDestructable;
        private static SetDestructableInvulnerablePrototype _SetDestructableInvulnerable;
        private static IsDestructableInvulnerablePrototype _IsDestructableInvulnerable;
        private static EnumDestructablesInRectPrototype _EnumDestructablesInRect;
        private static GetDestructableTypeIdPrototype _GetDestructableTypeId;
        private static GetDestructableXPrototype _GetDestructableX;
        private static GetDestructableYPrototype _GetDestructableY;
        private static SetDestructableLifePrototype _SetDestructableLife;
        private static GetDestructableLifePrototype _GetDestructableLife;
        private static SetDestructableMaxLifePrototype _SetDestructableMaxLife;
        private static GetDestructableMaxLifePrototype _GetDestructableMaxLife;
        private static DestructableRestoreLifePrototype _DestructableRestoreLife;
        private static QueueDestructableAnimationPrototype _QueueDestructableAnimation;
        private static SetDestructableAnimationPrototype _SetDestructableAnimation;
        private static SetDestructableAnimationSpeedPrototype _SetDestructableAnimationSpeed;
        private static ShowDestructablePrototype _ShowDestructable;
        private static GetDestructableOccluderHeightPrototype _GetDestructableOccluderHeight;
        private static SetDestructableOccluderHeightPrototype _SetDestructableOccluderHeight;
        private static GetDestructableNamePrototype _GetDestructableName;
        private static GetTriggerDestructablePrototype _GetTriggerDestructable;
        private static CreateItemPrototype _CreateItem;
        private static RemoveItemPrototype _RemoveItem;
        private static GetItemPlayerPrototype _GetItemPlayer;
        private static GetItemTypeIdPrototype _GetItemTypeId;
        private static GetItemXPrototype _GetItemX;
        private static GetItemYPrototype _GetItemY;
        private static SetItemPositionPrototype _SetItemPosition;
        private static SetItemDropOnDeathPrototype _SetItemDropOnDeath;
        private static SetItemDroppablePrototype _SetItemDroppable;
        private static SetItemPawnablePrototype _SetItemPawnable;
        private static SetItemPlayerPrototype _SetItemPlayer;
        private static SetItemInvulnerablePrototype _SetItemInvulnerable;
        private static IsItemInvulnerablePrototype _IsItemInvulnerable;
        private static SetItemVisiblePrototype _SetItemVisible;
        private static IsItemVisiblePrototype _IsItemVisible;
        private static IsItemOwnedPrototype _IsItemOwned;
        private static IsItemPowerupPrototype _IsItemPowerup;
        private static IsItemSellablePrototype _IsItemSellable;
        private static IsItemPawnablePrototype _IsItemPawnable;
        private static IsItemIdPowerupPrototype _IsItemIdPowerup;
        private static IsItemIdSellablePrototype _IsItemIdSellable;
        private static IsItemIdPawnablePrototype _IsItemIdPawnable;
        private static EnumItemsInRectPrototype _EnumItemsInRect;
        private static GetItemLevelPrototype _GetItemLevel;
        private static GetItemTypePrototype _GetItemType;
        private static SetItemDropIDPrototype _SetItemDropID;
        private static GetItemNamePrototype _GetItemName;
        private static GetItemChargesPrototype _GetItemCharges;
        private static SetItemChargesPrototype _SetItemCharges;
        private static GetItemUserDataPrototype _GetItemUserData;
        private static SetItemUserDataPrototype _SetItemUserData;
        private static CreateUnitPrototype _CreateUnit;
        private static CreateUnitByNamePrototype _CreateUnitByName;
        private static CreateUnitAtLocPrototype _CreateUnitAtLoc;
        private static CreateUnitAtLocByNamePrototype _CreateUnitAtLocByName;
        private static CreateCorpsePrototype _CreateCorpse;
        private static KillUnitPrototype _KillUnit;
        private static RemoveUnitPrototype _RemoveUnit;
        private static ShowUnitPrototype _ShowUnit;
        private static SetUnitStatePrototype _SetUnitState;
        private static SetUnitXPrototype _SetUnitX;
        private static SetUnitYPrototype _SetUnitY;
        private static SetUnitPositionPrototype _SetUnitPosition;
        private static SetUnitPositionLocPrototype _SetUnitPositionLoc;
        private static SetUnitFacingPrototype _SetUnitFacing;
        private static SetUnitFacingTimedPrototype _SetUnitFacingTimed;
        private static SetUnitMoveSpeedPrototype _SetUnitMoveSpeed;
        private static SetUnitFlyHeightPrototype _SetUnitFlyHeight;
        private static SetUnitTurnSpeedPrototype _SetUnitTurnSpeed;
        private static SetUnitPropWindowPrototype _SetUnitPropWindow;
        private static SetUnitAcquireRangePrototype _SetUnitAcquireRange;
        private static SetUnitCreepGuardPrototype _SetUnitCreepGuard;
        private static GetUnitAcquireRangePrototype _GetUnitAcquireRange;
        private static GetUnitTurnSpeedPrototype _GetUnitTurnSpeed;
        private static GetUnitPropWindowPrototype _GetUnitPropWindow;
        private static GetUnitFlyHeightPrototype _GetUnitFlyHeight;
        private static GetUnitDefaultAcquireRangePrototype _GetUnitDefaultAcquireRange;
        private static GetUnitDefaultTurnSpeedPrototype _GetUnitDefaultTurnSpeed;
        private static GetUnitDefaultPropWindowPrototype _GetUnitDefaultPropWindow;
        private static GetUnitDefaultFlyHeightPrototype _GetUnitDefaultFlyHeight;
        private static SetUnitOwnerPrototype _SetUnitOwner;
        private static SetUnitColorPrototype _SetUnitColor;
        private static SetUnitScalePrototype _SetUnitScale;
        private static SetUnitTimeScalePrototype _SetUnitTimeScale;
        private static SetUnitBlendTimePrototype _SetUnitBlendTime;
        private static SetUnitVertexColorPrototype _SetUnitVertexColor;
        private static QueueUnitAnimationPrototype _QueueUnitAnimation;
        private static SetUnitAnimationPrototype _SetUnitAnimation;
        private static SetUnitAnimationByIndexPrototype _SetUnitAnimationByIndex;
        private static SetUnitAnimationWithRarityPrototype _SetUnitAnimationWithRarity;
        private static AddUnitAnimationPropertiesPrototype _AddUnitAnimationProperties;
        private static SetUnitLookAtPrototype _SetUnitLookAt;
        private static ResetUnitLookAtPrototype _ResetUnitLookAt;
        private static SetUnitRescuablePrototype _SetUnitRescuable;
        private static SetUnitRescueRangePrototype _SetUnitRescueRange;
        private static SetHeroStrPrototype _SetHeroStr;
        private static SetHeroAgiPrototype _SetHeroAgi;
        private static SetHeroIntPrototype _SetHeroInt;
        private static GetHeroStrPrototype _GetHeroStr;
        private static GetHeroAgiPrototype _GetHeroAgi;
        private static GetHeroIntPrototype _GetHeroInt;
        private static UnitStripHeroLevelPrototype _UnitStripHeroLevel;
        private static GetHeroXPPrototype _GetHeroXP;
        private static SetHeroXPPrototype _SetHeroXP;
        private static GetHeroSkillPointsPrototype _GetHeroSkillPoints;
        private static UnitModifySkillPointsPrototype _UnitModifySkillPoints;
        private static AddHeroXPPrototype _AddHeroXP;
        private static SetHeroLevelPrototype _SetHeroLevel;
        private static GetHeroLevelPrototype _GetHeroLevel;
        private static GetUnitLevelPrototype _GetUnitLevel;
        private static GetHeroProperNamePrototype _GetHeroProperName;
        private static SuspendHeroXPPrototype _SuspendHeroXP;
        private static IsSuspendedXPPrototype _IsSuspendedXP;
        private static SelectHeroSkillPrototype _SelectHeroSkill;
        private static GetUnitAbilityLevelPrototype _GetUnitAbilityLevel;
        private static DecUnitAbilityLevelPrototype _DecUnitAbilityLevel;
        private static IncUnitAbilityLevelPrototype _IncUnitAbilityLevel;
        private static SetUnitAbilityLevelPrototype _SetUnitAbilityLevel;
        private static ReviveHeroPrototype _ReviveHero;
        private static ReviveHeroLocPrototype _ReviveHeroLoc;
        private static SetUnitExplodedPrototype _SetUnitExploded;
        private static SetUnitInvulnerablePrototype _SetUnitInvulnerable;
        private static PauseUnitPrototype _PauseUnit;
        private static IsUnitPausedPrototype _IsUnitPaused;
        private static SetUnitPathingPrototype _SetUnitPathing;
        private static ClearSelectionPrototype _ClearSelection;
        private static SelectUnitPrototype _SelectUnit;
        private static GetUnitPointValuePrototype _GetUnitPointValue;
        private static GetUnitPointValueByTypePrototype _GetUnitPointValueByType;
        private static UnitAddItemPrototype _UnitAddItem;
        private static UnitAddItemByIdPrototype _UnitAddItemById;
        private static UnitAddItemToSlotByIdPrototype _UnitAddItemToSlotById;
        private static UnitRemoveItemPrototype _UnitRemoveItem;
        private static UnitRemoveItemFromSlotPrototype _UnitRemoveItemFromSlot;
        private static UnitHasItemPrototype _UnitHasItem;
        private static UnitItemInSlotPrototype _UnitItemInSlot;
        private static UnitInventorySizePrototype _UnitInventorySize;
        private static UnitDropItemPointPrototype _UnitDropItemPoint;
        private static UnitDropItemSlotPrototype _UnitDropItemSlot;
        private static UnitDropItemTargetPrototype _UnitDropItemTarget;
        private static UnitUseItemPrototype _UnitUseItem;
        private static UnitUseItemPointPrototype _UnitUseItemPoint;
        private static UnitUseItemTargetPrototype _UnitUseItemTarget;
        private static GetUnitXPrototype _GetUnitX;
        private static GetUnitYPrototype _GetUnitY;
        private static GetUnitLocPrototype _GetUnitLoc;
        private static GetUnitFacingPrototype _GetUnitFacing;
        private static GetUnitMoveSpeedPrototype _GetUnitMoveSpeed;
        private static GetUnitDefaultMoveSpeedPrototype _GetUnitDefaultMoveSpeed;
        private static GetUnitStatePrototype _GetUnitState;
        private static GetOwningPlayerPrototype _GetOwningPlayer;
        private static GetUnitTypeIdPrototype _GetUnitTypeId;
        private static GetUnitRacePrototype _GetUnitRace;
        private static GetUnitNamePrototype _GetUnitName;
        private static GetUnitFoodUsedPrototype _GetUnitFoodUsed;
        private static GetUnitFoodMadePrototype _GetUnitFoodMade;
        private static GetFoodMadePrototype _GetFoodMade;
        private static GetFoodUsedPrototype _GetFoodUsed;
        private static SetUnitUseFoodPrototype _SetUnitUseFood;
        private static GetUnitRallyPointPrototype _GetUnitRallyPoint;
        private static GetUnitRallyUnitPrototype _GetUnitRallyUnit;
        private static GetUnitRallyDestructablePrototype _GetUnitRallyDestructable;
        private static IsUnitInGroupPrototype _IsUnitInGroup;
        private static IsUnitInForcePrototype _IsUnitInForce;
        private static IsUnitOwnedByPlayerPrototype _IsUnitOwnedByPlayer;
        private static IsUnitAllyPrototype _IsUnitAlly;
        private static IsUnitEnemyPrototype _IsUnitEnemy;
        private static IsUnitVisiblePrototype _IsUnitVisible;
        private static IsUnitDetectedPrototype _IsUnitDetected;
        private static IsUnitInvisiblePrototype _IsUnitInvisible;
        private static IsUnitFoggedPrototype _IsUnitFogged;
        private static IsUnitMaskedPrototype _IsUnitMasked;
        private static IsUnitSelectedPrototype _IsUnitSelected;
        private static IsUnitRacePrototype _IsUnitRace;
        private static IsUnitTypePrototype _IsUnitType;
        private static IsUnitPrototype _IsUnit;
        private static IsUnitInRangePrototype _IsUnitInRange;
        private static IsUnitInRangeXYPrototype _IsUnitInRangeXY;
        private static IsUnitInRangeLocPrototype _IsUnitInRangeLoc;
        private static IsUnitHiddenPrototype _IsUnitHidden;
        private static IsUnitIllusionPrototype _IsUnitIllusion;
        private static IsUnitInTransportPrototype _IsUnitInTransport;
        private static IsUnitLoadedPrototype _IsUnitLoaded;
        private static IsHeroUnitIdPrototype _IsHeroUnitId;
        private static IsUnitIdTypePrototype _IsUnitIdType;
        private static UnitShareVisionPrototype _UnitShareVision;
        private static UnitSuspendDecayPrototype _UnitSuspendDecay;
        private static UnitAddTypePrototype _UnitAddType;
        private static UnitRemoveTypePrototype _UnitRemoveType;
        private static UnitAddAbilityPrototype _UnitAddAbility;
        private static UnitRemoveAbilityPrototype _UnitRemoveAbility;
        private static UnitMakeAbilityPermanentPrototype _UnitMakeAbilityPermanent;
        private static UnitRemoveBuffsPrototype _UnitRemoveBuffs;
        private static UnitRemoveBuffsExPrototype _UnitRemoveBuffsEx;
        private static UnitHasBuffsExPrototype _UnitHasBuffsEx;
        private static UnitCountBuffsExPrototype _UnitCountBuffsEx;
        private static UnitAddSleepPrototype _UnitAddSleep;
        private static UnitCanSleepPrototype _UnitCanSleep;
        private static UnitAddSleepPermPrototype _UnitAddSleepPerm;
        private static UnitCanSleepPermPrototype _UnitCanSleepPerm;
        private static UnitIsSleepingPrototype _UnitIsSleeping;
        private static UnitWakeUpPrototype _UnitWakeUp;
        private static UnitApplyTimedLifePrototype _UnitApplyTimedLife;
        private static UnitIgnoreAlarmPrototype _UnitIgnoreAlarm;
        private static UnitIgnoreAlarmToggledPrototype _UnitIgnoreAlarmToggled;
        private static UnitResetCooldownPrototype _UnitResetCooldown;
        private static UnitSetConstructionProgressPrototype _UnitSetConstructionProgress;
        private static UnitSetUpgradeProgressPrototype _UnitSetUpgradeProgress;
        private static UnitPauseTimedLifePrototype _UnitPauseTimedLife;
        private static UnitSetUsesAltIconPrototype _UnitSetUsesAltIcon;
        private static UnitDamagePointPrototype _UnitDamagePoint;
        private static UnitDamageTargetPrototype _UnitDamageTarget;
        private static IssueImmediateOrderPrototype _IssueImmediateOrder;
        private static IssueImmediateOrderByIdPrototype _IssueImmediateOrderById;
        private static IssuePointOrderPrototype _IssuePointOrder;
        private static IssuePointOrderLocPrototype _IssuePointOrderLoc;
        private static IssuePointOrderByIdPrototype _IssuePointOrderById;
        private static IssuePointOrderByIdLocPrototype _IssuePointOrderByIdLoc;
        private static IssueTargetOrderPrototype _IssueTargetOrder;
        private static IssueTargetOrderByIdPrototype _IssueTargetOrderById;
        private static IssueInstantPointOrderPrototype _IssueInstantPointOrder;
        private static IssueInstantPointOrderByIdPrototype _IssueInstantPointOrderById;
        private static IssueInstantTargetOrderPrototype _IssueInstantTargetOrder;
        private static IssueInstantTargetOrderByIdPrototype _IssueInstantTargetOrderById;
        private static IssueBuildOrderPrototype _IssueBuildOrder;
        private static IssueBuildOrderByIdPrototype _IssueBuildOrderById;
        private static IssueNeutralImmediateOrderPrototype _IssueNeutralImmediateOrder;
        private static IssueNeutralImmediateOrderByIdPrototype _IssueNeutralImmediateOrderById;
        private static IssueNeutralPointOrderPrototype _IssueNeutralPointOrder;
        private static IssueNeutralPointOrderByIdPrototype _IssueNeutralPointOrderById;
        private static IssueNeutralTargetOrderPrototype _IssueNeutralTargetOrder;
        private static IssueNeutralTargetOrderByIdPrototype _IssueNeutralTargetOrderById;
        private static GetUnitCurrentOrderPrototype _GetUnitCurrentOrder;
        private static SetResourceAmountPrototype _SetResourceAmount;
        private static AddResourceAmountPrototype _AddResourceAmount;
        private static GetResourceAmountPrototype _GetResourceAmount;
        private static WaygateGetDestinationXPrototype _WaygateGetDestinationX;
        private static WaygateGetDestinationYPrototype _WaygateGetDestinationY;
        private static WaygateSetDestinationPrototype _WaygateSetDestination;
        private static WaygateActivatePrototype _WaygateActivate;
        private static WaygateIsActivePrototype _WaygateIsActive;
        private static AddItemToAllStockPrototype _AddItemToAllStock;
        private static AddItemToStockPrototype _AddItemToStock;
        private static AddUnitToAllStockPrototype _AddUnitToAllStock;
        private static AddUnitToStockPrototype _AddUnitToStock;
        private static RemoveItemFromAllStockPrototype _RemoveItemFromAllStock;
        private static RemoveItemFromStockPrototype _RemoveItemFromStock;
        private static RemoveUnitFromAllStockPrototype _RemoveUnitFromAllStock;
        private static RemoveUnitFromStockPrototype _RemoveUnitFromStock;
        private static SetAllItemTypeSlotsPrototype _SetAllItemTypeSlots;
        private static SetAllUnitTypeSlotsPrototype _SetAllUnitTypeSlots;
        private static SetItemTypeSlotsPrototype _SetItemTypeSlots;
        private static SetUnitTypeSlotsPrototype _SetUnitTypeSlots;
        private static GetUnitUserDataPrototype _GetUnitUserData;
        private static SetUnitUserDataPrototype _SetUnitUserData;
        private static PlayerPrototype _Player;
        private static GetLocalPlayerPrototype _GetLocalPlayer;
        private static IsPlayerAllyPrototype _IsPlayerAlly;
        private static IsPlayerEnemyPrototype _IsPlayerEnemy;
        private static IsPlayerInForcePrototype _IsPlayerInForce;
        private static IsPlayerObserverPrototype _IsPlayerObserver;
        private static IsVisibleToPlayerPrototype _IsVisibleToPlayer;
        private static IsLocationVisibleToPlayerPrototype _IsLocationVisibleToPlayer;
        private static IsFoggedToPlayerPrototype _IsFoggedToPlayer;
        private static IsLocationFoggedToPlayerPrototype _IsLocationFoggedToPlayer;
        private static IsMaskedToPlayerPrototype _IsMaskedToPlayer;
        private static IsLocationMaskedToPlayerPrototype _IsLocationMaskedToPlayer;
        private static GetPlayerRacePrototype _GetPlayerRace;
        private static GetPlayerIdPrototype _GetPlayerId;
        private static GetPlayerUnitCountPrototype _GetPlayerUnitCount;
        private static GetPlayerTypedUnitCountPrototype _GetPlayerTypedUnitCount;
        private static GetPlayerStructureCountPrototype _GetPlayerStructureCount;
        private static GetPlayerStatePrototype _GetPlayerState;
        private static GetPlayerScorePrototype _GetPlayerScore;
        private static GetPlayerAlliancePrototype _GetPlayerAlliance;
        private static GetPlayerHandicapPrototype _GetPlayerHandicap;
        private static GetPlayerHandicapXPPrototype _GetPlayerHandicapXP;
        private static SetPlayerHandicapPrototype _SetPlayerHandicap;
        private static SetPlayerHandicapXPPrototype _SetPlayerHandicapXP;
        private static SetPlayerTechMaxAllowedPrototype _SetPlayerTechMaxAllowed;
        private static GetPlayerTechMaxAllowedPrototype _GetPlayerTechMaxAllowed;
        private static AddPlayerTechResearchedPrototype _AddPlayerTechResearched;
        private static SetPlayerTechResearchedPrototype _SetPlayerTechResearched;
        private static GetPlayerTechResearchedPrototype _GetPlayerTechResearched;
        private static GetPlayerTechCountPrototype _GetPlayerTechCount;
        private static SetPlayerUnitsOwnerPrototype _SetPlayerUnitsOwner;
        private static CripplePlayerPrototype _CripplePlayer;
        private static SetPlayerAbilityAvailablePrototype _SetPlayerAbilityAvailable;
        private static SetPlayerStatePrototype _SetPlayerState;
        private static RemovePlayerPrototype _RemovePlayer;
        private static CachePlayerHeroDataPrototype _CachePlayerHeroData;
        private static SetFogStateRectPrototype _SetFogStateRect;
        private static SetFogStateRadiusPrototype _SetFogStateRadius;
        private static SetFogStateRadiusLocPrototype _SetFogStateRadiusLoc;
        private static FogMaskEnablePrototype _FogMaskEnable;
        private static IsFogMaskEnabledPrototype _IsFogMaskEnabled;
        private static FogEnablePrototype _FogEnable;
        private static IsFogEnabledPrototype _IsFogEnabled;
        private static CreateFogModifierRectPrototype _CreateFogModifierRect;
        private static CreateFogModifierRadiusPrototype _CreateFogModifierRadius;
        private static CreateFogModifierRadiusLocPrototype _CreateFogModifierRadiusLoc;
        private static DestroyFogModifierPrototype _DestroyFogModifier;
        private static FogModifierStartPrototype _FogModifierStart;
        private static FogModifierStopPrototype _FogModifierStop;
        private static VersionGetPrototype _VersionGet;
        private static VersionCompatiblePrototype _VersionCompatible;
        private static VersionSupportedPrototype _VersionSupported;
        private static EndGamePrototype _EndGame;
        private static ChangeLevelPrototype _ChangeLevel;
        private static RestartGamePrototype _RestartGame;
        private static ReloadGamePrototype _ReloadGame;
        private static SetCampaignMenuRacePrototype _SetCampaignMenuRace;
        private static SetCampaignMenuRaceExPrototype _SetCampaignMenuRaceEx;
        private static ForceCampaignSelectScreenPrototype _ForceCampaignSelectScreen;
        private static LoadGamePrototype _LoadGame;
        private static SaveGamePrototype _SaveGame;
        private static RenameSaveDirectoryPrototype _RenameSaveDirectory;
        private static RemoveSaveDirectoryPrototype _RemoveSaveDirectory;
        private static CopySaveGamePrototype _CopySaveGame;
        private static SaveGameExistsPrototype _SaveGameExists;
        private static SyncSelectionsPrototype _SyncSelections;
        private static SetFloatGameStatePrototype _SetFloatGameState;
        private static GetFloatGameStatePrototype _GetFloatGameState;
        private static SetIntegerGameStatePrototype _SetIntegerGameState;
        private static GetIntegerGameStatePrototype _GetIntegerGameState;
        private static SetTutorialClearedPrototype _SetTutorialCleared;
        private static SetMissionAvailablePrototype _SetMissionAvailable;
        private static SetCampaignAvailablePrototype _SetCampaignAvailable;
        private static SetOpCinematicAvailablePrototype _SetOpCinematicAvailable;
        private static SetEdCinematicAvailablePrototype _SetEdCinematicAvailable;
        private static GetDefaultDifficultyPrototype _GetDefaultDifficulty;
        private static SetDefaultDifficultyPrototype _SetDefaultDifficulty;
        private static SetCustomCampaignButtonVisiblePrototype _SetCustomCampaignButtonVisible;
        private static GetCustomCampaignButtonVisiblePrototype _GetCustomCampaignButtonVisible;
        private static DoNotSaveReplayPrototype _DoNotSaveReplay;
        private static DialogCreatePrototype _DialogCreate;
        private static DialogDestroyPrototype _DialogDestroy;
        private static DialogClearPrototype _DialogClear;
        private static DialogSetMessagePrototype _DialogSetMessage;
        private static DialogAddButtonPrototype _DialogAddButton;
        private static DialogAddQuitButtonPrototype _DialogAddQuitButton;
        private static DialogDisplayPrototype _DialogDisplay;
        private static ReloadGameCachesFromDiskPrototype _ReloadGameCachesFromDisk;
        private static InitGameCachePrototype _InitGameCache;
        private static SaveGameCachePrototype _SaveGameCache;
        private static StoreIntegerPrototype _StoreInteger;
        private static StoreRealPrototype _StoreReal;
        private static StoreBooleanPrototype _StoreBoolean;
        private static StoreUnitPrototype _StoreUnit;
        private static StoreStringPrototype _StoreString;
        private static SyncStoredIntegerPrototype _SyncStoredInteger;
        private static SyncStoredRealPrototype _SyncStoredReal;
        private static SyncStoredBooleanPrototype _SyncStoredBoolean;
        private static SyncStoredUnitPrototype _SyncStoredUnit;
        private static SyncStoredStringPrototype _SyncStoredString;
        private static HaveStoredIntegerPrototype _HaveStoredInteger;
        private static HaveStoredRealPrototype _HaveStoredReal;
        private static HaveStoredBooleanPrototype _HaveStoredBoolean;
        private static HaveStoredUnitPrototype _HaveStoredUnit;
        private static HaveStoredStringPrototype _HaveStoredString;
        private static FlushGameCachePrototype _FlushGameCache;
        private static FlushStoredMissionPrototype _FlushStoredMission;
        private static FlushStoredIntegerPrototype _FlushStoredInteger;
        private static FlushStoredRealPrototype _FlushStoredReal;
        private static FlushStoredBooleanPrototype _FlushStoredBoolean;
        private static FlushStoredUnitPrototype _FlushStoredUnit;
        private static FlushStoredStringPrototype _FlushStoredString;
        private static GetStoredIntegerPrototype _GetStoredInteger;
        private static GetStoredRealPrototype _GetStoredReal;
        private static GetStoredBooleanPrototype _GetStoredBoolean;
        private static GetStoredStringPrototype _GetStoredString;
        private static RestoreUnitPrototype _RestoreUnit;
        private static InitHashtablePrototype _InitHashtable;
        private static SaveIntegerPrototype _SaveInteger;
        private static SaveRealPrototype _SaveReal;
        private static SaveBooleanPrototype _SaveBoolean;
        private static SaveStrPrototype _SaveStr;
        private static SavePlayerHandlePrototype _SavePlayerHandle;
        private static SaveWidgetHandlePrototype _SaveWidgetHandle;
        private static SaveDestructableHandlePrototype _SaveDestructableHandle;
        private static SaveItemHandlePrototype _SaveItemHandle;
        private static SaveUnitHandlePrototype _SaveUnitHandle;
        private static SaveAbilityHandlePrototype _SaveAbilityHandle;
        private static SaveTimerHandlePrototype _SaveTimerHandle;
        private static SaveTriggerHandlePrototype _SaveTriggerHandle;
        private static SaveTriggerConditionHandlePrototype _SaveTriggerConditionHandle;
        private static SaveTriggerActionHandlePrototype _SaveTriggerActionHandle;
        private static SaveTriggerEventHandlePrototype _SaveTriggerEventHandle;
        private static SaveForceHandlePrototype _SaveForceHandle;
        private static SaveGroupHandlePrototype _SaveGroupHandle;
        private static SaveLocationHandlePrototype _SaveLocationHandle;
        private static SaveRectHandlePrototype _SaveRectHandle;
        private static SaveBooleanExprHandlePrototype _SaveBooleanExprHandle;
        private static SaveSoundHandlePrototype _SaveSoundHandle;
        private static SaveEffectHandlePrototype _SaveEffectHandle;
        private static SaveUnitPoolHandlePrototype _SaveUnitPoolHandle;
        private static SaveItemPoolHandlePrototype _SaveItemPoolHandle;
        private static SaveQuestHandlePrototype _SaveQuestHandle;
        private static SaveQuestItemHandlePrototype _SaveQuestItemHandle;
        private static SaveDefeatConditionHandlePrototype _SaveDefeatConditionHandle;
        private static SaveTimerDialogHandlePrototype _SaveTimerDialogHandle;
        private static SaveLeaderboardHandlePrototype _SaveLeaderboardHandle;
        private static SaveMultiboardHandlePrototype _SaveMultiboardHandle;
        private static SaveMultiboardItemHandlePrototype _SaveMultiboardItemHandle;
        private static SaveTrackableHandlePrototype _SaveTrackableHandle;
        private static SaveDialogHandlePrototype _SaveDialogHandle;
        private static SaveButtonHandlePrototype _SaveButtonHandle;
        private static SaveTextTagHandlePrototype _SaveTextTagHandle;
        private static SaveLightningHandlePrototype _SaveLightningHandle;
        private static SaveImageHandlePrototype _SaveImageHandle;
        private static SaveUbersplatHandlePrototype _SaveUbersplatHandle;
        private static SaveRegionHandlePrototype _SaveRegionHandle;
        private static SaveFogStateHandlePrototype _SaveFogStateHandle;
        private static SaveFogModifierHandlePrototype _SaveFogModifierHandle;
        private static SaveAgentHandlePrototype _SaveAgentHandle;
        private static SaveHashtableHandlePrototype _SaveHashtableHandle;
        private static LoadIntegerPrototype _LoadInteger;
        private static LoadRealPrototype _LoadReal;
        private static LoadBooleanPrototype _LoadBoolean;
        private static LoadStrPrototype _LoadStr;
        private static LoadPlayerHandlePrototype _LoadPlayerHandle;
        private static LoadWidgetHandlePrototype _LoadWidgetHandle;
        private static LoadDestructableHandlePrototype _LoadDestructableHandle;
        private static LoadItemHandlePrototype _LoadItemHandle;
        private static LoadUnitHandlePrototype _LoadUnitHandle;
        private static LoadAbilityHandlePrototype _LoadAbilityHandle;
        private static LoadTimerHandlePrototype _LoadTimerHandle;
        private static LoadTriggerHandlePrototype _LoadTriggerHandle;
        private static LoadTriggerConditionHandlePrototype _LoadTriggerConditionHandle;
        private static LoadTriggerActionHandlePrototype _LoadTriggerActionHandle;
        private static LoadTriggerEventHandlePrototype _LoadTriggerEventHandle;
        private static LoadForceHandlePrototype _LoadForceHandle;
        private static LoadGroupHandlePrototype _LoadGroupHandle;
        private static LoadLocationHandlePrototype _LoadLocationHandle;
        private static LoadRectHandlePrototype _LoadRectHandle;
        private static LoadBooleanExprHandlePrototype _LoadBooleanExprHandle;
        private static LoadSoundHandlePrototype _LoadSoundHandle;
        private static LoadEffectHandlePrototype _LoadEffectHandle;
        private static LoadUnitPoolHandlePrototype _LoadUnitPoolHandle;
        private static LoadItemPoolHandlePrototype _LoadItemPoolHandle;
        private static LoadQuestHandlePrototype _LoadQuestHandle;
        private static LoadQuestItemHandlePrototype _LoadQuestItemHandle;
        private static LoadDefeatConditionHandlePrototype _LoadDefeatConditionHandle;
        private static LoadTimerDialogHandlePrototype _LoadTimerDialogHandle;
        private static LoadLeaderboardHandlePrototype _LoadLeaderboardHandle;
        private static LoadMultiboardHandlePrototype _LoadMultiboardHandle;
        private static LoadMultiboardItemHandlePrototype _LoadMultiboardItemHandle;
        private static LoadTrackableHandlePrototype _LoadTrackableHandle;
        private static LoadDialogHandlePrototype _LoadDialogHandle;
        private static LoadButtonHandlePrototype _LoadButtonHandle;
        private static LoadTextTagHandlePrototype _LoadTextTagHandle;
        private static LoadLightningHandlePrototype _LoadLightningHandle;
        private static LoadImageHandlePrototype _LoadImageHandle;
        private static LoadUbersplatHandlePrototype _LoadUbersplatHandle;
        private static LoadRegionHandlePrototype _LoadRegionHandle;
        private static LoadFogStateHandlePrototype _LoadFogStateHandle;
        private static LoadFogModifierHandlePrototype _LoadFogModifierHandle;
        private static LoadHashtableHandlePrototype _LoadHashtableHandle;
        private static HaveSavedIntegerPrototype _HaveSavedInteger;
        private static HaveSavedRealPrototype _HaveSavedReal;
        private static HaveSavedBooleanPrototype _HaveSavedBoolean;
        private static HaveSavedStringPrototype _HaveSavedString;
        private static HaveSavedHandlePrototype _HaveSavedHandle;
        private static RemoveSavedIntegerPrototype _RemoveSavedInteger;
        private static RemoveSavedRealPrototype _RemoveSavedReal;
        private static RemoveSavedBooleanPrototype _RemoveSavedBoolean;
        private static RemoveSavedStringPrototype _RemoveSavedString;
        private static RemoveSavedHandlePrototype _RemoveSavedHandle;
        private static FlushParentHashtablePrototype _FlushParentHashtable;
        private static FlushChildHashtablePrototype _FlushChildHashtable;
        private static GetRandomIntPrototype _GetRandomInt;
        private static GetRandomRealPrototype _GetRandomReal;
        private static CreateUnitPoolPrototype _CreateUnitPool;
        private static DestroyUnitPoolPrototype _DestroyUnitPool;
        private static UnitPoolAddUnitTypePrototype _UnitPoolAddUnitType;
        private static UnitPoolRemoveUnitTypePrototype _UnitPoolRemoveUnitType;
        private static PlaceRandomUnitPrototype _PlaceRandomUnit;
        private static CreateItemPoolPrototype _CreateItemPool;
        private static DestroyItemPoolPrototype _DestroyItemPool;
        private static ItemPoolAddItemTypePrototype _ItemPoolAddItemType;
        private static ItemPoolRemoveItemTypePrototype _ItemPoolRemoveItemType;
        private static PlaceRandomItemPrototype _PlaceRandomItem;
        private static ChooseRandomCreepPrototype _ChooseRandomCreep;
        private static ChooseRandomNPBuildingPrototype _ChooseRandomNPBuilding;
        private static ChooseRandomItemPrototype _ChooseRandomItem;
        private static ChooseRandomItemExPrototype _ChooseRandomItemEx;
        private static SetRandomSeedPrototype _SetRandomSeed;
        private static SetTerrainFogPrototype _SetTerrainFog;
        private static ResetTerrainFogPrototype _ResetTerrainFog;
        private static SetUnitFogPrototype _SetUnitFog;
        private static SetTerrainFogExPrototype _SetTerrainFogEx;
        private static DisplayTextToPlayerPrototype _DisplayTextToPlayer;
        private static DisplayTimedTextToPlayerPrototype _DisplayTimedTextToPlayer;
        private static DisplayTimedTextFromPlayerPrototype _DisplayTimedTextFromPlayer;
        private static ClearTextMessagesPrototype _ClearTextMessages;
        private static SetDayNightModelsPrototype _SetDayNightModels;
        private static SetSkyModelPrototype _SetSkyModel;
        private static EnableUserControlPrototype _EnableUserControl;
        private static EnableUserUIPrototype _EnableUserUI;
        private static SuspendTimeOfDayPrototype _SuspendTimeOfDay;
        private static SetTimeOfDayScalePrototype _SetTimeOfDayScale;
        private static GetTimeOfDayScalePrototype _GetTimeOfDayScale;
        private static ShowInterfacePrototype _ShowInterface;
        private static PauseGamePrototype _PauseGame;
        private static UnitAddIndicatorPrototype _UnitAddIndicator;
        private static AddIndicatorPrototype _AddIndicator;
        private static PingMinimapPrototype _PingMinimap;
        private static PingMinimapExPrototype _PingMinimapEx;
        private static EnableOcclusionPrototype _EnableOcclusion;
        private static SetIntroShotTextPrototype _SetIntroShotText;
        private static SetIntroShotModelPrototype _SetIntroShotModel;
        private static EnableWorldFogBoundaryPrototype _EnableWorldFogBoundary;
        private static PlayModelCinematicPrototype _PlayModelCinematic;
        private static PlayCinematicPrototype _PlayCinematic;
        private static ForceUIKeyPrototype _ForceUIKey;
        private static ForceUICancelPrototype _ForceUICancel;
        private static DisplayLoadDialogPrototype _DisplayLoadDialog;
        private static SetAltMinimapIconPrototype _SetAltMinimapIcon;
        private static DisableRestartMissionPrototype _DisableRestartMission;
        private static CreateTextTagPrototype _CreateTextTag;
        private static DestroyTextTagPrototype _DestroyTextTag;
        private static SetTextTagTextPrototype _SetTextTagText;
        private static SetTextTagPosPrototype _SetTextTagPos;
        private static SetTextTagPosUnitPrototype _SetTextTagPosUnit;
        private static SetTextTagColorPrototype _SetTextTagColor;
        private static SetTextTagVelocityPrototype _SetTextTagVelocity;
        private static SetTextTagVisibilityPrototype _SetTextTagVisibility;
        private static SetTextTagSuspendedPrototype _SetTextTagSuspended;
        private static SetTextTagPermanentPrototype _SetTextTagPermanent;
        private static SetTextTagAgePrototype _SetTextTagAge;
        private static SetTextTagLifespanPrototype _SetTextTagLifespan;
        private static SetTextTagFadepointPrototype _SetTextTagFadepoint;
        private static SetReservedLocalHeroButtonsPrototype _SetReservedLocalHeroButtons;
        private static GetAllyColorFilterStatePrototype _GetAllyColorFilterState;
        private static SetAllyColorFilterStatePrototype _SetAllyColorFilterState;
        private static GetCreepCampFilterStatePrototype _GetCreepCampFilterState;
        private static SetCreepCampFilterStatePrototype _SetCreepCampFilterState;
        private static EnableMinimapFilterButtonsPrototype _EnableMinimapFilterButtons;
        private static EnableDragSelectPrototype _EnableDragSelect;
        private static EnablePreSelectPrototype _EnablePreSelect;
        private static EnableSelectPrototype _EnableSelect;
        private static CreateTrackablePrototype _CreateTrackable;
        private static CreateQuestPrototype _CreateQuest;
        private static DestroyQuestPrototype _DestroyQuest;
        private static QuestSetTitlePrototype _QuestSetTitle;
        private static QuestSetDescriptionPrototype _QuestSetDescription;
        private static QuestSetIconPathPrototype _QuestSetIconPath;
        private static QuestSetRequiredPrototype _QuestSetRequired;
        private static QuestSetCompletedPrototype _QuestSetCompleted;
        private static QuestSetDiscoveredPrototype _QuestSetDiscovered;
        private static QuestSetFailedPrototype _QuestSetFailed;
        private static QuestSetEnabledPrototype _QuestSetEnabled;
        private static IsQuestRequiredPrototype _IsQuestRequired;
        private static IsQuestCompletedPrototype _IsQuestCompleted;
        private static IsQuestDiscoveredPrototype _IsQuestDiscovered;
        private static IsQuestFailedPrototype _IsQuestFailed;
        private static IsQuestEnabledPrototype _IsQuestEnabled;
        private static QuestCreateItemPrototype _QuestCreateItem;
        private static QuestItemSetDescriptionPrototype _QuestItemSetDescription;
        private static QuestItemSetCompletedPrototype _QuestItemSetCompleted;
        private static IsQuestItemCompletedPrototype _IsQuestItemCompleted;
        private static CreateDefeatConditionPrototype _CreateDefeatCondition;
        private static DestroyDefeatConditionPrototype _DestroyDefeatCondition;
        private static DefeatConditionSetDescriptionPrototype _DefeatConditionSetDescription;
        private static FlashQuestDialogButtonPrototype _FlashQuestDialogButton;
        private static ForceQuestDialogUpdatePrototype _ForceQuestDialogUpdate;
        private static CreateTimerDialogPrototype _CreateTimerDialog;
        private static DestroyTimerDialogPrototype _DestroyTimerDialog;
        private static TimerDialogSetTitlePrototype _TimerDialogSetTitle;
        private static TimerDialogSetTitleColorPrototype _TimerDialogSetTitleColor;
        private static TimerDialogSetTimeColorPrototype _TimerDialogSetTimeColor;
        private static TimerDialogSetSpeedPrototype _TimerDialogSetSpeed;
        private static TimerDialogDisplayPrototype _TimerDialogDisplay;
        private static IsTimerDialogDisplayedPrototype _IsTimerDialogDisplayed;
        private static TimerDialogSetRealTimeRemainingPrototype _TimerDialogSetRealTimeRemaining;
        private static CreateLeaderboardPrototype _CreateLeaderboard;
        private static DestroyLeaderboardPrototype _DestroyLeaderboard;
        private static LeaderboardDisplayPrototype _LeaderboardDisplay;
        private static IsLeaderboardDisplayedPrototype _IsLeaderboardDisplayed;
        private static LeaderboardGetItemCountPrototype _LeaderboardGetItemCount;
        private static LeaderboardSetSizeByItemCountPrototype _LeaderboardSetSizeByItemCount;
        private static LeaderboardAddItemPrototype _LeaderboardAddItem;
        private static LeaderboardRemoveItemPrototype _LeaderboardRemoveItem;
        private static LeaderboardRemovePlayerItemPrototype _LeaderboardRemovePlayerItem;
        private static LeaderboardClearPrototype _LeaderboardClear;
        private static LeaderboardSortItemsByValuePrototype _LeaderboardSortItemsByValue;
        private static LeaderboardSortItemsByPlayerPrototype _LeaderboardSortItemsByPlayer;
        private static LeaderboardSortItemsByLabelPrototype _LeaderboardSortItemsByLabel;
        private static LeaderboardHasPlayerItemPrototype _LeaderboardHasPlayerItem;
        private static LeaderboardGetPlayerIndexPrototype _LeaderboardGetPlayerIndex;
        private static LeaderboardSetLabelPrototype _LeaderboardSetLabel;
        private static LeaderboardGetLabelTextPrototype _LeaderboardGetLabelText;
        private static PlayerSetLeaderboardPrototype _PlayerSetLeaderboard;
        private static PlayerGetLeaderboardPrototype _PlayerGetLeaderboard;
        private static LeaderboardSetLabelColorPrototype _LeaderboardSetLabelColor;
        private static LeaderboardSetValueColorPrototype _LeaderboardSetValueColor;
        private static LeaderboardSetStylePrototype _LeaderboardSetStyle;
        private static LeaderboardSetItemValuePrototype _LeaderboardSetItemValue;
        private static LeaderboardSetItemLabelPrototype _LeaderboardSetItemLabel;
        private static LeaderboardSetItemStylePrototype _LeaderboardSetItemStyle;
        private static LeaderboardSetItemLabelColorPrototype _LeaderboardSetItemLabelColor;
        private static LeaderboardSetItemValueColorPrototype _LeaderboardSetItemValueColor;
        private static CreateMultiboardPrototype _CreateMultiboard;
        private static DestroyMultiboardPrototype _DestroyMultiboard;
        private static MultiboardDisplayPrototype _MultiboardDisplay;
        private static IsMultiboardDisplayedPrototype _IsMultiboardDisplayed;
        private static MultiboardMinimizePrototype _MultiboardMinimize;
        private static IsMultiboardMinimizedPrototype _IsMultiboardMinimized;
        private static MultiboardClearPrototype _MultiboardClear;
        private static MultiboardSetTitleTextPrototype _MultiboardSetTitleText;
        private static MultiboardGetTitleTextPrototype _MultiboardGetTitleText;
        private static MultiboardSetTitleTextColorPrototype _MultiboardSetTitleTextColor;
        private static MultiboardGetRowCountPrototype _MultiboardGetRowCount;
        private static MultiboardGetColumnCountPrototype _MultiboardGetColumnCount;
        private static MultiboardSetColumnCountPrototype _MultiboardSetColumnCount;
        private static MultiboardSetRowCountPrototype _MultiboardSetRowCount;
        private static MultiboardSetItemsStylePrototype _MultiboardSetItemsStyle;
        private static MultiboardSetItemsValuePrototype _MultiboardSetItemsValue;
        private static MultiboardSetItemsValueColorPrototype _MultiboardSetItemsValueColor;
        private static MultiboardSetItemsWidthPrototype _MultiboardSetItemsWidth;
        private static MultiboardSetItemsIconPrototype _MultiboardSetItemsIcon;
        private static MultiboardGetItemPrototype _MultiboardGetItem;
        private static MultiboardReleaseItemPrototype _MultiboardReleaseItem;
        private static MultiboardSetItemStylePrototype _MultiboardSetItemStyle;
        private static MultiboardSetItemValuePrototype _MultiboardSetItemValue;
        private static MultiboardSetItemValueColorPrototype _MultiboardSetItemValueColor;
        private static MultiboardSetItemWidthPrototype _MultiboardSetItemWidth;
        private static MultiboardSetItemIconPrototype _MultiboardSetItemIcon;
        private static MultiboardSuppressDisplayPrototype _MultiboardSuppressDisplay;
        private static SetCameraPositionPrototype _SetCameraPosition;
        private static SetCameraQuickPositionPrototype _SetCameraQuickPosition;
        private static SetCameraBoundsPrototype _SetCameraBounds;
        private static StopCameraPrototype _StopCamera;
        private static ResetToGameCameraPrototype _ResetToGameCamera;
        private static PanCameraToPrototype _PanCameraTo;
        private static PanCameraToTimedPrototype _PanCameraToTimed;
        private static PanCameraToWithZPrototype _PanCameraToWithZ;
        private static PanCameraToTimedWithZPrototype _PanCameraToTimedWithZ;
        private static SetCinematicCameraPrototype _SetCinematicCamera;
        private static SetCameraRotateModePrototype _SetCameraRotateMode;
        private static SetCameraFieldPrototype _SetCameraField;
        private static AdjustCameraFieldPrototype _AdjustCameraField;
        private static SetCameraTargetControllerPrototype _SetCameraTargetController;
        private static SetCameraOrientControllerPrototype _SetCameraOrientController;
        private static CreateCameraSetupPrototype _CreateCameraSetup;
        private static CameraSetupSetFieldPrototype _CameraSetupSetField;
        private static CameraSetupGetFieldPrototype _CameraSetupGetField;
        private static CameraSetupSetDestPositionPrototype _CameraSetupSetDestPosition;
        private static CameraSetupGetDestPositionLocPrototype _CameraSetupGetDestPositionLoc;
        private static CameraSetupGetDestPositionXPrototype _CameraSetupGetDestPositionX;
        private static CameraSetupGetDestPositionYPrototype _CameraSetupGetDestPositionY;
        private static CameraSetupApplyPrototype _CameraSetupApply;
        private static CameraSetupApplyWithZPrototype _CameraSetupApplyWithZ;
        private static CameraSetupApplyForceDurationPrototype _CameraSetupApplyForceDuration;
        private static CameraSetupApplyForceDurationWithZPrototype _CameraSetupApplyForceDurationWithZ;
        private static CameraSetTargetNoisePrototype _CameraSetTargetNoise;
        private static CameraSetSourceNoisePrototype _CameraSetSourceNoise;
        private static CameraSetTargetNoiseExPrototype _CameraSetTargetNoiseEx;
        private static CameraSetSourceNoiseExPrototype _CameraSetSourceNoiseEx;
        private static CameraSetSmoothingFactorPrototype _CameraSetSmoothingFactor;
        private static SetCineFilterTexturePrototype _SetCineFilterTexture;
        private static SetCineFilterBlendModePrototype _SetCineFilterBlendMode;
        private static SetCineFilterTexMapFlagsPrototype _SetCineFilterTexMapFlags;
        private static SetCineFilterStartUVPrototype _SetCineFilterStartUV;
        private static SetCineFilterEndUVPrototype _SetCineFilterEndUV;
        private static SetCineFilterStartColorPrototype _SetCineFilterStartColor;
        private static SetCineFilterEndColorPrototype _SetCineFilterEndColor;
        private static SetCineFilterDurationPrototype _SetCineFilterDuration;
        private static DisplayCineFilterPrototype _DisplayCineFilter;
        private static IsCineFilterDisplayedPrototype _IsCineFilterDisplayed;
        private static SetCinematicScenePrototype _SetCinematicScene;
        private static EndCinematicScenePrototype _EndCinematicScene;
        private static ForceCinematicSubtitlesPrototype _ForceCinematicSubtitles;
        private static GetCameraMarginPrototype _GetCameraMargin;
        private static GetCameraBoundMinXPrototype _GetCameraBoundMinX;
        private static GetCameraBoundMinYPrototype _GetCameraBoundMinY;
        private static GetCameraBoundMaxXPrototype _GetCameraBoundMaxX;
        private static GetCameraBoundMaxYPrototype _GetCameraBoundMaxY;
        private static GetCameraFieldPrototype _GetCameraField;
        private static GetCameraTargetPositionXPrototype _GetCameraTargetPositionX;
        private static GetCameraTargetPositionYPrototype _GetCameraTargetPositionY;
        private static GetCameraTargetPositionZPrototype _GetCameraTargetPositionZ;
        private static GetCameraTargetPositionLocPrototype _GetCameraTargetPositionLoc;
        private static GetCameraEyePositionXPrototype _GetCameraEyePositionX;
        private static GetCameraEyePositionYPrototype _GetCameraEyePositionY;
        private static GetCameraEyePositionZPrototype _GetCameraEyePositionZ;
        private static GetCameraEyePositionLocPrototype _GetCameraEyePositionLoc;
        private static NewSoundEnvironmentPrototype _NewSoundEnvironment;
        private static CreateSoundPrototype _CreateSound;
        private static CreateSoundFilenameWithLabelPrototype _CreateSoundFilenameWithLabel;
        private static CreateSoundFromLabelPrototype _CreateSoundFromLabel;
        private static CreateMIDISoundPrototype _CreateMIDISound;
        private static SetSoundParamsFromLabelPrototype _SetSoundParamsFromLabel;
        private static SetSoundDistanceCutoffPrototype _SetSoundDistanceCutoff;
        private static SetSoundChannelPrototype _SetSoundChannel;
        private static SetSoundVolumePrototype _SetSoundVolume;
        private static SetSoundPitchPrototype _SetSoundPitch;
        private static SetSoundPlayPositionPrototype _SetSoundPlayPosition;
        private static SetSoundDistancesPrototype _SetSoundDistances;
        private static SetSoundConeAnglesPrototype _SetSoundConeAngles;
        private static SetSoundConeOrientationPrototype _SetSoundConeOrientation;
        private static SetSoundPositionPrototype _SetSoundPosition;
        private static SetSoundVelocityPrototype _SetSoundVelocity;
        private static AttachSoundToUnitPrototype _AttachSoundToUnit;
        private static StartSoundPrototype _StartSound;
        private static StopSoundPrototype _StopSound;
        private static KillSoundWhenDonePrototype _KillSoundWhenDone;
        private static SetMapMusicPrototype _SetMapMusic;
        private static ClearMapMusicPrototype _ClearMapMusic;
        private static PlayMusicPrototype _PlayMusic;
        private static PlayMusicExPrototype _PlayMusicEx;
        private static StopMusicPrototype _StopMusic;
        private static ResumeMusicPrototype _ResumeMusic;
        private static PlayThematicMusicPrototype _PlayThematicMusic;
        private static PlayThematicMusicExPrototype _PlayThematicMusicEx;
        private static EndThematicMusicPrototype _EndThematicMusic;
        private static SetMusicVolumePrototype _SetMusicVolume;
        private static SetMusicPlayPositionPrototype _SetMusicPlayPosition;
        private static SetThematicMusicPlayPositionPrototype _SetThematicMusicPlayPosition;
        private static SetSoundDurationPrototype _SetSoundDuration;
        private static GetSoundDurationPrototype _GetSoundDuration;
        private static GetSoundFileDurationPrototype _GetSoundFileDuration;
        private static VolumeGroupSetVolumePrototype _VolumeGroupSetVolume;
        private static VolumeGroupResetPrototype _VolumeGroupReset;
        private static GetSoundIsPlayingPrototype _GetSoundIsPlaying;
        private static GetSoundIsLoadingPrototype _GetSoundIsLoading;
        private static RegisterStackedSoundPrototype _RegisterStackedSound;
        private static UnregisterStackedSoundPrototype _UnregisterStackedSound;
        private static AddWeatherEffectPrototype _AddWeatherEffect;
        private static RemoveWeatherEffectPrototype _RemoveWeatherEffect;
        private static EnableWeatherEffectPrototype _EnableWeatherEffect;
        private static TerrainDeformCraterPrototype _TerrainDeformCrater;
        private static TerrainDeformRipplePrototype _TerrainDeformRipple;
        private static TerrainDeformWavePrototype _TerrainDeformWave;
        private static TerrainDeformRandomPrototype _TerrainDeformRandom;
        private static TerrainDeformStopPrototype _TerrainDeformStop;
        private static TerrainDeformStopAllPrototype _TerrainDeformStopAll;
        private static AddSpecialEffectPrototype _AddSpecialEffect;
        private static AddSpecialEffectLocPrototype _AddSpecialEffectLoc;
        private static AddSpecialEffectTargetPrototype _AddSpecialEffectTarget;
        private static DestroyEffectPrototype _DestroyEffect;
        private static AddSpellEffectPrototype _AddSpellEffect;
        private static AddSpellEffectLocPrototype _AddSpellEffectLoc;
        private static AddSpellEffectByIdPrototype _AddSpellEffectById;
        private static AddSpellEffectByIdLocPrototype _AddSpellEffectByIdLoc;
        private static AddSpellEffectTargetPrototype _AddSpellEffectTarget;
        private static AddSpellEffectTargetByIdPrototype _AddSpellEffectTargetById;
        private static AddLightningPrototype _AddLightning;
        private static AddLightningExPrototype _AddLightningEx;
        private static DestroyLightningPrototype _DestroyLightning;
        private static MoveLightningPrototype _MoveLightning;
        private static MoveLightningExPrototype _MoveLightningEx;
        private static GetLightningColorAPrototype _GetLightningColorA;
        private static GetLightningColorRPrototype _GetLightningColorR;
        private static GetLightningColorGPrototype _GetLightningColorG;
        private static GetLightningColorBPrototype _GetLightningColorB;
        private static SetLightningColorPrototype _SetLightningColor;
        private static GetAbilityEffectPrototype _GetAbilityEffect;
        private static GetAbilityEffectByIdPrototype _GetAbilityEffectById;
        private static GetAbilitySoundPrototype _GetAbilitySound;
        private static GetAbilitySoundByIdPrototype _GetAbilitySoundById;
        private static GetTerrainCliffLevelPrototype _GetTerrainCliffLevel;
        private static SetWaterBaseColorPrototype _SetWaterBaseColor;
        private static SetWaterDeformsPrototype _SetWaterDeforms;
        private static GetTerrainTypePrototype _GetTerrainType;
        private static GetTerrainVariancePrototype _GetTerrainVariance;
        private static SetTerrainTypePrototype _SetTerrainType;
        private static IsTerrainPathablePrototype _IsTerrainPathable;
        private static SetTerrainPathablePrototype _SetTerrainPathable;
        private static CreateImagePrototype _CreateImage;
        private static DestroyImagePrototype _DestroyImage;
        private static ShowImagePrototype _ShowImage;
        private static SetImageConstantHeightPrototype _SetImageConstantHeight;
        private static SetImagePositionPrototype _SetImagePosition;
        private static SetImageColorPrototype _SetImageColor;
        private static SetImageRenderPrototype _SetImageRender;
        private static SetImageRenderAlwaysPrototype _SetImageRenderAlways;
        private static SetImageAboveWaterPrototype _SetImageAboveWater;
        private static SetImageTypePrototype _SetImageType;
        private static CreateUbersplatPrototype _CreateUbersplat;
        private static DestroyUbersplatPrototype _DestroyUbersplat;
        private static ResetUbersplatPrototype _ResetUbersplat;
        private static FinishUbersplatPrototype _FinishUbersplat;
        private static ShowUbersplatPrototype _ShowUbersplat;
        private static SetUbersplatRenderPrototype _SetUbersplatRender;
        private static SetUbersplatRenderAlwaysPrototype _SetUbersplatRenderAlways;
        private static SetBlightPrototype _SetBlight;
        private static SetBlightRectPrototype _SetBlightRect;
        private static SetBlightPointPrototype _SetBlightPoint;
        private static SetBlightLocPrototype _SetBlightLoc;
        private static CreateBlightedGoldminePrototype _CreateBlightedGoldmine;
        private static IsPointBlightedPrototype _IsPointBlighted;
        private static SetDoodadAnimationPrototype _SetDoodadAnimation;
        private static SetDoodadAnimationRectPrototype _SetDoodadAnimationRect;
        private static StartMeleeAIPrototype _StartMeleeAI;
        private static StartCampaignAIPrototype _StartCampaignAI;
        private static CommandAIPrototype _CommandAI;
        private static PauseCompAIPrototype _PauseCompAI;
        private static GetAIDifficultyPrototype _GetAIDifficulty;
        private static RemoveGuardPositionPrototype _RemoveGuardPosition;
        private static RecycleGuardPositionPrototype _RecycleGuardPosition;
        private static RemoveAllGuardPositionsPrototype _RemoveAllGuardPositions;
        private static CheatPrototype _Cheat;
        private static IsNoVictoryCheatPrototype _IsNoVictoryCheat;
        private static IsNoDefeatCheatPrototype _IsNoDefeatCheat;
        private static PreloadPrototype _Preload;
        private static PreloadEndPrototype _PreloadEnd;
        private static PreloadStartPrototype _PreloadStart;
        private static PreloadRefreshPrototype _PreloadRefresh;
        private static PreloadEndExPrototype _PreloadEndEx;
        private static PreloadGenClearPrototype _PreloadGenClear;
        private static PreloadGenStartPrototype _PreloadGenStart;
        private static PreloadGenEndPrototype _PreloadGenEnd;
        private static PreloaderPrototype _Preloader;

        public static void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception($"Attempted to initialize {typeof(Natives).Name} before 'game.dll' has been loaded.");
            if (!GameAddresses.IsReady)
                throw new Exception($"Attempted to initialize {typeof(Natives).Name} before {typeof(GameAddresses).Name} was ready.");
            InitNatives = Memory.InstallHook(GameAddresses.InitNatives, new InitNativesPrototype(InitNativesHook), true, false);
            Trace.WriteLine("Scanning vanilla natives . . .");
            IntPtr initNatives = GameAddresses.InitNatives;
            int num = 5;
            while (Memory.Read<byte>(initNatives + num) == 0x68)
            {
                NativeDeclaration native = new NativeDeclaration(initNatives + num);
                //Trace.WriteLine($"{native.Name}\t{native.Prototype}\t0x{native.FunctionPtr.ToInt32():X8}");
                vanillaNatives.Add(native);
                num += 20;
            }
            InitializeVanillaNatives();
            Trace.WriteLine($"found {vanillaNatives.Count}!");
        }

        private static int InitNativesHook()
        {
            Trace.WriteLine("Natives initialized");
            int num = InitNatives();
            foreach (NativeDeclaration customNative in customNatives)
                GameFunctions.BindNative(customNative.Function, customNative.Name, customNative.Prototype);
            return num;
        }

        private static void Add(NativeDeclaration native)
        {
            Trace.WriteLine($"Native added: {native.Name}{native.Prototype}");
            customNatives.Add(native);
        }

        public static NativeDeclaration Add(Delegate function, string name, string prototype)
        {
            NativeDeclaration native = new NativeDeclaration(function, name, prototype);
            Add(native);
            return native;
        }

        public static NativeDeclaration Add(Delegate function, string name)
        {
            string str1 = "(";
            foreach (ParameterInfo parameter in function.Method.GetParameters())
            {
                JassTypeAttribute jassTypeAttribute = (JassTypeAttribute)((IEnumerable<object>)parameter.ParameterType.GetCustomAttributes(typeof(JassTypeAttribute), true)).Single();
                str1 += jassTypeAttribute.TypeString;
            }
            string str2 = str1 + ")";
            string prototype;
            if (function.Method.ReturnType == typeof(void))
            {
                prototype = str2 + "V";
            }
            else
            {
                JassTypeAttribute jassTypeAttribute = (JassTypeAttribute)((IEnumerable<object>)function.Method.ReturnType.GetCustomAttributes(typeof(JassTypeAttribute), true)).Single();
                prototype = str2 + jassTypeAttribute.TypeString;
            }
            return Add(function, name, prototype);
        }

        public static NativeDeclaration Add(Delegate function, bool AddJNPrefix = true)
        {
            return Add(function, (AddJNPrefix ? "JN" : string.Empty) + function.Method.Name);
        }

        public static NativeDeclaration Get(string name)
        {
            return vanillaNatives.FirstOrDefault(native => native.Name == name);
        }

        public static void Remove(NativeDeclaration native)
        {
            customNatives.Remove(native);
            Trace.WriteLine("Native removed: " + native.Name + native.Prototype);
        }

        public static JassRace ConvertRace(JassInteger i)
        {
            return _ConvertRace(i);
        }

        public static JassAllianceType ConvertAllianceType(JassInteger i)
        {
            return _ConvertAllianceType(i);
        }

        public static JassRacePreference ConvertRacePref(JassInteger i)
        {
            return _ConvertRacePref(i);
        }

        public static JassIGameState ConvertIGameState(JassInteger i)
        {
            return _ConvertIGameState(i);
        }

        public static JassFGameState ConvertFGameState(JassInteger i)
        {
            return _ConvertFGameState(i);
        }

        public static JassPlayerState ConvertPlayerState(JassInteger i)
        {
            return _ConvertPlayerState(i);
        }

        public static JassPlayerScore ConvertPlayerScore(JassInteger i)
        {
            return _ConvertPlayerScore(i);
        }

        public static JassPlayerGameResult ConvertPlayerGameResult(JassInteger i)
        {
            return _ConvertPlayerGameResult(i);
        }

        public static JassUnitState ConvertUnitState(JassInteger i)
        {
            return _ConvertUnitState(i);
        }

        public static JassAIDifficulty ConvertAIDifficulty(JassInteger i)
        {
            return _ConvertAIDifficulty(i);
        }

        public static JassGameEvent ConvertGameEvent(JassInteger i)
        {
            return _ConvertGameEvent(i);
        }

        public static JassPlayerEvent ConvertPlayerEvent(JassInteger i)
        {
            return _ConvertPlayerEvent(i);
        }

        public static JassPlayerUnitEvent ConvertPlayerUnitEvent(JassInteger i)
        {
            return _ConvertPlayerUnitEvent(i);
        }

        public static JassWidgetEvent ConvertWidgetEvent(JassInteger i)
        {
            return _ConvertWidgetEvent(i);
        }

        public static JassDialogEvent ConvertDialogEvent(JassInteger i)
        {
            return _ConvertDialogEvent(i);
        }

        public static JassUnitEvent ConvertUnitEvent(JassInteger i)
        {
            return _ConvertUnitEvent(i);
        }

        public static JassLimitOp ConvertLimitOp(JassInteger i)
        {
            return _ConvertLimitOp(i);
        }

        public static JassUnitType ConvertUnitType(JassInteger i)
        {
            return _ConvertUnitType(i);
        }

        public static JassGameSpeed ConvertGameSpeed(JassInteger i)
        {
            return _ConvertGameSpeed(i);
        }

        public static JassPlacement ConvertPlacement(JassInteger i)
        {
            return _ConvertPlacement(i);
        }

        public static JassStartLocationPriority ConvertStartLocPrio(JassInteger i)
        {
            return _ConvertStartLocPrio(i);
        }

        public static JassGameDifficulty ConvertGameDifficulty(JassInteger i)
        {
            return _ConvertGameDifficulty(i);
        }

        public static JassGameType ConvertGameType(JassInteger i)
        {
            return _ConvertGameType(i);
        }

        public static JassMapFlag ConvertMapFlag(JassInteger i)
        {
            return _ConvertMapFlag(i);
        }

        public static JassMapVisibility ConvertMapVisibility(JassInteger i)
        {
            return _ConvertMapVisibility(i);
        }

        public static JassMapSetting ConvertMapSetting(JassInteger i)
        {
            return _ConvertMapSetting(i);
        }

        public static JassMapDensity ConvertMapDensity(JassInteger i)
        {
            return _ConvertMapDensity(i);
        }

        public static JassMapControl ConvertMapControl(JassInteger i)
        {
            return _ConvertMapControl(i);
        }

        public static JassPlayerColor ConvertPlayerColor(JassInteger i)
        {
            return _ConvertPlayerColor(i);
        }

        public static JassPlayerSlotState ConvertPlayerSlotState(JassInteger i)
        {
            return _ConvertPlayerSlotState(i);
        }

        public static JassVolumeGroup ConvertVolumeGroup(JassInteger i)
        {
            return _ConvertVolumeGroup(i);
        }

        public static JassCameraField ConvertCameraField(JassInteger i)
        {
            return _ConvertCameraField(i);
        }

        public static JassBlendMode ConvertBlendMode(JassInteger i)
        {
            return _ConvertBlendMode(i);
        }

        public static JassRarityControl ConvertRarityControl(JassInteger i)
        {
            return _ConvertRarityControl(i);
        }

        public static JassTextureMapFlags ConvertTexMapFlags(JassInteger i)
        {
            return _ConvertTexMapFlags(i);
        }

        public static JassFogState ConvertFogState(JassInteger i)
        {
            return _ConvertFogState(i);
        }

        public static JassEffectType ConvertEffectType(JassInteger i)
        {
            return _ConvertEffectType(i);
        }

        public static JassVersion ConvertVersion(JassInteger i)
        {
            return _ConvertVersion(i);
        }

        public static JassItemType ConvertItemType(JassInteger i)
        {
            return _ConvertItemType(i);
        }

        public static JassAttackType ConvertAttackType(JassInteger i)
        {
            return _ConvertAttackType(i);
        }

        public static JassDamageType ConvertDamageType(JassInteger i)
        {
            return _ConvertDamageType(i);
        }

        public static JassWeaponType ConvertWeaponType(JassInteger i)
        {
            return _ConvertWeaponType(i);
        }

        public static JassSoundType ConvertSoundType(JassInteger i)
        {
            return _ConvertSoundType(i);
        }

        public static JassPathingType ConvertPathingType(JassInteger i)
        {
            return _ConvertPathingType(i);
        }

        public static JassOrder OrderId(string orderIdString)
        {
            return _OrderId(orderIdString);
        }

        public static string OrderId2String(JassOrder orderId)
        {
            return _OrderId2String(orderId);
        }

        public static JassObjectId UnitId(string unitIdString)
        {
            return _UnitId(unitIdString);
        }

        public static string UnitId2String(JassObjectId unitId)
        {
            return _UnitId2String(unitId);
        }

        public static JassObjectId AbilityId(string abilityIdString)
        {
            return _AbilityId(abilityIdString);
        }

        public static string AbilityId2String(JassObjectId abilityId)
        {
            return _AbilityId2String(abilityId);
        }

        public static string GetObjectName(JassObjectId objectId)
        {
            return _GetObjectName(objectId);
        }

        public static float Deg2Rad(float degrees)
        {
            return _Deg2Rad(degrees);
        }

        public static float Rad2Deg(float radians)
        {
            return _Rad2Deg(radians);
        }

        public static float Sin(float radians)
        {
            return _Sin(radians);
        }

        public static float Cos(float radians)
        {
            return _Cos(radians);
        }

        public static float Tan(float radians)
        {
            return _Tan(radians);
        }

        public static float Asin(float y)
        {
            return _Asin(y);
        }

        public static float Acos(float x)
        {
            return _Acos(x);
        }

        public static float Atan(float x)
        {
            return _Atan(x);
        }

        public static float Atan2(float y, float x)
        {
            return _Atan2(y, x);
        }

        public static float SquareRoot(float x)
        {
            return _SquareRoot(x);
        }

        public static float Pow(float x, float power)
        {
            return _Pow(x, power);
        }

        public static float I2R(JassInteger i)
        {
            return _I2R(i);
        }

        public static JassInteger R2I(float r)
        {
            return _R2I(r);
        }

        public static string I2S(JassInteger i)
        {
            return _I2S(i);
        }

        public static string R2S(float r)
        {
            return _R2S(r);
        }

        public static string R2SW(float r, JassInteger width, JassInteger precision)
        {
            return _R2SW(r, width, precision);
        }

        public static JassInteger S2I(string s)
        {
            return _S2I(s);
        }

        public static float S2R(string s)
        {
            return _S2R(s);
        }

        public static JassInteger GetHandleId(JassHandle h)
        {
            return _GetHandleId(h);
        }

        public static string SubString(string source, JassInteger start, JassInteger end)
        {
            return _SubString(source, start, end);
        }

        public static JassInteger StringLength(string s)
        {
            return _StringLength(s);
        }

        public static string StringCase(string source, bool upper)
        {
            return _StringCase(source, upper);
        }

        public static JassInteger StringHash(string s)
        {
            return _StringHash(s);
        }

        public static string GetLocalizedString(string source)
        {
            return _GetLocalizedString(source);
        }

        public static JassInteger GetLocalizedHotkey(string source)
        {
            return _GetLocalizedHotkey(source);
        }

        public static void SetMapName(string name)
        {
            _SetMapName(name);
        }

        public static void SetMapDescription(string description)
        {
            _SetMapDescription(description);
        }

        public static void SetTeams(JassInteger teamcount)
        {
            _SetTeams(teamcount);
        }

        public static void SetPlayers(JassInteger playercount)
        {
            _SetPlayers(playercount);
        }

        public static void DefineStartLocation(JassInteger whichStartLoc, float x, float y)
        {
            _DefineStartLocation(whichStartLoc, x, y);
        }

        public static void DefineStartLocationLoc(JassInteger whichStartLoc, JassLocation whichLocation)
        {
            _DefineStartLocationLoc(whichStartLoc, whichLocation);
        }

        public static void SetStartLocPrioCount(JassInteger whichStartLoc, JassInteger prioSlotCount)
        {
            _SetStartLocPrioCount(whichStartLoc, prioSlotCount);
        }

        public static void SetStartLocPrio(JassInteger whichStartLoc, JassInteger prioSlotIndex, JassInteger otherStartLocIndex, JassStartLocationPriority priority)
        {
            _SetStartLocPrio(whichStartLoc, prioSlotIndex, otherStartLocIndex, priority);
        }

        public static JassInteger GetStartLocPrioSlot(JassInteger whichStartLoc, JassInteger prioSlotIndex)
        {
            return _GetStartLocPrioSlot(whichStartLoc, prioSlotIndex);
        }

        public static JassStartLocationPriority GetStartLocPrio(JassInteger whichStartLoc, JassInteger prioSlotIndex)
        {
            return _GetStartLocPrio(whichStartLoc, prioSlotIndex);
        }

        public static void SetGameTypeSupported(JassGameType whichGameType, bool value)
        {
            _SetGameTypeSupported(whichGameType, value);
        }

        public static void SetMapFlag(JassMapFlag whichMapFlag, bool value)
        {
            _SetMapFlag(whichMapFlag, value);
        }

        public static void SetGamePlacement(JassPlacement whichPlacementType)
        {
            _SetGamePlacement(whichPlacementType);
        }

        public static void SetGameSpeed(JassGameSpeed whichspeed)
        {
            _SetGameSpeed(whichspeed);
        }

        public static void SetGameDifficulty(JassGameDifficulty whichdifficulty)
        {
            _SetGameDifficulty(whichdifficulty);
        }

        public static void SetResourceDensity(JassMapDensity whichdensity)
        {
            _SetResourceDensity(whichdensity);
        }

        public static void SetCreatureDensity(JassMapDensity whichdensity)
        {
            _SetCreatureDensity(whichdensity);
        }

        public static JassInteger GetTeams()
        {
            return _GetTeams();
        }

        public static JassInteger GetPlayers()
        {
            return _GetPlayers();
        }

        public static bool IsGameTypeSupported(JassGameType whichGameType)
        {
            return _IsGameTypeSupported(whichGameType);
        }

        public static JassGameType GetGameTypeSelected()
        {
            return _GetGameTypeSelected();
        }

        public static bool IsMapFlagSet(JassMapFlag whichMapFlag)
        {
            return _IsMapFlagSet(whichMapFlag);
        }

        public static JassPlacement GetGamePlacement()
        {
            return _GetGamePlacement();
        }

        public static JassGameSpeed GetGameSpeed()
        {
            return _GetGameSpeed();
        }

        public static JassGameDifficulty GetGameDifficulty()
        {
            return _GetGameDifficulty();
        }

        public static JassMapDensity GetResourceDensity()
        {
            return _GetResourceDensity();
        }

        public static JassMapDensity GetCreatureDensity()
        {
            return _GetCreatureDensity();
        }

        public static float GetStartLocationX(JassInteger whichStartLocation)
        {
            return _GetStartLocationX(whichStartLocation);
        }

        public static float GetStartLocationY(JassInteger whichStartLocation)
        {
            return _GetStartLocationY(whichStartLocation);
        }

        public static JassLocation GetStartLocationLoc(JassInteger whichStartLocation)
        {
            return _GetStartLocationLoc(whichStartLocation);
        }

        public static void SetPlayerTeam(JassPlayer whichPlayer, JassInteger whichTeam)
        {
            _SetPlayerTeam(whichPlayer, whichTeam);
        }

        public static void SetPlayerStartLocation(JassPlayer whichPlayer, JassInteger startLocIndex)
        {
            _SetPlayerStartLocation(whichPlayer, startLocIndex);
        }

        public static void ForcePlayerStartLocation(JassPlayer whichPlayer, JassInteger startLocIndex)
        {
            _ForcePlayerStartLocation(whichPlayer, startLocIndex);
        }

        public static void SetPlayerColor(JassPlayer whichPlayer, JassPlayerColor color)
        {
            _SetPlayerColor(whichPlayer, color);
        }

        public static void SetPlayerAlliance(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassAllianceType whichAllianceSetting, bool value)
        {
            _SetPlayerAlliance(sourcePlayer, otherPlayer, whichAllianceSetting, value);
        }

        public static void SetPlayerTaxRate(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassPlayerState whichResource, JassInteger rate)
        {
            _SetPlayerTaxRate(sourcePlayer, otherPlayer, whichResource, rate);
        }

        public static void SetPlayerRacePreference(JassPlayer whichPlayer, JassRacePreference whichRacePreference)
        {
            _SetPlayerRacePreference(whichPlayer, whichRacePreference);
        }

        public static void SetPlayerRaceSelectable(JassPlayer whichPlayer, bool value)
        {
            _SetPlayerRaceSelectable(whichPlayer, value);
        }

        public static void SetPlayerController(JassPlayer whichPlayer, JassMapControl controlType)
        {
            _SetPlayerController(whichPlayer, controlType);
        }

        public static void SetPlayerName(JassPlayer whichPlayer, string name)
        {
            _SetPlayerName(whichPlayer, name);
        }

        public static void SetPlayerOnScoreScreen(JassPlayer whichPlayer, bool flag)
        {
            _SetPlayerOnScoreScreen(whichPlayer, flag);
        }

        public static JassInteger GetPlayerTeam(JassPlayer whichPlayer)
        {
            return _GetPlayerTeam(whichPlayer);
        }

        public static JassInteger GetPlayerStartLocation(JassPlayer whichPlayer)
        {
            return _GetPlayerStartLocation(whichPlayer);
        }

        public static JassPlayerColor GetPlayerColor(JassPlayer whichPlayer)
        {
            return _GetPlayerColor(whichPlayer);
        }

        public static bool GetPlayerSelectable(JassPlayer whichPlayer)
        {
            return _GetPlayerSelectable(whichPlayer);
        }

        public static JassMapControl GetPlayerController(JassPlayer whichPlayer)
        {
            return _GetPlayerController(whichPlayer);
        }

        public static JassPlayerSlotState GetPlayerSlotState(JassPlayer whichPlayer)
        {
            return _GetPlayerSlotState(whichPlayer);
        }

        public static JassInteger GetPlayerTaxRate(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassPlayerState whichResource)
        {
            return _GetPlayerTaxRate(sourcePlayer, otherPlayer, whichResource);
        }

        public static bool IsPlayerRacePrefSet(JassPlayer whichPlayer, JassRacePreference pref)
        {
            return _IsPlayerRacePrefSet(whichPlayer, pref);
        }

        public static string GetPlayerName(JassPlayer whichPlayer)
        {
            return _GetPlayerName(whichPlayer);
        }

        public static JassTimer CreateTimer()
        {
            return _CreateTimer();
        }

        public static void DestroyTimer(JassTimer whichTimer)
        {
            _DestroyTimer(whichTimer);
        }

        public static void TimerStart(JassTimer whichTimer, float timeout, bool periodic, JassCode handlerFunc)
        {
            _TimerStart(whichTimer, timeout, periodic, handlerFunc);
        }

        public static float TimerGetElapsed(JassTimer whichTimer)
        {
            return _TimerGetElapsed(whichTimer);
        }

        public static float TimerGetRemaining(JassTimer whichTimer)
        {
            return _TimerGetRemaining(whichTimer);
        }

        public static float TimerGetTimeout(JassTimer whichTimer)
        {
            return _TimerGetTimeout(whichTimer);
        }

        public static void PauseTimer(JassTimer whichTimer)
        {
            _PauseTimer(whichTimer);
        }

        public static void ResumeTimer(JassTimer whichTimer)
        {
            _ResumeTimer(whichTimer);
        }

        public static JassTimer GetExpiredTimer()
        {
            return _GetExpiredTimer();
        }

        public static JassGroup CreateGroup()
        {
            return _CreateGroup();
        }

        public static void DestroyGroup(JassGroup whichGroup)
        {
            _DestroyGroup(whichGroup);
        }

        public static void GroupAddUnit(JassGroup whichGroup, JassUnit whichUnit)
        {
            _GroupAddUnit(whichGroup, whichUnit);
        }

        public static void GroupRemoveUnit(JassGroup whichGroup, JassUnit whichUnit)
        {
            _GroupRemoveUnit(whichGroup, whichUnit);
        }

        public static void GroupClear(JassGroup whichGroup)
        {
            _GroupClear(whichGroup);
        }

        public static void GroupEnumUnitsOfType(JassGroup whichGroup, string unitname, JassBooleanExpression filter)
        {
            _GroupEnumUnitsOfType(whichGroup, unitname, filter);
        }

        public static void GroupEnumUnitsOfPlayer(JassGroup whichGroup, JassPlayer whichPlayer, JassBooleanExpression filter)
        {
            _GroupEnumUnitsOfPlayer(whichGroup, whichPlayer, filter);
        }

        public static void GroupEnumUnitsOfTypeCounted(JassGroup whichGroup, string unitname, JassBooleanExpression filter, JassInteger countLimit)
        {
            _GroupEnumUnitsOfTypeCounted(whichGroup, unitname, filter, countLimit);
        }

        public static void GroupEnumUnitsInRect(JassGroup whichGroup, JassRect r, JassBooleanExpression filter)
        {
            _GroupEnumUnitsInRect(whichGroup, r, filter);
        }

        public static void GroupEnumUnitsInRectCounted(JassGroup whichGroup, JassRect r, JassBooleanExpression filter, JassInteger countLimit)
        {
            _GroupEnumUnitsInRectCounted(whichGroup, r, filter, countLimit);
        }

        public static void GroupEnumUnitsInRange(JassGroup whichGroup, float x, float y, float radius, JassBooleanExpression filter)
        {
            _GroupEnumUnitsInRange(whichGroup, x, y, radius, filter);
        }

        public static void GroupEnumUnitsInRangeOfLoc(JassGroup whichGroup, JassLocation whichLocation, float radius, JassBooleanExpression filter)
        {
            _GroupEnumUnitsInRangeOfLoc(whichGroup, whichLocation, radius, filter);
        }

        public static void GroupEnumUnitsInRangeCounted(JassGroup whichGroup, float x, float y, float radius, JassBooleanExpression filter, JassInteger countLimit)
        {
            _GroupEnumUnitsInRangeCounted(whichGroup, x, y, radius, filter, countLimit);
        }

        public static void GroupEnumUnitsInRangeOfLocCounted(JassGroup whichGroup, JassLocation whichLocation, float radius, JassBooleanExpression filter, JassInteger countLimit)
        {
            _GroupEnumUnitsInRangeOfLocCounted(whichGroup, whichLocation, radius, filter, countLimit);
        }

        public static void GroupEnumUnitsSelected(JassGroup whichGroup, JassPlayer whichPlayer, JassBooleanExpression filter)
        {
            _GroupEnumUnitsSelected(whichGroup, whichPlayer, filter);
        }

        public static bool GroupImmediateOrder(JassGroup whichGroup, string order)
        {
            return _GroupImmediateOrder(whichGroup, order);
        }

        public static bool GroupImmediateOrderById(JassGroup whichGroup, JassOrder order)
        {
            return _GroupImmediateOrderById(whichGroup, order);
        }

        public static bool GroupPointOrder(JassGroup whichGroup, string order, float x, float y)
        {
            return _GroupPointOrder(whichGroup, order, x, y);
        }

        public static bool GroupPointOrderLoc(JassGroup whichGroup, string order, JassLocation whichLocation)
        {
            return _GroupPointOrderLoc(whichGroup, order, whichLocation);
        }

        public static bool GroupPointOrderById(JassGroup whichGroup, JassOrder order, float x, float y)
        {
            return _GroupPointOrderById(whichGroup, order, x, y);
        }

        public static bool GroupPointOrderByIdLoc(JassGroup whichGroup, JassOrder order, JassLocation whichLocation)
        {
            return _GroupPointOrderByIdLoc(whichGroup, order, whichLocation);
        }

        public static bool GroupTargetOrder(JassGroup whichGroup, string order, JassWidget targetWidget)
        {
            return _GroupTargetOrder(whichGroup, order, targetWidget);
        }

        public static bool GroupTargetOrderById(JassGroup whichGroup, JassOrder order, JassWidget targetWidget)
        {
            return _GroupTargetOrderById(whichGroup, order, targetWidget);
        }

        public static void ForGroup(JassGroup whichGroup, JassCode CallBack)
        {
            _ForGroup(whichGroup, CallBack);
        }

        public static JassUnit FirstOfGroup(JassGroup whichGroup)
        {
            return _FirstOfGroup(whichGroup);
        }

        public static JassForce CreateForce()
        {
            return _CreateForce();
        }

        public static void DestroyForce(JassForce whichForce)
        {
            _DestroyForce(whichForce);
        }

        public static void ForceAddPlayer(JassForce whichForce, JassPlayer whichPlayer)
        {
            _ForceAddPlayer(whichForce, whichPlayer);
        }

        public static void ForceRemovePlayer(JassForce whichForce, JassPlayer whichPlayer)
        {
            _ForceRemovePlayer(whichForce, whichPlayer);
        }

        public static void ForceClear(JassForce whichForce)
        {
            _ForceClear(whichForce);
        }

        public static void ForceEnumPlayers(JassForce whichForce, JassBooleanExpression filter)
        {
            _ForceEnumPlayers(whichForce, filter);
        }

        public static void ForceEnumPlayersCounted(JassForce whichForce, JassBooleanExpression filter, JassInteger countLimit)
        {
            _ForceEnumPlayersCounted(whichForce, filter, countLimit);
        }

        public static void ForceEnumAllies(JassForce whichForce, JassPlayer whichPlayer, JassBooleanExpression filter)
        {
            _ForceEnumAllies(whichForce, whichPlayer, filter);
        }

        public static void ForceEnumEnemies(JassForce whichForce, JassPlayer whichPlayer, JassBooleanExpression filter)
        {
            _ForceEnumEnemies(whichForce, whichPlayer, filter);
        }

        public static void ForForce(JassForce whichForce, JassCode CallBack)
        {
            _ForForce(whichForce, CallBack);
        }

        public static JassRect Rect(float minx, float miny, float maxx, float maxy)
        {
            return _Rect(minx, miny, maxx, maxy);
        }

        public static JassRect RectFromLoc(JassLocation min, JassLocation max)
        {
            return _RectFromLoc(min, max);
        }

        public static void RemoveRect(JassRect whichRect)
        {
            _RemoveRect(whichRect);
        }

        public static void SetRect(JassRect whichRect, float minx, float miny, float maxx, float maxy)
        {
            _SetRect(whichRect, minx, miny, maxx, maxy);
        }

        public static void SetRectFromLoc(JassRect whichRect, JassLocation min, JassLocation max)
        {
            _SetRectFromLoc(whichRect, min, max);
        }

        public static void MoveRectTo(JassRect whichRect, float newCenterX, float newCenterY)
        {
            _MoveRectTo(whichRect, newCenterX, newCenterY);
        }

        public static void MoveRectToLoc(JassRect whichRect, JassLocation newCenterLoc)
        {
            _MoveRectToLoc(whichRect, newCenterLoc);
        }

        public static float GetRectCenterX(JassRect whichRect)
        {
            return _GetRectCenterX(whichRect);
        }

        public static float GetRectCenterY(JassRect whichRect)
        {
            return _GetRectCenterY(whichRect);
        }

        public static float GetRectMinX(JassRect whichRect)
        {
            return _GetRectMinX(whichRect);
        }

        public static float GetRectMinY(JassRect whichRect)
        {
            return _GetRectMinY(whichRect);
        }

        public static float GetRectMaxX(JassRect whichRect)
        {
            return _GetRectMaxX(whichRect);
        }

        public static float GetRectMaxY(JassRect whichRect)
        {
            return _GetRectMaxY(whichRect);
        }

        public static JassRegion CreateRegion()
        {
            return _CreateRegion();
        }

        public static void RemoveRegion(JassRegion whichRegion)
        {
            _RemoveRegion(whichRegion);
        }

        public static void RegionAddRect(JassRegion whichRegion, JassRect r)
        {
            _RegionAddRect(whichRegion, r);
        }

        public static void RegionClearRect(JassRegion whichRegion, JassRect r)
        {
            _RegionClearRect(whichRegion, r);
        }

        public static void RegionAddCell(JassRegion whichRegion, float x, float y)
        {
            _RegionAddCell(whichRegion, x, y);
        }

        public static void RegionAddCellAtLoc(JassRegion whichRegion, JassLocation whichLocation)
        {
            _RegionAddCellAtLoc(whichRegion, whichLocation);
        }

        public static void RegionClearCell(JassRegion whichRegion, float x, float y)
        {
            _RegionClearCell(whichRegion, x, y);
        }

        public static void RegionClearCellAtLoc(JassRegion whichRegion, JassLocation whichLocation)
        {
            _RegionClearCellAtLoc(whichRegion, whichLocation);
        }

        public static JassLocation Location(float x, float y)
        {
            return _Location(x, y);
        }

        public static void RemoveLocation(JassLocation whichLocation)
        {
            _RemoveLocation(whichLocation);
        }

        public static void MoveLocation(JassLocation whichLocation, float newX, float newY)
        {
            _MoveLocation(whichLocation, newX, newY);
        }

        public static float GetLocationX(JassLocation whichLocation)
        {
            return _GetLocationX(whichLocation);
        }

        public static float GetLocationY(JassLocation whichLocation)
        {
            return _GetLocationY(whichLocation);
        }

        public static float GetLocationZ(JassLocation whichLocation)
        {
            return _GetLocationZ(whichLocation);
        }

        public static bool IsUnitInRegion(JassRegion whichRegion, JassUnit whichUnit)
        {
            return _IsUnitInRegion(whichRegion, whichUnit);
        }

        public static bool IsPointInRegion(JassRegion whichRegion, float x, float y)
        {
            return _IsPointInRegion(whichRegion, x, y);
        }

        public static bool IsLocationInRegion(JassRegion whichRegion, JassLocation whichLocation)
        {
            return _IsLocationInRegion(whichRegion, whichLocation);
        }

        public static JassRect GetWorldBounds()
        {
            return _GetWorldBounds();
        }

        public static JassTrigger CreateTrigger()
        {
            return _CreateTrigger();
        }

        public static void DestroyTrigger(JassTrigger whichTrigger)
        {
            _DestroyTrigger(whichTrigger);
        }

        public static void ResetTrigger(JassTrigger whichTrigger)
        {
            _ResetTrigger(whichTrigger);
        }

        public static void EnableTrigger(JassTrigger whichTrigger)
        {
            _EnableTrigger(whichTrigger);
        }

        public static void DisableTrigger(JassTrigger whichTrigger)
        {
            _DisableTrigger(whichTrigger);
        }

        public static bool IsTriggerEnabled(JassTrigger whichTrigger)
        {
            return _IsTriggerEnabled(whichTrigger);
        }

        public static void TriggerWaitOnSleeps(JassTrigger whichTrigger, bool flag)
        {
            _TriggerWaitOnSleeps(whichTrigger, flag);
        }

        public static bool IsTriggerWaitOnSleeps(JassTrigger whichTrigger)
        {
            return _IsTriggerWaitOnSleeps(whichTrigger);
        }

        public static JassUnit GetFilterUnit()
        {
            return _GetFilterUnit();
        }

        public static JassUnit GetEnumUnit()
        {
            return _GetEnumUnit();
        }

        public static JassDestructable GetFilterDestructable()
        {
            return _GetFilterDestructable();
        }

        public static JassDestructable GetEnumDestructable()
        {
            return _GetEnumDestructable();
        }

        public static JassItem GetFilterItem()
        {
            return _GetFilterItem();
        }

        public static JassItem GetEnumItem()
        {
            return _GetEnumItem();
        }

        public static JassPlayer GetFilterPlayer()
        {
            return _GetFilterPlayer();
        }

        public static JassPlayer GetEnumPlayer()
        {
            return _GetEnumPlayer();
        }

        public static JassTrigger GetTriggeringTrigger()
        {
            return _GetTriggeringTrigger();
        }

        public static JassEventIndex GetTriggerEventId()
        {
            return _GetTriggerEventId();
        }

        public static JassInteger GetTriggerEvalCount(JassTrigger whichTrigger)
        {
            return _GetTriggerEvalCount(whichTrigger);
        }

        public static JassInteger GetTriggerExecCount(JassTrigger whichTrigger)
        {
            return _GetTriggerExecCount(whichTrigger);
        }

        public static void ExecuteFunc(string funcName)
        {
            _ExecuteFunc(funcName);
        }

        public static JassBooleanExpression And(JassBooleanExpression operandA, JassBooleanExpression operandB)
        {
            return _And(operandA, operandB);
        }

        public static JassBooleanExpression Or(JassBooleanExpression operandA, JassBooleanExpression operandB)
        {
            return _Or(operandA, operandB);
        }

        public static JassBooleanExpression Not(JassBooleanExpression operand)
        {
            return _Not(operand);
        }

        public static JassConditionFunction Condition(JassCode func)
        {
            return _Condition(func);
        }

        public static void DestroyCondition(JassConditionFunction c)
        {
            _DestroyCondition(c);
        }

        public static JassFilterFunction Filter(JassCode func)
        {
            return _Filter(func);
        }

        public static void DestroyFilter(JassFilterFunction f)
        {
            _DestroyFilter(f);
        }

        public static void DestroyBoolExpr(JassBooleanExpression e)
        {
            _DestroyBoolExpr(e);
        }

        public static JassEvent TriggerRegisterVariableEvent(JassTrigger whichTrigger, string varName, JassLimitOp opcode, float limitval)
        {
            return _TriggerRegisterVariableEvent(whichTrigger, varName, opcode, limitval);
        }

        public static JassEvent TriggerRegisterTimerEvent(JassTrigger whichTrigger, float timeout, bool periodic)
        {
            return _TriggerRegisterTimerEvent(whichTrigger, timeout, periodic);
        }

        public static JassEvent TriggerRegisterTimerExpireEvent(JassTrigger whichTrigger, JassTimer t)
        {
            return _TriggerRegisterTimerExpireEvent(whichTrigger, t);
        }

        public static JassEvent TriggerRegisterGameStateEvent(JassTrigger whichTrigger, JassGameState whichState, JassLimitOp opcode, float limitval)
        {
            return _TriggerRegisterGameStateEvent(whichTrigger, whichState, opcode, limitval);
        }

        public static JassEvent TriggerRegisterDialogEvent(JassTrigger whichTrigger, JassDialog whichDialog)
        {
            return _TriggerRegisterDialogEvent(whichTrigger, whichDialog);
        }

        public static JassEvent TriggerRegisterDialogButtonEvent(JassTrigger whichTrigger, JassButton whichButton)
        {
            return _TriggerRegisterDialogButtonEvent(whichTrigger, whichButton);
        }

        public static JassGameState GetEventGameState()
        {
            return _GetEventGameState();
        }

        public static JassEvent TriggerRegisterGameEvent(JassTrigger whichTrigger, JassGameEvent whichGameEvent)
        {
            return _TriggerRegisterGameEvent(whichTrigger, whichGameEvent);
        }

        public static JassPlayer GetWinningPlayer()
        {
            return _GetWinningPlayer();
        }

        public static JassEvent TriggerRegisterEnterRegion(JassTrigger whichTrigger, JassRegion whichRegion, JassBooleanExpression filter)
        {
            return _TriggerRegisterEnterRegion(whichTrigger, whichRegion, filter);
        }

        public static JassRegion GetTriggeringRegion()
        {
            return _GetTriggeringRegion();
        }

        public static JassUnit GetEnteringUnit()
        {
            return _GetEnteringUnit();
        }

        public static JassEvent TriggerRegisterLeaveRegion(JassTrigger whichTrigger, JassRegion whichRegion, JassBooleanExpression filter)
        {
            return _TriggerRegisterLeaveRegion(whichTrigger, whichRegion, filter);
        }

        public static JassUnit GetLeavingUnit()
        {
            return _GetLeavingUnit();
        }

        public static JassEvent TriggerRegisterTrackableHitEvent(JassTrigger whichTrigger, JassTrackable t)
        {
            return _TriggerRegisterTrackableHitEvent(whichTrigger, t);
        }

        public static JassEvent TriggerRegisterTrackableTrackEvent(JassTrigger whichTrigger, JassTrackable t)
        {
            return _TriggerRegisterTrackableTrackEvent(whichTrigger, t);
        }

        public static JassTrackable GetTriggeringTrackable()
        {
            return _GetTriggeringTrackable();
        }

        public static JassButton GetClickedButton()
        {
            return _GetClickedButton();
        }

        public static JassDialog GetClickedDialog()
        {
            return _GetClickedDialog();
        }

        public static float GetTournamentFinishSoonTimeRemaining()
        {
            return _GetTournamentFinishSoonTimeRemaining();
        }

        public static JassInteger GetTournamentFinishNowRule()
        {
            return _GetTournamentFinishNowRule();
        }

        public static JassPlayer GetTournamentFinishNowPlayer()
        {
            return _GetTournamentFinishNowPlayer();
        }

        public static JassInteger GetTournamentScore(JassPlayer whichPlayer)
        {
            return _GetTournamentScore(whichPlayer);
        }

        public static string GetSaveBasicFilename()
        {
            return _GetSaveBasicFilename();
        }

        public static JassEvent TriggerRegisterPlayerEvent(JassTrigger whichTrigger, JassPlayer whichPlayer, JassPlayerEvent whichPlayerEvent)
        {
            return _TriggerRegisterPlayerEvent(whichTrigger, whichPlayer, whichPlayerEvent);
        }

        public static JassPlayer GetTriggerPlayer()
        {
            return _GetTriggerPlayer();
        }

        public static JassEvent TriggerRegisterPlayerUnitEvent(JassTrigger whichTrigger, JassPlayer whichPlayer, JassPlayerUnitEvent whichPlayerUnitEvent, JassBooleanExpression filter)
        {
            return _TriggerRegisterPlayerUnitEvent(whichTrigger, whichPlayer, whichPlayerUnitEvent, filter);
        }

        public static JassUnit GetLevelingUnit()
        {
            return _GetLevelingUnit();
        }

        public static JassUnit GetLearningUnit()
        {
            return _GetLearningUnit();
        }

        public static JassInteger GetLearnedSkill()
        {
            return _GetLearnedSkill();
        }

        public static JassInteger GetLearnedSkillLevel()
        {
            return _GetLearnedSkillLevel();
        }

        public static JassUnit GetRevivableUnit()
        {
            return _GetRevivableUnit();
        }

        public static JassUnit GetRevivingUnit()
        {
            return _GetRevivingUnit();
        }

        public static JassUnit GetAttacker()
        {
            return _GetAttacker();
        }

        public static JassUnit GetRescuer()
        {
            return _GetRescuer();
        }

        public static JassUnit GetDyingUnit()
        {
            return _GetDyingUnit();
        }

        public static JassUnit GetKillingUnit()
        {
            return _GetKillingUnit();
        }

        public static JassUnit GetDecayingUnit()
        {
            return _GetDecayingUnit();
        }

        public static JassUnit GetConstructingStructure()
        {
            return _GetConstructingStructure();
        }

        public static JassUnit GetCancelledStructure()
        {
            return _GetCancelledStructure();
        }

        public static JassUnit GetConstructedStructure()
        {
            return _GetConstructedStructure();
        }

        public static JassUnit GetResearchingUnit()
        {
            return _GetResearchingUnit();
        }

        public static JassInteger GetResearched()
        {
            return _GetResearched();
        }

        public static JassInteger GetTrainedUnitType()
        {
            return _GetTrainedUnitType();
        }

        public static JassUnit GetTrainedUnit()
        {
            return _GetTrainedUnit();
        }

        public static JassUnit GetDetectedUnit()
        {
            return _GetDetectedUnit();
        }

        public static JassUnit GetSummoningUnit()
        {
            return _GetSummoningUnit();
        }

        public static JassUnit GetSummonedUnit()
        {
            return _GetSummonedUnit();
        }

        public static JassUnit GetTransportUnit()
        {
            return _GetTransportUnit();
        }

        public static JassUnit GetLoadedUnit()
        {
            return _GetLoadedUnit();
        }

        public static JassUnit GetSellingUnit()
        {
            return _GetSellingUnit();
        }

        public static JassUnit GetSoldUnit()
        {
            return _GetSoldUnit();
        }

        public static JassUnit GetBuyingUnit()
        {
            return _GetBuyingUnit();
        }

        public static JassItem GetSoldItem()
        {
            return _GetSoldItem();
        }

        public static JassUnit GetChangingUnit()
        {
            return _GetChangingUnit();
        }

        public static JassPlayer GetChangingUnitPrevOwner()
        {
            return _GetChangingUnitPrevOwner();
        }

        public static JassUnit GetManipulatingUnit()
        {
            return _GetManipulatingUnit();
        }

        public static JassItem GetManipulatedItem()
        {
            return _GetManipulatedItem();
        }

        public static JassUnit GetOrderedUnit()
        {
            return _GetOrderedUnit();
        }

        public static JassOrder GetIssuedOrderId()
        {
            return _GetIssuedOrderId();
        }

        public static float GetOrderPointX()
        {
            return _GetOrderPointX();
        }

        public static float GetOrderPointY()
        {
            return _GetOrderPointY();
        }

        public static JassLocation GetOrderPointLoc()
        {
            return _GetOrderPointLoc();
        }

        public static JassWidget GetOrderTarget()
        {
            return _GetOrderTarget();
        }

        public static JassDestructable GetOrderTargetDestructable()
        {
            return _GetOrderTargetDestructable();
        }

        public static JassItem GetOrderTargetItem()
        {
            return _GetOrderTargetItem();
        }

        public static JassUnit GetOrderTargetUnit()
        {
            return _GetOrderTargetUnit();
        }

        public static JassUnit GetSpellAbilityUnit()
        {
            return _GetSpellAbilityUnit();
        }

        public static JassObjectId GetSpellAbilityId()
        {
            return _GetSpellAbilityId();
        }

        public static JassAbility GetSpellAbility()
        {
            return _GetSpellAbility();
        }

        public static JassLocation GetSpellTargetLoc()
        {
            return _GetSpellTargetLoc();
        }

        public static float GetSpellTargetX()
        {
            return _GetSpellTargetX();
        }

        public static float GetSpellTargetY()
        {
            return _GetSpellTargetY();
        }

        public static JassDestructable GetSpellTargetDestructable()
        {
            return _GetSpellTargetDestructable();
        }

        public static JassItem GetSpellTargetItem()
        {
            return _GetSpellTargetItem();
        }

        public static JassUnit GetSpellTargetUnit()
        {
            return _GetSpellTargetUnit();
        }

        public static JassEvent TriggerRegisterPlayerAllianceChange(JassTrigger whichTrigger, JassPlayer whichPlayer, JassAllianceType whichAlliance)
        {
            return _TriggerRegisterPlayerAllianceChange(whichTrigger, whichPlayer, whichAlliance);
        }

        public static JassEvent TriggerRegisterPlayerStateEvent(JassTrigger whichTrigger, JassPlayer whichPlayer, JassPlayerState whichState, JassLimitOp opcode, float limitval)
        {
            return _TriggerRegisterPlayerStateEvent(whichTrigger, whichPlayer, whichState, opcode, limitval);
        }

        public static JassPlayerState GetEventPlayerState()
        {
            return _GetEventPlayerState();
        }

        public static JassEvent TriggerRegisterPlayerChatEvent(JassTrigger whichTrigger, JassPlayer whichPlayer, string chatMessageToDetect, bool exactMatchOnly)
        {
            return _TriggerRegisterPlayerChatEvent(whichTrigger, whichPlayer, chatMessageToDetect, exactMatchOnly);
        }

        public static string GetEventPlayerChatString()
        {
            return _GetEventPlayerChatString();
        }

        public static string GetEventPlayerChatStringMatched()
        {
            return _GetEventPlayerChatStringMatched();
        }

        public static JassEvent TriggerRegisterDeathEvent(JassTrigger whichTrigger, JassWidget whichWidget)
        {
            return _TriggerRegisterDeathEvent(whichTrigger, whichWidget);
        }

        public static JassUnit GetTriggerUnit()
        {
            return _GetTriggerUnit();
        }

        public static JassEvent TriggerRegisterUnitStateEvent(JassTrigger whichTrigger, JassUnit whichUnit, JassUnitState whichState, JassLimitOp opcode, float limitval)
        {
            return _TriggerRegisterUnitStateEvent(whichTrigger, whichUnit, whichState, opcode, limitval);
        }

        public static JassUnitState GetEventUnitState()
        {
            return _GetEventUnitState();
        }

        public static JassEvent TriggerRegisterUnitEvent(JassTrigger whichTrigger, JassUnit whichUnit, JassUnitEvent whichEvent)
        {
            return _TriggerRegisterUnitEvent(whichTrigger, whichUnit, whichEvent);
        }

        public static float GetEventDamage()
        {
            return _GetEventDamage();
        }

        public static JassUnit GetEventDamageSource()
        {
            return _GetEventDamageSource();
        }

        public static JassPlayer GetEventDetectingPlayer()
        {
            return _GetEventDetectingPlayer();
        }

        public static JassEvent TriggerRegisterFilterUnitEvent(JassTrigger whichTrigger, JassUnit whichUnit, JassUnitEvent whichEvent, JassBooleanExpression filter)
        {
            return _TriggerRegisterFilterUnitEvent(whichTrigger, whichUnit, whichEvent, filter);
        }

        public static JassUnit GetEventTargetUnit()
        {
            return _GetEventTargetUnit();
        }

        public static JassEvent TriggerRegisterUnitInRange(JassTrigger whichTrigger, JassUnit whichUnit, float range, JassBooleanExpression filter)
        {
            return _TriggerRegisterUnitInRange(whichTrigger, whichUnit, range, filter);
        }

        public static JassTriggerCondition TriggerAddCondition(JassTrigger whichTrigger, JassBooleanExpression condition)
        {
            return _TriggerAddCondition(whichTrigger, condition);
        }

        public static void TriggerRemoveCondition(JassTrigger whichTrigger, JassTriggerCondition whichCondition)
        {
            _TriggerRemoveCondition(whichTrigger, whichCondition);
        }

        public static void TriggerClearConditions(JassTrigger whichTrigger)
        {
            _TriggerClearConditions(whichTrigger);
        }

        public static JassTriggerAction TriggerAddAction(JassTrigger whichTrigger, JassCode actionFunc)
        {
            return _TriggerAddAction(whichTrigger, actionFunc);
        }

        public static void TriggerRemoveAction(JassTrigger whichTrigger, JassTriggerAction whichAction)
        {
            _TriggerRemoveAction(whichTrigger, whichAction);
        }

        public static void TriggerClearActions(JassTrigger whichTrigger)
        {
            _TriggerClearActions(whichTrigger);
        }

        public static void TriggerSleepAction(float timeout)
        {
            _TriggerSleepAction(timeout);
        }

        public static void TriggerWaitForSound(JassSound s, float offset)
        {
            _TriggerWaitForSound(s, offset);
        }

        public static bool TriggerEvaluate(JassTrigger whichTrigger)
        {
            return _TriggerEvaluate(whichTrigger);
        }

        public static void TriggerExecute(JassTrigger whichTrigger)
        {
            _TriggerExecute(whichTrigger);
        }

        public static void TriggerExecuteWait(JassTrigger whichTrigger)
        {
            _TriggerExecuteWait(whichTrigger);
        }

        public static void TriggerSyncStart()
        {
            _TriggerSyncStart();
        }

        public static void TriggerSyncReady()
        {
            _TriggerSyncReady();
        }

        public static float GetWidgetLife(JassWidget whichWidget)
        {
            return _GetWidgetLife(whichWidget);
        }

        public static void SetWidgetLife(JassWidget whichWidget, float newLife)
        {
            _SetWidgetLife(whichWidget, newLife);
        }

        public static float GetWidgetX(JassWidget whichWidget)
        {
            return _GetWidgetX(whichWidget);
        }

        public static float GetWidgetY(JassWidget whichWidget)
        {
            return _GetWidgetY(whichWidget);
        }

        public static JassWidget GetTriggerWidget()
        {
            return _GetTriggerWidget();
        }

        public static JassDestructable CreateDestructable(JassObjectId objectid, float x, float y, float face, float scale, JassInteger variation)
        {
            return _CreateDestructable(objectid, x, y, face, scale, variation);
        }

        public static JassDestructable CreateDestructableZ(JassObjectId objectid, float x, float y, float z, float face, float scale, JassInteger variation)
        {
            return _CreateDestructableZ(objectid, x, y, z, face, scale, variation);
        }

        public static JassDestructable CreateDeadDestructable(JassObjectId objectid, float x, float y, float face, float scale, JassInteger variation)
        {
            return _CreateDeadDestructable(objectid, x, y, face, scale, variation);
        }

        public static JassDestructable CreateDeadDestructableZ(JassObjectId objectid, float x, float y, float z, float face, float scale, JassInteger variation)
        {
            return _CreateDeadDestructableZ(objectid, x, y, z, face, scale, variation);
        }

        public static void RemoveDestructable(JassDestructable d)
        {
            _RemoveDestructable(d);
        }

        public static void KillDestructable(JassDestructable d)
        {
            _KillDestructable(d);
        }

        public static void SetDestructableInvulnerable(JassDestructable d, bool flag)
        {
            _SetDestructableInvulnerable(d, flag);
        }

        public static bool IsDestructableInvulnerable(JassDestructable d)
        {
            return _IsDestructableInvulnerable(d);
        }

        public static void EnumDestructablesInRect(JassRect r, JassBooleanExpression filter, JassCode actionFunc)
        {
            _EnumDestructablesInRect(r, filter, actionFunc);
        }

        public static JassObjectId GetDestructableTypeId(JassDestructable d)
        {
            return _GetDestructableTypeId(d);
        }

        public static float GetDestructableX(JassDestructable d)
        {
            return _GetDestructableX(d);
        }

        public static float GetDestructableY(JassDestructable d)
        {
            return _GetDestructableY(d);
        }

        public static void SetDestructableLife(JassDestructable d, float life)
        {
            _SetDestructableLife(d, life);
        }

        public static float GetDestructableLife(JassDestructable d)
        {
            return _GetDestructableLife(d);
        }

        public static void SetDestructableMaxLife(JassDestructable d, float max)
        {
            _SetDestructableMaxLife(d, max);
        }

        public static float GetDestructableMaxLife(JassDestructable d)
        {
            return _GetDestructableMaxLife(d);
        }

        public static void DestructableRestoreLife(JassDestructable d, float life, bool birth)
        {
            _DestructableRestoreLife(d, life, birth);
        }

        public static void QueueDestructableAnimation(JassDestructable d, string whichAnimation)
        {
            _QueueDestructableAnimation(d, whichAnimation);
        }

        public static void SetDestructableAnimation(JassDestructable d, string whichAnimation)
        {
            _SetDestructableAnimation(d, whichAnimation);
        }

        public static void SetDestructableAnimationSpeed(JassDestructable d, float speedFactor)
        {
            _SetDestructableAnimationSpeed(d, speedFactor);
        }

        public static void ShowDestructable(JassDestructable d, bool flag)
        {
            _ShowDestructable(d, flag);
        }

        public static float GetDestructableOccluderHeight(JassDestructable d)
        {
            return _GetDestructableOccluderHeight(d);
        }

        public static void SetDestructableOccluderHeight(JassDestructable d, float height)
        {
            _SetDestructableOccluderHeight(d, height);
        }

        public static string GetDestructableName(JassDestructable d)
        {
            return _GetDestructableName(d);
        }

        public static JassDestructable GetTriggerDestructable()
        {
            return _GetTriggerDestructable();
        }

        public static JassItem CreateItem(JassObjectId itemid, float x, float y)
        {
            return _CreateItem(itemid, x, y);
        }

        public static void RemoveItem(JassItem whichItem)
        {
            _RemoveItem(whichItem);
        }

        public static JassPlayer GetItemPlayer(JassItem whichItem)
        {
            return _GetItemPlayer(whichItem);
        }

        public static JassObjectId GetItemTypeId(JassItem i)
        {
            return _GetItemTypeId(i);
        }

        public static float GetItemX(JassItem i)
        {
            return _GetItemX(i);
        }

        public static float GetItemY(JassItem i)
        {
            return _GetItemY(i);
        }

        public static void SetItemPosition(JassItem i, float x, float y)
        {
            _SetItemPosition(i, x, y);
        }

        public static void SetItemDropOnDeath(JassItem whichItem, bool flag)
        {
            _SetItemDropOnDeath(whichItem, flag);
        }

        public static void SetItemDroppable(JassItem i, bool flag)
        {
            _SetItemDroppable(i, flag);
        }

        public static void SetItemPawnable(JassItem i, bool flag)
        {
            _SetItemPawnable(i, flag);
        }

        public static void SetItemPlayer(JassItem whichItem, JassPlayer whichPlayer, bool changeColor)
        {
            _SetItemPlayer(whichItem, whichPlayer, changeColor);
        }

        public static void SetItemInvulnerable(JassItem whichItem, bool flag)
        {
            _SetItemInvulnerable(whichItem, flag);
        }

        public static bool IsItemInvulnerable(JassItem whichItem)
        {
            return _IsItemInvulnerable(whichItem);
        }

        public static void SetItemVisible(JassItem whichItem, bool show)
        {
            _SetItemVisible(whichItem, show);
        }

        public static bool IsItemVisible(JassItem whichItem)
        {
            return _IsItemVisible(whichItem);
        }

        public static bool IsItemOwned(JassItem whichItem)
        {
            return _IsItemOwned(whichItem);
        }

        public static bool IsItemPowerup(JassItem whichItem)
        {
            return _IsItemPowerup(whichItem);
        }

        public static bool IsItemSellable(JassItem whichItem)
        {
            return _IsItemSellable(whichItem);
        }

        public static bool IsItemPawnable(JassItem whichItem)
        {
            return _IsItemPawnable(whichItem);
        }

        public static bool IsItemIdPowerup(JassObjectId itemId)
        {
            return _IsItemIdPowerup(itemId);
        }

        public static bool IsItemIdSellable(JassObjectId itemId)
        {
            return _IsItemIdSellable(itemId);
        }

        public static bool IsItemIdPawnable(JassObjectId itemId)
        {
            return _IsItemIdPawnable(itemId);
        }

        public static void EnumItemsInRect(JassRect r, JassBooleanExpression filter, JassCode actionFunc)
        {
            _EnumItemsInRect(r, filter, actionFunc);
        }

        public static JassInteger GetItemLevel(JassItem whichItem)
        {
            return _GetItemLevel(whichItem);
        }

        public static JassItemType GetItemType(JassItem whichItem)
        {
            return _GetItemType(whichItem);
        }

        public static void SetItemDropID(JassItem whichItem, JassObjectId unitId)
        {
            _SetItemDropID(whichItem, unitId);
        }

        public static string GetItemName(JassItem whichItem)
        {
            return _GetItemName(whichItem);
        }

        public static JassInteger GetItemCharges(JassItem whichItem)
        {
            return _GetItemCharges(whichItem);
        }

        public static void SetItemCharges(JassItem whichItem, JassInteger charges)
        {
            _SetItemCharges(whichItem, charges);
        }

        public static JassInteger GetItemUserData(JassItem whichItem)
        {
            return _GetItemUserData(whichItem);
        }

        public static void SetItemUserData(JassItem whichItem, JassInteger data)
        {
            _SetItemUserData(whichItem, data);
        }

        public static JassUnit CreateUnit(JassPlayer id, JassObjectId unitid, float x, float y, float face)
        {
            return _CreateUnit(id, unitid, x, y, face);
        }

        public static JassUnit CreateUnitByName(JassPlayer whichPlayer, string unitname, float x, float y, float face)
        {
            return _CreateUnitByName(whichPlayer, unitname, x, y, face);
        }

        public static JassUnit CreateUnitAtLoc(JassPlayer id, JassObjectId unitid, JassLocation whichLocation, float face)
        {
            return _CreateUnitAtLoc(id, unitid, whichLocation, face);
        }

        public static JassUnit CreateUnitAtLocByName(JassPlayer id, string unitname, JassLocation whichLocation, float face)
        {
            return _CreateUnitAtLocByName(id, unitname, whichLocation, face);
        }

        public static JassUnit CreateCorpse(JassPlayer whichPlayer, JassObjectId unitid, float x, float y, float face)
        {
            return _CreateCorpse(whichPlayer, unitid, x, y, face);
        }

        public static void KillUnit(JassUnit whichUnit)
        {
            _KillUnit(whichUnit);
        }

        public static void RemoveUnit(JassUnit whichUnit)
        {
            _RemoveUnit(whichUnit);
        }

        public static void ShowUnit(JassUnit whichUnit, bool show)
        {
            _ShowUnit(whichUnit, show);
        }

        public static void SetUnitState(JassUnit whichUnit, JassUnitState whichUnitState, float newVal)
        {
            _SetUnitState(whichUnit, whichUnitState, newVal);
        }

        public static void SetUnitX(JassUnit whichUnit, float newX)
        {
            _SetUnitX(whichUnit, newX);
        }

        public static void SetUnitY(JassUnit whichUnit, float newY)
        {
            _SetUnitY(whichUnit, newY);
        }

        public static void SetUnitPosition(JassUnit whichUnit, float newX, float newY)
        {
            _SetUnitPosition(whichUnit, newX, newY);
        }

        public static void SetUnitPositionLoc(JassUnit whichUnit, JassLocation whichLocation)
        {
            _SetUnitPositionLoc(whichUnit, whichLocation);
        }

        public static void SetUnitFacing(JassUnit whichUnit, float facingAngle)
        {
            _SetUnitFacing(whichUnit, facingAngle);
        }

        public static void SetUnitFacingTimed(JassUnit whichUnit, float facingAngle, float duration)
        {
            _SetUnitFacingTimed(whichUnit, facingAngle, duration);
        }

        public static void SetUnitMoveSpeed(JassUnit whichUnit, float newSpeed)
        {
            _SetUnitMoveSpeed(whichUnit, newSpeed);
        }

        public static void SetUnitFlyHeight(JassUnit whichUnit, float newHeight, float rate)
        {
            _SetUnitFlyHeight(whichUnit, newHeight, rate);
        }

        public static void SetUnitTurnSpeed(JassUnit whichUnit, float newTurnSpeed)
        {
            _SetUnitTurnSpeed(whichUnit, newTurnSpeed);
        }

        public static void SetUnitPropWindow(JassUnit whichUnit, float newPropWindowAngle)
        {
            _SetUnitPropWindow(whichUnit, newPropWindowAngle);
        }

        public static void SetUnitAcquireRange(JassUnit whichUnit, float newAcquireRange)
        {
            _SetUnitAcquireRange(whichUnit, newAcquireRange);
        }

        public static void SetUnitCreepGuard(JassUnit whichUnit, bool creepGuard)
        {
            _SetUnitCreepGuard(whichUnit, creepGuard);
        }

        public static float GetUnitAcquireRange(JassUnit whichUnit)
        {
            return _GetUnitAcquireRange(whichUnit);
        }

        public static float GetUnitTurnSpeed(JassUnit whichUnit)
        {
            return _GetUnitTurnSpeed(whichUnit);
        }

        public static float GetUnitPropWindow(JassUnit whichUnit)
        {
            return _GetUnitPropWindow(whichUnit);
        }

        public static float GetUnitFlyHeight(JassUnit whichUnit)
        {
            return _GetUnitFlyHeight(whichUnit);
        }

        public static float GetUnitDefaultAcquireRange(JassUnit whichUnit)
        {
            return _GetUnitDefaultAcquireRange(whichUnit);
        }

        public static float GetUnitDefaultTurnSpeed(JassUnit whichUnit)
        {
            return _GetUnitDefaultTurnSpeed(whichUnit);
        }

        public static float GetUnitDefaultPropWindow(JassUnit whichUnit)
        {
            return _GetUnitDefaultPropWindow(whichUnit);
        }

        public static float GetUnitDefaultFlyHeight(JassUnit whichUnit)
        {
            return _GetUnitDefaultFlyHeight(whichUnit);
        }

        public static void SetUnitOwner(JassUnit whichUnit, JassPlayer whichPlayer, bool changeColor)
        {
            _SetUnitOwner(whichUnit, whichPlayer, changeColor);
        }

        public static void SetUnitColor(JassUnit whichUnit, JassPlayerColor whichColor)
        {
            _SetUnitColor(whichUnit, whichColor);
        }

        public static void SetUnitScale(JassUnit whichUnit, float scaleX, float scaleY, float scaleZ)
        {
            _SetUnitScale(whichUnit, scaleX, scaleY, scaleZ);
        }

        public static void SetUnitTimeScale(JassUnit whichUnit, float timeScale)
        {
            _SetUnitTimeScale(whichUnit, timeScale);
        }

        public static void SetUnitBlendTime(JassUnit whichUnit, float blendTime)
        {
            _SetUnitBlendTime(whichUnit, blendTime);
        }

        public static void SetUnitVertexColor(JassUnit whichUnit, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _SetUnitVertexColor(whichUnit, red, green, blue, alpha);
        }

        public static void QueueUnitAnimation(JassUnit whichUnit, string whichAnimation)
        {
            _QueueUnitAnimation(whichUnit, whichAnimation);
        }

        public static void SetUnitAnimation(JassUnit whichUnit, string whichAnimation)
        {
            _SetUnitAnimation(whichUnit, whichAnimation);
        }

        public static void SetUnitAnimationByIndex(JassUnit whichUnit, JassInteger whichAnimation)
        {
            _SetUnitAnimationByIndex(whichUnit, whichAnimation);
        }

        public static void SetUnitAnimationWithRarity(JassUnit whichUnit, string whichAnimation, JassRarityControl rarity)
        {
            _SetUnitAnimationWithRarity(whichUnit, whichAnimation, rarity);
        }

        public static void AddUnitAnimationProperties(JassUnit whichUnit, string animProperties, bool add)
        {
            _AddUnitAnimationProperties(whichUnit, animProperties, add);
        }

        public static void SetUnitLookAt(JassUnit whichUnit, string whichBone, JassUnit lookAtTarget, float offsetX, float offsetY, float offsetZ)
        {
            _SetUnitLookAt(whichUnit, whichBone, lookAtTarget, offsetX, offsetY, offsetZ);
        }

        public static void ResetUnitLookAt(JassUnit whichUnit)
        {
            _ResetUnitLookAt(whichUnit);
        }

        public static void SetUnitRescuable(JassUnit whichUnit, JassPlayer byWhichPlayer, bool flag)
        {
            _SetUnitRescuable(whichUnit, byWhichPlayer, flag);
        }

        public static void SetUnitRescueRange(JassUnit whichUnit, float range)
        {
            _SetUnitRescueRange(whichUnit, range);
        }

        public static void SetHeroStr(JassUnit whichHero, JassInteger newStr, bool permanent)
        {
            _SetHeroStr(whichHero, newStr, permanent);
        }

        public static void SetHeroAgi(JassUnit whichHero, JassInteger newAgi, bool permanent)
        {
            _SetHeroAgi(whichHero, newAgi, permanent);
        }

        public static void SetHeroInt(JassUnit whichHero, JassInteger newInt, bool permanent)
        {
            _SetHeroInt(whichHero, newInt, permanent);
        }

        public static JassInteger GetHeroStr(JassUnit whichHero, bool includeBonuses)
        {
            return _GetHeroStr(whichHero, includeBonuses);
        }

        public static JassInteger GetHeroAgi(JassUnit whichHero, bool includeBonuses)
        {
            return _GetHeroAgi(whichHero, includeBonuses);
        }

        public static JassInteger GetHeroInt(JassUnit whichHero, bool includeBonuses)
        {
            return _GetHeroInt(whichHero, includeBonuses);
        }

        public static bool UnitStripHeroLevel(JassUnit whichHero, JassInteger howManyLevels)
        {
            return _UnitStripHeroLevel(whichHero, howManyLevels);
        }

        public static JassInteger GetHeroXP(JassUnit whichHero)
        {
            return _GetHeroXP(whichHero);
        }

        public static void SetHeroXP(JassUnit whichHero, JassInteger newXpVal, bool showEyeCandy)
        {
            _SetHeroXP(whichHero, newXpVal, showEyeCandy);
        }

        public static JassInteger GetHeroSkillPoints(JassUnit whichHero)
        {
            return _GetHeroSkillPoints(whichHero);
        }

        public static bool UnitModifySkillPoints(JassUnit whichHero, JassInteger skillPointDelta)
        {
            return _UnitModifySkillPoints(whichHero, skillPointDelta);
        }

        public static void AddHeroXP(JassUnit whichHero, JassInteger xpToAdd, bool showEyeCandy)
        {
            _AddHeroXP(whichHero, xpToAdd, showEyeCandy);
        }

        public static void SetHeroLevel(JassUnit whichHero, JassInteger level, bool showEyeCandy)
        {
            _SetHeroLevel(whichHero, level, showEyeCandy);
        }

        public static JassInteger GetHeroLevel(JassUnit whichHero)
        {
            return _GetHeroLevel(whichHero);
        }

        public static JassInteger GetUnitLevel(JassUnit whichUnit)
        {
            return _GetUnitLevel(whichUnit);
        }

        public static string GetHeroProperName(JassUnit whichHero)
        {
            return _GetHeroProperName(whichHero);
        }

        public static void SuspendHeroXP(JassUnit whichHero, bool flag)
        {
            _SuspendHeroXP(whichHero, flag);
        }

        public static bool IsSuspendedXP(JassUnit whichHero)
        {
            return _IsSuspendedXP(whichHero);
        }

        public static void SelectHeroSkill(JassUnit whichHero, JassObjectId abilcode)
        {
            _SelectHeroSkill(whichHero, abilcode);
        }

        public static JassInteger GetUnitAbilityLevel(JassUnit whichUnit, JassObjectId abilcode)
        {
            return _GetUnitAbilityLevel(whichUnit, abilcode);
        }

        public static JassInteger DecUnitAbilityLevel(JassUnit whichUnit, JassObjectId abilcode)
        {
            return _DecUnitAbilityLevel(whichUnit, abilcode);
        }

        public static JassInteger IncUnitAbilityLevel(JassUnit whichUnit, JassObjectId abilcode)
        {
            return _IncUnitAbilityLevel(whichUnit, abilcode);
        }

        public static JassInteger SetUnitAbilityLevel(JassUnit whichUnit, JassObjectId abilcode, JassInteger level)
        {
            return _SetUnitAbilityLevel(whichUnit, abilcode, level);
        }

        public static bool ReviveHero(JassUnit whichHero, float x, float y, bool doEyecandy)
        {
            return _ReviveHero(whichHero, x, y, doEyecandy);
        }

        public static bool ReviveHeroLoc(JassUnit whichHero, JassLocation loc, bool doEyecandy)
        {
            return _ReviveHeroLoc(whichHero, loc, doEyecandy);
        }

        public static void SetUnitExploded(JassUnit whichUnit, bool exploded)
        {
            _SetUnitExploded(whichUnit, exploded);
        }

        public static void SetUnitInvulnerable(JassUnit whichUnit, bool flag)
        {
            _SetUnitInvulnerable(whichUnit, flag);
        }

        public static void PauseUnit(JassUnit whichUnit, bool flag)
        {
            _PauseUnit(whichUnit, flag);
        }

        public static bool IsUnitPaused(JassUnit whichHero)
        {
            return _IsUnitPaused(whichHero);
        }

        public static void SetUnitPathing(JassUnit whichUnit, bool flag)
        {
            _SetUnitPathing(whichUnit, flag);
        }

        public static void ClearSelection()
        {
            _ClearSelection();
        }

        public static void SelectUnit(JassUnit whichUnit, bool flag)
        {
            _SelectUnit(whichUnit, flag);
        }

        public static JassInteger GetUnitPointValue(JassUnit whichUnit)
        {
            return _GetUnitPointValue(whichUnit);
        }

        public static JassInteger GetUnitPointValueByType(JassInteger unitType)
        {
            return _GetUnitPointValueByType(unitType);
        }

        public static bool UnitAddItem(JassUnit whichUnit, JassItem whichItem)
        {
            return _UnitAddItem(whichUnit, whichItem);
        }

        public static JassItem UnitAddItemById(JassUnit whichUnit, JassObjectId itemId)
        {
            return _UnitAddItemById(whichUnit, itemId);
        }

        public static bool UnitAddItemToSlotById(JassUnit whichUnit, JassObjectId itemId, JassInteger itemSlot)
        {
            return _UnitAddItemToSlotById(whichUnit, itemId, itemSlot);
        }

        public static void UnitRemoveItem(JassUnit whichUnit, JassItem whichItem)
        {
            _UnitRemoveItem(whichUnit, whichItem);
        }

        public static JassItem UnitRemoveItemFromSlot(JassUnit whichUnit, JassInteger itemSlot)
        {
            return _UnitRemoveItemFromSlot(whichUnit, itemSlot);
        }

        public static bool UnitHasItem(JassUnit whichUnit, JassItem whichItem)
        {
            return _UnitHasItem(whichUnit, whichItem);
        }

        public static JassItem UnitItemInSlot(JassUnit whichUnit, JassInteger itemSlot)
        {
            return _UnitItemInSlot(whichUnit, itemSlot);
        }

        public static JassInteger UnitInventorySize(JassUnit whichUnit)
        {
            return _UnitInventorySize(whichUnit);
        }

        public static bool UnitDropItemPoint(JassUnit whichUnit, JassItem whichItem, float x, float y)
        {
            return _UnitDropItemPoint(whichUnit, whichItem, x, y);
        }

        public static bool UnitDropItemSlot(JassUnit whichUnit, JassItem whichItem, JassInteger slot)
        {
            return _UnitDropItemSlot(whichUnit, whichItem, slot);
        }

        public static bool UnitDropItemTarget(JassUnit whichUnit, JassItem whichItem, JassWidget target)
        {
            return _UnitDropItemTarget(whichUnit, whichItem, target);
        }

        public static bool UnitUseItem(JassUnit whichUnit, JassItem whichItem)
        {
            return _UnitUseItem(whichUnit, whichItem);
        }

        public static bool UnitUseItemPoint(JassUnit whichUnit, JassItem whichItem, float x, float y)
        {
            return _UnitUseItemPoint(whichUnit, whichItem, x, y);
        }

        public static bool UnitUseItemTarget(JassUnit whichUnit, JassItem whichItem, JassWidget target)
        {
            return _UnitUseItemTarget(whichUnit, whichItem, target);
        }

        public static float GetUnitX(JassUnit whichUnit)
        {
            return _GetUnitX(whichUnit);
        }

        public static float GetUnitY(JassUnit whichUnit)
        {
            return _GetUnitY(whichUnit);
        }

        public static JassLocation GetUnitLoc(JassUnit whichUnit)
        {
            return _GetUnitLoc(whichUnit);
        }

        public static float GetUnitFacing(JassUnit whichUnit)
        {
            return _GetUnitFacing(whichUnit);
        }

        public static float GetUnitMoveSpeed(JassUnit whichUnit)
        {
            return _GetUnitMoveSpeed(whichUnit);
        }

        public static float GetUnitDefaultMoveSpeed(JassUnit whichUnit)
        {
            return _GetUnitDefaultMoveSpeed(whichUnit);
        }

        public static float GetUnitState(JassUnit whichUnit, JassUnitState whichUnitState)
        {
            return _GetUnitState(whichUnit, whichUnitState);
        }

        public static JassPlayer GetOwningPlayer(JassUnit whichUnit)
        {
            return _GetOwningPlayer(whichUnit);
        }

        public static JassObjectId GetUnitTypeId(JassUnit whichUnit)
        {
            return _GetUnitTypeId(whichUnit);
        }

        public static JassRace GetUnitRace(JassUnit whichUnit)
        {
            return _GetUnitRace(whichUnit);
        }

        public static string GetUnitName(JassUnit whichUnit)
        {
            return _GetUnitName(whichUnit);
        }

        public static JassInteger GetUnitFoodUsed(JassUnit whichUnit)
        {
            return _GetUnitFoodUsed(whichUnit);
        }

        public static JassInteger GetUnitFoodMade(JassUnit whichUnit)
        {
            return _GetUnitFoodMade(whichUnit);
        }

        public static JassInteger GetFoodMade(JassObjectId unitId)
        {
            return _GetFoodMade(unitId);
        }

        public static JassInteger GetFoodUsed(JassObjectId unitId)
        {
            return _GetFoodUsed(unitId);
        }

        public static void SetUnitUseFood(JassUnit whichUnit, bool useFood)
        {
            _SetUnitUseFood(whichUnit, useFood);
        }

        public static JassLocation GetUnitRallyPoint(JassUnit whichUnit)
        {
            return _GetUnitRallyPoint(whichUnit);
        }

        public static JassUnit GetUnitRallyUnit(JassUnit whichUnit)
        {
            return _GetUnitRallyUnit(whichUnit);
        }

        public static JassDestructable GetUnitRallyDestructable(JassUnit whichUnit)
        {
            return _GetUnitRallyDestructable(whichUnit);
        }

        public static bool IsUnitInGroup(JassUnit whichUnit, JassGroup whichGroup)
        {
            return _IsUnitInGroup(whichUnit, whichGroup);
        }

        public static bool IsUnitInForce(JassUnit whichUnit, JassForce whichForce)
        {
            return _IsUnitInForce(whichUnit, whichForce);
        }

        public static bool IsUnitOwnedByPlayer(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitOwnedByPlayer(whichUnit, whichPlayer);
        }

        public static bool IsUnitAlly(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitAlly(whichUnit, whichPlayer);
        }

        public static bool IsUnitEnemy(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitEnemy(whichUnit, whichPlayer);
        }

        public static bool IsUnitVisible(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitVisible(whichUnit, whichPlayer);
        }

        public static bool IsUnitDetected(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitDetected(whichUnit, whichPlayer);
        }

        public static bool IsUnitInvisible(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitInvisible(whichUnit, whichPlayer);
        }

        public static bool IsUnitFogged(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitFogged(whichUnit, whichPlayer);
        }

        public static bool IsUnitMasked(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitMasked(whichUnit, whichPlayer);
        }

        public static bool IsUnitSelected(JassUnit whichUnit, JassPlayer whichPlayer)
        {
            return _IsUnitSelected(whichUnit, whichPlayer);
        }

        public static bool IsUnitRace(JassUnit whichUnit, JassRace whichRace)
        {
            return _IsUnitRace(whichUnit, whichRace);
        }

        public static bool IsUnitType(JassUnit whichUnit, JassUnitType whichUnitType)
        {
            return _IsUnitType(whichUnit, whichUnitType);
        }

        public static bool IsUnit(JassUnit whichUnit, JassUnit whichSpecifiedUnit)
        {
            return _IsUnit(whichUnit, whichSpecifiedUnit);
        }

        public static bool IsUnitInRange(JassUnit whichUnit, JassUnit otherUnit, float distance)
        {
            return _IsUnitInRange(whichUnit, otherUnit, distance);
        }

        public static bool IsUnitInRangeXY(JassUnit whichUnit, float x, float y, float distance)
        {
            return _IsUnitInRangeXY(whichUnit, x, y, distance);
        }

        public static bool IsUnitInRangeLoc(JassUnit whichUnit, JassLocation whichLocation, float distance)
        {
            return _IsUnitInRangeLoc(whichUnit, whichLocation, distance);
        }

        public static bool IsUnitHidden(JassUnit whichUnit)
        {
            return _IsUnitHidden(whichUnit);
        }

        public static bool IsUnitIllusion(JassUnit whichUnit)
        {
            return _IsUnitIllusion(whichUnit);
        }

        public static bool IsUnitInTransport(JassUnit whichUnit, JassUnit whichTransport)
        {
            return _IsUnitInTransport(whichUnit, whichTransport);
        }

        public static bool IsUnitLoaded(JassUnit whichUnit)
        {
            return _IsUnitLoaded(whichUnit);
        }

        public static bool IsHeroUnitId(JassObjectId unitId)
        {
            return _IsHeroUnitId(unitId);
        }

        public static bool IsUnitIdType(JassObjectId unitId, JassUnitType whichUnitType)
        {
            return _IsUnitIdType(unitId, whichUnitType);
        }

        public static void UnitShareVision(JassUnit whichUnit, JassPlayer whichPlayer, bool share)
        {
            _UnitShareVision(whichUnit, whichPlayer, share);
        }

        public static void UnitSuspendDecay(JassUnit whichUnit, bool suspend)
        {
            _UnitSuspendDecay(whichUnit, suspend);
        }

        public static bool UnitAddType(JassUnit whichUnit, JassUnitType whichUnitType)
        {
            return _UnitAddType(whichUnit, whichUnitType);
        }

        public static bool UnitRemoveType(JassUnit whichUnit, JassUnitType whichUnitType)
        {
            return _UnitRemoveType(whichUnit, whichUnitType);
        }

        public static bool UnitAddAbility(JassUnit whichUnit, JassObjectId abilityId)
        {
            return _UnitAddAbility(whichUnit, abilityId);
        }

        public static bool UnitRemoveAbility(JassUnit whichUnit, JassObjectId abilityId)
        {
            return _UnitRemoveAbility(whichUnit, abilityId);
        }

        public static bool UnitMakeAbilityPermanent(JassUnit whichUnit, bool permanent, JassObjectId abilityId)
        {
            return _UnitMakeAbilityPermanent(whichUnit, permanent, abilityId);
        }

        public static void UnitRemoveBuffs(JassUnit whichUnit, bool removePositive, bool removeNegative)
        {
            _UnitRemoveBuffs(whichUnit, removePositive, removeNegative);
        }

        public static void UnitRemoveBuffsEx(JassUnit whichUnit, bool removePositive, bool removeNegative, bool magic, bool physical, bool timedLife, bool aura, bool autoDispel)
        {
            _UnitRemoveBuffsEx(whichUnit, removePositive, removeNegative, magic, physical, timedLife, aura, autoDispel);
        }

        public static bool UnitHasBuffsEx(JassUnit whichUnit, bool removePositive, bool removeNegative, bool magic, bool physical, bool timedLife, bool aura, bool autoDispel)
        {
            return _UnitHasBuffsEx(whichUnit, removePositive, removeNegative, magic, physical, timedLife, aura, autoDispel);
        }

        public static JassInteger UnitCountBuffsEx(JassUnit whichUnit, bool removePositive, bool removeNegative, bool magic, bool physical, bool timedLife, bool aura, bool autoDispel)
        {
            return _UnitCountBuffsEx(whichUnit, removePositive, removeNegative, magic, physical, timedLife, aura, autoDispel);
        }

        public static void UnitAddSleep(JassUnit whichUnit, bool add)
        {
            _UnitAddSleep(whichUnit, add);
        }

        public static bool UnitCanSleep(JassUnit whichUnit)
        {
            return _UnitCanSleep(whichUnit);
        }

        public static void UnitAddSleepPerm(JassUnit whichUnit, bool add)
        {
            _UnitAddSleepPerm(whichUnit, add);
        }

        public static bool UnitCanSleepPerm(JassUnit whichUnit)
        {
            return _UnitCanSleepPerm(whichUnit);
        }

        public static bool UnitIsSleeping(JassUnit whichUnit)
        {
            return _UnitIsSleeping(whichUnit);
        }

        public static void UnitWakeUp(JassUnit whichUnit)
        {
            _UnitWakeUp(whichUnit);
        }

        public static void UnitApplyTimedLife(JassUnit whichUnit, JassInteger buffId, float duration)
        {
            _UnitApplyTimedLife(whichUnit, buffId, duration);
        }

        public static bool UnitIgnoreAlarm(JassUnit whichUnit, bool flag)
        {
            return _UnitIgnoreAlarm(whichUnit, flag);
        }

        public static bool UnitIgnoreAlarmToggled(JassUnit whichUnit)
        {
            return _UnitIgnoreAlarmToggled(whichUnit);
        }

        public static void UnitResetCooldown(JassUnit whichUnit)
        {
            _UnitResetCooldown(whichUnit);
        }

        public static void UnitSetConstructionProgress(JassUnit whichUnit, JassInteger constructionPercentage)
        {
            _UnitSetConstructionProgress(whichUnit, constructionPercentage);
        }

        public static void UnitSetUpgradeProgress(JassUnit whichUnit, JassInteger upgradePercentage)
        {
            _UnitSetUpgradeProgress(whichUnit, upgradePercentage);
        }

        public static void UnitPauseTimedLife(JassUnit whichUnit, bool flag)
        {
            _UnitPauseTimedLife(whichUnit, flag);
        }

        public static void UnitSetUsesAltIcon(JassUnit whichUnit, bool flag)
        {
            _UnitSetUsesAltIcon(whichUnit, flag);
        }

        public static bool UnitDamagePoint(JassUnit whichUnit, float delay, float radius, float x, float y, float amount, bool attack, bool ranged, JassAttackType attackType, JassDamageType damageType, JassWeaponType weaponType)
        {
            return _UnitDamagePoint(whichUnit, delay, radius, x, y, amount, attack, ranged, attackType, damageType, weaponType);
        }

        public static bool UnitDamageTarget(JassUnit whichUnit, JassWidget target, float amount, bool attack, bool ranged, JassAttackType attackType, JassDamageType damageType, JassWeaponType weaponType)
        {
            return _UnitDamageTarget(whichUnit, target, amount, attack, ranged, attackType, damageType, weaponType);
        }

        public static bool IssueImmediateOrder(JassUnit whichUnit, string order)
        {
            return _IssueImmediateOrder(whichUnit, order);
        }

        public static bool IssueImmediateOrderById(JassUnit whichUnit, JassOrder order)
        {
            return _IssueImmediateOrderById(whichUnit, order);
        }

        public static bool IssuePointOrder(JassUnit whichUnit, string order, float x, float y)
        {
            return _IssuePointOrder(whichUnit, order, x, y);
        }

        public static bool IssuePointOrderLoc(JassUnit whichUnit, string order, JassLocation whichLocation)
        {
            return _IssuePointOrderLoc(whichUnit, order, whichLocation);
        }

        public static bool IssuePointOrderById(JassUnit whichUnit, JassOrder order, float x, float y)
        {
            return _IssuePointOrderById(whichUnit, order, x, y);
        }

        public static bool IssuePointOrderByIdLoc(JassUnit whichUnit, JassOrder order, JassLocation whichLocation)
        {
            return _IssuePointOrderByIdLoc(whichUnit, order, whichLocation);
        }

        public static bool IssueTargetOrder(JassUnit whichUnit, string order, JassWidget targetWidget)
        {
            return _IssueTargetOrder(whichUnit, order, targetWidget);
        }

        public static bool IssueTargetOrderById(JassUnit whichUnit, JassOrder order, JassWidget targetWidget)
        {
            return _IssueTargetOrderById(whichUnit, order, targetWidget);
        }

        public static bool IssueInstantPointOrder(JassUnit whichUnit, string order, float x, float y, JassWidget instantTargetWidget)
        {
            return _IssueInstantPointOrder(whichUnit, order, x, y, instantTargetWidget);
        }

        public static bool IssueInstantPointOrderById(JassUnit whichUnit, JassOrder order, float x, float y, JassWidget instantTargetWidget)
        {
            return _IssueInstantPointOrderById(whichUnit, order, x, y, instantTargetWidget);
        }

        public static bool IssueInstantTargetOrder(JassUnit whichUnit, string order, JassWidget targetWidget, JassWidget instantTargetWidget)
        {
            return _IssueInstantTargetOrder(whichUnit, order, targetWidget, instantTargetWidget);
        }

        public static bool IssueInstantTargetOrderById(JassUnit whichUnit, JassOrder order, JassWidget targetWidget, JassWidget instantTargetWidget)
        {
            return _IssueInstantTargetOrderById(whichUnit, order, targetWidget, instantTargetWidget);
        }

        public static bool IssueBuildOrder(JassUnit whichPeon, string unitToBuild, float x, float y)
        {
            return _IssueBuildOrder(whichPeon, unitToBuild, x, y);
        }

        public static bool IssueBuildOrderById(JassUnit whichPeon, JassObjectId unitId, float x, float y)
        {
            return _IssueBuildOrderById(whichPeon, unitId, x, y);
        }

        public static bool IssueNeutralImmediateOrder(JassPlayer forWhichPlayer, JassUnit neutralStructure, string unitToBuild)
        {
            return _IssueNeutralImmediateOrder(forWhichPlayer, neutralStructure, unitToBuild);
        }

        public static bool IssueNeutralImmediateOrderById(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassObjectId unitId)
        {
            return _IssueNeutralImmediateOrderById(forWhichPlayer, neutralStructure, unitId);
        }

        public static bool IssueNeutralPointOrder(JassPlayer forWhichPlayer, JassUnit neutralStructure, string unitToBuild, float x, float y)
        {
            return _IssueNeutralPointOrder(forWhichPlayer, neutralStructure, unitToBuild, x, y);
        }

        public static bool IssueNeutralPointOrderById(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassObjectId unitId, float x, float y)
        {
            return _IssueNeutralPointOrderById(forWhichPlayer, neutralStructure, unitId, x, y);
        }

        public static bool IssueNeutralTargetOrder(JassPlayer forWhichPlayer, JassUnit neutralStructure, string unitToBuild, JassWidget target)
        {
            return _IssueNeutralTargetOrder(forWhichPlayer, neutralStructure, unitToBuild, target);
        }

        public static bool IssueNeutralTargetOrderById(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassObjectId unitId, JassWidget target)
        {
            return _IssueNeutralTargetOrderById(forWhichPlayer, neutralStructure, unitId, target);
        }

        public static JassInteger GetUnitCurrentOrder(JassUnit whichUnit)
        {
            return _GetUnitCurrentOrder(whichUnit);
        }

        public static void SetResourceAmount(JassUnit whichUnit, JassInteger amount)
        {
            _SetResourceAmount(whichUnit, amount);
        }

        public static void AddResourceAmount(JassUnit whichUnit, JassInteger amount)
        {
            _AddResourceAmount(whichUnit, amount);
        }

        public static JassInteger GetResourceAmount(JassUnit whichUnit)
        {
            return _GetResourceAmount(whichUnit);
        }

        public static float WaygateGetDestinationX(JassUnit waygate)
        {
            return _WaygateGetDestinationX(waygate);
        }

        public static float WaygateGetDestinationY(JassUnit waygate)
        {
            return _WaygateGetDestinationY(waygate);
        }

        public static void WaygateSetDestination(JassUnit waygate, float x, float y)
        {
            _WaygateSetDestination(waygate, x, y);
        }

        public static void WaygateActivate(JassUnit waygate, bool activate)
        {
            _WaygateActivate(waygate, activate);
        }

        public static bool WaygateIsActive(JassUnit waygate)
        {
            return _WaygateIsActive(waygate);
        }

        public static void AddItemToAllStock(JassObjectId itemId, JassInteger currentStock, JassInteger stockMax)
        {
            _AddItemToAllStock(itemId, currentStock, stockMax);
        }

        public static void AddItemToStock(JassUnit whichUnit, JassObjectId itemId, JassInteger currentStock, JassInteger stockMax)
        {
            _AddItemToStock(whichUnit, itemId, currentStock, stockMax);
        }

        public static void AddUnitToAllStock(JassObjectId unitId, JassInteger currentStock, JassInteger stockMax)
        {
            _AddUnitToAllStock(unitId, currentStock, stockMax);
        }

        public static void AddUnitToStock(JassUnit whichUnit, JassObjectId unitId, JassInteger currentStock, JassInteger stockMax)
        {
            _AddUnitToStock(whichUnit, unitId, currentStock, stockMax);
        }

        public static void RemoveItemFromAllStock(JassObjectId itemId)
        {
            _RemoveItemFromAllStock(itemId);
        }

        public static void RemoveItemFromStock(JassUnit whichUnit, JassObjectId itemId)
        {
            _RemoveItemFromStock(whichUnit, itemId);
        }

        public static void RemoveUnitFromAllStock(JassObjectId unitId)
        {
            _RemoveUnitFromAllStock(unitId);
        }

        public static void RemoveUnitFromStock(JassUnit whichUnit, JassObjectId unitId)
        {
            _RemoveUnitFromStock(whichUnit, unitId);
        }

        public static void SetAllItemTypeSlots(JassInteger slots)
        {
            _SetAllItemTypeSlots(slots);
        }

        public static void SetAllUnitTypeSlots(JassInteger slots)
        {
            _SetAllUnitTypeSlots(slots);
        }

        public static void SetItemTypeSlots(JassUnit whichUnit, JassInteger slots)
        {
            _SetItemTypeSlots(whichUnit, slots);
        }

        public static void SetUnitTypeSlots(JassUnit whichUnit, JassInteger slots)
        {
            _SetUnitTypeSlots(whichUnit, slots);
        }

        public static JassInteger GetUnitUserData(JassUnit whichUnit)
        {
            return _GetUnitUserData(whichUnit);
        }

        public static void SetUnitUserData(JassUnit whichUnit, JassInteger data)
        {
            _SetUnitUserData(whichUnit, data);
        }

        public static JassPlayer Player(JassInteger number)
        {
            return _Player(number);
        }

        public static JassPlayer GetLocalPlayer()
        {
            return _GetLocalPlayer();
        }

        public static bool IsPlayerAlly(JassPlayer whichPlayer, JassPlayer otherPlayer)
        {
            return _IsPlayerAlly(whichPlayer, otherPlayer);
        }

        public static bool IsPlayerEnemy(JassPlayer whichPlayer, JassPlayer otherPlayer)
        {
            return _IsPlayerEnemy(whichPlayer, otherPlayer);
        }

        public static bool IsPlayerInForce(JassPlayer whichPlayer, JassForce whichForce)
        {
            return _IsPlayerInForce(whichPlayer, whichForce);
        }

        public static bool IsPlayerObserver(JassPlayer whichPlayer)
        {
            return _IsPlayerObserver(whichPlayer);
        }

        public static bool IsVisibleToPlayer(float x, float y, JassPlayer whichPlayer)
        {
            return _IsVisibleToPlayer(x, y, whichPlayer);
        }

        public static bool IsLocationVisibleToPlayer(JassLocation whichLocation, JassPlayer whichPlayer)
        {
            return _IsLocationVisibleToPlayer(whichLocation, whichPlayer);
        }

        public static bool IsFoggedToPlayer(float x, float y, JassPlayer whichPlayer)
        {
            return _IsFoggedToPlayer(x, y, whichPlayer);
        }

        public static bool IsLocationFoggedToPlayer(JassLocation whichLocation, JassPlayer whichPlayer)
        {
            return _IsLocationFoggedToPlayer(whichLocation, whichPlayer);
        }

        public static bool IsMaskedToPlayer(float x, float y, JassPlayer whichPlayer)
        {
            return _IsMaskedToPlayer(x, y, whichPlayer);
        }

        public static bool IsLocationMaskedToPlayer(JassLocation whichLocation, JassPlayer whichPlayer)
        {
            return _IsLocationMaskedToPlayer(whichLocation, whichPlayer);
        }

        public static JassRace GetPlayerRace(JassPlayer whichPlayer)
        {
            return _GetPlayerRace(whichPlayer);
        }

        public static JassInteger GetPlayerId(JassPlayer whichPlayer)
        {
            return _GetPlayerId(whichPlayer);
        }

        public static JassInteger GetPlayerUnitCount(JassPlayer whichPlayer, bool includeIncomplete)
        {
            return _GetPlayerUnitCount(whichPlayer, includeIncomplete);
        }

        public static JassInteger GetPlayerTypedUnitCount(JassPlayer whichPlayer, string unitName, bool includeIncomplete, bool includeUpgrades)
        {
            return _GetPlayerTypedUnitCount(whichPlayer, unitName, includeIncomplete, includeUpgrades);
        }

        public static JassInteger GetPlayerStructureCount(JassPlayer whichPlayer, bool includeIncomplete)
        {
            return _GetPlayerStructureCount(whichPlayer, includeIncomplete);
        }

        public static JassInteger GetPlayerState(JassPlayer whichPlayer, JassPlayerState whichPlayerState)
        {
            return _GetPlayerState(whichPlayer, whichPlayerState);
        }

        public static JassInteger GetPlayerScore(JassPlayer whichPlayer, JassPlayerScore whichPlayerScore)
        {
            return _GetPlayerScore(whichPlayer, whichPlayerScore);
        }

        public static bool GetPlayerAlliance(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassAllianceType whichAllianceSetting)
        {
            return _GetPlayerAlliance(sourcePlayer, otherPlayer, whichAllianceSetting);
        }

        public static float GetPlayerHandicap(JassPlayer whichPlayer)
        {
            return _GetPlayerHandicap(whichPlayer);
        }

        public static float GetPlayerHandicapXP(JassPlayer whichPlayer)
        {
            return _GetPlayerHandicapXP(whichPlayer);
        }

        public static void SetPlayerHandicap(JassPlayer whichPlayer, float handicap)
        {
            _SetPlayerHandicap(whichPlayer, handicap);
        }

        public static void SetPlayerHandicapXP(JassPlayer whichPlayer, float handicap)
        {
            _SetPlayerHandicapXP(whichPlayer, handicap);
        }

        public static void SetPlayerTechMaxAllowed(JassPlayer whichPlayer, JassInteger techid, JassInteger maximum)
        {
            _SetPlayerTechMaxAllowed(whichPlayer, techid, maximum);
        }

        public static JassInteger GetPlayerTechMaxAllowed(JassPlayer whichPlayer, JassInteger techid)
        {
            return _GetPlayerTechMaxAllowed(whichPlayer, techid);
        }

        public static void AddPlayerTechResearched(JassPlayer whichPlayer, JassInteger techid, JassInteger levels)
        {
            _AddPlayerTechResearched(whichPlayer, techid, levels);
        }

        public static void SetPlayerTechResearched(JassPlayer whichPlayer, JassInteger techid, JassInteger setToLevel)
        {
            _SetPlayerTechResearched(whichPlayer, techid, setToLevel);
        }

        public static bool GetPlayerTechResearched(JassPlayer whichPlayer, JassInteger techid, bool specificonly)
        {
            return _GetPlayerTechResearched(whichPlayer, techid, specificonly);
        }

        public static JassInteger GetPlayerTechCount(JassPlayer whichPlayer, JassInteger techid, bool specificonly)
        {
            return _GetPlayerTechCount(whichPlayer, techid, specificonly);
        }

        public static void SetPlayerUnitsOwner(JassPlayer whichPlayer, JassInteger newOwner)
        {
            _SetPlayerUnitsOwner(whichPlayer, newOwner);
        }

        public static void CripplePlayer(JassPlayer whichPlayer, JassForce toWhichPlayers, bool flag)
        {
            _CripplePlayer(whichPlayer, toWhichPlayers, flag);
        }

        public static void SetPlayerAbilityAvailable(JassPlayer whichPlayer, JassObjectId abilid, bool avail)
        {
            _SetPlayerAbilityAvailable(whichPlayer, abilid, avail);
        }

        public static void SetPlayerState(JassPlayer whichPlayer, JassPlayerState whichPlayerState, JassInteger value)
        {
            _SetPlayerState(whichPlayer, whichPlayerState, value);
        }

        public static void RemovePlayer(JassPlayer whichPlayer, JassPlayerGameResult gameResult)
        {
            _RemovePlayer(whichPlayer, gameResult);
        }

        public static void CachePlayerHeroData(JassPlayer whichPlayer)
        {
            _CachePlayerHeroData(whichPlayer);
        }

        public static void SetFogStateRect(JassPlayer forWhichPlayer, JassFogState whichState, JassRect where, bool useSharedVision)
        {
            _SetFogStateRect(forWhichPlayer, whichState, where, useSharedVision);
        }

        public static void SetFogStateRadius(JassPlayer forWhichPlayer, JassFogState whichState, float centerx, float centerY, float radius, bool useSharedVision)
        {
            _SetFogStateRadius(forWhichPlayer, whichState, centerx, centerY, radius, useSharedVision);
        }

        public static void SetFogStateRadiusLoc(JassPlayer forWhichPlayer, JassFogState whichState, JassLocation center, float radius, bool useSharedVision)
        {
            _SetFogStateRadiusLoc(forWhichPlayer, whichState, center, radius, useSharedVision);
        }

        public static void FogMaskEnable(bool enable)
        {
            _FogMaskEnable(enable);
        }

        public static bool IsFogMaskEnabled()
        {
            return _IsFogMaskEnabled();
        }

        public static void FogEnable(bool enable)
        {
            _FogEnable(enable);
        }

        public static bool IsFogEnabled()
        {
            return _IsFogEnabled();
        }

        public static JassFogModifier CreateFogModifierRect(JassPlayer forWhichPlayer, JassFogState whichState, JassRect where, bool useSharedVision, bool afterUnits)
        {
            return _CreateFogModifierRect(forWhichPlayer, whichState, where, useSharedVision, afterUnits);
        }

        public static JassFogModifier CreateFogModifierRadius(JassPlayer forWhichPlayer, JassFogState whichState, float centerx, float centerY, float radius, bool useSharedVision, bool afterUnits)
        {
            return _CreateFogModifierRadius(forWhichPlayer, whichState, centerx, centerY, radius, useSharedVision, afterUnits);
        }

        public static JassFogModifier CreateFogModifierRadiusLoc(JassPlayer forWhichPlayer, JassFogState whichState, JassLocation center, float radius, bool useSharedVision, bool afterUnits)
        {
            return _CreateFogModifierRadiusLoc(forWhichPlayer, whichState, center, radius, useSharedVision, afterUnits);
        }

        public static void DestroyFogModifier(JassFogModifier whichFogModifier)
        {
            _DestroyFogModifier(whichFogModifier);
        }

        public static void FogModifierStart(JassFogModifier whichFogModifier)
        {
            _FogModifierStart(whichFogModifier);
        }

        public static void FogModifierStop(JassFogModifier whichFogModifier)
        {
            _FogModifierStop(whichFogModifier);
        }

        public static JassVersion VersionGet()
        {
            return _VersionGet();
        }

        public static bool VersionCompatible(JassVersion whichVersion)
        {
            return _VersionCompatible(whichVersion);
        }

        public static bool VersionSupported(JassVersion whichVersion)
        {
            return _VersionSupported(whichVersion);
        }

        public static void EndGame(bool doScoreScreen)
        {
            _EndGame(doScoreScreen);
        }

        public static void ChangeLevel(string newLevel, bool doScoreScreen)
        {
            _ChangeLevel(newLevel, doScoreScreen);
        }

        public static void RestartGame(bool doScoreScreen)
        {
            _RestartGame(doScoreScreen);
        }

        public static void ReloadGame()
        {
            _ReloadGame();
        }

        public static void SetCampaignMenuRace(JassRace r)
        {
            _SetCampaignMenuRace(r);
        }

        public static void SetCampaignMenuRaceEx(JassInteger campaignIndex)
        {
            _SetCampaignMenuRaceEx(campaignIndex);
        }

        public static void ForceCampaignSelectScreen()
        {
            _ForceCampaignSelectScreen();
        }

        public static void LoadGame(string saveFileName, bool doScoreScreen)
        {
            _LoadGame(saveFileName, doScoreScreen);
        }

        public static void SaveGame(string saveFileName)
        {
            _SaveGame(saveFileName);
        }

        public static bool RenameSaveDirectory(string sourceDirName, string destDirName)
        {
            return _RenameSaveDirectory(sourceDirName, destDirName);
        }

        public static bool RemoveSaveDirectory(string sourceDirName)
        {
            return _RemoveSaveDirectory(sourceDirName);
        }

        public static bool CopySaveGame(string sourceSaveName, string destSaveName)
        {
            return _CopySaveGame(sourceSaveName, destSaveName);
        }

        public static bool SaveGameExists(string saveName)
        {
            return _SaveGameExists(saveName);
        }

        public static void SyncSelections()
        {
            _SyncSelections();
        }

        public static void SetFloatGameState(JassFGameState whichFloatGameState, float value)
        {
            _SetFloatGameState(whichFloatGameState, value);
        }

        public static float GetFloatGameState(JassFGameState whichFloatGameState)
        {
            return _GetFloatGameState(whichFloatGameState);
        }

        public static void SetIntegerGameState(JassIGameState whichIntegerGameState, JassInteger value)
        {
            _SetIntegerGameState(whichIntegerGameState, value);
        }

        public static JassInteger GetIntegerGameState(JassIGameState whichIntegerGameState)
        {
            return _GetIntegerGameState(whichIntegerGameState);
        }

        public static void SetTutorialCleared(bool cleared)
        {
            _SetTutorialCleared(cleared);
        }

        public static void SetMissionAvailable(JassInteger campaignNumber, JassInteger missionNumber, bool available)
        {
            _SetMissionAvailable(campaignNumber, missionNumber, available);
        }

        public static void SetCampaignAvailable(JassInteger campaignNumber, bool available)
        {
            _SetCampaignAvailable(campaignNumber, available);
        }

        public static void SetOpCinematicAvailable(JassInteger campaignNumber, bool available)
        {
            _SetOpCinematicAvailable(campaignNumber, available);
        }

        public static void SetEdCinematicAvailable(JassInteger campaignNumber, bool available)
        {
            _SetEdCinematicAvailable(campaignNumber, available);
        }

        public static JassGameDifficulty GetDefaultDifficulty()
        {
            return _GetDefaultDifficulty();
        }

        public static void SetDefaultDifficulty(JassGameDifficulty g)
        {
            _SetDefaultDifficulty(g);
        }

        public static void SetCustomCampaignButtonVisible(JassInteger whichButton, bool visible)
        {
            _SetCustomCampaignButtonVisible(whichButton, visible);
        }

        public static bool GetCustomCampaignButtonVisible(JassInteger whichButton)
        {
            return _GetCustomCampaignButtonVisible(whichButton);
        }

        public static void DoNotSaveReplay()
        {
            _DoNotSaveReplay();
        }

        public static JassDialog DialogCreate()
        {
            return _DialogCreate();
        }

        public static void DialogDestroy(JassDialog whichDialog)
        {
            _DialogDestroy(whichDialog);
        }

        public static void DialogClear(JassDialog whichDialog)
        {
            _DialogClear(whichDialog);
        }

        public static void DialogSetMessage(JassDialog whichDialog, string messageText)
        {
            _DialogSetMessage(whichDialog, messageText);
        }

        public static JassButton DialogAddButton(JassDialog whichDialog, string buttonText, JassInteger hotkey)
        {
            return _DialogAddButton(whichDialog, buttonText, hotkey);
        }

        public static JassButton DialogAddQuitButton(JassDialog whichDialog, bool doScoreScreen, string buttonText, JassInteger hotkey)
        {
            return _DialogAddQuitButton(whichDialog, doScoreScreen, buttonText, hotkey);
        }

        public static void DialogDisplay(JassPlayer whichPlayer, JassDialog whichDialog, bool flag)
        {
            _DialogDisplay(whichPlayer, whichDialog, flag);
        }

        public static bool ReloadGameCachesFromDisk()
        {
            return _ReloadGameCachesFromDisk();
        }

        public static JassGameCache InitGameCache(string campaignFile)
        {
            return _InitGameCache(campaignFile);
        }

        public static bool SaveGameCache(JassGameCache whichCache)
        {
            return _SaveGameCache(whichCache);
        }

        public static void StoreInteger(JassGameCache cache, string missionKey, string key, JassInteger value)
        {
            _StoreInteger(cache, missionKey, key, value);
        }

        public static void StoreReal(JassGameCache cache, string missionKey, string key, float value)
        {
            _StoreReal(cache, missionKey, key, value);
        }

        public static void StoreBoolean(JassGameCache cache, string missionKey, string key, bool value)
        {
            _StoreBoolean(cache, missionKey, key, value);
        }

        public static bool StoreUnit(JassGameCache cache, string missionKey, string key, JassUnit whichUnit)
        {
            return _StoreUnit(cache, missionKey, key, whichUnit);
        }

        public static bool StoreString(JassGameCache cache, string missionKey, string key, string value)
        {
            return _StoreString(cache, missionKey, key, value);
        }

        public static void SyncStoredInteger(JassGameCache cache, string missionKey, string key)
        {
            _SyncStoredInteger(cache, missionKey, key);
        }

        public static void SyncStoredReal(JassGameCache cache, string missionKey, string key)
        {
            _SyncStoredReal(cache, missionKey, key);
        }

        public static void SyncStoredBoolean(JassGameCache cache, string missionKey, string key)
        {
            _SyncStoredBoolean(cache, missionKey, key);
        }

        public static void SyncStoredUnit(JassGameCache cache, string missionKey, string key)
        {
            _SyncStoredUnit(cache, missionKey, key);
        }

        public static void SyncStoredString(JassGameCache cache, string missionKey, string key)
        {
            _SyncStoredString(cache, missionKey, key);
        }

        public static bool HaveStoredInteger(JassGameCache cache, string missionKey, string key)
        {
            return _HaveStoredInteger(cache, missionKey, key);
        }

        public static bool HaveStoredReal(JassGameCache cache, string missionKey, string key)
        {
            return _HaveStoredReal(cache, missionKey, key);
        }

        public static bool HaveStoredBoolean(JassGameCache cache, string missionKey, string key)
        {
            return _HaveStoredBoolean(cache, missionKey, key);
        }

        public static bool HaveStoredUnit(JassGameCache cache, string missionKey, string key)
        {
            return _HaveStoredUnit(cache, missionKey, key);
        }

        public static bool HaveStoredString(JassGameCache cache, string missionKey, string key)
        {
            return _HaveStoredString(cache, missionKey, key);
        }

        public static void FlushGameCache(JassGameCache cache)
        {
            _FlushGameCache(cache);
        }

        public static void FlushStoredMission(JassGameCache cache, string missionKey)
        {
            _FlushStoredMission(cache, missionKey);
        }

        public static void FlushStoredInteger(JassGameCache cache, string missionKey, string key)
        {
            _FlushStoredInteger(cache, missionKey, key);
        }

        public static void FlushStoredReal(JassGameCache cache, string missionKey, string key)
        {
            _FlushStoredReal(cache, missionKey, key);
        }

        public static void FlushStoredBoolean(JassGameCache cache, string missionKey, string key)
        {
            _FlushStoredBoolean(cache, missionKey, key);
        }

        public static void FlushStoredUnit(JassGameCache cache, string missionKey, string key)
        {
            _FlushStoredUnit(cache, missionKey, key);
        }

        public static void FlushStoredString(JassGameCache cache, string missionKey, string key)
        {
            _FlushStoredString(cache, missionKey, key);
        }

        public static JassInteger GetStoredInteger(JassGameCache cache, string missionKey, string key)
        {
            return _GetStoredInteger(cache, missionKey, key);
        }

        public static float GetStoredReal(JassGameCache cache, string missionKey, string key)
        {
            return _GetStoredReal(cache, missionKey, key);
        }

        public static bool GetStoredBoolean(JassGameCache cache, string missionKey, string key)
        {
            return _GetStoredBoolean(cache, missionKey, key);
        }

        public static string GetStoredString(JassGameCache cache, string missionKey, string key)
        {
            return _GetStoredString(cache, missionKey, key);
        }

        public static JassUnit RestoreUnit(JassGameCache cache, string missionKey, string key, JassPlayer forWhichPlayer, float x, float y, float facing)
        {
            return _RestoreUnit(cache, missionKey, key, forWhichPlayer, x, y, facing);
        }

        public static JassHashTable InitHashtable()
        {
            return _InitHashtable();
        }

        public static void SaveInteger(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassInteger value)
        {
            _SaveInteger(table, parentKey, childKey, value);
        }

        public static void SaveReal(JassHashTable table, JassInteger parentKey, JassInteger childKey, float value)
        {
            _SaveReal(table, parentKey, childKey, value);
        }

        public static void SaveBoolean(JassHashTable table, JassInteger parentKey, JassInteger childKey, bool value)
        {
            _SaveBoolean(table, parentKey, childKey, value);
        }

        public static bool SaveStr(JassHashTable table, JassInteger parentKey, JassInteger childKey, string value)
        {
            return _SaveStr(table, parentKey, childKey, value);
        }

        public static bool SavePlayerHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassPlayer whichPlayer)
        {
            return _SavePlayerHandle(table, parentKey, childKey, whichPlayer);
        }

        public static bool SaveWidgetHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassWidget whichWidget)
        {
            return _SaveWidgetHandle(table, parentKey, childKey, whichWidget);
        }

        public static bool SaveDestructableHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassDestructable whichDestructable)
        {
            return _SaveDestructableHandle(table, parentKey, childKey, whichDestructable);
        }

        public static bool SaveItemHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassItem whichItem)
        {
            return _SaveItemHandle(table, parentKey, childKey, whichItem);
        }

        public static bool SaveUnitHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassUnit whichUnit)
        {
            return _SaveUnitHandle(table, parentKey, childKey, whichUnit);
        }

        public static bool SaveAbilityHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassAbility whichAbility)
        {
            return _SaveAbilityHandle(table, parentKey, childKey, whichAbility);
        }

        public static bool SaveTimerHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTimer whichTimer)
        {
            return _SaveTimerHandle(table, parentKey, childKey, whichTimer);
        }

        public static bool SaveTriggerHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTrigger whichTrigger)
        {
            return _SaveTriggerHandle(table, parentKey, childKey, whichTrigger);
        }

        public static bool SaveTriggerConditionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTriggerCondition whichTriggercondition)
        {
            return _SaveTriggerConditionHandle(table, parentKey, childKey, whichTriggercondition);
        }

        public static bool SaveTriggerActionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTriggerAction whichTriggeraction)
        {
            return _SaveTriggerActionHandle(table, parentKey, childKey, whichTriggeraction);
        }

        public static bool SaveTriggerEventHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassEvent whichEvent)
        {
            return _SaveTriggerEventHandle(table, parentKey, childKey, whichEvent);
        }

        public static bool SaveForceHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassForce whichForce)
        {
            return _SaveForceHandle(table, parentKey, childKey, whichForce);
        }

        public static bool SaveGroupHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassGroup whichGroup)
        {
            return _SaveGroupHandle(table, parentKey, childKey, whichGroup);
        }

        public static bool SaveLocationHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassLocation whichLocation)
        {
            return _SaveLocationHandle(table, parentKey, childKey, whichLocation);
        }

        public static bool SaveRectHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassRect whichRect)
        {
            return _SaveRectHandle(table, parentKey, childKey, whichRect);
        }

        public static bool SaveBooleanExprHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassBooleanExpression whichBoolexpr)
        {
            return _SaveBooleanExprHandle(table, parentKey, childKey, whichBoolexpr);
        }

        public static bool SaveSoundHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassSound whichSound)
        {
            return _SaveSoundHandle(table, parentKey, childKey, whichSound);
        }

        public static bool SaveEffectHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassEffect whichEffect)
        {
            return _SaveEffectHandle(table, parentKey, childKey, whichEffect);
        }

        public static bool SaveUnitPoolHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassUnitPool whichUnitpool)
        {
            return _SaveUnitPoolHandle(table, parentKey, childKey, whichUnitpool);
        }

        public static bool SaveItemPoolHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassItemPool whichItempool)
        {
            return _SaveItemPoolHandle(table, parentKey, childKey, whichItempool);
        }

        public static bool SaveQuestHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassQuest whichQuest)
        {
            return _SaveQuestHandle(table, parentKey, childKey, whichQuest);
        }

        public static bool SaveQuestItemHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassQuestItem whichQuestitem)
        {
            return _SaveQuestItemHandle(table, parentKey, childKey, whichQuestitem);
        }

        public static bool SaveDefeatConditionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassDefeatCondition whichDefeatcondition)
        {
            return _SaveDefeatConditionHandle(table, parentKey, childKey, whichDefeatcondition);
        }

        public static bool SaveTimerDialogHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTimerDialog whichTimerdialog)
        {
            return _SaveTimerDialogHandle(table, parentKey, childKey, whichTimerdialog);
        }

        public static bool SaveLeaderboardHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassLeaderboard whichLeaderboard)
        {
            return _SaveLeaderboardHandle(table, parentKey, childKey, whichLeaderboard);
        }

        public static bool SaveMultiboardHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassMultiboard whichMultiboard)
        {
            return _SaveMultiboardHandle(table, parentKey, childKey, whichMultiboard);
        }

        public static bool SaveMultiboardItemHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassMultiboardItem whichMultiboarditem)
        {
            return _SaveMultiboardItemHandle(table, parentKey, childKey, whichMultiboarditem);
        }

        public static bool SaveTrackableHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTrackable whichTrackable)
        {
            return _SaveTrackableHandle(table, parentKey, childKey, whichTrackable);
        }

        public static bool SaveDialogHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassDialog whichDialog)
        {
            return _SaveDialogHandle(table, parentKey, childKey, whichDialog);
        }

        public static bool SaveButtonHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassButton whichButton)
        {
            return _SaveButtonHandle(table, parentKey, childKey, whichButton);
        }

        public static bool SaveTextTagHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTextTag whichTexttag)
        {
            return _SaveTextTagHandle(table, parentKey, childKey, whichTexttag);
        }

        public static bool SaveLightningHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassLightning whichLightning)
        {
            return _SaveLightningHandle(table, parentKey, childKey, whichLightning);
        }

        public static bool SaveImageHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassImage whichImage)
        {
            return _SaveImageHandle(table, parentKey, childKey, whichImage);
        }

        public static bool SaveUbersplatHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassUberSplat whichUbersplat)
        {
            return _SaveUbersplatHandle(table, parentKey, childKey, whichUbersplat);
        }

        public static bool SaveRegionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassRegion whichRegion)
        {
            return _SaveRegionHandle(table, parentKey, childKey, whichRegion);
        }

        public static bool SaveFogStateHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassFogState whichFogState)
        {
            return _SaveFogStateHandle(table, parentKey, childKey, whichFogState);
        }

        public static bool SaveFogModifierHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassFogModifier whichFogModifier)
        {
            return _SaveFogModifierHandle(table, parentKey, childKey, whichFogModifier);
        }

        public static bool SaveAgentHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassAgent whichAgent)
        {
            return _SaveAgentHandle(table, parentKey, childKey, whichAgent);
        }

        public static bool SaveHashtableHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassHashTable whichHashtable)
        {
            return _SaveHashtableHandle(table, parentKey, childKey, whichHashtable);
        }

        public static JassInteger LoadInteger(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadInteger(table, parentKey, childKey);
        }

        public static float LoadReal(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadReal(table, parentKey, childKey);
        }

        public static bool LoadBoolean(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadBoolean(table, parentKey, childKey);
        }

        public static string LoadStr(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadStr(table, parentKey, childKey);
        }

        public static JassPlayer LoadPlayerHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadPlayerHandle(table, parentKey, childKey);
        }

        public static JassWidget LoadWidgetHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadWidgetHandle(table, parentKey, childKey);
        }

        public static JassDestructable LoadDestructableHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadDestructableHandle(table, parentKey, childKey);
        }

        public static JassItem LoadItemHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadItemHandle(table, parentKey, childKey);
        }

        public static JassUnit LoadUnitHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadUnitHandle(table, parentKey, childKey);
        }

        public static JassAbility LoadAbilityHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadAbilityHandle(table, parentKey, childKey);
        }

        public static JassTimer LoadTimerHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTimerHandle(table, parentKey, childKey);
        }

        public static JassTrigger LoadTriggerHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTriggerHandle(table, parentKey, childKey);
        }

        public static JassTriggerCondition LoadTriggerConditionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTriggerConditionHandle(table, parentKey, childKey);
        }

        public static JassTriggerAction LoadTriggerActionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTriggerActionHandle(table, parentKey, childKey);
        }

        public static JassEvent LoadTriggerEventHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTriggerEventHandle(table, parentKey, childKey);
        }

        public static JassForce LoadForceHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadForceHandle(table, parentKey, childKey);
        }

        public static JassGroup LoadGroupHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadGroupHandle(table, parentKey, childKey);
        }

        public static JassLocation LoadLocationHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadLocationHandle(table, parentKey, childKey);
        }

        public static JassRect LoadRectHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadRectHandle(table, parentKey, childKey);
        }

        public static JassBooleanExpression LoadBooleanExprHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadBooleanExprHandle(table, parentKey, childKey);
        }

        public static JassSound LoadSoundHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadSoundHandle(table, parentKey, childKey);
        }

        public static JassEffect LoadEffectHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadEffectHandle(table, parentKey, childKey);
        }

        public static JassUnitPool LoadUnitPoolHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadUnitPoolHandle(table, parentKey, childKey);
        }

        public static JassItemPool LoadItemPoolHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadItemPoolHandle(table, parentKey, childKey);
        }

        public static JassQuest LoadQuestHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadQuestHandle(table, parentKey, childKey);
        }

        public static JassQuestItem LoadQuestItemHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadQuestItemHandle(table, parentKey, childKey);
        }

        public static JassDefeatCondition LoadDefeatConditionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadDefeatConditionHandle(table, parentKey, childKey);
        }

        public static JassTimerDialog LoadTimerDialogHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTimerDialogHandle(table, parentKey, childKey);
        }

        public static JassLeaderboard LoadLeaderboardHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadLeaderboardHandle(table, parentKey, childKey);
        }

        public static JassMultiboard LoadMultiboardHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadMultiboardHandle(table, parentKey, childKey);
        }

        public static JassMultiboardItem LoadMultiboardItemHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadMultiboardItemHandle(table, parentKey, childKey);
        }

        public static JassTrackable LoadTrackableHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTrackableHandle(table, parentKey, childKey);
        }

        public static JassDialog LoadDialogHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadDialogHandle(table, parentKey, childKey);
        }

        public static JassButton LoadButtonHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadButtonHandle(table, parentKey, childKey);
        }

        public static JassTextTag LoadTextTagHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadTextTagHandle(table, parentKey, childKey);
        }

        public static JassLightning LoadLightningHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadLightningHandle(table, parentKey, childKey);
        }

        public static JassImage LoadImageHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadImageHandle(table, parentKey, childKey);
        }

        public static JassUberSplat LoadUbersplatHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadUbersplatHandle(table, parentKey, childKey);
        }

        public static JassRegion LoadRegionHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadRegionHandle(table, parentKey, childKey);
        }

        public static JassFogState LoadFogStateHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadFogStateHandle(table, parentKey, childKey);
        }

        public static JassFogModifier LoadFogModifierHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadFogModifierHandle(table, parentKey, childKey);
        }

        public static JassHashTable LoadHashtableHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _LoadHashtableHandle(table, parentKey, childKey);
        }

        public static bool HaveSavedInteger(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _HaveSavedInteger(table, parentKey, childKey);
        }

        public static bool HaveSavedReal(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _HaveSavedReal(table, parentKey, childKey);
        }

        public static bool HaveSavedBoolean(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _HaveSavedBoolean(table, parentKey, childKey);
        }

        public static bool HaveSavedString(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _HaveSavedString(table, parentKey, childKey);
        }

        public static bool HaveSavedHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            return _HaveSavedHandle(table, parentKey, childKey);
        }

        public static void RemoveSavedInteger(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            _RemoveSavedInteger(table, parentKey, childKey);
        }

        public static void RemoveSavedReal(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            _RemoveSavedReal(table, parentKey, childKey);
        }

        public static void RemoveSavedBoolean(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            _RemoveSavedBoolean(table, parentKey, childKey);
        }

        public static void RemoveSavedString(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            _RemoveSavedString(table, parentKey, childKey);
        }

        public static void RemoveSavedHandle(JassHashTable table, JassInteger parentKey, JassInteger childKey)
        {
            _RemoveSavedHandle(table, parentKey, childKey);
        }

        public static void FlushParentHashtable(JassHashTable table)
        {
            _FlushParentHashtable(table);
        }

        public static void FlushChildHashtable(JassHashTable table, JassInteger parentKey)
        {
            _FlushChildHashtable(table, parentKey);
        }

        public static JassInteger GetRandomInt(JassInteger lowBound, JassInteger highBound)
        {
            return _GetRandomInt(lowBound, highBound);
        }

        public static float GetRandomReal(float lowBound, float highBound)
        {
            return _GetRandomReal(lowBound, highBound);
        }

        public static JassUnitPool CreateUnitPool()
        {
            return _CreateUnitPool();
        }

        public static void DestroyUnitPool(JassUnitPool whichPool)
        {
            _DestroyUnitPool(whichPool);
        }

        public static void UnitPoolAddUnitType(JassUnitPool whichPool, JassObjectId unitId, float weight)
        {
            _UnitPoolAddUnitType(whichPool, unitId, weight);
        }

        public static void UnitPoolRemoveUnitType(JassUnitPool whichPool, JassObjectId unitId)
        {
            _UnitPoolRemoveUnitType(whichPool, unitId);
        }

        public static JassUnit PlaceRandomUnit(JassUnitPool whichPool, JassPlayer forWhichPlayer, float x, float y, float facing)
        {
            return _PlaceRandomUnit(whichPool, forWhichPlayer, x, y, facing);
        }

        public static JassItemPool CreateItemPool()
        {
            return _CreateItemPool();
        }

        public static void DestroyItemPool(JassItemPool whichItemPool)
        {
            _DestroyItemPool(whichItemPool);
        }

        public static void ItemPoolAddItemType(JassItemPool whichItemPool, JassObjectId itemId, float weight)
        {
            _ItemPoolAddItemType(whichItemPool, itemId, weight);
        }

        public static void ItemPoolRemoveItemType(JassItemPool whichItemPool, JassObjectId itemId)
        {
            _ItemPoolRemoveItemType(whichItemPool, itemId);
        }

        public static JassItem PlaceRandomItem(JassItemPool whichItemPool, float x, float y)
        {
            return _PlaceRandomItem(whichItemPool, x, y);
        }

        public static JassInteger ChooseRandomCreep(JassInteger level)
        {
            return _ChooseRandomCreep(level);
        }

        public static JassInteger ChooseRandomNPBuilding()
        {
            return _ChooseRandomNPBuilding();
        }

        public static JassInteger ChooseRandomItem(JassInteger level)
        {
            return _ChooseRandomItem(level);
        }

        public static JassInteger ChooseRandomItemEx(JassItemType whichType, JassInteger level)
        {
            return _ChooseRandomItemEx(whichType, level);
        }

        public static void SetRandomSeed(JassInteger seed)
        {
            _SetRandomSeed(seed);
        }

        public static void SetTerrainFog(float a, float b, float c, float d, float e)
        {
            _SetTerrainFog(a, b, c, d, e);
        }

        public static void ResetTerrainFog()
        {
            _ResetTerrainFog();
        }

        public static void SetUnitFog(float a, float b, float c, float d, float e)
        {
            _SetUnitFog(a, b, c, d, e);
        }

        public static void SetTerrainFogEx(JassInteger style, float zstart, float zend, float density, float red, float green, float blue)
        {
            _SetTerrainFogEx(style, zstart, zend, density, red, green, blue);
        }

        public static void DisplayTextToPlayer(JassPlayer toPlayer, float x, float y, string message)
        {
            _DisplayTextToPlayer(toPlayer, x, y, message);
        }

        public static void DisplayTimedTextToPlayer(JassPlayer toPlayer, float x, float y, float duration, string message)
        {
            _DisplayTimedTextToPlayer(toPlayer, x, y, duration, message);
        }

        public static void DisplayTimedTextFromPlayer(JassPlayer toPlayer, float x, float y, float duration, string message)
        {
            _DisplayTimedTextFromPlayer(toPlayer, x, y, duration, message);
        }

        public static void ClearTextMessages()
        {
            _ClearTextMessages();
        }

        public static void SetDayNightModels(string terrainDNCFile, string unitDNCFile)
        {
            _SetDayNightModels(terrainDNCFile, unitDNCFile);
        }

        public static void SetSkyModel(string skyModelFile)
        {
            _SetSkyModel(skyModelFile);
        }

        public static void EnableUserControl(bool b)
        {
            _EnableUserControl(b);
        }

        public static void EnableUserUI(bool b)
        {
            _EnableUserUI(b);
        }

        public static void SuspendTimeOfDay(bool b)
        {
            _SuspendTimeOfDay(b);
        }

        public static void SetTimeOfDayScale(float r)
        {
            _SetTimeOfDayScale(r);
        }

        public static float GetTimeOfDayScale()
        {
            return _GetTimeOfDayScale();
        }

        public static void ShowInterface(bool flag, float fadeDuration)
        {
            _ShowInterface(flag, fadeDuration);
        }

        public static void PauseGame(bool flag)
        {
            _PauseGame(flag);
        }

        public static void UnitAddIndicator(JassUnit whichUnit, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _UnitAddIndicator(whichUnit, red, green, blue, alpha);
        }

        public static void AddIndicator(JassWidget whichWidget, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _AddIndicator(whichWidget, red, green, blue, alpha);
        }

        public static void PingMinimap(float x, float y, float duration)
        {
            _PingMinimap(x, y, duration);
        }

        public static void PingMinimapEx(float x, float y, float duration, JassInteger red, JassInteger green, JassInteger blue, bool extraEffects)
        {
            _PingMinimapEx(x, y, duration, red, green, blue, extraEffects);
        }

        public static void EnableOcclusion(bool flag)
        {
            _EnableOcclusion(flag);
        }

        public static void SetIntroShotText(string introText)
        {
            _SetIntroShotText(introText);
        }

        public static void SetIntroShotModel(string introModelPath)
        {
            _SetIntroShotModel(introModelPath);
        }

        public static void EnableWorldFogBoundary(bool b)
        {
            _EnableWorldFogBoundary(b);
        }

        public static void PlayModelCinematic(string modelName)
        {
            _PlayModelCinematic(modelName);
        }

        public static void PlayCinematic(string movieName)
        {
            _PlayCinematic(movieName);
        }

        public static void ForceUIKey(string key)
        {
            _ForceUIKey(key);
        }

        public static void ForceUICancel()
        {
            _ForceUICancel();
        }

        public static void DisplayLoadDialog()
        {
            _DisplayLoadDialog();
        }

        public static void SetAltMinimapIcon(string iconPath)
        {
            _SetAltMinimapIcon(iconPath);
        }

        public static void DisableRestartMission(bool flag)
        {
            _DisableRestartMission(flag);
        }

        public static JassTextTag CreateTextTag()
        {
            return _CreateTextTag();
        }

        public static void DestroyTextTag(JassTextTag t)
        {
            _DestroyTextTag(t);
        }

        public static void SetTextTagText(JassTextTag t, string s, float height)
        {
            _SetTextTagText(t, s, height);
        }

        public static void SetTextTagPos(JassTextTag t, float x, float y, float heightOffset)
        {
            _SetTextTagPos(t, x, y, heightOffset);
        }

        public static void SetTextTagPosUnit(JassTextTag t, JassUnit whichUnit, float heightOffset)
        {
            _SetTextTagPosUnit(t, whichUnit, heightOffset);
        }

        public static void SetTextTagColor(JassTextTag t, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _SetTextTagColor(t, red, green, blue, alpha);
        }

        public static void SetTextTagVelocity(JassTextTag t, float xvel, float yvel)
        {
            _SetTextTagVelocity(t, xvel, yvel);
        }

        public static void SetTextTagVisibility(JassTextTag t, bool flag)
        {
            _SetTextTagVisibility(t, flag);
        }

        public static void SetTextTagSuspended(JassTextTag t, bool flag)
        {
            _SetTextTagSuspended(t, flag);
        }

        public static void SetTextTagPermanent(JassTextTag t, bool flag)
        {
            _SetTextTagPermanent(t, flag);
        }

        public static void SetTextTagAge(JassTextTag t, float age)
        {
            _SetTextTagAge(t, age);
        }

        public static void SetTextTagLifespan(JassTextTag t, float lifespan)
        {
            _SetTextTagLifespan(t, lifespan);
        }

        public static void SetTextTagFadepoint(JassTextTag t, float fadepoint)
        {
            _SetTextTagFadepoint(t, fadepoint);
        }

        public static void SetReservedLocalHeroButtons(JassInteger reserved)
        {
            _SetReservedLocalHeroButtons(reserved);
        }

        public static JassInteger GetAllyColorFilterState()
        {
            return _GetAllyColorFilterState();
        }

        public static void SetAllyColorFilterState(JassInteger state)
        {
            _SetAllyColorFilterState(state);
        }

        public static bool GetCreepCampFilterState()
        {
            return _GetCreepCampFilterState();
        }

        public static void SetCreepCampFilterState(bool state)
        {
            _SetCreepCampFilterState(state);
        }

        public static void EnableMinimapFilterButtons(bool enableAlly, bool enableCreep)
        {
            _EnableMinimapFilterButtons(enableAlly, enableCreep);
        }

        public static void EnableDragSelect(bool state, bool ui)
        {
            _EnableDragSelect(state, ui);
        }

        public static void EnablePreSelect(bool state, bool ui)
        {
            _EnablePreSelect(state, ui);
        }

        public static void EnableSelect(bool state, bool ui)
        {
            _EnableSelect(state, ui);
        }

        public static JassTrackable CreateTrackable(string trackableModelPath, float x, float y, float facing)
        {
            return _CreateTrackable(trackableModelPath, x, y, facing);
        }

        public static JassQuest CreateQuest()
        {
            return _CreateQuest();
        }

        public static void DestroyQuest(JassQuest whichQuest)
        {
            _DestroyQuest(whichQuest);
        }

        public static void QuestSetTitle(JassQuest whichQuest, string title)
        {
            _QuestSetTitle(whichQuest, title);
        }

        public static void QuestSetDescription(JassQuest whichQuest, string description)
        {
            _QuestSetDescription(whichQuest, description);
        }

        public static void QuestSetIconPath(JassQuest whichQuest, string iconPath)
        {
            _QuestSetIconPath(whichQuest, iconPath);
        }

        public static void QuestSetRequired(JassQuest whichQuest, bool required)
        {
            _QuestSetRequired(whichQuest, required);
        }

        public static void QuestSetCompleted(JassQuest whichQuest, bool completed)
        {
            _QuestSetCompleted(whichQuest, completed);
        }

        public static void QuestSetDiscovered(JassQuest whichQuest, bool discovered)
        {
            _QuestSetDiscovered(whichQuest, discovered);
        }

        public static void QuestSetFailed(JassQuest whichQuest, bool failed)
        {
            _QuestSetFailed(whichQuest, failed);
        }

        public static void QuestSetEnabled(JassQuest whichQuest, bool enabled)
        {
            _QuestSetEnabled(whichQuest, enabled);
        }

        public static bool IsQuestRequired(JassQuest whichQuest)
        {
            return _IsQuestRequired(whichQuest);
        }

        public static bool IsQuestCompleted(JassQuest whichQuest)
        {
            return _IsQuestCompleted(whichQuest);
        }

        public static bool IsQuestDiscovered(JassQuest whichQuest)
        {
            return _IsQuestDiscovered(whichQuest);
        }

        public static bool IsQuestFailed(JassQuest whichQuest)
        {
            return _IsQuestFailed(whichQuest);
        }

        public static bool IsQuestEnabled(JassQuest whichQuest)
        {
            return _IsQuestEnabled(whichQuest);
        }

        public static JassQuestItem QuestCreateItem(JassQuest whichQuest)
        {
            return _QuestCreateItem(whichQuest);
        }

        public static void QuestItemSetDescription(JassQuestItem whichQuestItem, string description)
        {
            _QuestItemSetDescription(whichQuestItem, description);
        }

        public static void QuestItemSetCompleted(JassQuestItem whichQuestItem, bool completed)
        {
            _QuestItemSetCompleted(whichQuestItem, completed);
        }

        public static bool IsQuestItemCompleted(JassQuestItem whichQuestItem)
        {
            return _IsQuestItemCompleted(whichQuestItem);
        }

        public static JassDefeatCondition CreateDefeatCondition()
        {
            return _CreateDefeatCondition();
        }

        public static void DestroyDefeatCondition(JassDefeatCondition whichCondition)
        {
            _DestroyDefeatCondition(whichCondition);
        }

        public static void DefeatConditionSetDescription(JassDefeatCondition whichCondition, string description)
        {
            _DefeatConditionSetDescription(whichCondition, description);
        }

        public static void FlashQuestDialogButton()
        {
            _FlashQuestDialogButton();
        }

        public static void ForceQuestDialogUpdate()
        {
            _ForceQuestDialogUpdate();
        }

        public static JassTimerDialog CreateTimerDialog(JassTimer t)
        {
            return _CreateTimerDialog(t);
        }

        public static void DestroyTimerDialog(JassTimerDialog whichDialog)
        {
            _DestroyTimerDialog(whichDialog);
        }

        public static void TimerDialogSetTitle(JassTimerDialog whichDialog, string title)
        {
            _TimerDialogSetTitle(whichDialog, title);
        }

        public static void TimerDialogSetTitleColor(JassTimerDialog whichDialog, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _TimerDialogSetTitleColor(whichDialog, red, green, blue, alpha);
        }

        public static void TimerDialogSetTimeColor(JassTimerDialog whichDialog, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _TimerDialogSetTimeColor(whichDialog, red, green, blue, alpha);
        }

        public static void TimerDialogSetSpeed(JassTimerDialog whichDialog, float speedMultFactor)
        {
            _TimerDialogSetSpeed(whichDialog, speedMultFactor);
        }

        public static void TimerDialogDisplay(JassTimerDialog whichDialog, bool display)
        {
            _TimerDialogDisplay(whichDialog, display);
        }

        public static bool IsTimerDialogDisplayed(JassTimerDialog whichDialog)
        {
            return _IsTimerDialogDisplayed(whichDialog);
        }

        public static void TimerDialogSetRealTimeRemaining(JassTimerDialog whichDialog, float timeRemaining)
        {
            _TimerDialogSetRealTimeRemaining(whichDialog, timeRemaining);
        }

        public static JassLeaderboard CreateLeaderboard()
        {
            return _CreateLeaderboard();
        }

        public static void DestroyLeaderboard(JassLeaderboard lb)
        {
            _DestroyLeaderboard(lb);
        }

        public static void LeaderboardDisplay(JassLeaderboard lb, bool show)
        {
            _LeaderboardDisplay(lb, show);
        }

        public static bool IsLeaderboardDisplayed(JassLeaderboard lb)
        {
            return _IsLeaderboardDisplayed(lb);
        }

        public static JassInteger LeaderboardGetItemCount(JassLeaderboard lb)
        {
            return _LeaderboardGetItemCount(lb);
        }

        public static void LeaderboardSetSizeByItemCount(JassLeaderboard lb, JassInteger count)
        {
            _LeaderboardSetSizeByItemCount(lb, count);
        }

        public static void LeaderboardAddItem(JassLeaderboard lb, string label, JassInteger value, JassPlayer p)
        {
            _LeaderboardAddItem(lb, label, value, p);
        }

        public static void LeaderboardRemoveItem(JassLeaderboard lb, JassInteger index)
        {
            _LeaderboardRemoveItem(lb, index);
        }

        public static void LeaderboardRemovePlayerItem(JassLeaderboard lb, JassPlayer p)
        {
            _LeaderboardRemovePlayerItem(lb, p);
        }

        public static void LeaderboardClear(JassLeaderboard lb)
        {
            _LeaderboardClear(lb);
        }

        public static void LeaderboardSortItemsByValue(JassLeaderboard lb, bool ascending)
        {
            _LeaderboardSortItemsByValue(lb, ascending);
        }

        public static void LeaderboardSortItemsByPlayer(JassLeaderboard lb, bool ascending)
        {
            _LeaderboardSortItemsByPlayer(lb, ascending);
        }

        public static void LeaderboardSortItemsByLabel(JassLeaderboard lb, bool ascending)
        {
            _LeaderboardSortItemsByLabel(lb, ascending);
        }

        public static bool LeaderboardHasPlayerItem(JassLeaderboard lb, JassPlayer p)
        {
            return _LeaderboardHasPlayerItem(lb, p);
        }

        public static JassInteger LeaderboardGetPlayerIndex(JassLeaderboard lb, JassPlayer p)
        {
            return _LeaderboardGetPlayerIndex(lb, p);
        }

        public static void LeaderboardSetLabel(JassLeaderboard lb, string label)
        {
            _LeaderboardSetLabel(lb, label);
        }

        public static string LeaderboardGetLabelText(JassLeaderboard lb)
        {
            return _LeaderboardGetLabelText(lb);
        }

        public static void PlayerSetLeaderboard(JassPlayer toPlayer, JassLeaderboard lb)
        {
            _PlayerSetLeaderboard(toPlayer, lb);
        }

        public static JassLeaderboard PlayerGetLeaderboard(JassPlayer toPlayer)
        {
            return _PlayerGetLeaderboard(toPlayer);
        }

        public static void LeaderboardSetLabelColor(JassLeaderboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _LeaderboardSetLabelColor(lb, red, green, blue, alpha);
        }

        public static void LeaderboardSetValueColor(JassLeaderboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _LeaderboardSetValueColor(lb, red, green, blue, alpha);
        }

        public static void LeaderboardSetStyle(JassLeaderboard lb, bool showLabel, bool showNames, bool showValues, bool showIcons)
        {
            _LeaderboardSetStyle(lb, showLabel, showNames, showValues, showIcons);
        }

        public static void LeaderboardSetItemValue(JassLeaderboard lb, JassInteger whichItem, JassInteger val)
        {
            _LeaderboardSetItemValue(lb, whichItem, val);
        }

        public static void LeaderboardSetItemLabel(JassLeaderboard lb, JassInteger whichItem, string val)
        {
            _LeaderboardSetItemLabel(lb, whichItem, val);
        }

        public static void LeaderboardSetItemStyle(JassLeaderboard lb, JassInteger whichItem, bool showLabel, bool showValue, bool showIcon)
        {
            _LeaderboardSetItemStyle(lb, whichItem, showLabel, showValue, showIcon);
        }

        public static void LeaderboardSetItemLabelColor(JassLeaderboard lb, JassInteger whichItem, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _LeaderboardSetItemLabelColor(lb, whichItem, red, green, blue, alpha);
        }

        public static void LeaderboardSetItemValueColor(JassLeaderboard lb, JassInteger whichItem, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _LeaderboardSetItemValueColor(lb, whichItem, red, green, blue, alpha);
        }

        public static JassMultiboard CreateMultiboard()
        {
            return _CreateMultiboard();
        }

        public static void DestroyMultiboard(JassMultiboard lb)
        {
            _DestroyMultiboard(lb);
        }

        public static void MultiboardDisplay(JassMultiboard lb, bool show)
        {
            _MultiboardDisplay(lb, show);
        }

        public static bool IsMultiboardDisplayed(JassMultiboard lb)
        {
            return _IsMultiboardDisplayed(lb);
        }

        public static void MultiboardMinimize(JassMultiboard lb, bool minimize)
        {
            _MultiboardMinimize(lb, minimize);
        }

        public static bool IsMultiboardMinimized(JassMultiboard lb)
        {
            return _IsMultiboardMinimized(lb);
        }

        public static void MultiboardClear(JassMultiboard lb)
        {
            _MultiboardClear(lb);
        }

        public static void MultiboardSetTitleText(JassMultiboard lb, string label)
        {
            _MultiboardSetTitleText(lb, label);
        }

        public static string MultiboardGetTitleText(JassMultiboard lb)
        {
            return _MultiboardGetTitleText(lb);
        }

        public static void MultiboardSetTitleTextColor(JassMultiboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _MultiboardSetTitleTextColor(lb, red, green, blue, alpha);
        }

        public static JassInteger MultiboardGetRowCount(JassMultiboard lb)
        {
            return _MultiboardGetRowCount(lb);
        }

        public static JassInteger MultiboardGetColumnCount(JassMultiboard lb)
        {
            return _MultiboardGetColumnCount(lb);
        }

        public static void MultiboardSetColumnCount(JassMultiboard lb, JassInteger count)
        {
            _MultiboardSetColumnCount(lb, count);
        }

        public static void MultiboardSetRowCount(JassMultiboard lb, JassInteger count)
        {
            _MultiboardSetRowCount(lb, count);
        }

        public static void MultiboardSetItemsStyle(JassMultiboard lb, bool showValues, bool showIcons)
        {
            _MultiboardSetItemsStyle(lb, showValues, showIcons);
        }

        public static void MultiboardSetItemsValue(JassMultiboard lb, string value)
        {
            _MultiboardSetItemsValue(lb, value);
        }

        public static void MultiboardSetItemsValueColor(JassMultiboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _MultiboardSetItemsValueColor(lb, red, green, blue, alpha);
        }

        public static void MultiboardSetItemsWidth(JassMultiboard lb, float width)
        {
            _MultiboardSetItemsWidth(lb, width);
        }

        public static void MultiboardSetItemsIcon(JassMultiboard lb, string iconPath)
        {
            _MultiboardSetItemsIcon(lb, iconPath);
        }

        public static JassMultiboardItem MultiboardGetItem(JassMultiboard lb, JassInteger row, JassInteger column)
        {
            return _MultiboardGetItem(lb, row, column);
        }

        public static void MultiboardReleaseItem(JassMultiboardItem mbi)
        {
            _MultiboardReleaseItem(mbi);
        }

        public static void MultiboardSetItemStyle(JassMultiboardItem mbi, bool showValue, bool showIcon)
        {
            _MultiboardSetItemStyle(mbi, showValue, showIcon);
        }

        public static void MultiboardSetItemValue(JassMultiboardItem mbi, string val)
        {
            _MultiboardSetItemValue(mbi, val);
        }

        public static void MultiboardSetItemValueColor(JassMultiboardItem mbi, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _MultiboardSetItemValueColor(mbi, red, green, blue, alpha);
        }

        public static void MultiboardSetItemWidth(JassMultiboardItem mbi, float width)
        {
            _MultiboardSetItemWidth(mbi, width);
        }

        public static void MultiboardSetItemIcon(JassMultiboardItem mbi, string iconFileName)
        {
            _MultiboardSetItemIcon(mbi, iconFileName);
        }

        public static void MultiboardSuppressDisplay(bool flag)
        {
            _MultiboardSuppressDisplay(flag);
        }

        public static void SetCameraPosition(float x, float y)
        {
            _SetCameraPosition(x, y);
        }

        public static void SetCameraQuickPosition(float x, float y)
        {
            _SetCameraQuickPosition(x, y);
        }

        public static void SetCameraBounds(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            _SetCameraBounds(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        public static void StopCamera()
        {
            _StopCamera();
        }

        public static void ResetToGameCamera(float duration)
        {
            _ResetToGameCamera(duration);
        }

        public static void PanCameraTo(float x, float y)
        {
            _PanCameraTo(x, y);
        }

        public static void PanCameraToTimed(float x, float y, float duration)
        {
            _PanCameraToTimed(x, y, duration);
        }

        public static void PanCameraToWithZ(float x, float y, float zOffsetDest)
        {
            _PanCameraToWithZ(x, y, zOffsetDest);
        }

        public static void PanCameraToTimedWithZ(float x, float y, float zOffsetDest, float duration)
        {
            _PanCameraToTimedWithZ(x, y, zOffsetDest, duration);
        }

        public static void SetCinematicCamera(string cameraModelFile)
        {
            _SetCinematicCamera(cameraModelFile);
        }

        public static void SetCameraRotateMode(float x, float y, float radiansToSweep, float duration)
        {
            _SetCameraRotateMode(x, y, radiansToSweep, duration);
        }

        public static void SetCameraField(JassCameraField whichField, float value, float duration)
        {
            _SetCameraField(whichField, value, duration);
        }

        public static void AdjustCameraField(JassCameraField whichField, float offset, float duration)
        {
            _AdjustCameraField(whichField, offset, duration);
        }

        public static void SetCameraTargetController(JassUnit whichUnit, float xoffset, float yoffset, bool inheritOrientation)
        {
            _SetCameraTargetController(whichUnit, xoffset, yoffset, inheritOrientation);
        }

        public static void SetCameraOrientController(JassUnit whichUnit, float xoffset, float yoffset)
        {
            _SetCameraOrientController(whichUnit, xoffset, yoffset);
        }

        public static JassCameraSetup CreateCameraSetup()
        {
            return _CreateCameraSetup();
        }

        public static void CameraSetupSetField(JassCameraSetup whichSetup, JassCameraField whichField, float value, float duration)
        {
            _CameraSetupSetField(whichSetup, whichField, value, duration);
        }

        public static float CameraSetupGetField(JassCameraSetup whichSetup, JassCameraField whichField)
        {
            return _CameraSetupGetField(whichSetup, whichField);
        }

        public static void CameraSetupSetDestPosition(JassCameraSetup whichSetup, float x, float y, float duration)
        {
            _CameraSetupSetDestPosition(whichSetup, x, y, duration);
        }

        public static JassLocation CameraSetupGetDestPositionLoc(JassCameraSetup whichSetup)
        {
            return _CameraSetupGetDestPositionLoc(whichSetup);
        }

        public static float CameraSetupGetDestPositionX(JassCameraSetup whichSetup)
        {
            return _CameraSetupGetDestPositionX(whichSetup);
        }

        public static float CameraSetupGetDestPositionY(JassCameraSetup whichSetup)
        {
            return _CameraSetupGetDestPositionY(whichSetup);
        }

        public static void CameraSetupApply(JassCameraSetup whichSetup, bool doPan, bool panTimed)
        {
            _CameraSetupApply(whichSetup, doPan, panTimed);
        }

        public static void CameraSetupApplyWithZ(JassCameraSetup whichSetup, float zDestOffset)
        {
            _CameraSetupApplyWithZ(whichSetup, zDestOffset);
        }

        public static void CameraSetupApplyForceDuration(JassCameraSetup whichSetup, bool doPan, float forceDuration)
        {
            _CameraSetupApplyForceDuration(whichSetup, doPan, forceDuration);
        }

        public static void CameraSetupApplyForceDurationWithZ(JassCameraSetup whichSetup, float zDestOffset, float forceDuration)
        {
            _CameraSetupApplyForceDurationWithZ(whichSetup, zDestOffset, forceDuration);
        }

        public static void CameraSetTargetNoise(float mag, float velocity)
        {
            _CameraSetTargetNoise(mag, velocity);
        }

        public static void CameraSetSourceNoise(float mag, float velocity)
        {
            _CameraSetSourceNoise(mag, velocity);
        }

        public static void CameraSetTargetNoiseEx(float mag, float velocity, bool vertOnly)
        {
            _CameraSetTargetNoiseEx(mag, velocity, vertOnly);
        }

        public static void CameraSetSourceNoiseEx(float mag, float velocity, bool vertOnly)
        {
            _CameraSetSourceNoiseEx(mag, velocity, vertOnly);
        }

        public static void CameraSetSmoothingFactor(float factor)
        {
            _CameraSetSmoothingFactor(factor);
        }

        public static void SetCineFilterTexture(string filename)
        {
            _SetCineFilterTexture(filename);
        }

        public static void SetCineFilterBlendMode(JassBlendMode whichMode)
        {
            _SetCineFilterBlendMode(whichMode);
        }

        public static void SetCineFilterTexMapFlags(JassTextureMapFlags whichFlags)
        {
            _SetCineFilterTexMapFlags(whichFlags);
        }

        public static void SetCineFilterStartUV(float minu, float minv, float maxu, float maxv)
        {
            _SetCineFilterStartUV(minu, minv, maxu, maxv);
        }

        public static void SetCineFilterEndUV(float minu, float minv, float maxu, float maxv)
        {
            _SetCineFilterEndUV(minu, minv, maxu, maxv);
        }

        public static void SetCineFilterStartColor(JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _SetCineFilterStartColor(red, green, blue, alpha);
        }

        public static void SetCineFilterEndColor(JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _SetCineFilterEndColor(red, green, blue, alpha);
        }

        public static void SetCineFilterDuration(float duration)
        {
            _SetCineFilterDuration(duration);
        }

        public static void DisplayCineFilter(bool flag)
        {
            _DisplayCineFilter(flag);
        }

        public static bool IsCineFilterDisplayed()
        {
            return _IsCineFilterDisplayed();
        }

        public static void SetCinematicScene(JassInteger portraitUnitId, JassPlayerColor color, string speakerTitle, string text, float sceneDuration, float voiceoverDuration)
        {
            _SetCinematicScene(portraitUnitId, color, speakerTitle, text, sceneDuration, voiceoverDuration);
        }

        public static void EndCinematicScene()
        {
            _EndCinematicScene();
        }

        public static void ForceCinematicSubtitles(bool flag)
        {
            _ForceCinematicSubtitles(flag);
        }

        public static float GetCameraMargin(JassInteger whichMargin)
        {
            return _GetCameraMargin(whichMargin);
        }

        public static float GetCameraBoundMinX()
        {
            return _GetCameraBoundMinX();
        }

        public static float GetCameraBoundMinY()
        {
            return _GetCameraBoundMinY();
        }

        public static float GetCameraBoundMaxX()
        {
            return _GetCameraBoundMaxX();
        }

        public static float GetCameraBoundMaxY()
        {
            return _GetCameraBoundMaxY();
        }

        public static float GetCameraField(JassCameraField whichField)
        {
            return _GetCameraField(whichField);
        }

        public static float GetCameraTargetPositionX()
        {
            return _GetCameraTargetPositionX();
        }

        public static float GetCameraTargetPositionY()
        {
            return _GetCameraTargetPositionY();
        }

        public static float GetCameraTargetPositionZ()
        {
            return _GetCameraTargetPositionZ();
        }

        public static JassLocation GetCameraTargetPositionLoc()
        {
            return _GetCameraTargetPositionLoc();
        }

        public static float GetCameraEyePositionX()
        {
            return _GetCameraEyePositionX();
        }

        public static float GetCameraEyePositionY()
        {
            return _GetCameraEyePositionY();
        }

        public static float GetCameraEyePositionZ()
        {
            return _GetCameraEyePositionZ();
        }

        public static JassLocation GetCameraEyePositionLoc()
        {
            return _GetCameraEyePositionLoc();
        }

        public static void NewSoundEnvironment(string environmentName)
        {
            _NewSoundEnvironment(environmentName);
        }

        public static JassSound CreateSound(string fileName, bool looping, bool is3D, bool stopwhenoutofrange, JassInteger fadeInRate, JassInteger fadeOutRate, string eaxSetting)
        {
            return _CreateSound(fileName, looping, is3D, stopwhenoutofrange, fadeInRate, fadeOutRate, eaxSetting);
        }

        public static JassSound CreateSoundFilenameWithLabel(string fileName, bool looping, bool is3D, bool stopwhenoutofrange, JassInteger fadeInRate, JassInteger fadeOutRate, string SLKEntryName)
        {
            return _CreateSoundFilenameWithLabel(fileName, looping, is3D, stopwhenoutofrange, fadeInRate, fadeOutRate, SLKEntryName);
        }

        public static JassSound CreateSoundFromLabel(string soundLabel, bool looping, bool is3D, bool stopwhenoutofrange, JassInteger fadeInRate, JassInteger fadeOutRate)
        {
            return _CreateSoundFromLabel(soundLabel, looping, is3D, stopwhenoutofrange, fadeInRate, fadeOutRate);
        }

        public static JassSound CreateMIDISound(string soundLabel, JassInteger fadeInRate, JassInteger fadeOutRate)
        {
            return _CreateMIDISound(soundLabel, fadeInRate, fadeOutRate);
        }

        public static void SetSoundParamsFromLabel(JassSound soundHandle, string soundLabel)
        {
            _SetSoundParamsFromLabel(soundHandle, soundLabel);
        }

        public static void SetSoundDistanceCutoff(JassSound soundHandle, float cutoff)
        {
            _SetSoundDistanceCutoff(soundHandle, cutoff);
        }

        public static void SetSoundChannel(JassSound soundHandle, JassInteger channel)
        {
            _SetSoundChannel(soundHandle, channel);
        }

        public static void SetSoundVolume(JassSound soundHandle, JassInteger volume)
        {
            _SetSoundVolume(soundHandle, volume);
        }

        public static void SetSoundPitch(JassSound soundHandle, float pitch)
        {
            _SetSoundPitch(soundHandle, pitch);
        }

        public static void SetSoundPlayPosition(JassSound soundHandle, JassInteger millisecs)
        {
            _SetSoundPlayPosition(soundHandle, millisecs);
        }

        public static void SetSoundDistances(JassSound soundHandle, float minDist, float maxDist)
        {
            _SetSoundDistances(soundHandle, minDist, maxDist);
        }

        public static void SetSoundConeAngles(JassSound soundHandle, float inside, float outside, JassInteger outsideVolume)
        {
            _SetSoundConeAngles(soundHandle, inside, outside, outsideVolume);
        }

        public static void SetSoundConeOrientation(JassSound soundHandle, float x, float y, float z)
        {
            _SetSoundConeOrientation(soundHandle, x, y, z);
        }

        public static void SetSoundPosition(JassSound soundHandle, float x, float y, float z)
        {
            _SetSoundPosition(soundHandle, x, y, z);
        }

        public static void SetSoundVelocity(JassSound soundHandle, float x, float y, float z)
        {
            _SetSoundVelocity(soundHandle, x, y, z);
        }

        public static void AttachSoundToUnit(JassSound soundHandle, JassUnit whichUnit)
        {
            _AttachSoundToUnit(soundHandle, whichUnit);
        }

        public static void StartSound(JassSound soundHandle)
        {
            _StartSound(soundHandle);
        }

        public static void StopSound(JassSound soundHandle, bool killWhenDone, bool fadeOut)
        {
            _StopSound(soundHandle, killWhenDone, fadeOut);
        }

        public static void KillSoundWhenDone(JassSound soundHandle)
        {
            _KillSoundWhenDone(soundHandle);
        }

        public static void SetMapMusic(string musicName, bool random, JassInteger index)
        {
            _SetMapMusic(musicName, random, index);
        }

        public static void ClearMapMusic()
        {
            _ClearMapMusic();
        }

        public static void PlayMusic(string musicName)
        {
            _PlayMusic(musicName);
        }

        public static void PlayMusicEx(string musicName, JassInteger frommsecs, JassInteger fadeinmsecs)
        {
            _PlayMusicEx(musicName, frommsecs, fadeinmsecs);
        }

        public static void StopMusic(bool fadeOut)
        {
            _StopMusic(fadeOut);
        }

        public static void ResumeMusic()
        {
            _ResumeMusic();
        }

        public static void PlayThematicMusic(string musicFileName)
        {
            _PlayThematicMusic(musicFileName);
        }

        public static void PlayThematicMusicEx(string musicFileName, JassInteger frommsecs)
        {
            _PlayThematicMusicEx(musicFileName, frommsecs);
        }

        public static void EndThematicMusic()
        {
            _EndThematicMusic();
        }

        public static void SetMusicVolume(JassInteger volume)
        {
            _SetMusicVolume(volume);
        }

        public static void SetMusicPlayPosition(JassInteger millisecs)
        {
            _SetMusicPlayPosition(millisecs);
        }

        public static void SetThematicMusicPlayPosition(JassInteger millisecs)
        {
            _SetThematicMusicPlayPosition(millisecs);
        }

        public static void SetSoundDuration(JassSound soundHandle, JassInteger duration)
        {
            _SetSoundDuration(soundHandle, duration);
        }

        public static JassInteger GetSoundDuration(JassSound soundHandle)
        {
            return _GetSoundDuration(soundHandle);
        }

        public static JassInteger GetSoundFileDuration(string musicFileName)
        {
            return _GetSoundFileDuration(musicFileName);
        }

        public static void VolumeGroupSetVolume(JassVolumeGroup vgroup, float scale)
        {
            _VolumeGroupSetVolume(vgroup, scale);
        }

        public static void VolumeGroupReset()
        {
            _VolumeGroupReset();
        }

        public static bool GetSoundIsPlaying(JassSound soundHandle)
        {
            return _GetSoundIsPlaying(soundHandle);
        }

        public static bool GetSoundIsLoading(JassSound soundHandle)
        {
            return _GetSoundIsLoading(soundHandle);
        }

        public static void RegisterStackedSound(JassSound soundHandle, bool byPosition, float rectwidth, float rectheight)
        {
            _RegisterStackedSound(soundHandle, byPosition, rectwidth, rectheight);
        }

        public static void UnregisterStackedSound(JassSound soundHandle, bool byPosition, float rectwidth, float rectheight)
        {
            _UnregisterStackedSound(soundHandle, byPosition, rectwidth, rectheight);
        }

        public static JassWeatherEffect AddWeatherEffect(JassRect where, JassInteger effectID)
        {
            return _AddWeatherEffect(where, effectID);
        }

        public static void RemoveWeatherEffect(JassWeatherEffect whichEffect)
        {
            _RemoveWeatherEffect(whichEffect);
        }

        public static void EnableWeatherEffect(JassWeatherEffect whichEffect, bool enable)
        {
            _EnableWeatherEffect(whichEffect, enable);
        }

        public static JassTerrainDeformation TerrainDeformCrater(float x, float y, float radius, float depth, JassInteger duration, bool permanent)
        {
            return _TerrainDeformCrater(x, y, radius, depth, duration, permanent);
        }

        public static JassTerrainDeformation TerrainDeformRipple(float x, float y, float radius, float depth, JassInteger duration, JassInteger count, float spaceWaves, float timeWaves, float radiusStartPct, bool limitNeg)
        {
            return _TerrainDeformRipple(x, y, radius, depth, duration, count, spaceWaves, timeWaves, radiusStartPct, limitNeg);
        }

        public static JassTerrainDeformation TerrainDeformWave(float x, float y, float dirX, float dirY, float distance, float speed, float radius, float depth, JassInteger trailTime, JassInteger count)
        {
            return _TerrainDeformWave(x, y, dirX, dirY, distance, speed, radius, depth, trailTime, count);
        }

        public static JassTerrainDeformation TerrainDeformRandom(float x, float y, float radius, float minDelta, float maxDelta, JassInteger duration, JassInteger updateInterval)
        {
            return _TerrainDeformRandom(x, y, radius, minDelta, maxDelta, duration, updateInterval);
        }

        public static void TerrainDeformStop(JassTerrainDeformation deformation, JassInteger duration)
        {
            _TerrainDeformStop(deformation, duration);
        }

        public static void TerrainDeformStopAll()
        {
            _TerrainDeformStopAll();
        }

        public static JassEffect AddSpecialEffect(string modelName, float x, float y)
        {
            return _AddSpecialEffect(modelName, x, y);
        }

        public static JassEffect AddSpecialEffectLoc(string modelName, JassLocation where)
        {
            return _AddSpecialEffectLoc(modelName, where);
        }

        public static JassEffect AddSpecialEffectTarget(string modelName, JassWidget targetWidget, string attachPointName)
        {
            return _AddSpecialEffectTarget(modelName, targetWidget, attachPointName);
        }

        public static void DestroyEffect(JassEffect whichEffect)
        {
            _DestroyEffect(whichEffect);
        }

        public static JassEffect AddSpellEffect(string abilityString, JassEffectType t, float x, float y)
        {
            return _AddSpellEffect(abilityString, t, x, y);
        }

        public static JassEffect AddSpellEffectLoc(string abilityString, JassEffectType t, JassLocation where)
        {
            return _AddSpellEffectLoc(abilityString, t, where);
        }

        public static JassEffect AddSpellEffectById(JassObjectId abilityId, JassEffectType t, float x, float y)
        {
            return _AddSpellEffectById(abilityId, t, x, y);
        }

        public static JassEffect AddSpellEffectByIdLoc(JassObjectId abilityId, JassEffectType t, JassLocation where)
        {
            return _AddSpellEffectByIdLoc(abilityId, t, where);
        }

        public static JassEffect AddSpellEffectTarget(string modelName, JassEffectType t, JassWidget targetWidget, string attachPoint)
        {
            return _AddSpellEffectTarget(modelName, t, targetWidget, attachPoint);
        }

        public static JassEffect AddSpellEffectTargetById(JassObjectId abilityId, JassEffectType t, JassWidget targetWidget, string attachPoint)
        {
            return _AddSpellEffectTargetById(abilityId, t, targetWidget, attachPoint);
        }

        public static JassLightning AddLightning(string codeName, bool checkVisibility, float x1, float y1, float x2, float y2)
        {
            return _AddLightning(codeName, checkVisibility, x1, y1, x2, y2);
        }

        public static JassLightning AddLightningEx(string codeName, bool checkVisibility, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            return _AddLightningEx(codeName, checkVisibility, x1, y1, z1, x2, y2, z2);
        }

        public static bool DestroyLightning(JassLightning whichBolt)
        {
            return _DestroyLightning(whichBolt);
        }

        public static bool MoveLightning(JassLightning whichBolt, bool checkVisibility, float x1, float y1, float x2, float y2)
        {
            return _MoveLightning(whichBolt, checkVisibility, x1, y1, x2, y2);
        }

        public static bool MoveLightningEx(JassLightning whichBolt, bool checkVisibility, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            return _MoveLightningEx(whichBolt, checkVisibility, x1, y1, z1, x2, y2, z2);
        }

        public static float GetLightningColorA(JassLightning whichBolt)
        {
            return _GetLightningColorA(whichBolt);
        }

        public static float GetLightningColorR(JassLightning whichBolt)
        {
            return _GetLightningColorR(whichBolt);
        }

        public static float GetLightningColorG(JassLightning whichBolt)
        {
            return _GetLightningColorG(whichBolt);
        }

        public static float GetLightningColorB(JassLightning whichBolt)
        {
            return _GetLightningColorB(whichBolt);
        }

        public static bool SetLightningColor(JassLightning whichBolt, float r, float g, float b, float a)
        {
            return _SetLightningColor(whichBolt, r, g, b, a);
        }

        public static string GetAbilityEffect(string abilityString, JassEffectType t, JassInteger index)
        {
            return _GetAbilityEffect(abilityString, t, index);
        }

        public static string GetAbilityEffectById(JassObjectId abilityId, JassEffectType t, JassInteger index)
        {
            return _GetAbilityEffectById(abilityId, t, index);
        }

        public static string GetAbilitySound(string abilityString, JassSoundType t)
        {
            return _GetAbilitySound(abilityString, t);
        }

        public static string GetAbilitySoundById(JassObjectId abilityId, JassSoundType t)
        {
            return _GetAbilitySoundById(abilityId, t);
        }

        public static JassInteger GetTerrainCliffLevel(float x, float y)
        {
            return _GetTerrainCliffLevel(x, y);
        }

        public static void SetWaterBaseColor(JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _SetWaterBaseColor(red, green, blue, alpha);
        }

        public static void SetWaterDeforms(bool val)
        {
            _SetWaterDeforms(val);
        }

        public static JassInteger GetTerrainType(float x, float y)
        {
            return _GetTerrainType(x, y);
        }

        public static JassInteger GetTerrainVariance(float x, float y)
        {
            return _GetTerrainVariance(x, y);
        }

        public static void SetTerrainType(float x, float y, JassInteger terrainType, JassInteger variation, JassInteger area, JassInteger shape)
        {
            _SetTerrainType(x, y, terrainType, variation, area, shape);
        }

        public static bool IsTerrainPathable(float x, float y, JassPathingType t)
        {
            return _IsTerrainPathable(x, y, t);
        }

        public static void SetTerrainPathable(float x, float y, JassPathingType t, bool flag)
        {
            _SetTerrainPathable(x, y, t, flag);
        }

        public static JassImage CreateImage(string file, float sizeX, float sizeY, float sizeZ, float posX, float posY, float posZ, float originX, float originY, float originZ, JassInteger imageType)
        {
            return _CreateImage(file, sizeX, sizeY, sizeZ, posX, posY, posZ, originX, originY, originZ, imageType);
        }

        public static void DestroyImage(JassImage whichImage)
        {
            _DestroyImage(whichImage);
        }

        public static void ShowImage(JassImage whichImage, bool flag)
        {
            _ShowImage(whichImage, flag);
        }

        public static void SetImageConstantHeight(JassImage whichImage, bool flag, float height)
        {
            _SetImageConstantHeight(whichImage, flag, height);
        }

        public static void SetImagePosition(JassImage whichImage, float x, float y, float z)
        {
            _SetImagePosition(whichImage, x, y, z);
        }

        public static void SetImageColor(JassImage whichImage, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha)
        {
            _SetImageColor(whichImage, red, green, blue, alpha);
        }

        public static void SetImageRender(JassImage whichImage, bool flag)
        {
            _SetImageRender(whichImage, flag);
        }

        public static void SetImageRenderAlways(JassImage whichImage, bool flag)
        {
            _SetImageRenderAlways(whichImage, flag);
        }

        public static void SetImageAboveWater(JassImage whichImage, bool flag, bool useWaterAlpha)
        {
            _SetImageAboveWater(whichImage, flag, useWaterAlpha);
        }

        public static void SetImageType(JassImage whichImage, JassInteger imageType)
        {
            _SetImageType(whichImage, imageType);
        }

        public static JassUberSplat CreateUbersplat(float x, float y, string name, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha, bool forcePaused, bool noBirthTime)
        {
            return _CreateUbersplat(x, y, name, red, green, blue, alpha, forcePaused, noBirthTime);
        }

        public static void DestroyUbersplat(JassUberSplat whichSplat)
        {
            _DestroyUbersplat(whichSplat);
        }

        public static void ResetUbersplat(JassUberSplat whichSplat)
        {
            _ResetUbersplat(whichSplat);
        }

        public static void FinishUbersplat(JassUberSplat whichSplat)
        {
            _FinishUbersplat(whichSplat);
        }

        public static void ShowUbersplat(JassUberSplat whichSplat, bool flag)
        {
            _ShowUbersplat(whichSplat, flag);
        }

        public static void SetUbersplatRender(JassUberSplat whichSplat, bool flag)
        {
            _SetUbersplatRender(whichSplat, flag);
        }

        public static void SetUbersplatRenderAlways(JassUberSplat whichSplat, bool flag)
        {
            _SetUbersplatRenderAlways(whichSplat, flag);
        }

        public static void SetBlight(JassPlayer whichPlayer, float x, float y, float radius, bool addBlight)
        {
            _SetBlight(whichPlayer, x, y, radius, addBlight);
        }

        public static void SetBlightRect(JassPlayer whichPlayer, JassRect r, bool addBlight)
        {
            _SetBlightRect(whichPlayer, r, addBlight);
        }

        public static void SetBlightPoint(JassPlayer whichPlayer, float x, float y, bool addBlight)
        {
            _SetBlightPoint(whichPlayer, x, y, addBlight);
        }

        public static void SetBlightLoc(JassPlayer whichPlayer, JassLocation whichLocation, float radius, bool addBlight)
        {
            _SetBlightLoc(whichPlayer, whichLocation, radius, addBlight);
        }

        public static JassUnit CreateBlightedGoldmine(JassPlayer id, float x, float y, float face)
        {
            return _CreateBlightedGoldmine(id, x, y, face);
        }

        public static bool IsPointBlighted(float x, float y)
        {
            return _IsPointBlighted(x, y);
        }

        public static void SetDoodadAnimation(float x, float y, float radius, JassObjectId doodadID, bool nearestOnly, string animName, bool animRandom)
        {
            _SetDoodadAnimation(x, y, radius, doodadID, nearestOnly, animName, animRandom);
        }

        public static void SetDoodadAnimationRect(JassRect r, JassObjectId doodadID, string animName, bool animRandom)
        {
            _SetDoodadAnimationRect(r, doodadID, animName, animRandom);
        }

        public static void StartMeleeAI(JassPlayer num, string script)
        {
            _StartMeleeAI(num, script);
        }

        public static void StartCampaignAI(JassPlayer num, string script)
        {
            _StartCampaignAI(num, script);
        }

        public static void CommandAI(JassPlayer num, JassInteger command, JassInteger data)
        {
            _CommandAI(num, command, data);
        }

        public static void PauseCompAI(JassPlayer p, bool pause)
        {
            _PauseCompAI(p, pause);
        }

        public static JassAIDifficulty GetAIDifficulty(JassPlayer num)
        {
            return _GetAIDifficulty(num);
        }

        public static void RemoveGuardPosition(JassUnit hUnit)
        {
            _RemoveGuardPosition(hUnit);
        }

        public static void RecycleGuardPosition(JassUnit hUnit)
        {
            _RecycleGuardPosition(hUnit);
        }

        public static void RemoveAllGuardPositions(JassPlayer num)
        {
            _RemoveAllGuardPositions(num);
        }

        public static void Cheat(string cheatStr)
        {
            _Cheat(cheatStr);
        }

        public static bool IsNoVictoryCheat()
        {
            return _IsNoVictoryCheat();
        }

        public static bool IsNoDefeatCheat()
        {
            return _IsNoDefeatCheat();
        }

        public static void Preload(string filename)
        {
            _Preload(filename);
        }

        public static void PreloadEnd(float timeout)
        {
            _PreloadEnd(timeout);
        }

        public static void PreloadStart()
        {
            _PreloadStart();
        }

        public static void PreloadRefresh()
        {
            _PreloadRefresh();
        }

        public static void PreloadEndEx()
        {
            _PreloadEndEx();
        }

        public static void PreloadGenClear()
        {
            _PreloadGenClear();
        }

        public static void PreloadGenStart()
        {
            _PreloadGenStart();
        }

        public static void PreloadGenEnd(string filename)
        {
            _PreloadGenEnd(filename);
        }

        public static void Preloader(string filename)
        {
            _Preloader(filename);
        }

        private static void InitializeVanillaNatives()
        {
            _ConvertRace = Get("ConvertRace").ToDelegate<ConvertRacePrototype>();
            _ConvertAllianceType = Get("ConvertAllianceType").ToDelegate<ConvertAllianceTypePrototype>();
            _ConvertRacePref = Get("ConvertRacePref").ToDelegate<ConvertRacePrefPrototype>();
            _ConvertIGameState = Get("ConvertIGameState").ToDelegate<ConvertIGameStatePrototype>();
            _ConvertFGameState = Get("ConvertFGameState").ToDelegate<ConvertFGameStatePrototype>();
            _ConvertPlayerState = Get("ConvertPlayerState").ToDelegate<ConvertPlayerStatePrototype>();
            _ConvertPlayerScore = Get("ConvertPlayerScore").ToDelegate<ConvertPlayerScorePrototype>();
            _ConvertPlayerGameResult = Get("ConvertPlayerGameResult").ToDelegate<ConvertPlayerGameResultPrototype>();
            _ConvertUnitState = Get("ConvertUnitState").ToDelegate<ConvertUnitStatePrototype>();
            _ConvertAIDifficulty = Get("ConvertAIDifficulty").ToDelegate<ConvertAIDifficultyPrototype>();
            _ConvertGameEvent = Get("ConvertGameEvent").ToDelegate<ConvertGameEventPrototype>();
            _ConvertPlayerEvent = Get("ConvertPlayerEvent").ToDelegate<ConvertPlayerEventPrototype>();
            _ConvertPlayerUnitEvent = Get("ConvertPlayerUnitEvent").ToDelegate<ConvertPlayerUnitEventPrototype>();
            _ConvertWidgetEvent = Get("ConvertWidgetEvent").ToDelegate<ConvertWidgetEventPrototype>();
            _ConvertDialogEvent = Get("ConvertDialogEvent").ToDelegate<ConvertDialogEventPrototype>();
            _ConvertUnitEvent = Get("ConvertUnitEvent").ToDelegate<ConvertUnitEventPrototype>();
            _ConvertLimitOp = Get("ConvertLimitOp").ToDelegate<ConvertLimitOpPrototype>();
            _ConvertUnitType = Get("ConvertUnitType").ToDelegate<ConvertUnitTypePrototype>();
            _ConvertGameSpeed = Get("ConvertGameSpeed").ToDelegate<ConvertGameSpeedPrototype>();
            _ConvertPlacement = Get("ConvertPlacement").ToDelegate<ConvertPlacementPrototype>();
            _ConvertStartLocPrio = Get("ConvertStartLocPrio").ToDelegate<ConvertStartLocPrioPrototype>();
            _ConvertGameDifficulty = Get("ConvertGameDifficulty").ToDelegate<ConvertGameDifficultyPrototype>();
            _ConvertGameType = Get("ConvertGameType").ToDelegate<ConvertGameTypePrototype>();
            _ConvertMapFlag = Get("ConvertMapFlag").ToDelegate<ConvertMapFlagPrototype>();
            _ConvertMapVisibility = Get("ConvertMapVisibility").ToDelegate<ConvertMapVisibilityPrototype>();
            _ConvertMapSetting = Get("ConvertMapSetting").ToDelegate<ConvertMapSettingPrototype>();
            _ConvertMapDensity = Get("ConvertMapDensity").ToDelegate<ConvertMapDensityPrototype>();
            _ConvertMapControl = Get("ConvertMapControl").ToDelegate<ConvertMapControlPrototype>();
            _ConvertPlayerColor = Get("ConvertPlayerColor").ToDelegate<ConvertPlayerColorPrototype>();
            _ConvertPlayerSlotState = Get("ConvertPlayerSlotState").ToDelegate<ConvertPlayerSlotStatePrototype>();
            _ConvertVolumeGroup = Get("ConvertVolumeGroup").ToDelegate<ConvertVolumeGroupPrototype>();
            _ConvertCameraField = Get("ConvertCameraField").ToDelegate<ConvertCameraFieldPrototype>();
            _ConvertBlendMode = Get("ConvertBlendMode").ToDelegate<ConvertBlendModePrototype>();
            _ConvertRarityControl = Get("ConvertRarityControl").ToDelegate<ConvertRarityControlPrototype>();
            _ConvertTexMapFlags = Get("ConvertTexMapFlags").ToDelegate<ConvertTexMapFlagsPrototype>();
            _ConvertFogState = Get("ConvertFogState").ToDelegate<ConvertFogStatePrototype>();
            _ConvertEffectType = Get("ConvertEffectType").ToDelegate<ConvertEffectTypePrototype>();
            _ConvertVersion = Get("ConvertVersion").ToDelegate<ConvertVersionPrototype>();
            _ConvertItemType = Get("ConvertItemType").ToDelegate<ConvertItemTypePrototype>();
            _ConvertAttackType = Get("ConvertAttackType").ToDelegate<ConvertAttackTypePrototype>();
            _ConvertDamageType = Get("ConvertDamageType").ToDelegate<ConvertDamageTypePrototype>();
            _ConvertWeaponType = Get("ConvertWeaponType").ToDelegate<ConvertWeaponTypePrototype>();
            _ConvertSoundType = Get("ConvertSoundType").ToDelegate<ConvertSoundTypePrototype>();
            _ConvertPathingType = Get("ConvertPathingType").ToDelegate<ConvertPathingTypePrototype>();
            _OrderId = Get("OrderId").ToDelegate<OrderIdPrototype>();
            _OrderId2String = Get("OrderId2String").ToDelegate<OrderId2StringPrototype>();
            _UnitId = Get("UnitId").ToDelegate<UnitIdPrototype>();
            _UnitId2String = Get("UnitId2String").ToDelegate<UnitId2StringPrototype>();
            _AbilityId = Get("AbilityId").ToDelegate<AbilityIdPrototype>();
            _AbilityId2String = Get("AbilityId2String").ToDelegate<AbilityId2StringPrototype>();
            _GetObjectName = Get("GetObjectName").ToDelegate<GetObjectNamePrototype>();
            _Deg2Rad = Get("Deg2Rad").ToDelegate<Deg2RadPrototype>();
            _Rad2Deg = Get("Rad2Deg").ToDelegate<Rad2DegPrototype>();
            _Sin = Get("Sin").ToDelegate<SinPrototype>();
            _Cos = Get("Cos").ToDelegate<CosPrototype>();
            _Tan = Get("Tan").ToDelegate<TanPrototype>();
            _Asin = Get("Asin").ToDelegate<AsinPrototype>();
            _Acos = Get("Acos").ToDelegate<AcosPrototype>();
            _Atan = Get("Atan").ToDelegate<AtanPrototype>();
            _Atan2 = Get("Atan2").ToDelegate<Atan2Prototype>();
            _SquareRoot = Get("SquareRoot").ToDelegate<SquareRootPrototype>();
            _Pow = Get("Pow").ToDelegate<PowPrototype>();
            _I2R = Get("I2R").ToDelegate<I2RPrototype>();
            _R2I = Get("R2I").ToDelegate<R2IPrototype>();
            _I2S = Get("I2S").ToDelegate<I2SPrototype>();
            _R2S = Get("R2S").ToDelegate<R2SPrototype>();
            _R2SW = Get("R2SW").ToDelegate<R2SWPrototype>();
            _S2I = Get("S2I").ToDelegate<S2IPrototype>();
            _S2R = Get("S2R").ToDelegate<S2RPrototype>();
            _GetHandleId = Get("GetHandleId").ToDelegate<GetHandleIdPrototype>();
            _SubString = Get("SubString").ToDelegate<SubStringPrototype>();
            _StringLength = Get("StringLength").ToDelegate<StringLengthPrototype>();
            _StringCase = Get("StringCase").ToDelegate<StringCasePrototype>();
            _StringHash = Get("StringHash").ToDelegate<StringHashPrototype>();
            _GetLocalizedString = Get("GetLocalizedString").ToDelegate<GetLocalizedStringPrototype>();
            _GetLocalizedHotkey = Get("GetLocalizedHotkey").ToDelegate<GetLocalizedHotkeyPrototype>();
            _SetMapName = Get("SetMapName").ToDelegate<SetMapNamePrototype>();
            _SetMapDescription = Get("SetMapDescription").ToDelegate<SetMapDescriptionPrototype>();
            _SetTeams = Get("SetTeams").ToDelegate<SetTeamsPrototype>();
            _SetPlayers = Get("SetPlayers").ToDelegate<SetPlayersPrototype>();
            _DefineStartLocation = Get("DefineStartLocation").ToDelegate<DefineStartLocationPrototype>();
            _DefineStartLocationLoc = Get("DefineStartLocationLoc").ToDelegate<DefineStartLocationLocPrototype>();
            _SetStartLocPrioCount = Get("SetStartLocPrioCount").ToDelegate<SetStartLocPrioCountPrototype>();
            _SetStartLocPrio = Get("SetStartLocPrio").ToDelegate<SetStartLocPrioPrototype>();
            _GetStartLocPrioSlot = Get("GetStartLocPrioSlot").ToDelegate<GetStartLocPrioSlotPrototype>();
            _GetStartLocPrio = Get("GetStartLocPrio").ToDelegate<GetStartLocPrioPrototype>();
            _SetGameTypeSupported = Get("SetGameTypeSupported").ToDelegate<SetGameTypeSupportedPrototype>();
            _SetMapFlag = Get("SetMapFlag").ToDelegate<SetMapFlagPrototype>();
            _SetGamePlacement = Get("SetGamePlacement").ToDelegate<SetGamePlacementPrototype>();
            _SetGameSpeed = Get("SetGameSpeed").ToDelegate<SetGameSpeedPrototype>();
            _SetGameDifficulty = Get("SetGameDifficulty").ToDelegate<SetGameDifficultyPrototype>();
            _SetResourceDensity = Get("SetResourceDensity").ToDelegate<SetResourceDensityPrototype>();
            _SetCreatureDensity = Get("SetCreatureDensity").ToDelegate<SetCreatureDensityPrototype>();
            _GetTeams = Get("GetTeams").ToDelegate<GetTeamsPrototype>();
            _GetPlayers = Get("GetPlayers").ToDelegate<GetPlayersPrototype>();
            _IsGameTypeSupported = Get("IsGameTypeSupported").ToDelegate<IsGameTypeSupportedPrototype>();
            _GetGameTypeSelected = Get("GetGameTypeSelected").ToDelegate<GetGameTypeSelectedPrototype>();
            _IsMapFlagSet = Get("IsMapFlagSet").ToDelegate<IsMapFlagSetPrototype>();
            _GetGamePlacement = Get("GetGamePlacement").ToDelegate<GetGamePlacementPrototype>();
            _GetGameSpeed = Get("GetGameSpeed").ToDelegate<GetGameSpeedPrototype>();
            _GetGameDifficulty = Get("GetGameDifficulty").ToDelegate<GetGameDifficultyPrototype>();
            _GetResourceDensity = Get("GetResourceDensity").ToDelegate<GetResourceDensityPrototype>();
            _GetCreatureDensity = Get("GetCreatureDensity").ToDelegate<GetCreatureDensityPrototype>();
            _GetStartLocationX = Get("GetStartLocationX").ToDelegate<GetStartLocationXPrototype>();
            _GetStartLocationY = Get("GetStartLocationY").ToDelegate<GetStartLocationYPrototype>();
            _GetStartLocationLoc = Get("GetStartLocationLoc").ToDelegate<GetStartLocationLocPrototype>();
            _SetPlayerTeam = Get("SetPlayerTeam").ToDelegate<SetPlayerTeamPrototype>();
            _SetPlayerStartLocation = Get("SetPlayerStartLocation").ToDelegate<SetPlayerStartLocationPrototype>();
            _ForcePlayerStartLocation = Get("ForcePlayerStartLocation").ToDelegate<ForcePlayerStartLocationPrototype>();
            _SetPlayerColor = Get("SetPlayerColor").ToDelegate<SetPlayerColorPrototype>();
            _SetPlayerAlliance = Get("SetPlayerAlliance").ToDelegate<SetPlayerAlliancePrototype>();
            _SetPlayerTaxRate = Get("SetPlayerTaxRate").ToDelegate<SetPlayerTaxRatePrototype>();
            _SetPlayerRacePreference = Get("SetPlayerRacePreference").ToDelegate<SetPlayerRacePreferencePrototype>();
            _SetPlayerRaceSelectable = Get("SetPlayerRaceSelectable").ToDelegate<SetPlayerRaceSelectablePrototype>();
            _SetPlayerController = Get("SetPlayerController").ToDelegate<SetPlayerControllerPrototype>();
            _SetPlayerName = Get("SetPlayerName").ToDelegate<SetPlayerNamePrototype>();
            _SetPlayerOnScoreScreen = Get("SetPlayerOnScoreScreen").ToDelegate<SetPlayerOnScoreScreenPrototype>();
            _GetPlayerTeam = Get("GetPlayerTeam").ToDelegate<GetPlayerTeamPrototype>();
            _GetPlayerStartLocation = Get("GetPlayerStartLocation").ToDelegate<GetPlayerStartLocationPrototype>();
            _GetPlayerColor = Get("GetPlayerColor").ToDelegate<GetPlayerColorPrototype>();
            _GetPlayerSelectable = Get("GetPlayerSelectable").ToDelegate<GetPlayerSelectablePrototype>();
            _GetPlayerController = Get("GetPlayerController").ToDelegate<GetPlayerControllerPrototype>();
            _GetPlayerSlotState = Get("GetPlayerSlotState").ToDelegate<GetPlayerSlotStatePrototype>();
            _GetPlayerTaxRate = Get("GetPlayerTaxRate").ToDelegate<GetPlayerTaxRatePrototype>();
            _IsPlayerRacePrefSet = Get("IsPlayerRacePrefSet").ToDelegate<IsPlayerRacePrefSetPrototype>();
            _GetPlayerName = Get("GetPlayerName").ToDelegate<GetPlayerNamePrototype>();
            _CreateTimer = Get("CreateTimer").ToDelegate<CreateTimerPrototype>();
            _DestroyTimer = Get("DestroyTimer").ToDelegate<DestroyTimerPrototype>();
            _TimerStart = Get("TimerStart").ToDelegate<TimerStartPrototype>();
            _TimerGetElapsed = Get("TimerGetElapsed").ToDelegate<TimerGetElapsedPrototype>();
            _TimerGetRemaining = Get("TimerGetRemaining").ToDelegate<TimerGetRemainingPrototype>();
            _TimerGetTimeout = Get("TimerGetTimeout").ToDelegate<TimerGetTimeoutPrototype>();
            _PauseTimer = Get("PauseTimer").ToDelegate<PauseTimerPrototype>();
            _ResumeTimer = Get("ResumeTimer").ToDelegate<ResumeTimerPrototype>();
            _GetExpiredTimer = Get("GetExpiredTimer").ToDelegate<GetExpiredTimerPrototype>();
            _CreateGroup = Get("CreateGroup").ToDelegate<CreateGroupPrototype>();
            _DestroyGroup = Get("DestroyGroup").ToDelegate<DestroyGroupPrototype>();
            _GroupAddUnit = Get("GroupAddUnit").ToDelegate<GroupAddUnitPrototype>();
            _GroupRemoveUnit = Get("GroupRemoveUnit").ToDelegate<GroupRemoveUnitPrototype>();
            _GroupClear = Get("GroupClear").ToDelegate<GroupClearPrototype>();
            _GroupEnumUnitsOfType = Get("GroupEnumUnitsOfType").ToDelegate<GroupEnumUnitsOfTypePrototype>();
            _GroupEnumUnitsOfPlayer = Get("GroupEnumUnitsOfPlayer").ToDelegate<GroupEnumUnitsOfPlayerPrototype>();
            _GroupEnumUnitsOfTypeCounted = Get("GroupEnumUnitsOfTypeCounted").ToDelegate<GroupEnumUnitsOfTypeCountedPrototype>();
            _GroupEnumUnitsInRect = Get("GroupEnumUnitsInRect").ToDelegate<GroupEnumUnitsInRectPrototype>();
            _GroupEnumUnitsInRectCounted = Get("GroupEnumUnitsInRectCounted").ToDelegate<GroupEnumUnitsInRectCountedPrototype>();
            _GroupEnumUnitsInRange = Get("GroupEnumUnitsInRange").ToDelegate<GroupEnumUnitsInRangePrototype>();
            _GroupEnumUnitsInRangeOfLoc = Get("GroupEnumUnitsInRangeOfLoc").ToDelegate<GroupEnumUnitsInRangeOfLocPrototype>();
            _GroupEnumUnitsInRangeCounted = Get("GroupEnumUnitsInRangeCounted").ToDelegate<GroupEnumUnitsInRangeCountedPrototype>();
            _GroupEnumUnitsInRangeOfLocCounted = Get("GroupEnumUnitsInRangeOfLocCounted").ToDelegate<GroupEnumUnitsInRangeOfLocCountedPrototype>();
            _GroupEnumUnitsSelected = Get("GroupEnumUnitsSelected").ToDelegate<GroupEnumUnitsSelectedPrototype>();
            _GroupImmediateOrder = Get("GroupImmediateOrder").ToDelegate<GroupImmediateOrderPrototype>();
            _GroupImmediateOrderById = Get("GroupImmediateOrderById").ToDelegate<GroupImmediateOrderByIdPrototype>();
            _GroupPointOrder = Get("GroupPointOrder").ToDelegate<GroupPointOrderPrototype>();
            _GroupPointOrderLoc = Get("GroupPointOrderLoc").ToDelegate<GroupPointOrderLocPrototype>();
            _GroupPointOrderById = Get("GroupPointOrderById").ToDelegate<GroupPointOrderByIdPrototype>();
            _GroupPointOrderByIdLoc = Get("GroupPointOrderByIdLoc").ToDelegate<GroupPointOrderByIdLocPrototype>();
            _GroupTargetOrder = Get("GroupTargetOrder").ToDelegate<GroupTargetOrderPrototype>();
            _GroupTargetOrderById = Get("GroupTargetOrderById").ToDelegate<GroupTargetOrderByIdPrototype>();
            _ForGroup = Get("ForGroup").ToDelegate<ForGroupPrototype>();
            _FirstOfGroup = Get("FirstOfGroup").ToDelegate<FirstOfGroupPrototype>();
            _CreateForce = Get("CreateForce").ToDelegate<CreateForcePrototype>();
            _DestroyForce = Get("DestroyForce").ToDelegate<DestroyForcePrototype>();
            _ForceAddPlayer = Get("ForceAddPlayer").ToDelegate<ForceAddPlayerPrototype>();
            _ForceRemovePlayer = Get("ForceRemovePlayer").ToDelegate<ForceRemovePlayerPrototype>();
            _ForceClear = Get("ForceClear").ToDelegate<ForceClearPrototype>();
            _ForceEnumPlayers = Get("ForceEnumPlayers").ToDelegate<ForceEnumPlayersPrototype>();
            _ForceEnumPlayersCounted = Get("ForceEnumPlayersCounted").ToDelegate<ForceEnumPlayersCountedPrototype>();
            _ForceEnumAllies = Get("ForceEnumAllies").ToDelegate<ForceEnumAlliesPrototype>();
            _ForceEnumEnemies = Get("ForceEnumEnemies").ToDelegate<ForceEnumEnemiesPrototype>();
            _ForForce = Get("ForForce").ToDelegate<ForForcePrototype>();
            _Rect = Get("Rect").ToDelegate<RectPrototype>();
            _RectFromLoc = Get("RectFromLoc").ToDelegate<RectFromLocPrototype>();
            _RemoveRect = Get("RemoveRect").ToDelegate<RemoveRectPrototype>();
            _SetRect = Get("SetRect").ToDelegate<SetRectPrototype>();
            _SetRectFromLoc = Get("SetRectFromLoc").ToDelegate<SetRectFromLocPrototype>();
            _MoveRectTo = Get("MoveRectTo").ToDelegate<MoveRectToPrototype>();
            _MoveRectToLoc = Get("MoveRectToLoc").ToDelegate<MoveRectToLocPrototype>();
            _GetRectCenterX = Get("GetRectCenterX").ToDelegate<GetRectCenterXPrototype>();
            _GetRectCenterY = Get("GetRectCenterY").ToDelegate<GetRectCenterYPrototype>();
            _GetRectMinX = Get("GetRectMinX").ToDelegate<GetRectMinXPrototype>();
            _GetRectMinY = Get("GetRectMinY").ToDelegate<GetRectMinYPrototype>();
            _GetRectMaxX = Get("GetRectMaxX").ToDelegate<GetRectMaxXPrototype>();
            _GetRectMaxY = Get("GetRectMaxY").ToDelegate<GetRectMaxYPrototype>();
            _CreateRegion = Get("CreateRegion").ToDelegate<CreateRegionPrototype>();
            _RemoveRegion = Get("RemoveRegion").ToDelegate<RemoveRegionPrototype>();
            _RegionAddRect = Get("RegionAddRect").ToDelegate<RegionAddRectPrototype>();
            _RegionClearRect = Get("RegionClearRect").ToDelegate<RegionClearRectPrototype>();
            _RegionAddCell = Get("RegionAddCell").ToDelegate<RegionAddCellPrototype>();
            _RegionAddCellAtLoc = Get("RegionAddCellAtLoc").ToDelegate<RegionAddCellAtLocPrototype>();
            _RegionClearCell = Get("RegionClearCell").ToDelegate<RegionClearCellPrototype>();
            _RegionClearCellAtLoc = Get("RegionClearCellAtLoc").ToDelegate<RegionClearCellAtLocPrototype>();
            _Location = Get("Location").ToDelegate<LocationPrototype>();
            _RemoveLocation = Get("RemoveLocation").ToDelegate<RemoveLocationPrototype>();
            _MoveLocation = Get("MoveLocation").ToDelegate<MoveLocationPrototype>();
            _GetLocationX = Get("GetLocationX").ToDelegate<GetLocationXPrototype>();
            _GetLocationY = Get("GetLocationY").ToDelegate<GetLocationYPrototype>();
            _GetLocationZ = Get("GetLocationZ").ToDelegate<GetLocationZPrototype>();
            _IsUnitInRegion = Get("IsUnitInRegion").ToDelegate<IsUnitInRegionPrototype>();
            _IsPointInRegion = Get("IsPointInRegion").ToDelegate<IsPointInRegionPrototype>();
            _IsLocationInRegion = Get("IsLocationInRegion").ToDelegate<IsLocationInRegionPrototype>();
            _GetWorldBounds = Get("GetWorldBounds").ToDelegate<GetWorldBoundsPrototype>();
            _CreateTrigger = Get("CreateTrigger").ToDelegate<CreateTriggerPrototype>();
            _DestroyTrigger = Get("DestroyTrigger").ToDelegate<DestroyTriggerPrototype>();
            _ResetTrigger = Get("ResetTrigger").ToDelegate<ResetTriggerPrototype>();
            _EnableTrigger = Get("EnableTrigger").ToDelegate<EnableTriggerPrototype>();
            _DisableTrigger = Get("DisableTrigger").ToDelegate<DisableTriggerPrototype>();
            _IsTriggerEnabled = Get("IsTriggerEnabled").ToDelegate<IsTriggerEnabledPrototype>();
            _TriggerWaitOnSleeps = Get("TriggerWaitOnSleeps").ToDelegate<TriggerWaitOnSleepsPrototype>();
            _IsTriggerWaitOnSleeps = Get("IsTriggerWaitOnSleeps").ToDelegate<IsTriggerWaitOnSleepsPrototype>();
            _GetFilterUnit = Get("GetFilterUnit").ToDelegate<GetFilterUnitPrototype>();
            _GetEnumUnit = Get("GetEnumUnit").ToDelegate<GetEnumUnitPrototype>();
            _GetFilterDestructable = Get("GetFilterDestructable").ToDelegate<GetFilterDestructablePrototype>();
            _GetEnumDestructable = Get("GetEnumDestructable").ToDelegate<GetEnumDestructablePrototype>();
            _GetFilterItem = Get("GetFilterItem").ToDelegate<GetFilterItemPrototype>();
            _GetEnumItem = Get("GetEnumItem").ToDelegate<GetEnumItemPrototype>();
            _GetFilterPlayer = Get("GetFilterPlayer").ToDelegate<GetFilterPlayerPrototype>();
            _GetEnumPlayer = Get("GetEnumPlayer").ToDelegate<GetEnumPlayerPrototype>();
            _GetTriggeringTrigger = Get("GetTriggeringTrigger").ToDelegate<GetTriggeringTriggerPrototype>();
            _GetTriggerEventId = Get("GetTriggerEventId").ToDelegate<GetTriggerEventIdPrototype>();
            _GetTriggerEvalCount = Get("GetTriggerEvalCount").ToDelegate<GetTriggerEvalCountPrototype>();
            _GetTriggerExecCount = Get("GetTriggerExecCount").ToDelegate<GetTriggerExecCountPrototype>();
            _ExecuteFunc = Get("ExecuteFunc").ToDelegate<ExecuteFuncPrototype>();
            _And = Get("And").ToDelegate<AndPrototype>();
            _Or = Get("Or").ToDelegate<OrPrototype>();
            _Not = Get("Not").ToDelegate<NotPrototype>();
            _Condition = Get("Condition").ToDelegate<ConditionPrototype>();
            _DestroyCondition = Get("DestroyCondition").ToDelegate<DestroyConditionPrototype>();
            _Filter = Get("Filter").ToDelegate<FilterPrototype>();
            _DestroyFilter = Get("DestroyFilter").ToDelegate<DestroyFilterPrototype>();
            _DestroyBoolExpr = Get("DestroyBoolExpr").ToDelegate<DestroyBoolExprPrototype>();
            _TriggerRegisterVariableEvent = Get("TriggerRegisterVariableEvent").ToDelegate<TriggerRegisterVariableEventPrototype>();
            _TriggerRegisterTimerEvent = Get("TriggerRegisterTimerEvent").ToDelegate<TriggerRegisterTimerEventPrototype>();
            _TriggerRegisterTimerExpireEvent = Get("TriggerRegisterTimerExpireEvent").ToDelegate<TriggerRegisterTimerExpireEventPrototype>();
            _TriggerRegisterGameStateEvent = Get("TriggerRegisterGameStateEvent").ToDelegate<TriggerRegisterGameStateEventPrototype>();
            _TriggerRegisterDialogEvent = Get("TriggerRegisterDialogEvent").ToDelegate<TriggerRegisterDialogEventPrototype>();
            _TriggerRegisterDialogButtonEvent = Get("TriggerRegisterDialogButtonEvent").ToDelegate<TriggerRegisterDialogButtonEventPrototype>();
            _GetEventGameState = Get("GetEventGameState").ToDelegate<GetEventGameStatePrototype>();
            _TriggerRegisterGameEvent = Get("TriggerRegisterGameEvent").ToDelegate<TriggerRegisterGameEventPrototype>();
            _GetWinningPlayer = Get("GetWinningPlayer").ToDelegate<GetWinningPlayerPrototype>();
            _TriggerRegisterEnterRegion = Get("TriggerRegisterEnterRegion").ToDelegate<TriggerRegisterEnterRegionPrototype>();
            _GetTriggeringRegion = Get("GetTriggeringRegion").ToDelegate<GetTriggeringRegionPrototype>();
            _GetEnteringUnit = Get("GetEnteringUnit").ToDelegate<GetEnteringUnitPrototype>();
            _TriggerRegisterLeaveRegion = Get("TriggerRegisterLeaveRegion").ToDelegate<TriggerRegisterLeaveRegionPrototype>();
            _GetLeavingUnit = Get("GetLeavingUnit").ToDelegate<GetLeavingUnitPrototype>();
            _TriggerRegisterTrackableHitEvent = Get("TriggerRegisterTrackableHitEvent").ToDelegate<TriggerRegisterTrackableHitEventPrototype>();
            _TriggerRegisterTrackableTrackEvent = Get("TriggerRegisterTrackableTrackEvent").ToDelegate<TriggerRegisterTrackableTrackEventPrototype>();
            _GetTriggeringTrackable = Get("GetTriggeringTrackable").ToDelegate<GetTriggeringTrackablePrototype>();
            _GetClickedButton = Get("GetClickedButton").ToDelegate<GetClickedButtonPrototype>();
            _GetClickedDialog = Get("GetClickedDialog").ToDelegate<GetClickedDialogPrototype>();
            _GetTournamentFinishSoonTimeRemaining = Get("GetTournamentFinishSoonTimeRemaining").ToDelegate<GetTournamentFinishSoonTimeRemainingPrototype>();
            _GetTournamentFinishNowRule = Get("GetTournamentFinishNowRule").ToDelegate<GetTournamentFinishNowRulePrototype>();
            _GetTournamentFinishNowPlayer = Get("GetTournamentFinishNowPlayer").ToDelegate<GetTournamentFinishNowPlayerPrototype>();
            _GetTournamentScore = Get("GetTournamentScore").ToDelegate<GetTournamentScorePrototype>();
            _GetSaveBasicFilename = Get("GetSaveBasicFilename").ToDelegate<GetSaveBasicFilenamePrototype>();
            _TriggerRegisterPlayerEvent = Get("TriggerRegisterPlayerEvent").ToDelegate<TriggerRegisterPlayerEventPrototype>();
            _GetTriggerPlayer = Get("GetTriggerPlayer").ToDelegate<GetTriggerPlayerPrototype>();
            _TriggerRegisterPlayerUnitEvent = Get("TriggerRegisterPlayerUnitEvent").ToDelegate<TriggerRegisterPlayerUnitEventPrototype>();
            _GetLevelingUnit = Get("GetLevelingUnit").ToDelegate<GetLevelingUnitPrototype>();
            _GetLearningUnit = Get("GetLearningUnit").ToDelegate<GetLearningUnitPrototype>();
            _GetLearnedSkill = Get("GetLearnedSkill").ToDelegate<GetLearnedSkillPrototype>();
            _GetLearnedSkillLevel = Get("GetLearnedSkillLevel").ToDelegate<GetLearnedSkillLevelPrototype>();
            _GetRevivableUnit = Get("GetRevivableUnit").ToDelegate<GetRevivableUnitPrototype>();
            _GetRevivingUnit = Get("GetRevivingUnit").ToDelegate<GetRevivingUnitPrototype>();
            _GetAttacker = Get("GetAttacker").ToDelegate<GetAttackerPrototype>();
            _GetRescuer = Get("GetRescuer").ToDelegate<GetRescuerPrototype>();
            _GetDyingUnit = Get("GetDyingUnit").ToDelegate<GetDyingUnitPrototype>();
            _GetKillingUnit = Get("GetKillingUnit").ToDelegate<GetKillingUnitPrototype>();
            _GetDecayingUnit = Get("GetDecayingUnit").ToDelegate<GetDecayingUnitPrototype>();
            _GetConstructingStructure = Get("GetConstructingStructure").ToDelegate<GetConstructingStructurePrototype>();
            _GetCancelledStructure = Get("GetCancelledStructure").ToDelegate<GetCancelledStructurePrototype>();
            _GetConstructedStructure = Get("GetConstructedStructure").ToDelegate<GetConstructedStructurePrototype>();
            _GetResearchingUnit = Get("GetResearchingUnit").ToDelegate<GetResearchingUnitPrototype>();
            _GetResearched = Get("GetResearched").ToDelegate<GetResearchedPrototype>();
            _GetTrainedUnitType = Get("GetTrainedUnitType").ToDelegate<GetTrainedUnitTypePrototype>();
            _GetTrainedUnit = Get("GetTrainedUnit").ToDelegate<GetTrainedUnitPrototype>();
            _GetDetectedUnit = Get("GetDetectedUnit").ToDelegate<GetDetectedUnitPrototype>();
            _GetSummoningUnit = Get("GetSummoningUnit").ToDelegate<GetSummoningUnitPrototype>();
            _GetSummonedUnit = Get("GetSummonedUnit").ToDelegate<GetSummonedUnitPrototype>();
            _GetTransportUnit = Get("GetTransportUnit").ToDelegate<GetTransportUnitPrototype>();
            _GetLoadedUnit = Get("GetLoadedUnit").ToDelegate<GetLoadedUnitPrototype>();
            _GetSellingUnit = Get("GetSellingUnit").ToDelegate<GetSellingUnitPrototype>();
            _GetSoldUnit = Get("GetSoldUnit").ToDelegate<GetSoldUnitPrototype>();
            _GetBuyingUnit = Get("GetBuyingUnit").ToDelegate<GetBuyingUnitPrototype>();
            _GetSoldItem = Get("GetSoldItem").ToDelegate<GetSoldItemPrototype>();
            _GetChangingUnit = Get("GetChangingUnit").ToDelegate<GetChangingUnitPrototype>();
            _GetChangingUnitPrevOwner = Get("GetChangingUnitPrevOwner").ToDelegate<GetChangingUnitPrevOwnerPrototype>();
            _GetManipulatingUnit = Get("GetManipulatingUnit").ToDelegate<GetManipulatingUnitPrototype>();
            _GetManipulatedItem = Get("GetManipulatedItem").ToDelegate<GetManipulatedItemPrototype>();
            _GetOrderedUnit = Get("GetOrderedUnit").ToDelegate<GetOrderedUnitPrototype>();
            _GetIssuedOrderId = Get("GetIssuedOrderId").ToDelegate<GetIssuedOrderIdPrototype>();
            _GetOrderPointX = Get("GetOrderPointX").ToDelegate<GetOrderPointXPrototype>();
            _GetOrderPointY = Get("GetOrderPointY").ToDelegate<GetOrderPointYPrototype>();
            _GetOrderPointLoc = Get("GetOrderPointLoc").ToDelegate<GetOrderPointLocPrototype>();
            _GetOrderTarget = Get("GetOrderTarget").ToDelegate<GetOrderTargetPrototype>();
            _GetOrderTargetDestructable = Get("GetOrderTargetDestructable").ToDelegate<GetOrderTargetDestructablePrototype>();
            _GetOrderTargetItem = Get("GetOrderTargetItem").ToDelegate<GetOrderTargetItemPrototype>();
            _GetOrderTargetUnit = Get("GetOrderTargetUnit").ToDelegate<GetOrderTargetUnitPrototype>();
            _GetSpellAbilityUnit = Get("GetSpellAbilityUnit").ToDelegate<GetSpellAbilityUnitPrototype>();
            _GetSpellAbilityId = Get("GetSpellAbilityId").ToDelegate<GetSpellAbilityIdPrototype>();
            _GetSpellAbility = Get("GetSpellAbility").ToDelegate<GetSpellAbilityPrototype>();
            _GetSpellTargetLoc = Get("GetSpellTargetLoc").ToDelegate<GetSpellTargetLocPrototype>();
            _GetSpellTargetX = Get("GetSpellTargetX").ToDelegate<GetSpellTargetXPrototype>();
            _GetSpellTargetY = Get("GetSpellTargetY").ToDelegate<GetSpellTargetYPrototype>();
            _GetSpellTargetDestructable = Get("GetSpellTargetDestructable").ToDelegate<GetSpellTargetDestructablePrototype>();
            _GetSpellTargetItem = Get("GetSpellTargetItem").ToDelegate<GetSpellTargetItemPrototype>();
            _GetSpellTargetUnit = Get("GetSpellTargetUnit").ToDelegate<GetSpellTargetUnitPrototype>();
            _TriggerRegisterPlayerAllianceChange = Get("TriggerRegisterPlayerAllianceChange").ToDelegate<TriggerRegisterPlayerAllianceChangePrototype>();
            _TriggerRegisterPlayerStateEvent = Get("TriggerRegisterPlayerStateEvent").ToDelegate<TriggerRegisterPlayerStateEventPrototype>();
            _GetEventPlayerState = Get("GetEventPlayerState").ToDelegate<GetEventPlayerStatePrototype>();
            _TriggerRegisterPlayerChatEvent = Get("TriggerRegisterPlayerChatEvent").ToDelegate<TriggerRegisterPlayerChatEventPrototype>();
            _GetEventPlayerChatString = Get("GetEventPlayerChatString").ToDelegate<GetEventPlayerChatStringPrototype>();
            _GetEventPlayerChatStringMatched = Get("GetEventPlayerChatStringMatched").ToDelegate<GetEventPlayerChatStringMatchedPrototype>();
            _TriggerRegisterDeathEvent = Get("TriggerRegisterDeathEvent").ToDelegate<TriggerRegisterDeathEventPrototype>();
            _GetTriggerUnit = Get("GetTriggerUnit").ToDelegate<GetTriggerUnitPrototype>();
            _TriggerRegisterUnitStateEvent = Get("TriggerRegisterUnitStateEvent").ToDelegate<TriggerRegisterUnitStateEventPrototype>();
            _GetEventUnitState = Get("GetEventUnitState").ToDelegate<GetEventUnitStatePrototype>();
            _TriggerRegisterUnitEvent = Get("TriggerRegisterUnitEvent").ToDelegate<TriggerRegisterUnitEventPrototype>();
            _GetEventDamage = Get("GetEventDamage").ToDelegate<GetEventDamagePrototype>();
            _GetEventDamageSource = Get("GetEventDamageSource").ToDelegate<GetEventDamageSourcePrototype>();
            _GetEventDetectingPlayer = Get("GetEventDetectingPlayer").ToDelegate<GetEventDetectingPlayerPrototype>();
            _TriggerRegisterFilterUnitEvent = Get("TriggerRegisterFilterUnitEvent").ToDelegate<TriggerRegisterFilterUnitEventPrototype>();
            _GetEventTargetUnit = Get("GetEventTargetUnit").ToDelegate<GetEventTargetUnitPrototype>();
            _TriggerRegisterUnitInRange = Get("TriggerRegisterUnitInRange").ToDelegate<TriggerRegisterUnitInRangePrototype>();
            _TriggerAddCondition = Get("TriggerAddCondition").ToDelegate<TriggerAddConditionPrototype>();
            _TriggerRemoveCondition = Get("TriggerRemoveCondition").ToDelegate<TriggerRemoveConditionPrototype>();
            _TriggerClearConditions = Get("TriggerClearConditions").ToDelegate<TriggerClearConditionsPrototype>();
            _TriggerAddAction = Get("TriggerAddAction").ToDelegate<TriggerAddActionPrototype>();
            _TriggerRemoveAction = Get("TriggerRemoveAction").ToDelegate<TriggerRemoveActionPrototype>();
            _TriggerClearActions = Get("TriggerClearActions").ToDelegate<TriggerClearActionsPrototype>();
            _TriggerSleepAction = Get("TriggerSleepAction").ToDelegate<TriggerSleepActionPrototype>();
            _TriggerWaitForSound = Get("TriggerWaitForSound").ToDelegate<TriggerWaitForSoundPrototype>();
            _TriggerEvaluate = Get("TriggerEvaluate").ToDelegate<TriggerEvaluatePrototype>();
            _TriggerExecute = Get("TriggerExecute").ToDelegate<TriggerExecutePrototype>();
            _TriggerExecuteWait = Get("TriggerExecuteWait").ToDelegate<TriggerExecuteWaitPrototype>();
            _TriggerSyncStart = Get("TriggerSyncStart").ToDelegate<TriggerSyncStartPrototype>();
            _TriggerSyncReady = Get("TriggerSyncReady").ToDelegate<TriggerSyncReadyPrototype>();
            _GetWidgetLife = Get("GetWidgetLife").ToDelegate<GetWidgetLifePrototype>();
            _SetWidgetLife = Get("SetWidgetLife").ToDelegate<SetWidgetLifePrototype>();
            _GetWidgetX = Get("GetWidgetX").ToDelegate<GetWidgetXPrototype>();
            _GetWidgetY = Get("GetWidgetY").ToDelegate<GetWidgetYPrototype>();
            _GetTriggerWidget = Get("GetTriggerWidget").ToDelegate<GetTriggerWidgetPrototype>();
            _CreateDestructable = Get("CreateDestructable").ToDelegate<CreateDestructablePrototype>();
            _CreateDestructableZ = Get("CreateDestructableZ").ToDelegate<CreateDestructableZPrototype>();
            _CreateDeadDestructable = Get("CreateDeadDestructable").ToDelegate<CreateDeadDestructablePrototype>();
            _CreateDeadDestructableZ = Get("CreateDeadDestructableZ").ToDelegate<CreateDeadDestructableZPrototype>();
            _RemoveDestructable = Get("RemoveDestructable").ToDelegate<RemoveDestructablePrototype>();
            _KillDestructable = Get("KillDestructable").ToDelegate<KillDestructablePrototype>();
            _SetDestructableInvulnerable = Get("SetDestructableInvulnerable").ToDelegate<SetDestructableInvulnerablePrototype>();
            _IsDestructableInvulnerable = Get("IsDestructableInvulnerable").ToDelegate<IsDestructableInvulnerablePrototype>();
            _EnumDestructablesInRect = Get("EnumDestructablesInRect").ToDelegate<EnumDestructablesInRectPrototype>();
            _GetDestructableTypeId = Get("GetDestructableTypeId").ToDelegate<GetDestructableTypeIdPrototype>();
            _GetDestructableX = Get("GetDestructableX").ToDelegate<GetDestructableXPrototype>();
            _GetDestructableY = Get("GetDestructableY").ToDelegate<GetDestructableYPrototype>();
            _SetDestructableLife = Get("SetDestructableLife").ToDelegate<SetDestructableLifePrototype>();
            _GetDestructableLife = Get("GetDestructableLife").ToDelegate<GetDestructableLifePrototype>();
            _SetDestructableMaxLife = Get("SetDestructableMaxLife").ToDelegate<SetDestructableMaxLifePrototype>();
            _GetDestructableMaxLife = Get("GetDestructableMaxLife").ToDelegate<GetDestructableMaxLifePrototype>();
            _DestructableRestoreLife = Get("DestructableRestoreLife").ToDelegate<DestructableRestoreLifePrototype>();
            _QueueDestructableAnimation = Get("QueueDestructableAnimation").ToDelegate<QueueDestructableAnimationPrototype>();
            _SetDestructableAnimation = Get("SetDestructableAnimation").ToDelegate<SetDestructableAnimationPrototype>();
            _SetDestructableAnimationSpeed = Get("SetDestructableAnimationSpeed").ToDelegate<SetDestructableAnimationSpeedPrototype>();
            _ShowDestructable = Get("ShowDestructable").ToDelegate<ShowDestructablePrototype>();
            _GetDestructableOccluderHeight = Get("GetDestructableOccluderHeight").ToDelegate<GetDestructableOccluderHeightPrototype>();
            _SetDestructableOccluderHeight = Get("SetDestructableOccluderHeight").ToDelegate<SetDestructableOccluderHeightPrototype>();
            _GetDestructableName = Get("GetDestructableName").ToDelegate<GetDestructableNamePrototype>();
            _GetTriggerDestructable = Get("GetTriggerDestructable").ToDelegate<GetTriggerDestructablePrototype>();
            _CreateItem = Get("CreateItem").ToDelegate<CreateItemPrototype>();
            _RemoveItem = Get("RemoveItem").ToDelegate<RemoveItemPrototype>();
            _GetItemPlayer = Get("GetItemPlayer").ToDelegate<GetItemPlayerPrototype>();
            _GetItemTypeId = Get("GetItemTypeId").ToDelegate<GetItemTypeIdPrototype>();
            _GetItemX = Get("GetItemX").ToDelegate<GetItemXPrototype>();
            _GetItemY = Get("GetItemY").ToDelegate<GetItemYPrototype>();
            _SetItemPosition = Get("SetItemPosition").ToDelegate<SetItemPositionPrototype>();
            _SetItemDropOnDeath = Get("SetItemDropOnDeath").ToDelegate<SetItemDropOnDeathPrototype>();
            _SetItemDroppable = Get("SetItemDroppable").ToDelegate<SetItemDroppablePrototype>();
            _SetItemPawnable = Get("SetItemPawnable").ToDelegate<SetItemPawnablePrototype>();
            _SetItemPlayer = Get("SetItemPlayer").ToDelegate<SetItemPlayerPrototype>();
            _SetItemInvulnerable = Get("SetItemInvulnerable").ToDelegate<SetItemInvulnerablePrototype>();
            _IsItemInvulnerable = Get("IsItemInvulnerable").ToDelegate<IsItemInvulnerablePrototype>();
            _SetItemVisible = Get("SetItemVisible").ToDelegate<SetItemVisiblePrototype>();
            _IsItemVisible = Get("IsItemVisible").ToDelegate<IsItemVisiblePrototype>();
            _IsItemOwned = Get("IsItemOwned").ToDelegate<IsItemOwnedPrototype>();
            _IsItemPowerup = Get("IsItemPowerup").ToDelegate<IsItemPowerupPrototype>();
            _IsItemSellable = Get("IsItemSellable").ToDelegate<IsItemSellablePrototype>();
            _IsItemPawnable = Get("IsItemPawnable").ToDelegate<IsItemPawnablePrototype>();
            _IsItemIdPowerup = Get("IsItemIdPowerup").ToDelegate<IsItemIdPowerupPrototype>();
            _IsItemIdSellable = Get("IsItemIdSellable").ToDelegate<IsItemIdSellablePrototype>();
            _IsItemIdPawnable = Get("IsItemIdPawnable").ToDelegate<IsItemIdPawnablePrototype>();
            _EnumItemsInRect = Get("EnumItemsInRect").ToDelegate<EnumItemsInRectPrototype>();
            _GetItemLevel = Get("GetItemLevel").ToDelegate<GetItemLevelPrototype>();
            _GetItemType = Get("GetItemType").ToDelegate<GetItemTypePrototype>();
            _SetItemDropID = Get("SetItemDropID").ToDelegate<SetItemDropIDPrototype>();
            _GetItemName = Get("GetItemName").ToDelegate<GetItemNamePrototype>();
            _GetItemCharges = Get("GetItemCharges").ToDelegate<GetItemChargesPrototype>();
            _SetItemCharges = Get("SetItemCharges").ToDelegate<SetItemChargesPrototype>();
            _GetItemUserData = Get("GetItemUserData").ToDelegate<GetItemUserDataPrototype>();
            _SetItemUserData = Get("SetItemUserData").ToDelegate<SetItemUserDataPrototype>();
            _CreateUnit = Get("CreateUnit").ToDelegate<CreateUnitPrototype>();
            _CreateUnitByName = Get("CreateUnitByName").ToDelegate<CreateUnitByNamePrototype>();
            _CreateUnitAtLoc = Get("CreateUnitAtLoc").ToDelegate<CreateUnitAtLocPrototype>();
            _CreateUnitAtLocByName = Get("CreateUnitAtLocByName").ToDelegate<CreateUnitAtLocByNamePrototype>();
            _CreateCorpse = Get("CreateCorpse").ToDelegate<CreateCorpsePrototype>();
            _KillUnit = Get("KillUnit").ToDelegate<KillUnitPrototype>();
            _RemoveUnit = Get("RemoveUnit").ToDelegate<RemoveUnitPrototype>();
            _ShowUnit = Get("ShowUnit").ToDelegate<ShowUnitPrototype>();
            _SetUnitState = Get("SetUnitState").ToDelegate<SetUnitStatePrototype>();
            _SetUnitX = Get("SetUnitX").ToDelegate<SetUnitXPrototype>();
            _SetUnitY = Get("SetUnitY").ToDelegate<SetUnitYPrototype>();
            _SetUnitPosition = Get("SetUnitPosition").ToDelegate<SetUnitPositionPrototype>();
            _SetUnitPositionLoc = Get("SetUnitPositionLoc").ToDelegate<SetUnitPositionLocPrototype>();
            _SetUnitFacing = Get("SetUnitFacing").ToDelegate<SetUnitFacingPrototype>();
            _SetUnitFacingTimed = Get("SetUnitFacingTimed").ToDelegate<SetUnitFacingTimedPrototype>();
            _SetUnitMoveSpeed = Get("SetUnitMoveSpeed").ToDelegate<SetUnitMoveSpeedPrototype>();
            _SetUnitFlyHeight = Get("SetUnitFlyHeight").ToDelegate<SetUnitFlyHeightPrototype>();
            _SetUnitTurnSpeed = Get("SetUnitTurnSpeed").ToDelegate<SetUnitTurnSpeedPrototype>();
            _SetUnitPropWindow = Get("SetUnitPropWindow").ToDelegate<SetUnitPropWindowPrototype>();
            _SetUnitAcquireRange = Get("SetUnitAcquireRange").ToDelegate<SetUnitAcquireRangePrototype>();
            _SetUnitCreepGuard = Get("SetUnitCreepGuard").ToDelegate<SetUnitCreepGuardPrototype>();
            _GetUnitAcquireRange = Get("GetUnitAcquireRange").ToDelegate<GetUnitAcquireRangePrototype>();
            _GetUnitTurnSpeed = Get("GetUnitTurnSpeed").ToDelegate<GetUnitTurnSpeedPrototype>();
            _GetUnitPropWindow = Get("GetUnitPropWindow").ToDelegate<GetUnitPropWindowPrototype>();
            _GetUnitFlyHeight = Get("GetUnitFlyHeight").ToDelegate<GetUnitFlyHeightPrototype>();
            _GetUnitDefaultAcquireRange = Get("GetUnitDefaultAcquireRange").ToDelegate<GetUnitDefaultAcquireRangePrototype>();
            _GetUnitDefaultTurnSpeed = Get("GetUnitDefaultTurnSpeed").ToDelegate<GetUnitDefaultTurnSpeedPrototype>();
            _GetUnitDefaultPropWindow = Get("GetUnitDefaultPropWindow").ToDelegate<GetUnitDefaultPropWindowPrototype>();
            _GetUnitDefaultFlyHeight = Get("GetUnitDefaultFlyHeight").ToDelegate<GetUnitDefaultFlyHeightPrototype>();
            _SetUnitOwner = Get("SetUnitOwner").ToDelegate<SetUnitOwnerPrototype>();
            _SetUnitColor = Get("SetUnitColor").ToDelegate<SetUnitColorPrototype>();
            _SetUnitScale = Get("SetUnitScale").ToDelegate<SetUnitScalePrototype>();
            _SetUnitTimeScale = Get("SetUnitTimeScale").ToDelegate<SetUnitTimeScalePrototype>();
            _SetUnitBlendTime = Get("SetUnitBlendTime").ToDelegate<SetUnitBlendTimePrototype>();
            _SetUnitVertexColor = Get("SetUnitVertexColor").ToDelegate<SetUnitVertexColorPrototype>();
            _QueueUnitAnimation = Get("QueueUnitAnimation").ToDelegate<QueueUnitAnimationPrototype>();
            _SetUnitAnimation = Get("SetUnitAnimation").ToDelegate<SetUnitAnimationPrototype>();
            _SetUnitAnimationByIndex = Get("SetUnitAnimationByIndex").ToDelegate<SetUnitAnimationByIndexPrototype>();
            _SetUnitAnimationWithRarity = Get("SetUnitAnimationWithRarity").ToDelegate<SetUnitAnimationWithRarityPrototype>();
            _AddUnitAnimationProperties = Get("AddUnitAnimationProperties").ToDelegate<AddUnitAnimationPropertiesPrototype>();
            _SetUnitLookAt = Get("SetUnitLookAt").ToDelegate<SetUnitLookAtPrototype>();
            _ResetUnitLookAt = Get("ResetUnitLookAt").ToDelegate<ResetUnitLookAtPrototype>();
            _SetUnitRescuable = Get("SetUnitRescuable").ToDelegate<SetUnitRescuablePrototype>();
            _SetUnitRescueRange = Get("SetUnitRescueRange").ToDelegate<SetUnitRescueRangePrototype>();
            _SetHeroStr = Get("SetHeroStr").ToDelegate<SetHeroStrPrototype>();
            _SetHeroAgi = Get("SetHeroAgi").ToDelegate<SetHeroAgiPrototype>();
            _SetHeroInt = Get("SetHeroInt").ToDelegate<SetHeroIntPrototype>();
            _GetHeroStr = Get("GetHeroStr").ToDelegate<GetHeroStrPrototype>();
            _GetHeroAgi = Get("GetHeroAgi").ToDelegate<GetHeroAgiPrototype>();
            _GetHeroInt = Get("GetHeroInt").ToDelegate<GetHeroIntPrototype>();
            _UnitStripHeroLevel = Get("UnitStripHeroLevel").ToDelegate<UnitStripHeroLevelPrototype>();
            _GetHeroXP = Get("GetHeroXP").ToDelegate<GetHeroXPPrototype>();
            _SetHeroXP = Get("SetHeroXP").ToDelegate<SetHeroXPPrototype>();
            _GetHeroSkillPoints = Get("GetHeroSkillPoints").ToDelegate<GetHeroSkillPointsPrototype>();
            _UnitModifySkillPoints = Get("UnitModifySkillPoints").ToDelegate<UnitModifySkillPointsPrototype>();
            _AddHeroXP = Get("AddHeroXP").ToDelegate<AddHeroXPPrototype>();
            _SetHeroLevel = Get("SetHeroLevel").ToDelegate<SetHeroLevelPrototype>();
            _GetHeroLevel = Get("GetHeroLevel").ToDelegate<GetHeroLevelPrototype>();
            _GetUnitLevel = Get("GetUnitLevel").ToDelegate<GetUnitLevelPrototype>();
            _GetHeroProperName = Get("GetHeroProperName").ToDelegate<GetHeroProperNamePrototype>();
            _SuspendHeroXP = Get("SuspendHeroXP").ToDelegate<SuspendHeroXPPrototype>();
            _IsSuspendedXP = Get("IsSuspendedXP").ToDelegate<IsSuspendedXPPrototype>();
            _SelectHeroSkill = Get("SelectHeroSkill").ToDelegate<SelectHeroSkillPrototype>();
            _GetUnitAbilityLevel = Get("GetUnitAbilityLevel").ToDelegate<GetUnitAbilityLevelPrototype>();
            _DecUnitAbilityLevel = Get("DecUnitAbilityLevel").ToDelegate<DecUnitAbilityLevelPrototype>();
            _IncUnitAbilityLevel = Get("IncUnitAbilityLevel").ToDelegate<IncUnitAbilityLevelPrototype>();
            _SetUnitAbilityLevel = Get("SetUnitAbilityLevel").ToDelegate<SetUnitAbilityLevelPrototype>();
            _ReviveHero = Get("ReviveHero").ToDelegate<ReviveHeroPrototype>();
            _ReviveHeroLoc = Get("ReviveHeroLoc").ToDelegate<ReviveHeroLocPrototype>();
            _SetUnitExploded = Get("SetUnitExploded").ToDelegate<SetUnitExplodedPrototype>();
            _SetUnitInvulnerable = Get("SetUnitInvulnerable").ToDelegate<SetUnitInvulnerablePrototype>();
            _PauseUnit = Get("PauseUnit").ToDelegate<PauseUnitPrototype>();
            _IsUnitPaused = Get("IsUnitPaused").ToDelegate<IsUnitPausedPrototype>();
            _SetUnitPathing = Get("SetUnitPathing").ToDelegate<SetUnitPathingPrototype>();
            _ClearSelection = Get("ClearSelection").ToDelegate<ClearSelectionPrototype>();
            _SelectUnit = Get("SelectUnit").ToDelegate<SelectUnitPrototype>();
            _GetUnitPointValue = Get("GetUnitPointValue").ToDelegate<GetUnitPointValuePrototype>();
            _GetUnitPointValueByType = Get("GetUnitPointValueByType").ToDelegate<GetUnitPointValueByTypePrototype>();
            _UnitAddItem = Get("UnitAddItem").ToDelegate<UnitAddItemPrototype>();
            _UnitAddItemById = Get("UnitAddItemById").ToDelegate<UnitAddItemByIdPrototype>();
            _UnitAddItemToSlotById = Get("UnitAddItemToSlotById").ToDelegate<UnitAddItemToSlotByIdPrototype>();
            _UnitRemoveItem = Get("UnitRemoveItem").ToDelegate<UnitRemoveItemPrototype>();
            _UnitRemoveItemFromSlot = Get("UnitRemoveItemFromSlot").ToDelegate<UnitRemoveItemFromSlotPrototype>();
            _UnitHasItem = Get("UnitHasItem").ToDelegate<UnitHasItemPrototype>();
            _UnitItemInSlot = Get("UnitItemInSlot").ToDelegate<UnitItemInSlotPrototype>();
            _UnitInventorySize = Get("UnitInventorySize").ToDelegate<UnitInventorySizePrototype>();
            _UnitDropItemPoint = Get("UnitDropItemPoint").ToDelegate<UnitDropItemPointPrototype>();
            _UnitDropItemSlot = Get("UnitDropItemSlot").ToDelegate<UnitDropItemSlotPrototype>();
            _UnitDropItemTarget = Get("UnitDropItemTarget").ToDelegate<UnitDropItemTargetPrototype>();
            _UnitUseItem = Get("UnitUseItem").ToDelegate<UnitUseItemPrototype>();
            _UnitUseItemPoint = Get("UnitUseItemPoint").ToDelegate<UnitUseItemPointPrototype>();
            _UnitUseItemTarget = Get("UnitUseItemTarget").ToDelegate<UnitUseItemTargetPrototype>();
            _GetUnitX = Get("GetUnitX").ToDelegate<GetUnitXPrototype>();
            _GetUnitY = Get("GetUnitY").ToDelegate<GetUnitYPrototype>();
            _GetUnitLoc = Get("GetUnitLoc").ToDelegate<GetUnitLocPrototype>();
            _GetUnitFacing = Get("GetUnitFacing").ToDelegate<GetUnitFacingPrototype>();
            _GetUnitMoveSpeed = Get("GetUnitMoveSpeed").ToDelegate<GetUnitMoveSpeedPrototype>();
            _GetUnitDefaultMoveSpeed = Get("GetUnitDefaultMoveSpeed").ToDelegate<GetUnitDefaultMoveSpeedPrototype>();
            _GetUnitState = Get("GetUnitState").ToDelegate<GetUnitStatePrototype>();
            _GetOwningPlayer = Get("GetOwningPlayer").ToDelegate<GetOwningPlayerPrototype>();
            _GetUnitTypeId = Get("GetUnitTypeId").ToDelegate<GetUnitTypeIdPrototype>();
            _GetUnitRace = Get("GetUnitRace").ToDelegate<GetUnitRacePrototype>();
            _GetUnitName = Get("GetUnitName").ToDelegate<GetUnitNamePrototype>();
            _GetUnitFoodUsed = Get("GetUnitFoodUsed").ToDelegate<GetUnitFoodUsedPrototype>();
            _GetUnitFoodMade = Get("GetUnitFoodMade").ToDelegate<GetUnitFoodMadePrototype>();
            _GetFoodMade = Get("GetFoodMade").ToDelegate<GetFoodMadePrototype>();
            _GetFoodUsed = Get("GetFoodUsed").ToDelegate<GetFoodUsedPrototype>();
            _SetUnitUseFood = Get("SetUnitUseFood").ToDelegate<SetUnitUseFoodPrototype>();
            _GetUnitRallyPoint = Get("GetUnitRallyPoint").ToDelegate<GetUnitRallyPointPrototype>();
            _GetUnitRallyUnit = Get("GetUnitRallyUnit").ToDelegate<GetUnitRallyUnitPrototype>();
            _GetUnitRallyDestructable = Get("GetUnitRallyDestructable").ToDelegate<GetUnitRallyDestructablePrototype>();
            _IsUnitInGroup = Get("IsUnitInGroup").ToDelegate<IsUnitInGroupPrototype>();
            _IsUnitInForce = Get("IsUnitInForce").ToDelegate<IsUnitInForcePrototype>();
            _IsUnitOwnedByPlayer = Get("IsUnitOwnedByPlayer").ToDelegate<IsUnitOwnedByPlayerPrototype>();
            _IsUnitAlly = Get("IsUnitAlly").ToDelegate<IsUnitAllyPrototype>();
            _IsUnitEnemy = Get("IsUnitEnemy").ToDelegate<IsUnitEnemyPrototype>();
            _IsUnitVisible = Get("IsUnitVisible").ToDelegate<IsUnitVisiblePrototype>();
            _IsUnitDetected = Get("IsUnitDetected").ToDelegate<IsUnitDetectedPrototype>();
            _IsUnitInvisible = Get("IsUnitInvisible").ToDelegate<IsUnitInvisiblePrototype>();
            _IsUnitFogged = Get("IsUnitFogged").ToDelegate<IsUnitFoggedPrototype>();
            _IsUnitMasked = Get("IsUnitMasked").ToDelegate<IsUnitMaskedPrototype>();
            _IsUnitSelected = Get("IsUnitSelected").ToDelegate<IsUnitSelectedPrototype>();
            _IsUnitRace = Get("IsUnitRace").ToDelegate<IsUnitRacePrototype>();
            _IsUnitType = Get("IsUnitType").ToDelegate<IsUnitTypePrototype>();
            _IsUnit = Get("IsUnit").ToDelegate<IsUnitPrototype>();
            _IsUnitInRange = Get("IsUnitInRange").ToDelegate<IsUnitInRangePrototype>();
            _IsUnitInRangeXY = Get("IsUnitInRangeXY").ToDelegate<IsUnitInRangeXYPrototype>();
            _IsUnitInRangeLoc = Get("IsUnitInRangeLoc").ToDelegate<IsUnitInRangeLocPrototype>();
            _IsUnitHidden = Get("IsUnitHidden").ToDelegate<IsUnitHiddenPrototype>();
            _IsUnitIllusion = Get("IsUnitIllusion").ToDelegate<IsUnitIllusionPrototype>();
            _IsUnitInTransport = Get("IsUnitInTransport").ToDelegate<IsUnitInTransportPrototype>();
            _IsUnitLoaded = Get("IsUnitLoaded").ToDelegate<IsUnitLoadedPrototype>();
            _IsHeroUnitId = Get("IsHeroUnitId").ToDelegate<IsHeroUnitIdPrototype>();
            _IsUnitIdType = Get("IsUnitIdType").ToDelegate<IsUnitIdTypePrototype>();
            _UnitShareVision = Get("UnitShareVision").ToDelegate<UnitShareVisionPrototype>();
            _UnitSuspendDecay = Get("UnitSuspendDecay").ToDelegate<UnitSuspendDecayPrototype>();
            _UnitAddType = Get("UnitAddType").ToDelegate<UnitAddTypePrototype>();
            _UnitRemoveType = Get("UnitRemoveType").ToDelegate<UnitRemoveTypePrototype>();
            _UnitAddAbility = Get("UnitAddAbility").ToDelegate<UnitAddAbilityPrototype>();
            _UnitRemoveAbility = Get("UnitRemoveAbility").ToDelegate<UnitRemoveAbilityPrototype>();
            _UnitMakeAbilityPermanent = Get("UnitMakeAbilityPermanent").ToDelegate<UnitMakeAbilityPermanentPrototype>();
            _UnitRemoveBuffs = Get("UnitRemoveBuffs").ToDelegate<UnitRemoveBuffsPrototype>();
            _UnitRemoveBuffsEx = Get("UnitRemoveBuffsEx").ToDelegate<UnitRemoveBuffsExPrototype>();
            _UnitHasBuffsEx = Get("UnitHasBuffsEx").ToDelegate<UnitHasBuffsExPrototype>();
            _UnitCountBuffsEx = Get("UnitCountBuffsEx").ToDelegate<UnitCountBuffsExPrototype>();
            _UnitAddSleep = Get("UnitAddSleep").ToDelegate<UnitAddSleepPrototype>();
            _UnitCanSleep = Get("UnitCanSleep").ToDelegate<UnitCanSleepPrototype>();
            _UnitAddSleepPerm = Get("UnitAddSleepPerm").ToDelegate<UnitAddSleepPermPrototype>();
            _UnitCanSleepPerm = Get("UnitCanSleepPerm").ToDelegate<UnitCanSleepPermPrototype>();
            _UnitIsSleeping = Get("UnitIsSleeping").ToDelegate<UnitIsSleepingPrototype>();
            _UnitWakeUp = Get("UnitWakeUp").ToDelegate<UnitWakeUpPrototype>();
            _UnitApplyTimedLife = Get("UnitApplyTimedLife").ToDelegate<UnitApplyTimedLifePrototype>();
            _UnitIgnoreAlarm = Get("UnitIgnoreAlarm").ToDelegate<UnitIgnoreAlarmPrototype>();
            _UnitIgnoreAlarmToggled = Get("UnitIgnoreAlarmToggled").ToDelegate<UnitIgnoreAlarmToggledPrototype>();
            _UnitResetCooldown = Get("UnitResetCooldown").ToDelegate<UnitResetCooldownPrototype>();
            _UnitSetConstructionProgress = Get("UnitSetConstructionProgress").ToDelegate<UnitSetConstructionProgressPrototype>();
            _UnitSetUpgradeProgress = Get("UnitSetUpgradeProgress").ToDelegate<UnitSetUpgradeProgressPrototype>();
            _UnitPauseTimedLife = Get("UnitPauseTimedLife").ToDelegate<UnitPauseTimedLifePrototype>();
            _UnitSetUsesAltIcon = Get("UnitSetUsesAltIcon").ToDelegate<UnitSetUsesAltIconPrototype>();
            _UnitDamagePoint = Get("UnitDamagePoint").ToDelegate<UnitDamagePointPrototype>();
            _UnitDamageTarget = Get("UnitDamageTarget").ToDelegate<UnitDamageTargetPrototype>();
            _IssueImmediateOrder = Get("IssueImmediateOrder").ToDelegate<IssueImmediateOrderPrototype>();
            _IssueImmediateOrderById = Get("IssueImmediateOrderById").ToDelegate<IssueImmediateOrderByIdPrototype>();
            _IssuePointOrder = Get("IssuePointOrder").ToDelegate<IssuePointOrderPrototype>();
            _IssuePointOrderLoc = Get("IssuePointOrderLoc").ToDelegate<IssuePointOrderLocPrototype>();
            _IssuePointOrderById = Get("IssuePointOrderById").ToDelegate<IssuePointOrderByIdPrototype>();
            _IssuePointOrderByIdLoc = Get("IssuePointOrderByIdLoc").ToDelegate<IssuePointOrderByIdLocPrototype>();
            _IssueTargetOrder = Get("IssueTargetOrder").ToDelegate<IssueTargetOrderPrototype>();
            _IssueTargetOrderById = Get("IssueTargetOrderById").ToDelegate<IssueTargetOrderByIdPrototype>();
            _IssueInstantPointOrder = Get("IssueInstantPointOrder").ToDelegate<IssueInstantPointOrderPrototype>();
            _IssueInstantPointOrderById = Get("IssueInstantPointOrderById").ToDelegate<IssueInstantPointOrderByIdPrototype>();
            _IssueInstantTargetOrder = Get("IssueInstantTargetOrder").ToDelegate<IssueInstantTargetOrderPrototype>();
            _IssueInstantTargetOrderById = Get("IssueInstantTargetOrderById").ToDelegate<IssueInstantTargetOrderByIdPrototype>();
            _IssueBuildOrder = Get("IssueBuildOrder").ToDelegate<IssueBuildOrderPrototype>();
            _IssueBuildOrderById = Get("IssueBuildOrderById").ToDelegate<IssueBuildOrderByIdPrototype>();
            _IssueNeutralImmediateOrder = Get("IssueNeutralImmediateOrder").ToDelegate<IssueNeutralImmediateOrderPrototype>();
            _IssueNeutralImmediateOrderById = Get("IssueNeutralImmediateOrderById").ToDelegate<IssueNeutralImmediateOrderByIdPrototype>();
            _IssueNeutralPointOrder = Get("IssueNeutralPointOrder").ToDelegate<IssueNeutralPointOrderPrototype>();
            _IssueNeutralPointOrderById = Get("IssueNeutralPointOrderById").ToDelegate<IssueNeutralPointOrderByIdPrototype>();
            _IssueNeutralTargetOrder = Get("IssueNeutralTargetOrder").ToDelegate<IssueNeutralTargetOrderPrototype>();
            _IssueNeutralTargetOrderById = Get("IssueNeutralTargetOrderById").ToDelegate<IssueNeutralTargetOrderByIdPrototype>();
            _GetUnitCurrentOrder = Get("GetUnitCurrentOrder").ToDelegate<GetUnitCurrentOrderPrototype>();
            _SetResourceAmount = Get("SetResourceAmount").ToDelegate<SetResourceAmountPrototype>();
            _AddResourceAmount = Get("AddResourceAmount").ToDelegate<AddResourceAmountPrototype>();
            _GetResourceAmount = Get("GetResourceAmount").ToDelegate<GetResourceAmountPrototype>();
            _WaygateGetDestinationX = Get("WaygateGetDestinationX").ToDelegate<WaygateGetDestinationXPrototype>();
            _WaygateGetDestinationY = Get("WaygateGetDestinationY").ToDelegate<WaygateGetDestinationYPrototype>();
            _WaygateSetDestination = Get("WaygateSetDestination").ToDelegate<WaygateSetDestinationPrototype>();
            _WaygateActivate = Get("WaygateActivate").ToDelegate<WaygateActivatePrototype>();
            _WaygateIsActive = Get("WaygateIsActive").ToDelegate<WaygateIsActivePrototype>();
            _AddItemToAllStock = Get("AddItemToAllStock").ToDelegate<AddItemToAllStockPrototype>();
            _AddItemToStock = Get("AddItemToStock").ToDelegate<AddItemToStockPrototype>();
            _AddUnitToAllStock = Get("AddUnitToAllStock").ToDelegate<AddUnitToAllStockPrototype>();
            _AddUnitToStock = Get("AddUnitToStock").ToDelegate<AddUnitToStockPrototype>();
            _RemoveItemFromAllStock = Get("RemoveItemFromAllStock").ToDelegate<RemoveItemFromAllStockPrototype>();
            _RemoveItemFromStock = Get("RemoveItemFromStock").ToDelegate<RemoveItemFromStockPrototype>();
            _RemoveUnitFromAllStock = Get("RemoveUnitFromAllStock").ToDelegate<RemoveUnitFromAllStockPrototype>();
            _RemoveUnitFromStock = Get("RemoveUnitFromStock").ToDelegate<RemoveUnitFromStockPrototype>();
            _SetAllItemTypeSlots = Get("SetAllItemTypeSlots").ToDelegate<SetAllItemTypeSlotsPrototype>();
            _SetAllUnitTypeSlots = Get("SetAllUnitTypeSlots").ToDelegate<SetAllUnitTypeSlotsPrototype>();
            _SetItemTypeSlots = Get("SetItemTypeSlots").ToDelegate<SetItemTypeSlotsPrototype>();
            _SetUnitTypeSlots = Get("SetUnitTypeSlots").ToDelegate<SetUnitTypeSlotsPrototype>();
            _GetUnitUserData = Get("GetUnitUserData").ToDelegate<GetUnitUserDataPrototype>();
            _SetUnitUserData = Get("SetUnitUserData").ToDelegate<SetUnitUserDataPrototype>();
            _Player = Get("Player").ToDelegate<PlayerPrototype>();
            _GetLocalPlayer = Get("GetLocalPlayer").ToDelegate<GetLocalPlayerPrototype>();
            _IsPlayerAlly = Get("IsPlayerAlly").ToDelegate<IsPlayerAllyPrototype>();
            _IsPlayerEnemy = Get("IsPlayerEnemy").ToDelegate<IsPlayerEnemyPrototype>();
            _IsPlayerInForce = Get("IsPlayerInForce").ToDelegate<IsPlayerInForcePrototype>();
            _IsPlayerObserver = Get("IsPlayerObserver").ToDelegate<IsPlayerObserverPrototype>();
            _IsVisibleToPlayer = Get("IsVisibleToPlayer").ToDelegate<IsVisibleToPlayerPrototype>();
            _IsLocationVisibleToPlayer = Get("IsLocationVisibleToPlayer").ToDelegate<IsLocationVisibleToPlayerPrototype>();
            _IsFoggedToPlayer = Get("IsFoggedToPlayer").ToDelegate<IsFoggedToPlayerPrototype>();
            _IsLocationFoggedToPlayer = Get("IsLocationFoggedToPlayer").ToDelegate<IsLocationFoggedToPlayerPrototype>();
            _IsMaskedToPlayer = Get("IsMaskedToPlayer").ToDelegate<IsMaskedToPlayerPrototype>();
            _IsLocationMaskedToPlayer = Get("IsLocationMaskedToPlayer").ToDelegate<IsLocationMaskedToPlayerPrototype>();
            _GetPlayerRace = Get("GetPlayerRace").ToDelegate<GetPlayerRacePrototype>();
            _GetPlayerId = Get("GetPlayerId").ToDelegate<GetPlayerIdPrototype>();
            _GetPlayerUnitCount = Get("GetPlayerUnitCount").ToDelegate<GetPlayerUnitCountPrototype>();
            _GetPlayerTypedUnitCount = Get("GetPlayerTypedUnitCount").ToDelegate<GetPlayerTypedUnitCountPrototype>();
            _GetPlayerStructureCount = Get("GetPlayerStructureCount").ToDelegate<GetPlayerStructureCountPrototype>();
            _GetPlayerState = Get("GetPlayerState").ToDelegate<GetPlayerStatePrototype>();
            _GetPlayerScore = Get("GetPlayerScore").ToDelegate<GetPlayerScorePrototype>();
            _GetPlayerAlliance = Get("GetPlayerAlliance").ToDelegate<GetPlayerAlliancePrototype>();
            _GetPlayerHandicap = Get("GetPlayerHandicap").ToDelegate<GetPlayerHandicapPrototype>();
            _GetPlayerHandicapXP = Get("GetPlayerHandicapXP").ToDelegate<GetPlayerHandicapXPPrototype>();
            _SetPlayerHandicap = Get("SetPlayerHandicap").ToDelegate<SetPlayerHandicapPrototype>();
            _SetPlayerHandicapXP = Get("SetPlayerHandicapXP").ToDelegate<SetPlayerHandicapXPPrototype>();
            _SetPlayerTechMaxAllowed = Get("SetPlayerTechMaxAllowed").ToDelegate<SetPlayerTechMaxAllowedPrototype>();
            _GetPlayerTechMaxAllowed = Get("GetPlayerTechMaxAllowed").ToDelegate<GetPlayerTechMaxAllowedPrototype>();
            _AddPlayerTechResearched = Get("AddPlayerTechResearched").ToDelegate<AddPlayerTechResearchedPrototype>();
            _SetPlayerTechResearched = Get("SetPlayerTechResearched").ToDelegate<SetPlayerTechResearchedPrototype>();
            _GetPlayerTechResearched = Get("GetPlayerTechResearched").ToDelegate<GetPlayerTechResearchedPrototype>();
            _GetPlayerTechCount = Get("GetPlayerTechCount").ToDelegate<GetPlayerTechCountPrototype>();
            _SetPlayerUnitsOwner = Get("SetPlayerUnitsOwner").ToDelegate<SetPlayerUnitsOwnerPrototype>();
            _CripplePlayer = Get("CripplePlayer").ToDelegate<CripplePlayerPrototype>();
            _SetPlayerAbilityAvailable = Get("SetPlayerAbilityAvailable").ToDelegate<SetPlayerAbilityAvailablePrototype>();
            _SetPlayerState = Get("SetPlayerState").ToDelegate<SetPlayerStatePrototype>();
            _RemovePlayer = Get("RemovePlayer").ToDelegate<RemovePlayerPrototype>();
            _CachePlayerHeroData = Get("CachePlayerHeroData").ToDelegate<CachePlayerHeroDataPrototype>();
            _SetFogStateRect = Get("SetFogStateRect").ToDelegate<SetFogStateRectPrototype>();
            _SetFogStateRadius = Get("SetFogStateRadius").ToDelegate<SetFogStateRadiusPrototype>();
            _SetFogStateRadiusLoc = Get("SetFogStateRadiusLoc").ToDelegate<SetFogStateRadiusLocPrototype>();
            _FogMaskEnable = Get("FogMaskEnable").ToDelegate<FogMaskEnablePrototype>();
            _IsFogMaskEnabled = Get("IsFogMaskEnabled").ToDelegate<IsFogMaskEnabledPrototype>();
            _FogEnable = Get("FogEnable").ToDelegate<FogEnablePrototype>();
            _IsFogEnabled = Get("IsFogEnabled").ToDelegate<IsFogEnabledPrototype>();
            _CreateFogModifierRect = Get("CreateFogModifierRect").ToDelegate<CreateFogModifierRectPrototype>();
            _CreateFogModifierRadius = Get("CreateFogModifierRadius").ToDelegate<CreateFogModifierRadiusPrototype>();
            _CreateFogModifierRadiusLoc = Get("CreateFogModifierRadiusLoc").ToDelegate<CreateFogModifierRadiusLocPrototype>();
            _DestroyFogModifier = Get("DestroyFogModifier").ToDelegate<DestroyFogModifierPrototype>();
            _FogModifierStart = Get("FogModifierStart").ToDelegate<FogModifierStartPrototype>();
            _FogModifierStop = Get("FogModifierStop").ToDelegate<FogModifierStopPrototype>();
            _VersionGet = Get("VersionGet").ToDelegate<VersionGetPrototype>();
            _VersionCompatible = Get("VersionCompatible").ToDelegate<VersionCompatiblePrototype>();
            _VersionSupported = Get("VersionSupported").ToDelegate<VersionSupportedPrototype>();
            _EndGame = Get("EndGame").ToDelegate<EndGamePrototype>();
            _ChangeLevel = Get("ChangeLevel").ToDelegate<ChangeLevelPrototype>();
            _RestartGame = Get("RestartGame").ToDelegate<RestartGamePrototype>();
            _ReloadGame = Get("ReloadGame").ToDelegate<ReloadGamePrototype>();
            _SetCampaignMenuRace = Get("SetCampaignMenuRace").ToDelegate<SetCampaignMenuRacePrototype>();
            _SetCampaignMenuRaceEx = Get("SetCampaignMenuRaceEx").ToDelegate<SetCampaignMenuRaceExPrototype>();
            _ForceCampaignSelectScreen = Get("ForceCampaignSelectScreen").ToDelegate<ForceCampaignSelectScreenPrototype>();
            _LoadGame = Get("LoadGame").ToDelegate<LoadGamePrototype>();
            _SaveGame = Get("SaveGame").ToDelegate<SaveGamePrototype>();
            _RenameSaveDirectory = Get("RenameSaveDirectory").ToDelegate<RenameSaveDirectoryPrototype>();
            _RemoveSaveDirectory = Get("RemoveSaveDirectory").ToDelegate<RemoveSaveDirectoryPrototype>();
            _CopySaveGame = Get("CopySaveGame").ToDelegate<CopySaveGamePrototype>();
            _SaveGameExists = Get("SaveGameExists").ToDelegate<SaveGameExistsPrototype>();
            _SyncSelections = Get("SyncSelections").ToDelegate<SyncSelectionsPrototype>();
            _SetFloatGameState = Get("SetFloatGameState").ToDelegate<SetFloatGameStatePrototype>();
            _GetFloatGameState = Get("GetFloatGameState").ToDelegate<GetFloatGameStatePrototype>();
            _SetIntegerGameState = Get("SetIntegerGameState").ToDelegate<SetIntegerGameStatePrototype>();
            _GetIntegerGameState = Get("GetIntegerGameState").ToDelegate<GetIntegerGameStatePrototype>();
            _SetTutorialCleared = Get("SetTutorialCleared").ToDelegate<SetTutorialClearedPrototype>();
            _SetMissionAvailable = Get("SetMissionAvailable").ToDelegate<SetMissionAvailablePrototype>();
            _SetCampaignAvailable = Get("SetCampaignAvailable").ToDelegate<SetCampaignAvailablePrototype>();
            _SetOpCinematicAvailable = Get("SetOpCinematicAvailable").ToDelegate<SetOpCinematicAvailablePrototype>();
            _SetEdCinematicAvailable = Get("SetEdCinematicAvailable").ToDelegate<SetEdCinematicAvailablePrototype>();
            _GetDefaultDifficulty = Get("GetDefaultDifficulty").ToDelegate<GetDefaultDifficultyPrototype>();
            _SetDefaultDifficulty = Get("SetDefaultDifficulty").ToDelegate<SetDefaultDifficultyPrototype>();
            _SetCustomCampaignButtonVisible = Get("SetCustomCampaignButtonVisible").ToDelegate<SetCustomCampaignButtonVisiblePrototype>();
            _GetCustomCampaignButtonVisible = Get("GetCustomCampaignButtonVisible").ToDelegate<GetCustomCampaignButtonVisiblePrototype>();
            _DoNotSaveReplay = Get("DoNotSaveReplay").ToDelegate<DoNotSaveReplayPrototype>();
            _DialogCreate = Get("DialogCreate").ToDelegate<DialogCreatePrototype>();
            _DialogDestroy = Get("DialogDestroy").ToDelegate<DialogDestroyPrototype>();
            _DialogClear = Get("DialogClear").ToDelegate<DialogClearPrototype>();
            _DialogSetMessage = Get("DialogSetMessage").ToDelegate<DialogSetMessagePrototype>();
            _DialogAddButton = Get("DialogAddButton").ToDelegate<DialogAddButtonPrototype>();
            _DialogAddQuitButton = Get("DialogAddQuitButton").ToDelegate<DialogAddQuitButtonPrototype>();
            _DialogDisplay = Get("DialogDisplay").ToDelegate<DialogDisplayPrototype>();
            _ReloadGameCachesFromDisk = Get("ReloadGameCachesFromDisk").ToDelegate<ReloadGameCachesFromDiskPrototype>();
            _InitGameCache = Get("InitGameCache").ToDelegate<InitGameCachePrototype>();
            _SaveGameCache = Get("SaveGameCache").ToDelegate<SaveGameCachePrototype>();
            _StoreInteger = Get("StoreInteger").ToDelegate<StoreIntegerPrototype>();
            _StoreReal = Get("StoreReal").ToDelegate<StoreRealPrototype>();
            _StoreBoolean = Get("StoreBoolean").ToDelegate<StoreBooleanPrototype>();
            _StoreUnit = Get("StoreUnit").ToDelegate<StoreUnitPrototype>();
            _StoreString = Get("StoreString").ToDelegate<StoreStringPrototype>();
            _SyncStoredInteger = Get("SyncStoredInteger").ToDelegate<SyncStoredIntegerPrototype>();
            _SyncStoredReal = Get("SyncStoredReal").ToDelegate<SyncStoredRealPrototype>();
            _SyncStoredBoolean = Get("SyncStoredBoolean").ToDelegate<SyncStoredBooleanPrototype>();
            _SyncStoredUnit = Get("SyncStoredUnit").ToDelegate<SyncStoredUnitPrototype>();
            _SyncStoredString = Get("SyncStoredString").ToDelegate<SyncStoredStringPrototype>();
            _HaveStoredInteger = Get("HaveStoredInteger").ToDelegate<HaveStoredIntegerPrototype>();
            _HaveStoredReal = Get("HaveStoredReal").ToDelegate<HaveStoredRealPrototype>();
            _HaveStoredBoolean = Get("HaveStoredBoolean").ToDelegate<HaveStoredBooleanPrototype>();
            _HaveStoredUnit = Get("HaveStoredUnit").ToDelegate<HaveStoredUnitPrototype>();
            _HaveStoredString = Get("HaveStoredString").ToDelegate<HaveStoredStringPrototype>();
            _FlushGameCache = Get("FlushGameCache").ToDelegate<FlushGameCachePrototype>();
            _FlushStoredMission = Get("FlushStoredMission").ToDelegate<FlushStoredMissionPrototype>();
            _FlushStoredInteger = Get("FlushStoredInteger").ToDelegate<FlushStoredIntegerPrototype>();
            _FlushStoredReal = Get("FlushStoredReal").ToDelegate<FlushStoredRealPrototype>();
            _FlushStoredBoolean = Get("FlushStoredBoolean").ToDelegate<FlushStoredBooleanPrototype>();
            _FlushStoredUnit = Get("FlushStoredUnit").ToDelegate<FlushStoredUnitPrototype>();
            _FlushStoredString = Get("FlushStoredString").ToDelegate<FlushStoredStringPrototype>();
            _GetStoredInteger = Get("GetStoredInteger").ToDelegate<GetStoredIntegerPrototype>();
            _GetStoredReal = Get("GetStoredReal").ToDelegate<GetStoredRealPrototype>();
            _GetStoredBoolean = Get("GetStoredBoolean").ToDelegate<GetStoredBooleanPrototype>();
            _GetStoredString = Get("GetStoredString").ToDelegate<GetStoredStringPrototype>();
            _RestoreUnit = Get("RestoreUnit").ToDelegate<RestoreUnitPrototype>();
            _InitHashtable = Get("InitHashtable").ToDelegate<InitHashtablePrototype>();
            _SaveInteger = Get("SaveInteger").ToDelegate<SaveIntegerPrototype>();
            _SaveReal = Get("SaveReal").ToDelegate<SaveRealPrototype>();
            _SaveBoolean = Get("SaveBoolean").ToDelegate<SaveBooleanPrototype>();
            _SaveStr = Get("SaveStr").ToDelegate<SaveStrPrototype>();
            _SavePlayerHandle = Get("SavePlayerHandle").ToDelegate<SavePlayerHandlePrototype>();
            _SaveWidgetHandle = Get("SaveWidgetHandle").ToDelegate<SaveWidgetHandlePrototype>();
            _SaveDestructableHandle = Get("SaveDestructableHandle").ToDelegate<SaveDestructableHandlePrototype>();
            _SaveItemHandle = Get("SaveItemHandle").ToDelegate<SaveItemHandlePrototype>();
            _SaveUnitHandle = Get("SaveUnitHandle").ToDelegate<SaveUnitHandlePrototype>();
            _SaveAbilityHandle = Get("SaveAbilityHandle").ToDelegate<SaveAbilityHandlePrototype>();
            _SaveTimerHandle = Get("SaveTimerHandle").ToDelegate<SaveTimerHandlePrototype>();
            _SaveTriggerHandle = Get("SaveTriggerHandle").ToDelegate<SaveTriggerHandlePrototype>();
            _SaveTriggerConditionHandle = Get("SaveTriggerConditionHandle").ToDelegate<SaveTriggerConditionHandlePrototype>();
            _SaveTriggerActionHandle = Get("SaveTriggerActionHandle").ToDelegate<SaveTriggerActionHandlePrototype>();
            _SaveTriggerEventHandle = Get("SaveTriggerEventHandle").ToDelegate<SaveTriggerEventHandlePrototype>();
            _SaveForceHandle = Get("SaveForceHandle").ToDelegate<SaveForceHandlePrototype>();
            _SaveGroupHandle = Get("SaveGroupHandle").ToDelegate<SaveGroupHandlePrototype>();
            _SaveLocationHandle = Get("SaveLocationHandle").ToDelegate<SaveLocationHandlePrototype>();
            _SaveRectHandle = Get("SaveRectHandle").ToDelegate<SaveRectHandlePrototype>();
            _SaveBooleanExprHandle = Get("SaveBooleanExprHandle").ToDelegate<SaveBooleanExprHandlePrototype>();
            _SaveSoundHandle = Get("SaveSoundHandle").ToDelegate<SaveSoundHandlePrototype>();
            _SaveEffectHandle = Get("SaveEffectHandle").ToDelegate<SaveEffectHandlePrototype>();
            _SaveUnitPoolHandle = Get("SaveUnitPoolHandle").ToDelegate<SaveUnitPoolHandlePrototype>();
            _SaveItemPoolHandle = Get("SaveItemPoolHandle").ToDelegate<SaveItemPoolHandlePrototype>();
            _SaveQuestHandle = Get("SaveQuestHandle").ToDelegate<SaveQuestHandlePrototype>();
            _SaveQuestItemHandle = Get("SaveQuestItemHandle").ToDelegate<SaveQuestItemHandlePrototype>();
            _SaveDefeatConditionHandle = Get("SaveDefeatConditionHandle").ToDelegate<SaveDefeatConditionHandlePrototype>();
            _SaveTimerDialogHandle = Get("SaveTimerDialogHandle").ToDelegate<SaveTimerDialogHandlePrototype>();
            _SaveLeaderboardHandle = Get("SaveLeaderboardHandle").ToDelegate<SaveLeaderboardHandlePrototype>();
            _SaveMultiboardHandle = Get("SaveMultiboardHandle").ToDelegate<SaveMultiboardHandlePrototype>();
            _SaveMultiboardItemHandle = Get("SaveMultiboardItemHandle").ToDelegate<SaveMultiboardItemHandlePrototype>();
            _SaveTrackableHandle = Get("SaveTrackableHandle").ToDelegate<SaveTrackableHandlePrototype>();
            _SaveDialogHandle = Get("SaveDialogHandle").ToDelegate<SaveDialogHandlePrototype>();
            _SaveButtonHandle = Get("SaveButtonHandle").ToDelegate<SaveButtonHandlePrototype>();
            _SaveTextTagHandle = Get("SaveTextTagHandle").ToDelegate<SaveTextTagHandlePrototype>();
            _SaveLightningHandle = Get("SaveLightningHandle").ToDelegate<SaveLightningHandlePrototype>();
            _SaveImageHandle = Get("SaveImageHandle").ToDelegate<SaveImageHandlePrototype>();
            _SaveUbersplatHandle = Get("SaveUbersplatHandle").ToDelegate<SaveUbersplatHandlePrototype>();
            _SaveRegionHandle = Get("SaveRegionHandle").ToDelegate<SaveRegionHandlePrototype>();
            _SaveFogStateHandle = Get("SaveFogStateHandle").ToDelegate<SaveFogStateHandlePrototype>();
            _SaveFogModifierHandle = Get("SaveFogModifierHandle").ToDelegate<SaveFogModifierHandlePrototype>();
            _SaveAgentHandle = Get("SaveAgentHandle").ToDelegate<SaveAgentHandlePrototype>();
            _SaveHashtableHandle = Get("SaveHashtableHandle").ToDelegate<SaveHashtableHandlePrototype>();
            _LoadInteger = Get("LoadInteger").ToDelegate<LoadIntegerPrototype>();
            _LoadReal = Get("LoadReal").ToDelegate<LoadRealPrototype>();
            _LoadBoolean = Get("LoadBoolean").ToDelegate<LoadBooleanPrototype>();
            _LoadStr = Get("LoadStr").ToDelegate<LoadStrPrototype>();
            _LoadPlayerHandle = Get("LoadPlayerHandle").ToDelegate<LoadPlayerHandlePrototype>();
            _LoadWidgetHandle = Get("LoadWidgetHandle").ToDelegate<LoadWidgetHandlePrototype>();
            _LoadDestructableHandle = Get("LoadDestructableHandle").ToDelegate<LoadDestructableHandlePrototype>();
            _LoadItemHandle = Get("LoadItemHandle").ToDelegate<LoadItemHandlePrototype>();
            _LoadUnitHandle = Get("LoadUnitHandle").ToDelegate<LoadUnitHandlePrototype>();
            _LoadAbilityHandle = Get("LoadAbilityHandle").ToDelegate<LoadAbilityHandlePrototype>();
            _LoadTimerHandle = Get("LoadTimerHandle").ToDelegate<LoadTimerHandlePrototype>();
            _LoadTriggerHandle = Get("LoadTriggerHandle").ToDelegate<LoadTriggerHandlePrototype>();
            _LoadTriggerConditionHandle = Get("LoadTriggerConditionHandle").ToDelegate<LoadTriggerConditionHandlePrototype>();
            _LoadTriggerActionHandle = Get("LoadTriggerActionHandle").ToDelegate<LoadTriggerActionHandlePrototype>();
            _LoadTriggerEventHandle = Get("LoadTriggerEventHandle").ToDelegate<LoadTriggerEventHandlePrototype>();
            _LoadForceHandle = Get("LoadForceHandle").ToDelegate<LoadForceHandlePrototype>();
            _LoadGroupHandle = Get("LoadGroupHandle").ToDelegate<LoadGroupHandlePrototype>();
            _LoadLocationHandle = Get("LoadLocationHandle").ToDelegate<LoadLocationHandlePrototype>();
            _LoadRectHandle = Get("LoadRectHandle").ToDelegate<LoadRectHandlePrototype>();
            _LoadBooleanExprHandle = Get("LoadBooleanExprHandle").ToDelegate<LoadBooleanExprHandlePrototype>();
            _LoadSoundHandle = Get("LoadSoundHandle").ToDelegate<LoadSoundHandlePrototype>();
            _LoadEffectHandle = Get("LoadEffectHandle").ToDelegate<LoadEffectHandlePrototype>();
            _LoadUnitPoolHandle = Get("LoadUnitPoolHandle").ToDelegate<LoadUnitPoolHandlePrototype>();
            _LoadItemPoolHandle = Get("LoadItemPoolHandle").ToDelegate<LoadItemPoolHandlePrototype>();
            _LoadQuestHandle = Get("LoadQuestHandle").ToDelegate<LoadQuestHandlePrototype>();
            _LoadQuestItemHandle = Get("LoadQuestItemHandle").ToDelegate<LoadQuestItemHandlePrototype>();
            _LoadDefeatConditionHandle = Get("LoadDefeatConditionHandle").ToDelegate<LoadDefeatConditionHandlePrototype>();
            _LoadTimerDialogHandle = Get("LoadTimerDialogHandle").ToDelegate<LoadTimerDialogHandlePrototype>();
            _LoadLeaderboardHandle = Get("LoadLeaderboardHandle").ToDelegate<LoadLeaderboardHandlePrototype>();
            _LoadMultiboardHandle = Get("LoadMultiboardHandle").ToDelegate<LoadMultiboardHandlePrototype>();
            _LoadMultiboardItemHandle = Get("LoadMultiboardItemHandle").ToDelegate<LoadMultiboardItemHandlePrototype>();
            _LoadTrackableHandle = Get("LoadTrackableHandle").ToDelegate<LoadTrackableHandlePrototype>();
            _LoadDialogHandle = Get("LoadDialogHandle").ToDelegate<LoadDialogHandlePrototype>();
            _LoadButtonHandle = Get("LoadButtonHandle").ToDelegate<LoadButtonHandlePrototype>();
            _LoadTextTagHandle = Get("LoadTextTagHandle").ToDelegate<LoadTextTagHandlePrototype>();
            _LoadLightningHandle = Get("LoadLightningHandle").ToDelegate<LoadLightningHandlePrototype>();
            _LoadImageHandle = Get("LoadImageHandle").ToDelegate<LoadImageHandlePrototype>();
            _LoadUbersplatHandle = Get("LoadUbersplatHandle").ToDelegate<LoadUbersplatHandlePrototype>();
            _LoadRegionHandle = Get("LoadRegionHandle").ToDelegate<LoadRegionHandlePrototype>();
            _LoadFogStateHandle = Get("LoadFogStateHandle").ToDelegate<LoadFogStateHandlePrototype>();
            _LoadFogModifierHandle = Get("LoadFogModifierHandle").ToDelegate<LoadFogModifierHandlePrototype>();
            _LoadHashtableHandle = Get("LoadHashtableHandle").ToDelegate<LoadHashtableHandlePrototype>();
            _HaveSavedInteger = Get("HaveSavedInteger").ToDelegate<HaveSavedIntegerPrototype>();
            _HaveSavedReal = Get("HaveSavedReal").ToDelegate<HaveSavedRealPrototype>();
            _HaveSavedBoolean = Get("HaveSavedBoolean").ToDelegate<HaveSavedBooleanPrototype>();
            _HaveSavedString = Get("HaveSavedString").ToDelegate<HaveSavedStringPrototype>();
            _HaveSavedHandle = Get("HaveSavedHandle").ToDelegate<HaveSavedHandlePrototype>();
            _RemoveSavedInteger = Get("RemoveSavedInteger").ToDelegate<RemoveSavedIntegerPrototype>();
            _RemoveSavedReal = Get("RemoveSavedReal").ToDelegate<RemoveSavedRealPrototype>();
            _RemoveSavedBoolean = Get("RemoveSavedBoolean").ToDelegate<RemoveSavedBooleanPrototype>();
            _RemoveSavedString = Get("RemoveSavedString").ToDelegate<RemoveSavedStringPrototype>();
            _RemoveSavedHandle = Get("RemoveSavedHandle").ToDelegate<RemoveSavedHandlePrototype>();
            _FlushParentHashtable = Get("FlushParentHashtable").ToDelegate<FlushParentHashtablePrototype>();
            _FlushChildHashtable = Get("FlushChildHashtable").ToDelegate<FlushChildHashtablePrototype>();
            _GetRandomInt = Get("GetRandomInt").ToDelegate<GetRandomIntPrototype>();
            _GetRandomReal = Get("GetRandomReal").ToDelegate<GetRandomRealPrototype>();
            _CreateUnitPool = Get("CreateUnitPool").ToDelegate<CreateUnitPoolPrototype>();
            _DestroyUnitPool = Get("DestroyUnitPool").ToDelegate<DestroyUnitPoolPrototype>();
            _UnitPoolAddUnitType = Get("UnitPoolAddUnitType").ToDelegate<UnitPoolAddUnitTypePrototype>();
            _UnitPoolRemoveUnitType = Get("UnitPoolRemoveUnitType").ToDelegate<UnitPoolRemoveUnitTypePrototype>();
            _PlaceRandomUnit = Get("PlaceRandomUnit").ToDelegate<PlaceRandomUnitPrototype>();
            _CreateItemPool = Get("CreateItemPool").ToDelegate<CreateItemPoolPrototype>();
            _DestroyItemPool = Get("DestroyItemPool").ToDelegate<DestroyItemPoolPrototype>();
            _ItemPoolAddItemType = Get("ItemPoolAddItemType").ToDelegate<ItemPoolAddItemTypePrototype>();
            _ItemPoolRemoveItemType = Get("ItemPoolRemoveItemType").ToDelegate<ItemPoolRemoveItemTypePrototype>();
            _PlaceRandomItem = Get("PlaceRandomItem").ToDelegate<PlaceRandomItemPrototype>();
            _ChooseRandomCreep = Get("ChooseRandomCreep").ToDelegate<ChooseRandomCreepPrototype>();
            _ChooseRandomNPBuilding = Get("ChooseRandomNPBuilding").ToDelegate<ChooseRandomNPBuildingPrototype>();
            _ChooseRandomItem = Get("ChooseRandomItem").ToDelegate<ChooseRandomItemPrototype>();
            _ChooseRandomItemEx = Get("ChooseRandomItemEx").ToDelegate<ChooseRandomItemExPrototype>();
            _SetRandomSeed = Get("SetRandomSeed").ToDelegate<SetRandomSeedPrototype>();
            _SetTerrainFog = Get("SetTerrainFog").ToDelegate<SetTerrainFogPrototype>();
            _ResetTerrainFog = Get("ResetTerrainFog").ToDelegate<ResetTerrainFogPrototype>();
            _SetUnitFog = Get("SetUnitFog").ToDelegate<SetUnitFogPrototype>();
            _SetTerrainFogEx = Get("SetTerrainFogEx").ToDelegate<SetTerrainFogExPrototype>();
            _DisplayTextToPlayer = Get("DisplayTextToPlayer").ToDelegate<DisplayTextToPlayerPrototype>();
            _DisplayTimedTextToPlayer = Get("DisplayTimedTextToPlayer").ToDelegate<DisplayTimedTextToPlayerPrototype>();
            _DisplayTimedTextFromPlayer = Get("DisplayTimedTextFromPlayer").ToDelegate<DisplayTimedTextFromPlayerPrototype>();
            _ClearTextMessages = Get("ClearTextMessages").ToDelegate<ClearTextMessagesPrototype>();
            _SetDayNightModels = Get("SetDayNightModels").ToDelegate<SetDayNightModelsPrototype>();
            _SetSkyModel = Get("SetSkyModel").ToDelegate<SetSkyModelPrototype>();
            _EnableUserControl = Get("EnableUserControl").ToDelegate<EnableUserControlPrototype>();
            _EnableUserUI = Get("EnableUserUI").ToDelegate<EnableUserUIPrototype>();
            _SuspendTimeOfDay = Get("SuspendTimeOfDay").ToDelegate<SuspendTimeOfDayPrototype>();
            _SetTimeOfDayScale = Get("SetTimeOfDayScale").ToDelegate<SetTimeOfDayScalePrototype>();
            _GetTimeOfDayScale = Get("GetTimeOfDayScale").ToDelegate<GetTimeOfDayScalePrototype>();
            _ShowInterface = Get("ShowInterface").ToDelegate<ShowInterfacePrototype>();
            _PauseGame = Get("PauseGame").ToDelegate<PauseGamePrototype>();
            _UnitAddIndicator = Get("UnitAddIndicator").ToDelegate<UnitAddIndicatorPrototype>();
            _AddIndicator = Get("AddIndicator").ToDelegate<AddIndicatorPrototype>();
            _PingMinimap = Get("PingMinimap").ToDelegate<PingMinimapPrototype>();
            _PingMinimapEx = Get("PingMinimapEx").ToDelegate<PingMinimapExPrototype>();
            _EnableOcclusion = Get("EnableOcclusion").ToDelegate<EnableOcclusionPrototype>();
            _SetIntroShotText = Get("SetIntroShotText").ToDelegate<SetIntroShotTextPrototype>();
            _SetIntroShotModel = Get("SetIntroShotModel").ToDelegate<SetIntroShotModelPrototype>();
            _EnableWorldFogBoundary = Get("EnableWorldFogBoundary").ToDelegate<EnableWorldFogBoundaryPrototype>();
            _PlayModelCinematic = Get("PlayModelCinematic").ToDelegate<PlayModelCinematicPrototype>();
            _PlayCinematic = Get("PlayCinematic").ToDelegate<PlayCinematicPrototype>();
            _ForceUIKey = Get("ForceUIKey").ToDelegate<ForceUIKeyPrototype>();
            _ForceUICancel = Get("ForceUICancel").ToDelegate<ForceUICancelPrototype>();
            _DisplayLoadDialog = Get("DisplayLoadDialog").ToDelegate<DisplayLoadDialogPrototype>();
            _SetAltMinimapIcon = Get("SetAltMinimapIcon").ToDelegate<SetAltMinimapIconPrototype>();
            _DisableRestartMission = Get("DisableRestartMission").ToDelegate<DisableRestartMissionPrototype>();
            _CreateTextTag = Get("CreateTextTag").ToDelegate<CreateTextTagPrototype>();
            _DestroyTextTag = Get("DestroyTextTag").ToDelegate<DestroyTextTagPrototype>();
            _SetTextTagText = Get("SetTextTagText").ToDelegate<SetTextTagTextPrototype>();
            _SetTextTagPos = Get("SetTextTagPos").ToDelegate<SetTextTagPosPrototype>();
            _SetTextTagPosUnit = Get("SetTextTagPosUnit").ToDelegate<SetTextTagPosUnitPrototype>();
            _SetTextTagColor = Get("SetTextTagColor").ToDelegate<SetTextTagColorPrototype>();
            _SetTextTagVelocity = Get("SetTextTagVelocity").ToDelegate<SetTextTagVelocityPrototype>();
            _SetTextTagVisibility = Get("SetTextTagVisibility").ToDelegate<SetTextTagVisibilityPrototype>();
            _SetTextTagSuspended = Get("SetTextTagSuspended").ToDelegate<SetTextTagSuspendedPrototype>();
            _SetTextTagPermanent = Get("SetTextTagPermanent").ToDelegate<SetTextTagPermanentPrototype>();
            _SetTextTagAge = Get("SetTextTagAge").ToDelegate<SetTextTagAgePrototype>();
            _SetTextTagLifespan = Get("SetTextTagLifespan").ToDelegate<SetTextTagLifespanPrototype>();
            _SetTextTagFadepoint = Get("SetTextTagFadepoint").ToDelegate<SetTextTagFadepointPrototype>();
            _SetReservedLocalHeroButtons = Get("SetReservedLocalHeroButtons").ToDelegate<SetReservedLocalHeroButtonsPrototype>();
            _GetAllyColorFilterState = Get("GetAllyColorFilterState").ToDelegate<GetAllyColorFilterStatePrototype>();
            _SetAllyColorFilterState = Get("SetAllyColorFilterState").ToDelegate<SetAllyColorFilterStatePrototype>();
            _GetCreepCampFilterState = Get("GetCreepCampFilterState").ToDelegate<GetCreepCampFilterStatePrototype>();
            _SetCreepCampFilterState = Get("SetCreepCampFilterState").ToDelegate<SetCreepCampFilterStatePrototype>();
            _EnableMinimapFilterButtons = Get("EnableMinimapFilterButtons").ToDelegate<EnableMinimapFilterButtonsPrototype>();
            _EnableDragSelect = Get("EnableDragSelect").ToDelegate<EnableDragSelectPrototype>();
            _EnablePreSelect = Get("EnablePreSelect").ToDelegate<EnablePreSelectPrototype>();
            _EnableSelect = Get("EnableSelect").ToDelegate<EnableSelectPrototype>();
            _CreateTrackable = Get("CreateTrackable").ToDelegate<CreateTrackablePrototype>();
            _CreateQuest = Get("CreateQuest").ToDelegate<CreateQuestPrototype>();
            _DestroyQuest = Get("DestroyQuest").ToDelegate<DestroyQuestPrototype>();
            _QuestSetTitle = Get("QuestSetTitle").ToDelegate<QuestSetTitlePrototype>();
            _QuestSetDescription = Get("QuestSetDescription").ToDelegate<QuestSetDescriptionPrototype>();
            _QuestSetIconPath = Get("QuestSetIconPath").ToDelegate<QuestSetIconPathPrototype>();
            _QuestSetRequired = Get("QuestSetRequired").ToDelegate<QuestSetRequiredPrototype>();
            _QuestSetCompleted = Get("QuestSetCompleted").ToDelegate<QuestSetCompletedPrototype>();
            _QuestSetDiscovered = Get("QuestSetDiscovered").ToDelegate<QuestSetDiscoveredPrototype>();
            _QuestSetFailed = Get("QuestSetFailed").ToDelegate<QuestSetFailedPrototype>();
            _QuestSetEnabled = Get("QuestSetEnabled").ToDelegate<QuestSetEnabledPrototype>();
            _IsQuestRequired = Get("IsQuestRequired").ToDelegate<IsQuestRequiredPrototype>();
            _IsQuestCompleted = Get("IsQuestCompleted").ToDelegate<IsQuestCompletedPrototype>();
            _IsQuestDiscovered = Get("IsQuestDiscovered").ToDelegate<IsQuestDiscoveredPrototype>();
            _IsQuestFailed = Get("IsQuestFailed").ToDelegate<IsQuestFailedPrototype>();
            _IsQuestEnabled = Get("IsQuestEnabled").ToDelegate<IsQuestEnabledPrototype>();
            _QuestCreateItem = Get("QuestCreateItem").ToDelegate<QuestCreateItemPrototype>();
            _QuestItemSetDescription = Get("QuestItemSetDescription").ToDelegate<QuestItemSetDescriptionPrototype>();
            _QuestItemSetCompleted = Get("QuestItemSetCompleted").ToDelegate<QuestItemSetCompletedPrototype>();
            _IsQuestItemCompleted = Get("IsQuestItemCompleted").ToDelegate<IsQuestItemCompletedPrototype>();
            _CreateDefeatCondition = Get("CreateDefeatCondition").ToDelegate<CreateDefeatConditionPrototype>();
            _DestroyDefeatCondition = Get("DestroyDefeatCondition").ToDelegate<DestroyDefeatConditionPrototype>();
            _DefeatConditionSetDescription = Get("DefeatConditionSetDescription").ToDelegate<DefeatConditionSetDescriptionPrototype>();
            _FlashQuestDialogButton = Get("FlashQuestDialogButton").ToDelegate<FlashQuestDialogButtonPrototype>();
            _ForceQuestDialogUpdate = Get("ForceQuestDialogUpdate").ToDelegate<ForceQuestDialogUpdatePrototype>();
            _CreateTimerDialog = Get("CreateTimerDialog").ToDelegate<CreateTimerDialogPrototype>();
            _DestroyTimerDialog = Get("DestroyTimerDialog").ToDelegate<DestroyTimerDialogPrototype>();
            _TimerDialogSetTitle = Get("TimerDialogSetTitle").ToDelegate<TimerDialogSetTitlePrototype>();
            _TimerDialogSetTitleColor = Get("TimerDialogSetTitleColor").ToDelegate<TimerDialogSetTitleColorPrototype>();
            _TimerDialogSetTimeColor = Get("TimerDialogSetTimeColor").ToDelegate<TimerDialogSetTimeColorPrototype>();
            _TimerDialogSetSpeed = Get("TimerDialogSetSpeed").ToDelegate<TimerDialogSetSpeedPrototype>();
            _TimerDialogDisplay = Get("TimerDialogDisplay").ToDelegate<TimerDialogDisplayPrototype>();
            _IsTimerDialogDisplayed = Get("IsTimerDialogDisplayed").ToDelegate<IsTimerDialogDisplayedPrototype>();
            _TimerDialogSetRealTimeRemaining = Get("TimerDialogSetRealTimeRemaining").ToDelegate<TimerDialogSetRealTimeRemainingPrototype>();
            _CreateLeaderboard = Get("CreateLeaderboard").ToDelegate<CreateLeaderboardPrototype>();
            _DestroyLeaderboard = Get("DestroyLeaderboard").ToDelegate<DestroyLeaderboardPrototype>();
            _LeaderboardDisplay = Get("LeaderboardDisplay").ToDelegate<LeaderboardDisplayPrototype>();
            _IsLeaderboardDisplayed = Get("IsLeaderboardDisplayed").ToDelegate<IsLeaderboardDisplayedPrototype>();
            _LeaderboardGetItemCount = Get("LeaderboardGetItemCount").ToDelegate<LeaderboardGetItemCountPrototype>();
            _LeaderboardSetSizeByItemCount = Get("LeaderboardSetSizeByItemCount").ToDelegate<LeaderboardSetSizeByItemCountPrototype>();
            _LeaderboardAddItem = Get("LeaderboardAddItem").ToDelegate<LeaderboardAddItemPrototype>();
            _LeaderboardRemoveItem = Get("LeaderboardRemoveItem").ToDelegate<LeaderboardRemoveItemPrototype>();
            _LeaderboardRemovePlayerItem = Get("LeaderboardRemovePlayerItem").ToDelegate<LeaderboardRemovePlayerItemPrototype>();
            _LeaderboardClear = Get("LeaderboardClear").ToDelegate<LeaderboardClearPrototype>();
            _LeaderboardSortItemsByValue = Get("LeaderboardSortItemsByValue").ToDelegate<LeaderboardSortItemsByValuePrototype>();
            _LeaderboardSortItemsByPlayer = Get("LeaderboardSortItemsByPlayer").ToDelegate<LeaderboardSortItemsByPlayerPrototype>();
            _LeaderboardSortItemsByLabel = Get("LeaderboardSortItemsByLabel").ToDelegate<LeaderboardSortItemsByLabelPrototype>();
            _LeaderboardHasPlayerItem = Get("LeaderboardHasPlayerItem").ToDelegate<LeaderboardHasPlayerItemPrototype>();
            _LeaderboardGetPlayerIndex = Get("LeaderboardGetPlayerIndex").ToDelegate<LeaderboardGetPlayerIndexPrototype>();
            _LeaderboardSetLabel = Get("LeaderboardSetLabel").ToDelegate<LeaderboardSetLabelPrototype>();
            _LeaderboardGetLabelText = Get("LeaderboardGetLabelText").ToDelegate<LeaderboardGetLabelTextPrototype>();
            _PlayerSetLeaderboard = Get("PlayerSetLeaderboard").ToDelegate<PlayerSetLeaderboardPrototype>();
            _PlayerGetLeaderboard = Get("PlayerGetLeaderboard").ToDelegate<PlayerGetLeaderboardPrototype>();
            _LeaderboardSetLabelColor = Get("LeaderboardSetLabelColor").ToDelegate<LeaderboardSetLabelColorPrototype>();
            _LeaderboardSetValueColor = Get("LeaderboardSetValueColor").ToDelegate<LeaderboardSetValueColorPrototype>();
            _LeaderboardSetStyle = Get("LeaderboardSetStyle").ToDelegate<LeaderboardSetStylePrototype>();
            _LeaderboardSetItemValue = Get("LeaderboardSetItemValue").ToDelegate<LeaderboardSetItemValuePrototype>();
            _LeaderboardSetItemLabel = Get("LeaderboardSetItemLabel").ToDelegate<LeaderboardSetItemLabelPrototype>();
            _LeaderboardSetItemStyle = Get("LeaderboardSetItemStyle").ToDelegate<LeaderboardSetItemStylePrototype>();
            _LeaderboardSetItemLabelColor = Get("LeaderboardSetItemLabelColor").ToDelegate<LeaderboardSetItemLabelColorPrototype>();
            _LeaderboardSetItemValueColor = Get("LeaderboardSetItemValueColor").ToDelegate<LeaderboardSetItemValueColorPrototype>();
            _CreateMultiboard = Get("CreateMultiboard").ToDelegate<CreateMultiboardPrototype>();
            _DestroyMultiboard = Get("DestroyMultiboard").ToDelegate<DestroyMultiboardPrototype>();
            _MultiboardDisplay = Get("MultiboardDisplay").ToDelegate<MultiboardDisplayPrototype>();
            _IsMultiboardDisplayed = Get("IsMultiboardDisplayed").ToDelegate<IsMultiboardDisplayedPrototype>();
            _MultiboardMinimize = Get("MultiboardMinimize").ToDelegate<MultiboardMinimizePrototype>();
            _IsMultiboardMinimized = Get("IsMultiboardMinimized").ToDelegate<IsMultiboardMinimizedPrototype>();
            _MultiboardClear = Get("MultiboardClear").ToDelegate<MultiboardClearPrototype>();
            _MultiboardSetTitleText = Get("MultiboardSetTitleText").ToDelegate<MultiboardSetTitleTextPrototype>();
            _MultiboardGetTitleText = Get("MultiboardGetTitleText").ToDelegate<MultiboardGetTitleTextPrototype>();
            _MultiboardSetTitleTextColor = Get("MultiboardSetTitleTextColor").ToDelegate<MultiboardSetTitleTextColorPrototype>();
            _MultiboardGetRowCount = Get("MultiboardGetRowCount").ToDelegate<MultiboardGetRowCountPrototype>();
            _MultiboardGetColumnCount = Get("MultiboardGetColumnCount").ToDelegate<MultiboardGetColumnCountPrototype>();
            _MultiboardSetColumnCount = Get("MultiboardSetColumnCount").ToDelegate<MultiboardSetColumnCountPrototype>();
            _MultiboardSetRowCount = Get("MultiboardSetRowCount").ToDelegate<MultiboardSetRowCountPrototype>();
            _MultiboardSetItemsStyle = Get("MultiboardSetItemsStyle").ToDelegate<MultiboardSetItemsStylePrototype>();
            _MultiboardSetItemsValue = Get("MultiboardSetItemsValue").ToDelegate<MultiboardSetItemsValuePrototype>();
            _MultiboardSetItemsValueColor = Get("MultiboardSetItemsValueColor").ToDelegate<MultiboardSetItemsValueColorPrototype>();
            _MultiboardSetItemsWidth = Get("MultiboardSetItemsWidth").ToDelegate<MultiboardSetItemsWidthPrototype>();
            _MultiboardSetItemsIcon = Get("MultiboardSetItemsIcon").ToDelegate<MultiboardSetItemsIconPrototype>();
            _MultiboardGetItem = Get("MultiboardGetItem").ToDelegate<MultiboardGetItemPrototype>();
            _MultiboardReleaseItem = Get("MultiboardReleaseItem").ToDelegate<MultiboardReleaseItemPrototype>();
            _MultiboardSetItemStyle = Get("MultiboardSetItemStyle").ToDelegate<MultiboardSetItemStylePrototype>();
            _MultiboardSetItemValue = Get("MultiboardSetItemValue").ToDelegate<MultiboardSetItemValuePrototype>();
            _MultiboardSetItemValueColor = Get("MultiboardSetItemValueColor").ToDelegate<MultiboardSetItemValueColorPrototype>();
            _MultiboardSetItemWidth = Get("MultiboardSetItemWidth").ToDelegate<MultiboardSetItemWidthPrototype>();
            _MultiboardSetItemIcon = Get("MultiboardSetItemIcon").ToDelegate<MultiboardSetItemIconPrototype>();
            _MultiboardSuppressDisplay = Get("MultiboardSuppressDisplay").ToDelegate<MultiboardSuppressDisplayPrototype>();
            _SetCameraPosition = Get("SetCameraPosition").ToDelegate<SetCameraPositionPrototype>();
            _SetCameraQuickPosition = Get("SetCameraQuickPosition").ToDelegate<SetCameraQuickPositionPrototype>();
            _SetCameraBounds = Get("SetCameraBounds").ToDelegate<SetCameraBoundsPrototype>();
            _StopCamera = Get("StopCamera").ToDelegate<StopCameraPrototype>();
            _ResetToGameCamera = Get("ResetToGameCamera").ToDelegate<ResetToGameCameraPrototype>();
            _PanCameraTo = Get("PanCameraTo").ToDelegate<PanCameraToPrototype>();
            _PanCameraToTimed = Get("PanCameraToTimed").ToDelegate<PanCameraToTimedPrototype>();
            _PanCameraToWithZ = Get("PanCameraToWithZ").ToDelegate<PanCameraToWithZPrototype>();
            _PanCameraToTimedWithZ = Get("PanCameraToTimedWithZ").ToDelegate<PanCameraToTimedWithZPrototype>();
            _SetCinematicCamera = Get("SetCinematicCamera").ToDelegate<SetCinematicCameraPrototype>();
            _SetCameraRotateMode = Get("SetCameraRotateMode").ToDelegate<SetCameraRotateModePrototype>();
            _SetCameraField = Get("SetCameraField").ToDelegate<SetCameraFieldPrototype>();
            _AdjustCameraField = Get("AdjustCameraField").ToDelegate<AdjustCameraFieldPrototype>();
            _SetCameraTargetController = Get("SetCameraTargetController").ToDelegate<SetCameraTargetControllerPrototype>();
            _SetCameraOrientController = Get("SetCameraOrientController").ToDelegate<SetCameraOrientControllerPrototype>();
            _CreateCameraSetup = Get("CreateCameraSetup").ToDelegate<CreateCameraSetupPrototype>();
            _CameraSetupSetField = Get("CameraSetupSetField").ToDelegate<CameraSetupSetFieldPrototype>();
            _CameraSetupGetField = Get("CameraSetupGetField").ToDelegate<CameraSetupGetFieldPrototype>();
            _CameraSetupSetDestPosition = Get("CameraSetupSetDestPosition").ToDelegate<CameraSetupSetDestPositionPrototype>();
            _CameraSetupGetDestPositionLoc = Get("CameraSetupGetDestPositionLoc").ToDelegate<CameraSetupGetDestPositionLocPrototype>();
            _CameraSetupGetDestPositionX = Get("CameraSetupGetDestPositionX").ToDelegate<CameraSetupGetDestPositionXPrototype>();
            _CameraSetupGetDestPositionY = Get("CameraSetupGetDestPositionY").ToDelegate<CameraSetupGetDestPositionYPrototype>();
            _CameraSetupApply = Get("CameraSetupApply").ToDelegate<CameraSetupApplyPrototype>();
            _CameraSetupApplyWithZ = Get("CameraSetupApplyWithZ").ToDelegate<CameraSetupApplyWithZPrototype>();
            _CameraSetupApplyForceDuration = Get("CameraSetupApplyForceDuration").ToDelegate<CameraSetupApplyForceDurationPrototype>();
            _CameraSetupApplyForceDurationWithZ = Get("CameraSetupApplyForceDurationWithZ").ToDelegate<CameraSetupApplyForceDurationWithZPrototype>();
            _CameraSetTargetNoise = Get("CameraSetTargetNoise").ToDelegate<CameraSetTargetNoisePrototype>();
            _CameraSetSourceNoise = Get("CameraSetSourceNoise").ToDelegate<CameraSetSourceNoisePrototype>();
            _CameraSetTargetNoiseEx = Get("CameraSetTargetNoiseEx").ToDelegate<CameraSetTargetNoiseExPrototype>();
            _CameraSetSourceNoiseEx = Get("CameraSetSourceNoiseEx").ToDelegate<CameraSetSourceNoiseExPrototype>();
            _CameraSetSmoothingFactor = Get("CameraSetSmoothingFactor").ToDelegate<CameraSetSmoothingFactorPrototype>();
            _SetCineFilterTexture = Get("SetCineFilterTexture").ToDelegate<SetCineFilterTexturePrototype>();
            _SetCineFilterBlendMode = Get("SetCineFilterBlendMode").ToDelegate<SetCineFilterBlendModePrototype>();
            _SetCineFilterTexMapFlags = Get("SetCineFilterTexMapFlags").ToDelegate<SetCineFilterTexMapFlagsPrototype>();
            _SetCineFilterStartUV = Get("SetCineFilterStartUV").ToDelegate<SetCineFilterStartUVPrototype>();
            _SetCineFilterEndUV = Get("SetCineFilterEndUV").ToDelegate<SetCineFilterEndUVPrototype>();
            _SetCineFilterStartColor = Get("SetCineFilterStartColor").ToDelegate<SetCineFilterStartColorPrototype>();
            _SetCineFilterEndColor = Get("SetCineFilterEndColor").ToDelegate<SetCineFilterEndColorPrototype>();
            _SetCineFilterDuration = Get("SetCineFilterDuration").ToDelegate<SetCineFilterDurationPrototype>();
            _DisplayCineFilter = Get("DisplayCineFilter").ToDelegate<DisplayCineFilterPrototype>();
            _IsCineFilterDisplayed = Get("IsCineFilterDisplayed").ToDelegate<IsCineFilterDisplayedPrototype>();
            _SetCinematicScene = Get("SetCinematicScene").ToDelegate<SetCinematicScenePrototype>();
            _EndCinematicScene = Get("EndCinematicScene").ToDelegate<EndCinematicScenePrototype>();
            _ForceCinematicSubtitles = Get("ForceCinematicSubtitles").ToDelegate<ForceCinematicSubtitlesPrototype>();
            _GetCameraMargin = Get("GetCameraMargin").ToDelegate<GetCameraMarginPrototype>();
            _GetCameraBoundMinX = Get("GetCameraBoundMinX").ToDelegate<GetCameraBoundMinXPrototype>();
            _GetCameraBoundMinY = Get("GetCameraBoundMinY").ToDelegate<GetCameraBoundMinYPrototype>();
            _GetCameraBoundMaxX = Get("GetCameraBoundMaxX").ToDelegate<GetCameraBoundMaxXPrototype>();
            _GetCameraBoundMaxY = Get("GetCameraBoundMaxY").ToDelegate<GetCameraBoundMaxYPrototype>();
            _GetCameraField = Get("GetCameraField").ToDelegate<GetCameraFieldPrototype>();
            _GetCameraTargetPositionX = Get("GetCameraTargetPositionX").ToDelegate<GetCameraTargetPositionXPrototype>();
            _GetCameraTargetPositionY = Get("GetCameraTargetPositionY").ToDelegate<GetCameraTargetPositionYPrototype>();
            _GetCameraTargetPositionZ = Get("GetCameraTargetPositionZ").ToDelegate<GetCameraTargetPositionZPrototype>();
            _GetCameraTargetPositionLoc = Get("GetCameraTargetPositionLoc").ToDelegate<GetCameraTargetPositionLocPrototype>();
            _GetCameraEyePositionX = Get("GetCameraEyePositionX").ToDelegate<GetCameraEyePositionXPrototype>();
            _GetCameraEyePositionY = Get("GetCameraEyePositionY").ToDelegate<GetCameraEyePositionYPrototype>();
            _GetCameraEyePositionZ = Get("GetCameraEyePositionZ").ToDelegate<GetCameraEyePositionZPrototype>();
            _GetCameraEyePositionLoc = Get("GetCameraEyePositionLoc").ToDelegate<GetCameraEyePositionLocPrototype>();
            _NewSoundEnvironment = Get("NewSoundEnvironment").ToDelegate<NewSoundEnvironmentPrototype>();
            _CreateSound = Get("CreateSound").ToDelegate<CreateSoundPrototype>();
            _CreateSoundFilenameWithLabel = Get("CreateSoundFilenameWithLabel").ToDelegate<CreateSoundFilenameWithLabelPrototype>();
            _CreateSoundFromLabel = Get("CreateSoundFromLabel").ToDelegate<CreateSoundFromLabelPrototype>();
            _CreateMIDISound = Get("CreateMIDISound").ToDelegate<CreateMIDISoundPrototype>();
            _SetSoundParamsFromLabel = Get("SetSoundParamsFromLabel").ToDelegate<SetSoundParamsFromLabelPrototype>();
            _SetSoundDistanceCutoff = Get("SetSoundDistanceCutoff").ToDelegate<SetSoundDistanceCutoffPrototype>();
            _SetSoundChannel = Get("SetSoundChannel").ToDelegate<SetSoundChannelPrototype>();
            _SetSoundVolume = Get("SetSoundVolume").ToDelegate<SetSoundVolumePrototype>();
            _SetSoundPitch = Get("SetSoundPitch").ToDelegate<SetSoundPitchPrototype>();
            _SetSoundPlayPosition = Get("SetSoundPlayPosition").ToDelegate<SetSoundPlayPositionPrototype>();
            _SetSoundDistances = Get("SetSoundDistances").ToDelegate<SetSoundDistancesPrototype>();
            _SetSoundConeAngles = Get("SetSoundConeAngles").ToDelegate<SetSoundConeAnglesPrototype>();
            _SetSoundConeOrientation = Get("SetSoundConeOrientation").ToDelegate<SetSoundConeOrientationPrototype>();
            _SetSoundPosition = Get("SetSoundPosition").ToDelegate<SetSoundPositionPrototype>();
            _SetSoundVelocity = Get("SetSoundVelocity").ToDelegate<SetSoundVelocityPrototype>();
            _AttachSoundToUnit = Get("AttachSoundToUnit").ToDelegate<AttachSoundToUnitPrototype>();
            _StartSound = Get("StartSound").ToDelegate<StartSoundPrototype>();
            _StopSound = Get("StopSound").ToDelegate<StopSoundPrototype>();
            _KillSoundWhenDone = Get("KillSoundWhenDone").ToDelegate<KillSoundWhenDonePrototype>();
            _SetMapMusic = Get("SetMapMusic").ToDelegate<SetMapMusicPrototype>();
            _ClearMapMusic = Get("ClearMapMusic").ToDelegate<ClearMapMusicPrototype>();
            _PlayMusic = Get("PlayMusic").ToDelegate<PlayMusicPrototype>();
            _PlayMusicEx = Get("PlayMusicEx").ToDelegate<PlayMusicExPrototype>();
            _StopMusic = Get("StopMusic").ToDelegate<StopMusicPrototype>();
            _ResumeMusic = Get("ResumeMusic").ToDelegate<ResumeMusicPrototype>();
            _PlayThematicMusic = Get("PlayThematicMusic").ToDelegate<PlayThematicMusicPrototype>();
            _PlayThematicMusicEx = Get("PlayThematicMusicEx").ToDelegate<PlayThematicMusicExPrototype>();
            _EndThematicMusic = Get("EndThematicMusic").ToDelegate<EndThematicMusicPrototype>();
            _SetMusicVolume = Get("SetMusicVolume").ToDelegate<SetMusicVolumePrototype>();
            _SetMusicPlayPosition = Get("SetMusicPlayPosition").ToDelegate<SetMusicPlayPositionPrototype>();
            _SetThematicMusicPlayPosition = Get("SetThematicMusicPlayPosition").ToDelegate<SetThematicMusicPlayPositionPrototype>();
            _SetSoundDuration = Get("SetSoundDuration").ToDelegate<SetSoundDurationPrototype>();
            _GetSoundDuration = Get("GetSoundDuration").ToDelegate<GetSoundDurationPrototype>();
            _GetSoundFileDuration = Get("GetSoundFileDuration").ToDelegate<GetSoundFileDurationPrototype>();
            _VolumeGroupSetVolume = Get("VolumeGroupSetVolume").ToDelegate<VolumeGroupSetVolumePrototype>();
            _VolumeGroupReset = Get("VolumeGroupReset").ToDelegate<VolumeGroupResetPrototype>();
            _GetSoundIsPlaying = Get("GetSoundIsPlaying").ToDelegate<GetSoundIsPlayingPrototype>();
            _GetSoundIsLoading = Get("GetSoundIsLoading").ToDelegate<GetSoundIsLoadingPrototype>();
            _RegisterStackedSound = Get("RegisterStackedSound").ToDelegate<RegisterStackedSoundPrototype>();
            _UnregisterStackedSound = Get("UnregisterStackedSound").ToDelegate<UnregisterStackedSoundPrototype>();
            _AddWeatherEffect = Get("AddWeatherEffect").ToDelegate<AddWeatherEffectPrototype>();
            _RemoveWeatherEffect = Get("RemoveWeatherEffect").ToDelegate<RemoveWeatherEffectPrototype>();
            _EnableWeatherEffect = Get("EnableWeatherEffect").ToDelegate<EnableWeatherEffectPrototype>();
            _TerrainDeformCrater = Get("TerrainDeformCrater").ToDelegate<TerrainDeformCraterPrototype>();
            _TerrainDeformRipple = Get("TerrainDeformRipple").ToDelegate<TerrainDeformRipplePrototype>();
            _TerrainDeformWave = Get("TerrainDeformWave").ToDelegate<TerrainDeformWavePrototype>();
            _TerrainDeformRandom = Get("TerrainDeformRandom").ToDelegate<TerrainDeformRandomPrototype>();
            _TerrainDeformStop = Get("TerrainDeformStop").ToDelegate<TerrainDeformStopPrototype>();
            _TerrainDeformStopAll = Get("TerrainDeformStopAll").ToDelegate<TerrainDeformStopAllPrototype>();
            _AddSpecialEffect = Get("AddSpecialEffect").ToDelegate<AddSpecialEffectPrototype>();
            _AddSpecialEffectLoc = Get("AddSpecialEffectLoc").ToDelegate<AddSpecialEffectLocPrototype>();
            _AddSpecialEffectTarget = Get("AddSpecialEffectTarget").ToDelegate<AddSpecialEffectTargetPrototype>();
            _DestroyEffect = Get("DestroyEffect").ToDelegate<DestroyEffectPrototype>();
            _AddSpellEffect = Get("AddSpellEffect").ToDelegate<AddSpellEffectPrototype>();
            _AddSpellEffectLoc = Get("AddSpellEffectLoc").ToDelegate<AddSpellEffectLocPrototype>();
            _AddSpellEffectById = Get("AddSpellEffectById").ToDelegate<AddSpellEffectByIdPrototype>();
            _AddSpellEffectByIdLoc = Get("AddSpellEffectByIdLoc").ToDelegate<AddSpellEffectByIdLocPrototype>();
            _AddSpellEffectTarget = Get("AddSpellEffectTarget").ToDelegate<AddSpellEffectTargetPrototype>();
            _AddSpellEffectTargetById = Get("AddSpellEffectTargetById").ToDelegate<AddSpellEffectTargetByIdPrototype>();
            _AddLightning = Get("AddLightning").ToDelegate<AddLightningPrototype>();
            _AddLightningEx = Get("AddLightningEx").ToDelegate<AddLightningExPrototype>();
            _DestroyLightning = Get("DestroyLightning").ToDelegate<DestroyLightningPrototype>();
            _MoveLightning = Get("MoveLightning").ToDelegate<MoveLightningPrototype>();
            _MoveLightningEx = Get("MoveLightningEx").ToDelegate<MoveLightningExPrototype>();
            _GetLightningColorA = Get("GetLightningColorA").ToDelegate<GetLightningColorAPrototype>();
            _GetLightningColorR = Get("GetLightningColorR").ToDelegate<GetLightningColorRPrototype>();
            _GetLightningColorG = Get("GetLightningColorG").ToDelegate<GetLightningColorGPrototype>();
            _GetLightningColorB = Get("GetLightningColorB").ToDelegate<GetLightningColorBPrototype>();
            _SetLightningColor = Get("SetLightningColor").ToDelegate<SetLightningColorPrototype>();
            _GetAbilityEffect = Get("GetAbilityEffect").ToDelegate<GetAbilityEffectPrototype>();
            _GetAbilityEffectById = Get("GetAbilityEffectById").ToDelegate<GetAbilityEffectByIdPrototype>();
            _GetAbilitySound = Get("GetAbilitySound").ToDelegate<GetAbilitySoundPrototype>();
            _GetAbilitySoundById = Get("GetAbilitySoundById").ToDelegate<GetAbilitySoundByIdPrototype>();
            _GetTerrainCliffLevel = Get("GetTerrainCliffLevel").ToDelegate<GetTerrainCliffLevelPrototype>();
            _SetWaterBaseColor = Get("SetWaterBaseColor").ToDelegate<SetWaterBaseColorPrototype>();
            _SetWaterDeforms = Get("SetWaterDeforms").ToDelegate<SetWaterDeformsPrototype>();
            _GetTerrainType = Get("GetTerrainType").ToDelegate<GetTerrainTypePrototype>();
            _GetTerrainVariance = Get("GetTerrainVariance").ToDelegate<GetTerrainVariancePrototype>();
            _SetTerrainType = Get("SetTerrainType").ToDelegate<SetTerrainTypePrototype>();
            _IsTerrainPathable = Get("IsTerrainPathable").ToDelegate<IsTerrainPathablePrototype>();
            _SetTerrainPathable = Get("SetTerrainPathable").ToDelegate<SetTerrainPathablePrototype>();
            _CreateImage = Get("CreateImage").ToDelegate<CreateImagePrototype>();
            _DestroyImage = Get("DestroyImage").ToDelegate<DestroyImagePrototype>();
            _ShowImage = Get("ShowImage").ToDelegate<ShowImagePrototype>();
            _SetImageConstantHeight = Get("SetImageConstantHeight").ToDelegate<SetImageConstantHeightPrototype>();
            _SetImagePosition = Get("SetImagePosition").ToDelegate<SetImagePositionPrototype>();
            _SetImageColor = Get("SetImageColor").ToDelegate<SetImageColorPrototype>();
            _SetImageRender = Get("SetImageRender").ToDelegate<SetImageRenderPrototype>();
            _SetImageRenderAlways = Get("SetImageRenderAlways").ToDelegate<SetImageRenderAlwaysPrototype>();
            _SetImageAboveWater = Get("SetImageAboveWater").ToDelegate<SetImageAboveWaterPrototype>();
            _SetImageType = Get("SetImageType").ToDelegate<SetImageTypePrototype>();
            _CreateUbersplat = Get("CreateUbersplat").ToDelegate<CreateUbersplatPrototype>();
            _DestroyUbersplat = Get("DestroyUbersplat").ToDelegate<DestroyUbersplatPrototype>();
            _ResetUbersplat = Get("ResetUbersplat").ToDelegate<ResetUbersplatPrototype>();
            _FinishUbersplat = Get("FinishUbersplat").ToDelegate<FinishUbersplatPrototype>();
            _ShowUbersplat = Get("ShowUbersplat").ToDelegate<ShowUbersplatPrototype>();
            _SetUbersplatRender = Get("SetUbersplatRender").ToDelegate<SetUbersplatRenderPrototype>();
            _SetUbersplatRenderAlways = Get("SetUbersplatRenderAlways").ToDelegate<SetUbersplatRenderAlwaysPrototype>();
            _SetBlight = Get("SetBlight").ToDelegate<SetBlightPrototype>();
            _SetBlightRect = Get("SetBlightRect").ToDelegate<SetBlightRectPrototype>();
            _SetBlightPoint = Get("SetBlightPoint").ToDelegate<SetBlightPointPrototype>();
            _SetBlightLoc = Get("SetBlightLoc").ToDelegate<SetBlightLocPrototype>();
            _CreateBlightedGoldmine = Get("CreateBlightedGoldmine").ToDelegate<CreateBlightedGoldminePrototype>();
            _IsPointBlighted = Get("IsPointBlighted").ToDelegate<IsPointBlightedPrototype>();
            _SetDoodadAnimation = Get("SetDoodadAnimation").ToDelegate<SetDoodadAnimationPrototype>();
            _SetDoodadAnimationRect = Get("SetDoodadAnimationRect").ToDelegate<SetDoodadAnimationRectPrototype>();
            _StartMeleeAI = Get("StartMeleeAI").ToDelegate<StartMeleeAIPrototype>();
            _StartCampaignAI = Get("StartCampaignAI").ToDelegate<StartCampaignAIPrototype>();
            _CommandAI = Get("CommandAI").ToDelegate<CommandAIPrototype>();
            _PauseCompAI = Get("PauseCompAI").ToDelegate<PauseCompAIPrototype>();
            _GetAIDifficulty = Get("GetAIDifficulty").ToDelegate<GetAIDifficultyPrototype>();
            _RemoveGuardPosition = Get("RemoveGuardPosition").ToDelegate<RemoveGuardPositionPrototype>();
            _RecycleGuardPosition = Get("RecycleGuardPosition").ToDelegate<RecycleGuardPositionPrototype>();
            _RemoveAllGuardPositions = Get("RemoveAllGuardPositions").ToDelegate<RemoveAllGuardPositionsPrototype>();
            _Cheat = Get("Cheat").ToDelegate<CheatPrototype>();
            _IsNoVictoryCheat = Get("IsNoVictoryCheat").ToDelegate<IsNoVictoryCheatPrototype>();
            _IsNoDefeatCheat = Get("IsNoDefeatCheat").ToDelegate<IsNoDefeatCheatPrototype>();
            _Preload = Get("Preload").ToDelegate<PreloadPrototype>();
            _PreloadEnd = Get("PreloadEnd").ToDelegate<PreloadEndPrototype>();
            _PreloadStart = Get("PreloadStart").ToDelegate<PreloadStartPrototype>();
            _PreloadRefresh = Get("PreloadRefresh").ToDelegate<PreloadRefreshPrototype>();
            _PreloadEndEx = Get("PreloadEndEx").ToDelegate<PreloadEndExPrototype>();
            _PreloadGenClear = Get("PreloadGenClear").ToDelegate<PreloadGenClearPrototype>();
            _PreloadGenStart = Get("PreloadGenStart").ToDelegate<PreloadGenStartPrototype>();
            _PreloadGenEnd = Get("PreloadGenEnd").ToDelegate<PreloadGenEndPrototype>();
            _Preloader = Get("Preloader").ToDelegate<PreloaderPrototype>();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int InitNativesPrototype();

        public delegate JassRace ConvertRacePrototype(JassInteger i);

        public delegate JassAllianceType ConvertAllianceTypePrototype(JassInteger i);

        public delegate JassRacePreference ConvertRacePrefPrototype(JassInteger i);

        public delegate JassIGameState ConvertIGameStatePrototype(JassInteger i);

        public delegate JassFGameState ConvertFGameStatePrototype(JassInteger i);

        public delegate JassPlayerState ConvertPlayerStatePrototype(JassInteger i);

        public delegate JassPlayerScore ConvertPlayerScorePrototype(JassInteger i);

        public delegate JassPlayerGameResult ConvertPlayerGameResultPrototype(JassInteger i);

        public delegate JassUnitState ConvertUnitStatePrototype(JassInteger i);

        public delegate JassAIDifficulty ConvertAIDifficultyPrototype(JassInteger i);

        public delegate JassGameEvent ConvertGameEventPrototype(JassInteger i);

        public delegate JassPlayerEvent ConvertPlayerEventPrototype(JassInteger i);

        public delegate JassPlayerUnitEvent ConvertPlayerUnitEventPrototype(JassInteger i);

        public delegate JassWidgetEvent ConvertWidgetEventPrototype(JassInteger i);

        public delegate JassDialogEvent ConvertDialogEventPrototype(JassInteger i);

        public delegate JassUnitEvent ConvertUnitEventPrototype(JassInteger i);

        public delegate JassLimitOp ConvertLimitOpPrototype(JassInteger i);

        public delegate JassUnitType ConvertUnitTypePrototype(JassInteger i);

        public delegate JassGameSpeed ConvertGameSpeedPrototype(JassInteger i);

        public delegate JassPlacement ConvertPlacementPrototype(JassInteger i);

        public delegate JassStartLocationPriority ConvertStartLocPrioPrototype(JassInteger i);

        public delegate JassGameDifficulty ConvertGameDifficultyPrototype(JassInteger i);

        public delegate JassGameType ConvertGameTypePrototype(JassInteger i);

        public delegate JassMapFlag ConvertMapFlagPrototype(JassInteger i);

        public delegate JassMapVisibility ConvertMapVisibilityPrototype(JassInteger i);

        public delegate JassMapSetting ConvertMapSettingPrototype(JassInteger i);

        public delegate JassMapDensity ConvertMapDensityPrototype(JassInteger i);

        public delegate JassMapControl ConvertMapControlPrototype(JassInteger i);

        public delegate JassPlayerColor ConvertPlayerColorPrototype(JassInteger i);

        public delegate JassPlayerSlotState ConvertPlayerSlotStatePrototype(JassInteger i);

        public delegate JassVolumeGroup ConvertVolumeGroupPrototype(JassInteger i);

        public delegate JassCameraField ConvertCameraFieldPrototype(JassInteger i);

        public delegate JassBlendMode ConvertBlendModePrototype(JassInteger i);

        public delegate JassRarityControl ConvertRarityControlPrototype(JassInteger i);

        public delegate JassTextureMapFlags ConvertTexMapFlagsPrototype(JassInteger i);

        public delegate JassFogState ConvertFogStatePrototype(JassInteger i);

        public delegate JassEffectType ConvertEffectTypePrototype(JassInteger i);

        public delegate JassVersion ConvertVersionPrototype(JassInteger i);

        public delegate JassItemType ConvertItemTypePrototype(JassInteger i);

        public delegate JassAttackType ConvertAttackTypePrototype(JassInteger i);

        public delegate JassDamageType ConvertDamageTypePrototype(JassInteger i);

        public delegate JassWeaponType ConvertWeaponTypePrototype(JassInteger i);

        public delegate JassSoundType ConvertSoundTypePrototype(JassInteger i);

        public delegate JassPathingType ConvertPathingTypePrototype(JassInteger i);

        public delegate JassOrder OrderIdPrototype(JassStringArg orderIdString);

        public delegate JassStringRet OrderId2StringPrototype(JassOrder orderId);

        public delegate JassObjectId UnitIdPrototype(JassStringArg unitIdString);

        public delegate JassStringRet UnitId2StringPrototype(JassObjectId unitId);

        public delegate JassObjectId AbilityIdPrototype(JassStringArg abilityIdString);

        public delegate JassStringRet AbilityId2StringPrototype(JassObjectId abilityId);

        public delegate JassStringRet GetObjectNamePrototype(JassObjectId objectId);

        public delegate JassRealRet Deg2RadPrototype(JassRealArg degrees);

        public delegate JassRealRet Rad2DegPrototype(JassRealArg radians);

        public delegate JassRealRet SinPrototype(JassRealArg radians);

        public delegate JassRealRet CosPrototype(JassRealArg radians);

        public delegate JassRealRet TanPrototype(JassRealArg radians);

        public delegate JassRealRet AsinPrototype(JassRealArg y);

        public delegate JassRealRet AcosPrototype(JassRealArg x);

        public delegate JassRealRet AtanPrototype(JassRealArg x);

        public delegate JassRealRet Atan2Prototype(JassRealArg y, JassRealArg x);

        public delegate JassRealRet SquareRootPrototype(JassRealArg x);

        public delegate JassRealRet PowPrototype(JassRealArg x, JassRealArg power);

        public delegate JassRealRet I2RPrototype(JassInteger i);

        public delegate JassInteger R2IPrototype(JassRealArg r);

        public delegate JassStringRet I2SPrototype(JassInteger i);

        public delegate JassStringRet R2SPrototype(JassRealArg r);

        public delegate JassStringRet R2SWPrototype(JassRealArg r, JassInteger width, JassInteger precision);

        public delegate JassInteger S2IPrototype(JassStringArg s);

        public delegate JassRealRet S2RPrototype(JassStringArg s);

        public delegate JassInteger GetHandleIdPrototype(JassHandle h);

        public delegate JassStringRet SubStringPrototype(JassStringArg source, JassInteger start, JassInteger end);

        public delegate JassInteger StringLengthPrototype(JassStringArg s);

        public delegate JassStringRet StringCasePrototype(JassStringArg source, JassBoolean upper);

        public delegate JassInteger StringHashPrototype(JassStringArg s);

        public delegate JassStringRet GetLocalizedStringPrototype(JassStringArg source);

        public delegate JassInteger GetLocalizedHotkeyPrototype(JassStringArg source);

        public delegate void SetMapNamePrototype(JassStringArg name);

        public delegate void SetMapDescriptionPrototype(JassStringArg description);

        public delegate void SetTeamsPrototype(JassInteger teamcount);

        public delegate void SetPlayersPrototype(JassInteger playercount);

        public delegate void DefineStartLocationPrototype(JassInteger whichStartLoc, JassRealArg x, JassRealArg y);

        public delegate void DefineStartLocationLocPrototype(JassInteger whichStartLoc, JassLocation whichLocation);

        public delegate void SetStartLocPrioCountPrototype(JassInteger whichStartLoc, JassInteger prioSlotCount);

        public delegate void SetStartLocPrioPrototype(JassInteger whichStartLoc, JassInteger prioSlotIndex, JassInteger otherStartLocIndex, JassStartLocationPriority priority);

        public delegate JassInteger GetStartLocPrioSlotPrototype(JassInteger whichStartLoc, JassInteger prioSlotIndex);

        public delegate JassStartLocationPriority GetStartLocPrioPrototype(JassInteger whichStartLoc, JassInteger prioSlotIndex);

        public delegate void SetGameTypeSupportedPrototype(JassGameType whichGameType, JassBoolean value);

        public delegate void SetMapFlagPrototype(JassMapFlag whichMapFlag, JassBoolean value);

        public delegate void SetGamePlacementPrototype(JassPlacement whichPlacementType);

        public delegate void SetGameSpeedPrototype(JassGameSpeed whichspeed);

        public delegate void SetGameDifficultyPrototype(JassGameDifficulty whichdifficulty);

        public delegate void SetResourceDensityPrototype(JassMapDensity whichdensity);

        public delegate void SetCreatureDensityPrototype(JassMapDensity whichdensity);

        public delegate JassInteger GetTeamsPrototype();

        public delegate JassInteger GetPlayersPrototype();

        public delegate JassBoolean IsGameTypeSupportedPrototype(JassGameType whichGameType);

        public delegate JassGameType GetGameTypeSelectedPrototype();

        public delegate JassBoolean IsMapFlagSetPrototype(JassMapFlag whichMapFlag);

        public delegate JassPlacement GetGamePlacementPrototype();

        public delegate JassGameSpeed GetGameSpeedPrototype();

        public delegate JassGameDifficulty GetGameDifficultyPrototype();

        public delegate JassMapDensity GetResourceDensityPrototype();

        public delegate JassMapDensity GetCreatureDensityPrototype();

        public delegate JassRealRet GetStartLocationXPrototype(JassInteger whichStartLocation);

        public delegate JassRealRet GetStartLocationYPrototype(JassInteger whichStartLocation);

        public delegate JassLocation GetStartLocationLocPrototype(JassInteger whichStartLocation);

        public delegate void SetPlayerTeamPrototype(JassPlayer whichPlayer, JassInteger whichTeam);

        public delegate void SetPlayerStartLocationPrototype(JassPlayer whichPlayer, JassInteger startLocIndex);

        public delegate void ForcePlayerStartLocationPrototype(JassPlayer whichPlayer, JassInteger startLocIndex);

        public delegate void SetPlayerColorPrototype(JassPlayer whichPlayer, JassPlayerColor color);

        public delegate void SetPlayerAlliancePrototype(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassAllianceType whichAllianceSetting, JassBoolean value);

        public delegate void SetPlayerTaxRatePrototype(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassPlayerState whichResource, JassInteger rate);

        public delegate void SetPlayerRacePreferencePrototype(JassPlayer whichPlayer, JassRacePreference whichRacePreference);

        public delegate void SetPlayerRaceSelectablePrototype(JassPlayer whichPlayer, JassBoolean value);

        public delegate void SetPlayerControllerPrototype(JassPlayer whichPlayer, JassMapControl controlType);

        public delegate void SetPlayerNamePrototype(JassPlayer whichPlayer, JassStringArg name);

        public delegate void SetPlayerOnScoreScreenPrototype(JassPlayer whichPlayer, JassBoolean flag);

        public delegate JassInteger GetPlayerTeamPrototype(JassPlayer whichPlayer);

        public delegate JassInteger GetPlayerStartLocationPrototype(JassPlayer whichPlayer);

        public delegate JassPlayerColor GetPlayerColorPrototype(JassPlayer whichPlayer);

        public delegate JassBoolean GetPlayerSelectablePrototype(JassPlayer whichPlayer);

        public delegate JassMapControl GetPlayerControllerPrototype(JassPlayer whichPlayer);

        public delegate JassPlayerSlotState GetPlayerSlotStatePrototype(JassPlayer whichPlayer);

        public delegate JassInteger GetPlayerTaxRatePrototype(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassPlayerState whichResource);

        public delegate JassBoolean IsPlayerRacePrefSetPrototype(JassPlayer whichPlayer, JassRacePreference pref);

        public delegate JassStringRet GetPlayerNamePrototype(JassPlayer whichPlayer);

        public delegate JassTimer CreateTimerPrototype();

        public delegate void DestroyTimerPrototype(JassTimer whichTimer);

        public delegate void TimerStartPrototype(JassTimer whichTimer, JassRealArg timeout, JassBoolean periodic, JassCode handlerFunc);

        public delegate JassRealRet TimerGetElapsedPrototype(JassTimer whichTimer);

        public delegate JassRealRet TimerGetRemainingPrototype(JassTimer whichTimer);

        public delegate JassRealRet TimerGetTimeoutPrototype(JassTimer whichTimer);

        public delegate void PauseTimerPrototype(JassTimer whichTimer);

        public delegate void ResumeTimerPrototype(JassTimer whichTimer);

        public delegate JassTimer GetExpiredTimerPrototype();

        public delegate JassGroup CreateGroupPrototype();

        public delegate void DestroyGroupPrototype(JassGroup whichGroup);

        public delegate void GroupAddUnitPrototype(JassGroup whichGroup, JassUnit whichUnit);

        public delegate void GroupRemoveUnitPrototype(JassGroup whichGroup, JassUnit whichUnit);

        public delegate void GroupClearPrototype(JassGroup whichGroup);

        public delegate void GroupEnumUnitsOfTypePrototype(JassGroup whichGroup, JassStringArg unitname, JassBooleanExpression filter);

        public delegate void GroupEnumUnitsOfPlayerPrototype(JassGroup whichGroup, JassPlayer whichPlayer, JassBooleanExpression filter);

        public delegate void GroupEnumUnitsOfTypeCountedPrototype(JassGroup whichGroup, JassStringArg unitname, JassBooleanExpression filter, JassInteger countLimit);

        public delegate void GroupEnumUnitsInRectPrototype(JassGroup whichGroup, JassRect r, JassBooleanExpression filter);

        public delegate void GroupEnumUnitsInRectCountedPrototype(JassGroup whichGroup, JassRect r, JassBooleanExpression filter, JassInteger countLimit);

        public delegate void GroupEnumUnitsInRangePrototype(JassGroup whichGroup, JassRealArg x, JassRealArg y, JassRealArg radius, JassBooleanExpression filter);

        public delegate void GroupEnumUnitsInRangeOfLocPrototype(JassGroup whichGroup, JassLocation whichLocation, JassRealArg radius, JassBooleanExpression filter);

        public delegate void GroupEnumUnitsInRangeCountedPrototype(JassGroup whichGroup, JassRealArg x, JassRealArg y, JassRealArg radius, JassBooleanExpression filter, JassInteger countLimit);

        public delegate void GroupEnumUnitsInRangeOfLocCountedPrototype(JassGroup whichGroup, JassLocation whichLocation, JassRealArg radius, JassBooleanExpression filter, JassInteger countLimit);

        public delegate void GroupEnumUnitsSelectedPrototype(JassGroup whichGroup, JassPlayer whichPlayer, JassBooleanExpression filter);

        public delegate JassBoolean GroupImmediateOrderPrototype(JassGroup whichGroup, JassStringArg order);

        public delegate JassBoolean GroupImmediateOrderByIdPrototype(JassGroup whichGroup, JassOrder order);

        public delegate JassBoolean GroupPointOrderPrototype(JassGroup whichGroup, JassStringArg order, JassRealArg x, JassRealArg y);

        public delegate JassBoolean GroupPointOrderLocPrototype(JassGroup whichGroup, JassStringArg order, JassLocation whichLocation);

        public delegate JassBoolean GroupPointOrderByIdPrototype(JassGroup whichGroup, JassOrder order, JassRealArg x, JassRealArg y);

        public delegate JassBoolean GroupPointOrderByIdLocPrototype(JassGroup whichGroup, JassOrder order, JassLocation whichLocation);

        public delegate JassBoolean GroupTargetOrderPrototype(JassGroup whichGroup, JassStringArg order, JassWidget targetWidget);

        public delegate JassBoolean GroupTargetOrderByIdPrototype(JassGroup whichGroup, JassOrder order, JassWidget targetWidget);

        public delegate void ForGroupPrototype(JassGroup whichGroup, JassCode CallBack);

        public delegate JassUnit FirstOfGroupPrototype(JassGroup whichGroup);

        public delegate JassForce CreateForcePrototype();

        public delegate void DestroyForcePrototype(JassForce whichForce);

        public delegate void ForceAddPlayerPrototype(JassForce whichForce, JassPlayer whichPlayer);

        public delegate void ForceRemovePlayerPrototype(JassForce whichForce, JassPlayer whichPlayer);

        public delegate void ForceClearPrototype(JassForce whichForce);

        public delegate void ForceEnumPlayersPrototype(JassForce whichForce, JassBooleanExpression filter);

        public delegate void ForceEnumPlayersCountedPrototype(JassForce whichForce, JassBooleanExpression filter, JassInteger countLimit);

        public delegate void ForceEnumAlliesPrototype(JassForce whichForce, JassPlayer whichPlayer, JassBooleanExpression filter);

        public delegate void ForceEnumEnemiesPrototype(JassForce whichForce, JassPlayer whichPlayer, JassBooleanExpression filter);

        public delegate void ForForcePrototype(JassForce whichForce, JassCode CallBack);

        public delegate JassRect RectPrototype(JassRealArg minx, JassRealArg miny, JassRealArg maxx, JassRealArg maxy);

        public delegate JassRect RectFromLocPrototype(JassLocation min, JassLocation max);

        public delegate void RemoveRectPrototype(JassRect whichRect);

        public delegate void SetRectPrototype(JassRect whichRect, JassRealArg minx, JassRealArg miny, JassRealArg maxx, JassRealArg maxy);

        public delegate void SetRectFromLocPrototype(JassRect whichRect, JassLocation min, JassLocation max);

        public delegate void MoveRectToPrototype(JassRect whichRect, JassRealArg newCenterX, JassRealArg newCenterY);

        public delegate void MoveRectToLocPrototype(JassRect whichRect, JassLocation newCenterLoc);

        public delegate JassRealRet GetRectCenterXPrototype(JassRect whichRect);

        public delegate JassRealRet GetRectCenterYPrototype(JassRect whichRect);

        public delegate JassRealRet GetRectMinXPrototype(JassRect whichRect);

        public delegate JassRealRet GetRectMinYPrototype(JassRect whichRect);

        public delegate JassRealRet GetRectMaxXPrototype(JassRect whichRect);

        public delegate JassRealRet GetRectMaxYPrototype(JassRect whichRect);

        public delegate JassRegion CreateRegionPrototype();

        public delegate void RemoveRegionPrototype(JassRegion whichRegion);

        public delegate void RegionAddRectPrototype(JassRegion whichRegion, JassRect r);

        public delegate void RegionClearRectPrototype(JassRegion whichRegion, JassRect r);

        public delegate void RegionAddCellPrototype(JassRegion whichRegion, JassRealArg x, JassRealArg y);

        public delegate void RegionAddCellAtLocPrototype(JassRegion whichRegion, JassLocation whichLocation);

        public delegate void RegionClearCellPrototype(JassRegion whichRegion, JassRealArg x, JassRealArg y);

        public delegate void RegionClearCellAtLocPrototype(JassRegion whichRegion, JassLocation whichLocation);

        public delegate JassLocation LocationPrototype(JassRealArg x, JassRealArg y);

        public delegate void RemoveLocationPrototype(JassLocation whichLocation);

        public delegate void MoveLocationPrototype(JassLocation whichLocation, JassRealArg newX, JassRealArg newY);

        public delegate JassRealRet GetLocationXPrototype(JassLocation whichLocation);

        public delegate JassRealRet GetLocationYPrototype(JassLocation whichLocation);

        public delegate JassRealRet GetLocationZPrototype(JassLocation whichLocation);

        public delegate JassBoolean IsUnitInRegionPrototype(JassRegion whichRegion, JassUnit whichUnit);

        public delegate JassBoolean IsPointInRegionPrototype(JassRegion whichRegion, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IsLocationInRegionPrototype(JassRegion whichRegion, JassLocation whichLocation);

        public delegate JassRect GetWorldBoundsPrototype();

        public delegate JassTrigger CreateTriggerPrototype();

        public delegate void DestroyTriggerPrototype(JassTrigger whichTrigger);

        public delegate void ResetTriggerPrototype(JassTrigger whichTrigger);

        public delegate void EnableTriggerPrototype(JassTrigger whichTrigger);

        public delegate void DisableTriggerPrototype(JassTrigger whichTrigger);

        public delegate JassBoolean IsTriggerEnabledPrototype(JassTrigger whichTrigger);

        public delegate void TriggerWaitOnSleepsPrototype(JassTrigger whichTrigger, JassBoolean flag);

        public delegate JassBoolean IsTriggerWaitOnSleepsPrototype(JassTrigger whichTrigger);

        public delegate JassUnit GetFilterUnitPrototype();

        public delegate JassUnit GetEnumUnitPrototype();

        public delegate JassDestructable GetFilterDestructablePrototype();

        public delegate JassDestructable GetEnumDestructablePrototype();

        public delegate JassItem GetFilterItemPrototype();

        public delegate JassItem GetEnumItemPrototype();

        public delegate JassPlayer GetFilterPlayerPrototype();

        public delegate JassPlayer GetEnumPlayerPrototype();

        public delegate JassTrigger GetTriggeringTriggerPrototype();

        public delegate JassEventIndex GetTriggerEventIdPrototype();

        public delegate JassInteger GetTriggerEvalCountPrototype(JassTrigger whichTrigger);

        public delegate JassInteger GetTriggerExecCountPrototype(JassTrigger whichTrigger);

        public delegate void ExecuteFuncPrototype(JassStringArg funcName);

        public delegate JassBooleanExpression AndPrototype(JassBooleanExpression operandA, JassBooleanExpression operandB);

        public delegate JassBooleanExpression OrPrototype(JassBooleanExpression operandA, JassBooleanExpression operandB);

        public delegate JassBooleanExpression NotPrototype(JassBooleanExpression operand);

        public delegate JassConditionFunction ConditionPrototype(JassCode func);

        public delegate void DestroyConditionPrototype(JassConditionFunction c);

        public delegate JassFilterFunction FilterPrototype(JassCode func);

        public delegate void DestroyFilterPrototype(JassFilterFunction f);

        public delegate void DestroyBoolExprPrototype(JassBooleanExpression e);

        public delegate JassEvent TriggerRegisterVariableEventPrototype(JassTrigger whichTrigger, JassStringArg varName, JassLimitOp opcode, JassRealArg limitval);

        public delegate JassEvent TriggerRegisterTimerEventPrototype(JassTrigger whichTrigger, JassRealArg timeout, JassBoolean periodic);

        public delegate JassEvent TriggerRegisterTimerExpireEventPrototype(JassTrigger whichTrigger, JassTimer t);

        public delegate JassEvent TriggerRegisterGameStateEventPrototype(JassTrigger whichTrigger, JassGameState whichState, JassLimitOp opcode, JassRealArg limitval);

        public delegate JassEvent TriggerRegisterDialogEventPrototype(JassTrigger whichTrigger, JassDialog whichDialog);

        public delegate JassEvent TriggerRegisterDialogButtonEventPrototype(JassTrigger whichTrigger, JassButton whichButton);

        public delegate JassGameState GetEventGameStatePrototype();

        public delegate JassEvent TriggerRegisterGameEventPrototype(JassTrigger whichTrigger, JassGameEvent whichGameEvent);

        public delegate JassPlayer GetWinningPlayerPrototype();

        public delegate JassEvent TriggerRegisterEnterRegionPrototype(JassTrigger whichTrigger, JassRegion whichRegion, JassBooleanExpression filter);

        public delegate JassRegion GetTriggeringRegionPrototype();

        public delegate JassUnit GetEnteringUnitPrototype();

        public delegate JassEvent TriggerRegisterLeaveRegionPrototype(JassTrigger whichTrigger, JassRegion whichRegion, JassBooleanExpression filter);

        public delegate JassUnit GetLeavingUnitPrototype();

        public delegate JassEvent TriggerRegisterTrackableHitEventPrototype(JassTrigger whichTrigger, JassTrackable t);

        public delegate JassEvent TriggerRegisterTrackableTrackEventPrototype(JassTrigger whichTrigger, JassTrackable t);

        public delegate JassTrackable GetTriggeringTrackablePrototype();

        public delegate JassButton GetClickedButtonPrototype();

        public delegate JassDialog GetClickedDialogPrototype();

        public delegate JassRealRet GetTournamentFinishSoonTimeRemainingPrototype();

        public delegate JassInteger GetTournamentFinishNowRulePrototype();

        public delegate JassPlayer GetTournamentFinishNowPlayerPrototype();

        public delegate JassInteger GetTournamentScorePrototype(JassPlayer whichPlayer);

        public delegate JassStringRet GetSaveBasicFilenamePrototype();

        public delegate JassEvent TriggerRegisterPlayerEventPrototype(JassTrigger whichTrigger, JassPlayer whichPlayer, JassPlayerEvent whichPlayerEvent);

        public delegate JassPlayer GetTriggerPlayerPrototype();

        public delegate JassEvent TriggerRegisterPlayerUnitEventPrototype(JassTrigger whichTrigger, JassPlayer whichPlayer, JassPlayerUnitEvent whichPlayerUnitEvent, JassBooleanExpression filter);

        public delegate JassUnit GetLevelingUnitPrototype();

        public delegate JassUnit GetLearningUnitPrototype();

        public delegate JassInteger GetLearnedSkillPrototype();

        public delegate JassInteger GetLearnedSkillLevelPrototype();

        public delegate JassUnit GetRevivableUnitPrototype();

        public delegate JassUnit GetRevivingUnitPrototype();

        public delegate JassUnit GetAttackerPrototype();

        public delegate JassUnit GetRescuerPrototype();

        public delegate JassUnit GetDyingUnitPrototype();

        public delegate JassUnit GetKillingUnitPrototype();

        public delegate JassUnit GetDecayingUnitPrototype();

        public delegate JassUnit GetConstructingStructurePrototype();

        public delegate JassUnit GetCancelledStructurePrototype();

        public delegate JassUnit GetConstructedStructurePrototype();

        public delegate JassUnit GetResearchingUnitPrototype();

        public delegate JassInteger GetResearchedPrototype();

        public delegate JassInteger GetTrainedUnitTypePrototype();

        public delegate JassUnit GetTrainedUnitPrototype();

        public delegate JassUnit GetDetectedUnitPrototype();

        public delegate JassUnit GetSummoningUnitPrototype();

        public delegate JassUnit GetSummonedUnitPrototype();

        public delegate JassUnit GetTransportUnitPrototype();

        public delegate JassUnit GetLoadedUnitPrototype();

        public delegate JassUnit GetSellingUnitPrototype();

        public delegate JassUnit GetSoldUnitPrototype();

        public delegate JassUnit GetBuyingUnitPrototype();

        public delegate JassItem GetSoldItemPrototype();

        public delegate JassUnit GetChangingUnitPrototype();

        public delegate JassPlayer GetChangingUnitPrevOwnerPrototype();

        public delegate JassUnit GetManipulatingUnitPrototype();

        public delegate JassItem GetManipulatedItemPrototype();

        public delegate JassUnit GetOrderedUnitPrototype();

        public delegate JassOrder GetIssuedOrderIdPrototype();

        public delegate JassRealRet GetOrderPointXPrototype();

        public delegate JassRealRet GetOrderPointYPrototype();

        public delegate JassLocation GetOrderPointLocPrototype();

        public delegate JassWidget GetOrderTargetPrototype();

        public delegate JassDestructable GetOrderTargetDestructablePrototype();

        public delegate JassItem GetOrderTargetItemPrototype();

        public delegate JassUnit GetOrderTargetUnitPrototype();

        public delegate JassUnit GetSpellAbilityUnitPrototype();

        public delegate JassObjectId GetSpellAbilityIdPrototype();

        public delegate JassAbility GetSpellAbilityPrototype();

        public delegate JassLocation GetSpellTargetLocPrototype();

        public delegate JassRealRet GetSpellTargetXPrototype();

        public delegate JassRealRet GetSpellTargetYPrototype();

        public delegate JassDestructable GetSpellTargetDestructablePrototype();

        public delegate JassItem GetSpellTargetItemPrototype();

        public delegate JassUnit GetSpellTargetUnitPrototype();

        public delegate JassEvent TriggerRegisterPlayerAllianceChangePrototype(JassTrigger whichTrigger, JassPlayer whichPlayer, JassAllianceType whichAlliance);

        public delegate JassEvent TriggerRegisterPlayerStateEventPrototype(JassTrigger whichTrigger, JassPlayer whichPlayer, JassPlayerState whichState, JassLimitOp opcode, JassRealArg limitval);

        public delegate JassPlayerState GetEventPlayerStatePrototype();

        public delegate JassEvent TriggerRegisterPlayerChatEventPrototype(JassTrigger whichTrigger, JassPlayer whichPlayer, JassStringArg chatMessageToDetect, JassBoolean exactMatchOnly);

        public delegate JassStringRet GetEventPlayerChatStringPrototype();

        public delegate JassStringRet GetEventPlayerChatStringMatchedPrototype();

        public delegate JassEvent TriggerRegisterDeathEventPrototype(JassTrigger whichTrigger, JassWidget whichWidget);

        public delegate JassUnit GetTriggerUnitPrototype();

        public delegate JassEvent TriggerRegisterUnitStateEventPrototype(JassTrigger whichTrigger, JassUnit whichUnit, JassUnitState whichState, JassLimitOp opcode, JassRealArg limitval);

        public delegate JassUnitState GetEventUnitStatePrototype();

        public delegate JassEvent TriggerRegisterUnitEventPrototype(JassTrigger whichTrigger, JassUnit whichUnit, JassUnitEvent whichEvent);

        public delegate JassRealRet GetEventDamagePrototype();

        public delegate JassUnit GetEventDamageSourcePrototype();

        public delegate JassPlayer GetEventDetectingPlayerPrototype();

        public delegate JassEvent TriggerRegisterFilterUnitEventPrototype(JassTrigger whichTrigger, JassUnit whichUnit, JassUnitEvent whichEvent, JassBooleanExpression filter);

        public delegate JassUnit GetEventTargetUnitPrototype();

        public delegate JassEvent TriggerRegisterUnitInRangePrototype(JassTrigger whichTrigger, JassUnit whichUnit, JassRealArg range, JassBooleanExpression filter);

        public delegate JassTriggerCondition TriggerAddConditionPrototype(JassTrigger whichTrigger, JassBooleanExpression condition);

        public delegate void TriggerRemoveConditionPrototype(JassTrigger whichTrigger, JassTriggerCondition whichCondition);

        public delegate void TriggerClearConditionsPrototype(JassTrigger whichTrigger);

        public delegate JassTriggerAction TriggerAddActionPrototype(JassTrigger whichTrigger, JassCode actionFunc);

        public delegate void TriggerRemoveActionPrototype(JassTrigger whichTrigger, JassTriggerAction whichAction);

        public delegate void TriggerClearActionsPrototype(JassTrigger whichTrigger);

        public delegate void TriggerSleepActionPrototype(JassRealArg timeout);

        public delegate void TriggerWaitForSoundPrototype(JassSound s, JassRealArg offset);

        public delegate JassBoolean TriggerEvaluatePrototype(JassTrigger whichTrigger);

        public delegate void TriggerExecutePrototype(JassTrigger whichTrigger);

        public delegate void TriggerExecuteWaitPrototype(JassTrigger whichTrigger);

        public delegate void TriggerSyncStartPrototype();

        public delegate void TriggerSyncReadyPrototype();

        public delegate JassRealRet GetWidgetLifePrototype(JassWidget whichWidget);

        public delegate void SetWidgetLifePrototype(JassWidget whichWidget, JassRealArg newLife);

        public delegate JassRealRet GetWidgetXPrototype(JassWidget whichWidget);

        public delegate JassRealRet GetWidgetYPrototype(JassWidget whichWidget);

        public delegate JassWidget GetTriggerWidgetPrototype();

        public delegate JassDestructable CreateDestructablePrototype(JassObjectId objectid, JassRealArg x, JassRealArg y, JassRealArg face, JassRealArg scale, JassInteger variation);

        public delegate JassDestructable CreateDestructableZPrototype(JassObjectId objectid, JassRealArg x, JassRealArg y, JassRealArg z, JassRealArg face, JassRealArg scale, JassInteger variation);

        public delegate JassDestructable CreateDeadDestructablePrototype(JassObjectId objectid, JassRealArg x, JassRealArg y, JassRealArg face, JassRealArg scale, JassInteger variation);

        public delegate JassDestructable CreateDeadDestructableZPrototype(JassObjectId objectid, JassRealArg x, JassRealArg y, JassRealArg z, JassRealArg face, JassRealArg scale, JassInteger variation);

        public delegate void RemoveDestructablePrototype(JassDestructable d);

        public delegate void KillDestructablePrototype(JassDestructable d);

        public delegate void SetDestructableInvulnerablePrototype(JassDestructable d, JassBoolean flag);

        public delegate JassBoolean IsDestructableInvulnerablePrototype(JassDestructable d);

        public delegate void EnumDestructablesInRectPrototype(JassRect r, JassBooleanExpression filter, JassCode actionFunc);

        public delegate JassObjectId GetDestructableTypeIdPrototype(JassDestructable d);

        public delegate JassRealRet GetDestructableXPrototype(JassDestructable d);

        public delegate JassRealRet GetDestructableYPrototype(JassDestructable d);

        public delegate void SetDestructableLifePrototype(JassDestructable d, JassRealArg life);

        public delegate JassRealRet GetDestructableLifePrototype(JassDestructable d);

        public delegate void SetDestructableMaxLifePrototype(JassDestructable d, JassRealArg max);

        public delegate JassRealRet GetDestructableMaxLifePrototype(JassDestructable d);

        public delegate void DestructableRestoreLifePrototype(JassDestructable d, JassRealArg life, JassBoolean birth);

        public delegate void QueueDestructableAnimationPrototype(JassDestructable d, JassStringArg whichAnimation);

        public delegate void SetDestructableAnimationPrototype(JassDestructable d, JassStringArg whichAnimation);

        public delegate void SetDestructableAnimationSpeedPrototype(JassDestructable d, JassRealArg speedFactor);

        public delegate void ShowDestructablePrototype(JassDestructable d, JassBoolean flag);

        public delegate JassRealRet GetDestructableOccluderHeightPrototype(JassDestructable d);

        public delegate void SetDestructableOccluderHeightPrototype(JassDestructable d, JassRealArg height);

        public delegate JassStringRet GetDestructableNamePrototype(JassDestructable d);

        public delegate JassDestructable GetTriggerDestructablePrototype();

        public delegate JassItem CreateItemPrototype(JassObjectId itemid, JassRealArg x, JassRealArg y);

        public delegate void RemoveItemPrototype(JassItem whichItem);

        public delegate JassPlayer GetItemPlayerPrototype(JassItem whichItem);

        public delegate JassObjectId GetItemTypeIdPrototype(JassItem i);

        public delegate JassRealRet GetItemXPrototype(JassItem i);

        public delegate JassRealRet GetItemYPrototype(JassItem i);

        public delegate void SetItemPositionPrototype(JassItem i, JassRealArg x, JassRealArg y);

        public delegate void SetItemDropOnDeathPrototype(JassItem whichItem, JassBoolean flag);

        public delegate void SetItemDroppablePrototype(JassItem i, JassBoolean flag);

        public delegate void SetItemPawnablePrototype(JassItem i, JassBoolean flag);

        public delegate void SetItemPlayerPrototype(JassItem whichItem, JassPlayer whichPlayer, JassBoolean changeColor);

        public delegate void SetItemInvulnerablePrototype(JassItem whichItem, JassBoolean flag);

        public delegate JassBoolean IsItemInvulnerablePrototype(JassItem whichItem);

        public delegate void SetItemVisiblePrototype(JassItem whichItem, JassBoolean show);

        public delegate JassBoolean IsItemVisiblePrototype(JassItem whichItem);

        public delegate JassBoolean IsItemOwnedPrototype(JassItem whichItem);

        public delegate JassBoolean IsItemPowerupPrototype(JassItem whichItem);

        public delegate JassBoolean IsItemSellablePrototype(JassItem whichItem);

        public delegate JassBoolean IsItemPawnablePrototype(JassItem whichItem);

        public delegate JassBoolean IsItemIdPowerupPrototype(JassObjectId itemId);

        public delegate JassBoolean IsItemIdSellablePrototype(JassObjectId itemId);

        public delegate JassBoolean IsItemIdPawnablePrototype(JassObjectId itemId);

        public delegate void EnumItemsInRectPrototype(JassRect r, JassBooleanExpression filter, JassCode actionFunc);

        public delegate JassInteger GetItemLevelPrototype(JassItem whichItem);

        public delegate JassItemType GetItemTypePrototype(JassItem whichItem);

        public delegate void SetItemDropIDPrototype(JassItem whichItem, JassObjectId unitId);

        public delegate JassStringRet GetItemNamePrototype(JassItem whichItem);

        public delegate JassInteger GetItemChargesPrototype(JassItem whichItem);

        public delegate void SetItemChargesPrototype(JassItem whichItem, JassInteger charges);

        public delegate JassInteger GetItemUserDataPrototype(JassItem whichItem);

        public delegate void SetItemUserDataPrototype(JassItem whichItem, JassInteger data);

        public delegate JassUnit CreateUnitPrototype(JassPlayer id, JassObjectId unitid, JassRealArg x, JassRealArg y, JassRealArg face);

        public delegate JassUnit CreateUnitByNamePrototype(JassPlayer whichPlayer, JassStringArg unitname, JassRealArg x, JassRealArg y, JassRealArg face);

        public delegate JassUnit CreateUnitAtLocPrototype(JassPlayer id, JassObjectId unitid, JassLocation whichLocation, JassRealArg face);

        public delegate JassUnit CreateUnitAtLocByNamePrototype(JassPlayer id, JassStringArg unitname, JassLocation whichLocation, JassRealArg face);

        public delegate JassUnit CreateCorpsePrototype(JassPlayer whichPlayer, JassObjectId unitid, JassRealArg x, JassRealArg y, JassRealArg face);

        public delegate void KillUnitPrototype(JassUnit whichUnit);

        public delegate void RemoveUnitPrototype(JassUnit whichUnit);

        public delegate void ShowUnitPrototype(JassUnit whichUnit, JassBoolean show);

        public delegate void SetUnitStatePrototype(JassUnit whichUnit, JassUnitState whichUnitState, JassRealArg newVal);

        public delegate void SetUnitXPrototype(JassUnit whichUnit, JassRealArg newX);

        public delegate void SetUnitYPrototype(JassUnit whichUnit, JassRealArg newY);

        public delegate void SetUnitPositionPrototype(JassUnit whichUnit, JassRealArg newX, JassRealArg newY);

        public delegate void SetUnitPositionLocPrototype(JassUnit whichUnit, JassLocation whichLocation);

        public delegate void SetUnitFacingPrototype(JassUnit whichUnit, JassRealArg facingAngle);

        public delegate void SetUnitFacingTimedPrototype(JassUnit whichUnit, JassRealArg facingAngle, JassRealArg duration);

        public delegate void SetUnitMoveSpeedPrototype(JassUnit whichUnit, JassRealArg newSpeed);

        public delegate void SetUnitFlyHeightPrototype(JassUnit whichUnit, JassRealArg newHeight, JassRealArg rate);

        public delegate void SetUnitTurnSpeedPrototype(JassUnit whichUnit, JassRealArg newTurnSpeed);

        public delegate void SetUnitPropWindowPrototype(JassUnit whichUnit, JassRealArg newPropWindowAngle);

        public delegate void SetUnitAcquireRangePrototype(JassUnit whichUnit, JassRealArg newAcquireRange);

        public delegate void SetUnitCreepGuardPrototype(JassUnit whichUnit, JassBoolean creepGuard);

        public delegate JassRealRet GetUnitAcquireRangePrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitTurnSpeedPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitPropWindowPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitFlyHeightPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitDefaultAcquireRangePrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitDefaultTurnSpeedPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitDefaultPropWindowPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitDefaultFlyHeightPrototype(JassUnit whichUnit);

        public delegate void SetUnitOwnerPrototype(JassUnit whichUnit, JassPlayer whichPlayer, JassBoolean changeColor);

        public delegate void SetUnitColorPrototype(JassUnit whichUnit, JassPlayerColor whichColor);

        public delegate void SetUnitScalePrototype(JassUnit whichUnit, JassRealArg scaleX, JassRealArg scaleY, JassRealArg scaleZ);

        public delegate void SetUnitTimeScalePrototype(JassUnit whichUnit, JassRealArg timeScale);

        public delegate void SetUnitBlendTimePrototype(JassUnit whichUnit, JassRealArg blendTime);

        public delegate void SetUnitVertexColorPrototype(JassUnit whichUnit, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void QueueUnitAnimationPrototype(JassUnit whichUnit, JassStringArg whichAnimation);

        public delegate void SetUnitAnimationPrototype(JassUnit whichUnit, JassStringArg whichAnimation);

        public delegate void SetUnitAnimationByIndexPrototype(JassUnit whichUnit, JassInteger whichAnimation);

        public delegate void SetUnitAnimationWithRarityPrototype(JassUnit whichUnit, JassStringArg whichAnimation, JassRarityControl rarity);

        public delegate void AddUnitAnimationPropertiesPrototype(JassUnit whichUnit, JassStringArg animProperties, JassBoolean add);

        public delegate void SetUnitLookAtPrototype(JassUnit whichUnit, JassStringArg whichBone, JassUnit lookAtTarget, JassRealArg offsetX, JassRealArg offsetY, JassRealArg offsetZ);

        public delegate void ResetUnitLookAtPrototype(JassUnit whichUnit);

        public delegate void SetUnitRescuablePrototype(JassUnit whichUnit, JassPlayer byWhichPlayer, JassBoolean flag);

        public delegate void SetUnitRescueRangePrototype(JassUnit whichUnit, JassRealArg range);

        public delegate void SetHeroStrPrototype(JassUnit whichHero, JassInteger newStr, JassBoolean permanent);

        public delegate void SetHeroAgiPrototype(JassUnit whichHero, JassInteger newAgi, JassBoolean permanent);

        public delegate void SetHeroIntPrototype(JassUnit whichHero, JassInteger newInt, JassBoolean permanent);

        public delegate JassInteger GetHeroStrPrototype(JassUnit whichHero, JassBoolean includeBonuses);

        public delegate JassInteger GetHeroAgiPrototype(JassUnit whichHero, JassBoolean includeBonuses);

        public delegate JassInteger GetHeroIntPrototype(JassUnit whichHero, JassBoolean includeBonuses);

        public delegate JassBoolean UnitStripHeroLevelPrototype(JassUnit whichHero, JassInteger howManyLevels);

        public delegate JassInteger GetHeroXPPrototype(JassUnit whichHero);

        public delegate void SetHeroXPPrototype(JassUnit whichHero, JassInteger newXpVal, JassBoolean showEyeCandy);

        public delegate JassInteger GetHeroSkillPointsPrototype(JassUnit whichHero);

        public delegate JassBoolean UnitModifySkillPointsPrototype(JassUnit whichHero, JassInteger skillPointDelta);

        public delegate void AddHeroXPPrototype(JassUnit whichHero, JassInteger xpToAdd, JassBoolean showEyeCandy);

        public delegate void SetHeroLevelPrototype(JassUnit whichHero, JassInteger level, JassBoolean showEyeCandy);

        public delegate JassInteger GetHeroLevelPrototype(JassUnit whichHero);

        public delegate JassInteger GetUnitLevelPrototype(JassUnit whichUnit);

        public delegate JassStringRet GetHeroProperNamePrototype(JassUnit whichHero);

        public delegate void SuspendHeroXPPrototype(JassUnit whichHero, JassBoolean flag);

        public delegate JassBoolean IsSuspendedXPPrototype(JassUnit whichHero);

        public delegate void SelectHeroSkillPrototype(JassUnit whichHero, JassObjectId abilcode);

        public delegate JassInteger GetUnitAbilityLevelPrototype(JassUnit whichUnit, JassObjectId abilcode);

        public delegate JassInteger DecUnitAbilityLevelPrototype(JassUnit whichUnit, JassObjectId abilcode);

        public delegate JassInteger IncUnitAbilityLevelPrototype(JassUnit whichUnit, JassObjectId abilcode);

        public delegate JassInteger SetUnitAbilityLevelPrototype(JassUnit whichUnit, JassObjectId abilcode, JassInteger level);

        public delegate JassBoolean ReviveHeroPrototype(JassUnit whichHero, JassRealArg x, JassRealArg y, JassBoolean doEyecandy);

        public delegate JassBoolean ReviveHeroLocPrototype(JassUnit whichHero, JassLocation loc, JassBoolean doEyecandy);

        public delegate void SetUnitExplodedPrototype(JassUnit whichUnit, JassBoolean exploded);

        public delegate void SetUnitInvulnerablePrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate void PauseUnitPrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate JassBoolean IsUnitPausedPrototype(JassUnit whichHero);

        public delegate void SetUnitPathingPrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate void ClearSelectionPrototype();

        public delegate void SelectUnitPrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate JassInteger GetUnitPointValuePrototype(JassUnit whichUnit);

        public delegate JassInteger GetUnitPointValueByTypePrototype(JassInteger unitType);

        public delegate JassBoolean UnitAddItemPrototype(JassUnit whichUnit, JassItem whichItem);

        public delegate JassItem UnitAddItemByIdPrototype(JassUnit whichUnit, JassObjectId itemId);

        public delegate JassBoolean UnitAddItemToSlotByIdPrototype(JassUnit whichUnit, JassObjectId itemId, JassInteger itemSlot);

        public delegate void UnitRemoveItemPrototype(JassUnit whichUnit, JassItem whichItem);

        public delegate JassItem UnitRemoveItemFromSlotPrototype(JassUnit whichUnit, JassInteger itemSlot);

        public delegate JassBoolean UnitHasItemPrototype(JassUnit whichUnit, JassItem whichItem);

        public delegate JassItem UnitItemInSlotPrototype(JassUnit whichUnit, JassInteger itemSlot);

        public delegate JassInteger UnitInventorySizePrototype(JassUnit whichUnit);

        public delegate JassBoolean UnitDropItemPointPrototype(JassUnit whichUnit, JassItem whichItem, JassRealArg x, JassRealArg y);

        public delegate JassBoolean UnitDropItemSlotPrototype(JassUnit whichUnit, JassItem whichItem, JassInteger slot);

        public delegate JassBoolean UnitDropItemTargetPrototype(JassUnit whichUnit, JassItem whichItem, JassWidget target);

        public delegate JassBoolean UnitUseItemPrototype(JassUnit whichUnit, JassItem whichItem);

        public delegate JassBoolean UnitUseItemPointPrototype(JassUnit whichUnit, JassItem whichItem, JassRealArg x, JassRealArg y);

        public delegate JassBoolean UnitUseItemTargetPrototype(JassUnit whichUnit, JassItem whichItem, JassWidget target);

        public delegate JassRealRet GetUnitXPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitYPrototype(JassUnit whichUnit);

        public delegate JassLocation GetUnitLocPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitFacingPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitMoveSpeedPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitDefaultMoveSpeedPrototype(JassUnit whichUnit);

        public delegate JassRealRet GetUnitStatePrototype(JassUnit whichUnit, JassUnitState whichUnitState);

        public delegate JassPlayer GetOwningPlayerPrototype(JassUnit whichUnit);

        public delegate JassObjectId GetUnitTypeIdPrototype(JassUnit whichUnit);

        public delegate JassRace GetUnitRacePrototype(JassUnit whichUnit);

        public delegate JassStringRet GetUnitNamePrototype(JassUnit whichUnit);

        public delegate JassInteger GetUnitFoodUsedPrototype(JassUnit whichUnit);

        public delegate JassInteger GetUnitFoodMadePrototype(JassUnit whichUnit);

        public delegate JassInteger GetFoodMadePrototype(JassObjectId unitId);

        public delegate JassInteger GetFoodUsedPrototype(JassObjectId unitId);

        public delegate void SetUnitUseFoodPrototype(JassUnit whichUnit, JassBoolean useFood);

        public delegate JassLocation GetUnitRallyPointPrototype(JassUnit whichUnit);

        public delegate JassUnit GetUnitRallyUnitPrototype(JassUnit whichUnit);

        public delegate JassDestructable GetUnitRallyDestructablePrototype(JassUnit whichUnit);

        public delegate JassBoolean IsUnitInGroupPrototype(JassUnit whichUnit, JassGroup whichGroup);

        public delegate JassBoolean IsUnitInForcePrototype(JassUnit whichUnit, JassForce whichForce);

        public delegate JassBoolean IsUnitOwnedByPlayerPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitAllyPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitEnemyPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitVisiblePrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitDetectedPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitInvisiblePrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitFoggedPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitMaskedPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitSelectedPrototype(JassUnit whichUnit, JassPlayer whichPlayer);

        public delegate JassBoolean IsUnitRacePrototype(JassUnit whichUnit, JassRace whichRace);

        public delegate JassBoolean IsUnitTypePrototype(JassUnit whichUnit, JassUnitType whichUnitType);

        public delegate JassBoolean IsUnitPrototype(JassUnit whichUnit, JassUnit whichSpecifiedUnit);

        public delegate JassBoolean IsUnitInRangePrototype(JassUnit whichUnit, JassUnit otherUnit, JassRealArg distance);

        public delegate JassBoolean IsUnitInRangeXYPrototype(JassUnit whichUnit, JassRealArg x, JassRealArg y, JassRealArg distance);

        public delegate JassBoolean IsUnitInRangeLocPrototype(JassUnit whichUnit, JassLocation whichLocation, JassRealArg distance);

        public delegate JassBoolean IsUnitHiddenPrototype(JassUnit whichUnit);

        public delegate JassBoolean IsUnitIllusionPrototype(JassUnit whichUnit);

        public delegate JassBoolean IsUnitInTransportPrototype(JassUnit whichUnit, JassUnit whichTransport);

        public delegate JassBoolean IsUnitLoadedPrototype(JassUnit whichUnit);

        public delegate JassBoolean IsHeroUnitIdPrototype(JassObjectId unitId);

        public delegate JassBoolean IsUnitIdTypePrototype(JassObjectId unitId, JassUnitType whichUnitType);

        public delegate void UnitShareVisionPrototype(JassUnit whichUnit, JassPlayer whichPlayer, JassBoolean share);

        public delegate void UnitSuspendDecayPrototype(JassUnit whichUnit, JassBoolean suspend);

        public delegate JassBoolean UnitAddTypePrototype(JassUnit whichUnit, JassUnitType whichUnitType);

        public delegate JassBoolean UnitRemoveTypePrototype(JassUnit whichUnit, JassUnitType whichUnitType);

        public delegate JassBoolean UnitAddAbilityPrototype(JassUnit whichUnit, JassObjectId abilityId);

        public delegate JassBoolean UnitRemoveAbilityPrototype(JassUnit whichUnit, JassObjectId abilityId);

        public delegate JassBoolean UnitMakeAbilityPermanentPrototype(JassUnit whichUnit, JassBoolean permanent, JassObjectId abilityId);

        public delegate void UnitRemoveBuffsPrototype(JassUnit whichUnit, JassBoolean removePositive, JassBoolean removeNegative);

        public delegate void UnitRemoveBuffsExPrototype(JassUnit whichUnit, JassBoolean removePositive, JassBoolean removeNegative, JassBoolean magic, JassBoolean physical, JassBoolean timedLife, JassBoolean aura, JassBoolean autoDispel);

        public delegate JassBoolean UnitHasBuffsExPrototype(JassUnit whichUnit, JassBoolean removePositive, JassBoolean removeNegative, JassBoolean magic, JassBoolean physical, JassBoolean timedLife, JassBoolean aura, JassBoolean autoDispel);

        public delegate JassInteger UnitCountBuffsExPrototype(JassUnit whichUnit, JassBoolean removePositive, JassBoolean removeNegative, JassBoolean magic, JassBoolean physical, JassBoolean timedLife, JassBoolean aura, JassBoolean autoDispel);

        public delegate void UnitAddSleepPrototype(JassUnit whichUnit, JassBoolean add);

        public delegate JassBoolean UnitCanSleepPrototype(JassUnit whichUnit);

        public delegate void UnitAddSleepPermPrototype(JassUnit whichUnit, JassBoolean add);

        public delegate JassBoolean UnitCanSleepPermPrototype(JassUnit whichUnit);

        public delegate JassBoolean UnitIsSleepingPrototype(JassUnit whichUnit);

        public delegate void UnitWakeUpPrototype(JassUnit whichUnit);

        public delegate void UnitApplyTimedLifePrototype(JassUnit whichUnit, JassInteger buffId, JassRealArg duration);

        public delegate JassBoolean UnitIgnoreAlarmPrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate JassBoolean UnitIgnoreAlarmToggledPrototype(JassUnit whichUnit);

        public delegate void UnitResetCooldownPrototype(JassUnit whichUnit);

        public delegate void UnitSetConstructionProgressPrototype(JassUnit whichUnit, JassInteger constructionPercentage);

        public delegate void UnitSetUpgradeProgressPrototype(JassUnit whichUnit, JassInteger upgradePercentage);

        public delegate void UnitPauseTimedLifePrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate void UnitSetUsesAltIconPrototype(JassUnit whichUnit, JassBoolean flag);

        public delegate JassBoolean UnitDamagePointPrototype(JassUnit whichUnit, JassRealArg delay, JassRealArg radius, JassRealArg x, JassRealArg y, JassRealArg amount, JassBoolean attack, JassBoolean ranged, JassAttackType attackType, JassDamageType damageType, JassWeaponType weaponType);

        public delegate JassBoolean UnitDamageTargetPrototype(JassUnit whichUnit, JassWidget target, JassRealArg amount, JassBoolean attack, JassBoolean ranged, JassAttackType attackType, JassDamageType damageType, JassWeaponType weaponType);

        public delegate JassBoolean IssueImmediateOrderPrototype(JassUnit whichUnit, JassStringArg order);

        public delegate JassBoolean IssueImmediateOrderByIdPrototype(JassUnit whichUnit, JassOrder order);

        public delegate JassBoolean IssuePointOrderPrototype(JassUnit whichUnit, JassStringArg order, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IssuePointOrderLocPrototype(JassUnit whichUnit, JassStringArg order, JassLocation whichLocation);

        public delegate JassBoolean IssuePointOrderByIdPrototype(JassUnit whichUnit, JassOrder order, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IssuePointOrderByIdLocPrototype(JassUnit whichUnit, JassOrder order, JassLocation whichLocation);

        public delegate JassBoolean IssueTargetOrderPrototype(JassUnit whichUnit, JassStringArg order, JassWidget targetWidget);

        public delegate JassBoolean IssueTargetOrderByIdPrototype(JassUnit whichUnit, JassOrder order, JassWidget targetWidget);

        public delegate JassBoolean IssueInstantPointOrderPrototype(JassUnit whichUnit, JassStringArg order, JassRealArg x, JassRealArg y, JassWidget instantTargetWidget);

        public delegate JassBoolean IssueInstantPointOrderByIdPrototype(JassUnit whichUnit, JassOrder order, JassRealArg x, JassRealArg y, JassWidget instantTargetWidget);

        public delegate JassBoolean IssueInstantTargetOrderPrototype(JassUnit whichUnit, JassStringArg order, JassWidget targetWidget, JassWidget instantTargetWidget);

        public delegate JassBoolean IssueInstantTargetOrderByIdPrototype(JassUnit whichUnit, JassOrder order, JassWidget targetWidget, JassWidget instantTargetWidget);

        public delegate JassBoolean IssueBuildOrderPrototype(JassUnit whichPeon, JassStringArg unitToBuild, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IssueBuildOrderByIdPrototype(JassUnit whichPeon, JassObjectId unitId, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IssueNeutralImmediateOrderPrototype(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassStringArg unitToBuild);

        public delegate JassBoolean IssueNeutralImmediateOrderByIdPrototype(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassObjectId unitId);

        public delegate JassBoolean IssueNeutralPointOrderPrototype(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassStringArg unitToBuild, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IssueNeutralPointOrderByIdPrototype(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassObjectId unitId, JassRealArg x, JassRealArg y);

        public delegate JassBoolean IssueNeutralTargetOrderPrototype(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassStringArg unitToBuild, JassWidget target);

        public delegate JassBoolean IssueNeutralTargetOrderByIdPrototype(JassPlayer forWhichPlayer, JassUnit neutralStructure, JassObjectId unitId, JassWidget target);

        public delegate JassInteger GetUnitCurrentOrderPrototype(JassUnit whichUnit);

        public delegate void SetResourceAmountPrototype(JassUnit whichUnit, JassInteger amount);

        public delegate void AddResourceAmountPrototype(JassUnit whichUnit, JassInteger amount);

        public delegate JassInteger GetResourceAmountPrototype(JassUnit whichUnit);

        public delegate JassRealRet WaygateGetDestinationXPrototype(JassUnit waygate);

        public delegate JassRealRet WaygateGetDestinationYPrototype(JassUnit waygate);

        public delegate void WaygateSetDestinationPrototype(JassUnit waygate, JassRealArg x, JassRealArg y);

        public delegate void WaygateActivatePrototype(JassUnit waygate, JassBoolean activate);

        public delegate JassBoolean WaygateIsActivePrototype(JassUnit waygate);

        public delegate void AddItemToAllStockPrototype(JassObjectId itemId, JassInteger currentStock, JassInteger stockMax);

        public delegate void AddItemToStockPrototype(JassUnit whichUnit, JassObjectId itemId, JassInteger currentStock, JassInteger stockMax);

        public delegate void AddUnitToAllStockPrototype(JassObjectId unitId, JassInteger currentStock, JassInteger stockMax);

        public delegate void AddUnitToStockPrototype(JassUnit whichUnit, JassObjectId unitId, JassInteger currentStock, JassInteger stockMax);

        public delegate void RemoveItemFromAllStockPrototype(JassObjectId itemId);

        public delegate void RemoveItemFromStockPrototype(JassUnit whichUnit, JassObjectId itemId);

        public delegate void RemoveUnitFromAllStockPrototype(JassObjectId unitId);

        public delegate void RemoveUnitFromStockPrototype(JassUnit whichUnit, JassObjectId unitId);

        public delegate void SetAllItemTypeSlotsPrototype(JassInteger slots);

        public delegate void SetAllUnitTypeSlotsPrototype(JassInteger slots);

        public delegate void SetItemTypeSlotsPrototype(JassUnit whichUnit, JassInteger slots);

        public delegate void SetUnitTypeSlotsPrototype(JassUnit whichUnit, JassInteger slots);

        public delegate JassInteger GetUnitUserDataPrototype(JassUnit whichUnit);

        public delegate void SetUnitUserDataPrototype(JassUnit whichUnit, JassInteger data);

        public delegate JassPlayer PlayerPrototype(JassInteger number);

        public delegate JassPlayer GetLocalPlayerPrototype();

        public delegate JassBoolean IsPlayerAllyPrototype(JassPlayer whichPlayer, JassPlayer otherPlayer);

        public delegate JassBoolean IsPlayerEnemyPrototype(JassPlayer whichPlayer, JassPlayer otherPlayer);

        public delegate JassBoolean IsPlayerInForcePrototype(JassPlayer whichPlayer, JassForce whichForce);

        public delegate JassBoolean IsPlayerObserverPrototype(JassPlayer whichPlayer);

        public delegate JassBoolean IsVisibleToPlayerPrototype(JassRealArg x, JassRealArg y, JassPlayer whichPlayer);

        public delegate JassBoolean IsLocationVisibleToPlayerPrototype(JassLocation whichLocation, JassPlayer whichPlayer);

        public delegate JassBoolean IsFoggedToPlayerPrototype(JassRealArg x, JassRealArg y, JassPlayer whichPlayer);

        public delegate JassBoolean IsLocationFoggedToPlayerPrototype(JassLocation whichLocation, JassPlayer whichPlayer);

        public delegate JassBoolean IsMaskedToPlayerPrototype(JassRealArg x, JassRealArg y, JassPlayer whichPlayer);

        public delegate JassBoolean IsLocationMaskedToPlayerPrototype(JassLocation whichLocation, JassPlayer whichPlayer);

        public delegate JassRace GetPlayerRacePrototype(JassPlayer whichPlayer);

        public delegate JassInteger GetPlayerIdPrototype(JassPlayer whichPlayer);

        public delegate JassInteger GetPlayerUnitCountPrototype(JassPlayer whichPlayer, JassBoolean includeIncomplete);

        public delegate JassInteger GetPlayerTypedUnitCountPrototype(JassPlayer whichPlayer, JassStringArg unitName, JassBoolean includeIncomplete, JassBoolean includeUpgrades);

        public delegate JassInteger GetPlayerStructureCountPrototype(JassPlayer whichPlayer, JassBoolean includeIncomplete);

        public delegate JassInteger GetPlayerStatePrototype(JassPlayer whichPlayer, JassPlayerState whichPlayerState);

        public delegate JassInteger GetPlayerScorePrototype(JassPlayer whichPlayer, JassPlayerScore whichPlayerScore);

        public delegate JassBoolean GetPlayerAlliancePrototype(JassPlayer sourcePlayer, JassPlayer otherPlayer, JassAllianceType whichAllianceSetting);

        public delegate JassRealRet GetPlayerHandicapPrototype(JassPlayer whichPlayer);

        public delegate JassRealRet GetPlayerHandicapXPPrototype(JassPlayer whichPlayer);

        public delegate void SetPlayerHandicapPrototype(JassPlayer whichPlayer, JassRealArg handicap);

        public delegate void SetPlayerHandicapXPPrototype(JassPlayer whichPlayer, JassRealArg handicap);

        public delegate void SetPlayerTechMaxAllowedPrototype(JassPlayer whichPlayer, JassInteger techid, JassInteger maximum);

        public delegate JassInteger GetPlayerTechMaxAllowedPrototype(JassPlayer whichPlayer, JassInteger techid);

        public delegate void AddPlayerTechResearchedPrototype(JassPlayer whichPlayer, JassInteger techid, JassInteger levels);

        public delegate void SetPlayerTechResearchedPrototype(JassPlayer whichPlayer, JassInteger techid, JassInteger setToLevel);

        public delegate JassBoolean GetPlayerTechResearchedPrototype(JassPlayer whichPlayer, JassInteger techid, JassBoolean specificonly);

        public delegate JassInteger GetPlayerTechCountPrototype(JassPlayer whichPlayer, JassInteger techid, JassBoolean specificonly);

        public delegate void SetPlayerUnitsOwnerPrototype(JassPlayer whichPlayer, JassInteger newOwner);

        public delegate void CripplePlayerPrototype(JassPlayer whichPlayer, JassForce toWhichPlayers, JassBoolean flag);

        public delegate void SetPlayerAbilityAvailablePrototype(JassPlayer whichPlayer, JassObjectId abilid, JassBoolean avail);

        public delegate void SetPlayerStatePrototype(JassPlayer whichPlayer, JassPlayerState whichPlayerState, JassInteger value);

        public delegate void RemovePlayerPrototype(JassPlayer whichPlayer, JassPlayerGameResult gameResult);

        public delegate void CachePlayerHeroDataPrototype(JassPlayer whichPlayer);

        public delegate void SetFogStateRectPrototype(JassPlayer forWhichPlayer, JassFogState whichState, JassRect where, JassBoolean useSharedVision);

        public delegate void SetFogStateRadiusPrototype(JassPlayer forWhichPlayer, JassFogState whichState, JassRealArg centerx, JassRealArg centerY, JassRealArg radius, JassBoolean useSharedVision);

        public delegate void SetFogStateRadiusLocPrototype(JassPlayer forWhichPlayer, JassFogState whichState, JassLocation center, JassRealArg radius, JassBoolean useSharedVision);

        public delegate void FogMaskEnablePrototype(JassBoolean enable);

        public delegate JassBoolean IsFogMaskEnabledPrototype();

        public delegate void FogEnablePrototype(JassBoolean enable);

        public delegate JassBoolean IsFogEnabledPrototype();

        public delegate JassFogModifier CreateFogModifierRectPrototype(JassPlayer forWhichPlayer, JassFogState whichState, JassRect where, JassBoolean useSharedVision, JassBoolean afterUnits);

        public delegate JassFogModifier CreateFogModifierRadiusPrototype(JassPlayer forWhichPlayer, JassFogState whichState, JassRealArg centerx, JassRealArg centerY, JassRealArg radius, JassBoolean useSharedVision, JassBoolean afterUnits);

        public delegate JassFogModifier CreateFogModifierRadiusLocPrototype(JassPlayer forWhichPlayer, JassFogState whichState, JassLocation center, JassRealArg radius, JassBoolean useSharedVision, JassBoolean afterUnits);

        public delegate void DestroyFogModifierPrototype(JassFogModifier whichFogModifier);

        public delegate void FogModifierStartPrototype(JassFogModifier whichFogModifier);

        public delegate void FogModifierStopPrototype(JassFogModifier whichFogModifier);

        public delegate JassVersion VersionGetPrototype();

        public delegate JassBoolean VersionCompatiblePrototype(JassVersion whichVersion);

        public delegate JassBoolean VersionSupportedPrototype(JassVersion whichVersion);

        public delegate void EndGamePrototype(JassBoolean doScoreScreen);

        public delegate void ChangeLevelPrototype(JassStringArg newLevel, JassBoolean doScoreScreen);

        public delegate void RestartGamePrototype(JassBoolean doScoreScreen);

        public delegate void ReloadGamePrototype();

        public delegate void SetCampaignMenuRacePrototype(JassRace r);

        public delegate void SetCampaignMenuRaceExPrototype(JassInteger campaignIndex);

        public delegate void ForceCampaignSelectScreenPrototype();

        public delegate void LoadGamePrototype(JassStringArg saveFileName, JassBoolean doScoreScreen);

        public delegate void SaveGamePrototype(JassStringArg saveFileName);

        public delegate JassBoolean RenameSaveDirectoryPrototype(JassStringArg sourceDirName, JassStringArg destDirName);

        public delegate JassBoolean RemoveSaveDirectoryPrototype(JassStringArg sourceDirName);

        public delegate JassBoolean CopySaveGamePrototype(JassStringArg sourceSaveName, JassStringArg destSaveName);

        public delegate JassBoolean SaveGameExistsPrototype(JassStringArg saveName);

        public delegate void SyncSelectionsPrototype();

        public delegate void SetFloatGameStatePrototype(JassFGameState whichFloatGameState, JassRealArg value);

        public delegate JassRealRet GetFloatGameStatePrototype(JassFGameState whichFloatGameState);

        public delegate void SetIntegerGameStatePrototype(JassIGameState whichIntegerGameState, JassInteger value);

        public delegate JassInteger GetIntegerGameStatePrototype(JassIGameState whichIntegerGameState);

        public delegate void SetTutorialClearedPrototype(JassBoolean cleared);

        public delegate void SetMissionAvailablePrototype(JassInteger campaignNumber, JassInteger missionNumber, JassBoolean available);

        public delegate void SetCampaignAvailablePrototype(JassInteger campaignNumber, JassBoolean available);

        public delegate void SetOpCinematicAvailablePrototype(JassInteger campaignNumber, JassBoolean available);

        public delegate void SetEdCinematicAvailablePrototype(JassInteger campaignNumber, JassBoolean available);

        public delegate JassGameDifficulty GetDefaultDifficultyPrototype();

        public delegate void SetDefaultDifficultyPrototype(JassGameDifficulty g);

        public delegate void SetCustomCampaignButtonVisiblePrototype(JassInteger whichButton, JassBoolean visible);

        public delegate JassBoolean GetCustomCampaignButtonVisiblePrototype(JassInteger whichButton);

        public delegate void DoNotSaveReplayPrototype();

        public delegate JassDialog DialogCreatePrototype();

        public delegate void DialogDestroyPrototype(JassDialog whichDialog);

        public delegate void DialogClearPrototype(JassDialog whichDialog);

        public delegate void DialogSetMessagePrototype(JassDialog whichDialog, JassStringArg messageText);

        public delegate JassButton DialogAddButtonPrototype(JassDialog whichDialog, JassStringArg buttonText, JassInteger hotkey);

        public delegate JassButton DialogAddQuitButtonPrototype(JassDialog whichDialog, JassBoolean doScoreScreen, JassStringArg buttonText, JassInteger hotkey);

        public delegate void DialogDisplayPrototype(JassPlayer whichPlayer, JassDialog whichDialog, JassBoolean flag);

        public delegate JassBoolean ReloadGameCachesFromDiskPrototype();

        public delegate JassGameCache InitGameCachePrototype(JassStringArg campaignFile);

        public delegate JassBoolean SaveGameCachePrototype(JassGameCache whichCache);

        public delegate void StoreIntegerPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key, JassInteger value);

        public delegate void StoreRealPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key, JassRealArg value);

        public delegate void StoreBooleanPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key, JassBoolean value);

        public delegate JassBoolean StoreUnitPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key, JassUnit whichUnit);

        public delegate JassBoolean StoreStringPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key, JassStringArg value);

        public delegate void SyncStoredIntegerPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void SyncStoredRealPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void SyncStoredBooleanPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void SyncStoredUnitPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void SyncStoredStringPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassBoolean HaveStoredIntegerPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassBoolean HaveStoredRealPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassBoolean HaveStoredBooleanPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassBoolean HaveStoredUnitPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassBoolean HaveStoredStringPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void FlushGameCachePrototype(JassGameCache cache);

        public delegate void FlushStoredMissionPrototype(JassGameCache cache, JassStringArg missionKey);

        public delegate void FlushStoredIntegerPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void FlushStoredRealPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void FlushStoredBooleanPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void FlushStoredUnitPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate void FlushStoredStringPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassInteger GetStoredIntegerPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassRealRet GetStoredRealPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassBoolean GetStoredBooleanPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassStringRet GetStoredStringPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key);

        public delegate JassUnit RestoreUnitPrototype(JassGameCache cache, JassStringArg missionKey, JassStringArg key, JassPlayer forWhichPlayer, JassRealArg x, JassRealArg y, JassRealArg facing);

        public delegate JassHashTable InitHashtablePrototype();

        public delegate void SaveIntegerPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassInteger value);

        public delegate void SaveRealPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassRealArg value);

        public delegate void SaveBooleanPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassBoolean value);

        public delegate JassBoolean SaveStrPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassStringArg value);

        public delegate JassBoolean SavePlayerHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassPlayer whichPlayer);

        public delegate JassBoolean SaveWidgetHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassWidget whichWidget);

        public delegate JassBoolean SaveDestructableHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassDestructable whichDestructable);

        public delegate JassBoolean SaveItemHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassItem whichItem);

        public delegate JassBoolean SaveUnitHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassUnit whichUnit);

        public delegate JassBoolean SaveAbilityHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassAbility whichAbility);

        public delegate JassBoolean SaveTimerHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTimer whichTimer);

        public delegate JassBoolean SaveTriggerHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTrigger whichTrigger);

        public delegate JassBoolean SaveTriggerConditionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTriggerCondition whichTriggercondition);

        public delegate JassBoolean SaveTriggerActionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTriggerAction whichTriggeraction);

        public delegate JassBoolean SaveTriggerEventHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassEvent whichEvent);

        public delegate JassBoolean SaveForceHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassForce whichForce);

        public delegate JassBoolean SaveGroupHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassGroup whichGroup);

        public delegate JassBoolean SaveLocationHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassLocation whichLocation);

        public delegate JassBoolean SaveRectHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassRect whichRect);

        public delegate JassBoolean SaveBooleanExprHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassBooleanExpression whichBoolexpr);

        public delegate JassBoolean SaveSoundHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassSound whichSound);

        public delegate JassBoolean SaveEffectHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassEffect whichEffect);

        public delegate JassBoolean SaveUnitPoolHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassUnitPool whichUnitpool);

        public delegate JassBoolean SaveItemPoolHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassItemPool whichItempool);

        public delegate JassBoolean SaveQuestHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassQuest whichQuest);

        public delegate JassBoolean SaveQuestItemHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassQuestItem whichQuestitem);

        public delegate JassBoolean SaveDefeatConditionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassDefeatCondition whichDefeatcondition);

        public delegate JassBoolean SaveTimerDialogHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTimerDialog whichTimerdialog);

        public delegate JassBoolean SaveLeaderboardHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassLeaderboard whichLeaderboard);

        public delegate JassBoolean SaveMultiboardHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassMultiboard whichMultiboard);

        public delegate JassBoolean SaveMultiboardItemHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassMultiboardItem whichMultiboarditem);

        public delegate JassBoolean SaveTrackableHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTrackable whichTrackable);

        public delegate JassBoolean SaveDialogHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassDialog whichDialog);

        public delegate JassBoolean SaveButtonHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassButton whichButton);

        public delegate JassBoolean SaveTextTagHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassTextTag whichTexttag);

        public delegate JassBoolean SaveLightningHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassLightning whichLightning);

        public delegate JassBoolean SaveImageHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassImage whichImage);

        public delegate JassBoolean SaveUbersplatHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassUberSplat whichUbersplat);

        public delegate JassBoolean SaveRegionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassRegion whichRegion);

        public delegate JassBoolean SaveFogStateHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassFogState whichFogState);

        public delegate JassBoolean SaveFogModifierHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassFogModifier whichFogModifier);

        public delegate JassBoolean SaveAgentHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassAgent whichAgent);

        public delegate JassBoolean SaveHashtableHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey, JassHashTable whichHashtable);

        public delegate JassInteger LoadIntegerPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassRealRet LoadRealPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBoolean LoadBooleanPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassStringRet LoadStrPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassPlayer LoadPlayerHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassWidget LoadWidgetHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassDestructable LoadDestructableHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassItem LoadItemHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassUnit LoadUnitHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassAbility LoadAbilityHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTimer LoadTimerHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTrigger LoadTriggerHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTriggerCondition LoadTriggerConditionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTriggerAction LoadTriggerActionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassEvent LoadTriggerEventHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassForce LoadForceHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassGroup LoadGroupHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassLocation LoadLocationHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassRect LoadRectHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBooleanExpression LoadBooleanExprHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassSound LoadSoundHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassEffect LoadEffectHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassUnitPool LoadUnitPoolHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassItemPool LoadItemPoolHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassQuest LoadQuestHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassQuestItem LoadQuestItemHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassDefeatCondition LoadDefeatConditionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTimerDialog LoadTimerDialogHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassLeaderboard LoadLeaderboardHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassMultiboard LoadMultiboardHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassMultiboardItem LoadMultiboardItemHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTrackable LoadTrackableHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassDialog LoadDialogHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassButton LoadButtonHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassTextTag LoadTextTagHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassLightning LoadLightningHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassImage LoadImageHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassUberSplat LoadUbersplatHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassRegion LoadRegionHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassFogState LoadFogStateHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassFogModifier LoadFogModifierHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassHashTable LoadHashtableHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBoolean HaveSavedIntegerPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBoolean HaveSavedRealPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBoolean HaveSavedBooleanPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBoolean HaveSavedStringPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate JassBoolean HaveSavedHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate void RemoveSavedIntegerPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate void RemoveSavedRealPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate void RemoveSavedBooleanPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate void RemoveSavedStringPrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate void RemoveSavedHandlePrototype(JassHashTable table, JassInteger parentKey, JassInteger childKey);

        public delegate void FlushParentHashtablePrototype(JassHashTable table);

        public delegate void FlushChildHashtablePrototype(JassHashTable table, JassInteger parentKey);

        public delegate JassInteger GetRandomIntPrototype(JassInteger lowBound, JassInteger highBound);

        public delegate JassRealRet GetRandomRealPrototype(JassRealArg lowBound, JassRealArg highBound);

        public delegate JassUnitPool CreateUnitPoolPrototype();

        public delegate void DestroyUnitPoolPrototype(JassUnitPool whichPool);

        public delegate void UnitPoolAddUnitTypePrototype(JassUnitPool whichPool, JassObjectId unitId, JassRealArg weight);

        public delegate void UnitPoolRemoveUnitTypePrototype(JassUnitPool whichPool, JassObjectId unitId);

        public delegate JassUnit PlaceRandomUnitPrototype(JassUnitPool whichPool, JassPlayer forWhichPlayer, JassRealArg x, JassRealArg y, JassRealArg facing);

        public delegate JassItemPool CreateItemPoolPrototype();

        public delegate void DestroyItemPoolPrototype(JassItemPool whichItemPool);

        public delegate void ItemPoolAddItemTypePrototype(JassItemPool whichItemPool, JassObjectId itemId, JassRealArg weight);

        public delegate void ItemPoolRemoveItemTypePrototype(JassItemPool whichItemPool, JassObjectId itemId);

        public delegate JassItem PlaceRandomItemPrototype(JassItemPool whichItemPool, JassRealArg x, JassRealArg y);

        public delegate JassInteger ChooseRandomCreepPrototype(JassInteger level);

        public delegate JassInteger ChooseRandomNPBuildingPrototype();

        public delegate JassInteger ChooseRandomItemPrototype(JassInteger level);

        public delegate JassInteger ChooseRandomItemExPrototype(JassItemType whichType, JassInteger level);

        public delegate void SetRandomSeedPrototype(JassInteger seed);

        public delegate void SetTerrainFogPrototype(JassRealArg a, JassRealArg b, JassRealArg c, JassRealArg d, JassRealArg e);

        public delegate void ResetTerrainFogPrototype();

        public delegate void SetUnitFogPrototype(JassRealArg a, JassRealArg b, JassRealArg c, JassRealArg d, JassRealArg e);

        public delegate void SetTerrainFogExPrototype(JassInteger style, JassRealArg zstart, JassRealArg zend, JassRealArg density, JassRealArg red, JassRealArg green, JassRealArg blue);

        public delegate void DisplayTextToPlayerPrototype(JassPlayer toPlayer, JassRealArg x, JassRealArg y, JassStringArg message);

        public delegate void DisplayTimedTextToPlayerPrototype(JassPlayer toPlayer, JassRealArg x, JassRealArg y, JassRealArg duration, JassStringArg message);

        public delegate void DisplayTimedTextFromPlayerPrototype(JassPlayer toPlayer, JassRealArg x, JassRealArg y, JassRealArg duration, JassStringArg message);

        public delegate void ClearTextMessagesPrototype();

        public delegate void SetDayNightModelsPrototype(JassStringArg terrainDNCFile, JassStringArg unitDNCFile);

        public delegate void SetSkyModelPrototype(JassStringArg skyModelFile);

        public delegate void EnableUserControlPrototype(JassBoolean b);

        public delegate void EnableUserUIPrototype(JassBoolean b);

        public delegate void SuspendTimeOfDayPrototype(JassBoolean b);

        public delegate void SetTimeOfDayScalePrototype(JassRealArg r);

        public delegate JassRealRet GetTimeOfDayScalePrototype();

        public delegate void ShowInterfacePrototype(JassBoolean flag, JassRealArg fadeDuration);

        public delegate void PauseGamePrototype(JassBoolean flag);

        public delegate void UnitAddIndicatorPrototype(JassUnit whichUnit, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void AddIndicatorPrototype(JassWidget whichWidget, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void PingMinimapPrototype(JassRealArg x, JassRealArg y, JassRealArg duration);

        public delegate void PingMinimapExPrototype(JassRealArg x, JassRealArg y, JassRealArg duration, JassInteger red, JassInteger green, JassInteger blue, JassBoolean extraEffects);

        public delegate void EnableOcclusionPrototype(JassBoolean flag);

        public delegate void SetIntroShotTextPrototype(JassStringArg introText);

        public delegate void SetIntroShotModelPrototype(JassStringArg introModelPath);

        public delegate void EnableWorldFogBoundaryPrototype(JassBoolean b);

        public delegate void PlayModelCinematicPrototype(JassStringArg modelName);

        public delegate void PlayCinematicPrototype(JassStringArg movieName);

        public delegate void ForceUIKeyPrototype(JassStringArg key);

        public delegate void ForceUICancelPrototype();

        public delegate void DisplayLoadDialogPrototype();

        public delegate void SetAltMinimapIconPrototype(JassStringArg iconPath);

        public delegate void DisableRestartMissionPrototype(JassBoolean flag);

        public delegate JassTextTag CreateTextTagPrototype();

        public delegate void DestroyTextTagPrototype(JassTextTag t);

        public delegate void SetTextTagTextPrototype(JassTextTag t, JassStringArg s, JassRealArg height);

        public delegate void SetTextTagPosPrototype(JassTextTag t, JassRealArg x, JassRealArg y, JassRealArg heightOffset);

        public delegate void SetTextTagPosUnitPrototype(JassTextTag t, JassUnit whichUnit, JassRealArg heightOffset);

        public delegate void SetTextTagColorPrototype(JassTextTag t, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void SetTextTagVelocityPrototype(JassTextTag t, JassRealArg xvel, JassRealArg yvel);

        public delegate void SetTextTagVisibilityPrototype(JassTextTag t, JassBoolean flag);

        public delegate void SetTextTagSuspendedPrototype(JassTextTag t, JassBoolean flag);

        public delegate void SetTextTagPermanentPrototype(JassTextTag t, JassBoolean flag);

        public delegate void SetTextTagAgePrototype(JassTextTag t, JassRealArg age);

        public delegate void SetTextTagLifespanPrototype(JassTextTag t, JassRealArg lifespan);

        public delegate void SetTextTagFadepointPrototype(JassTextTag t, JassRealArg fadepoint);

        public delegate void SetReservedLocalHeroButtonsPrototype(JassInteger reserved);

        public delegate JassInteger GetAllyColorFilterStatePrototype();

        public delegate void SetAllyColorFilterStatePrototype(JassInteger state);

        public delegate JassBoolean GetCreepCampFilterStatePrototype();

        public delegate void SetCreepCampFilterStatePrototype(JassBoolean state);

        public delegate void EnableMinimapFilterButtonsPrototype(JassBoolean enableAlly, JassBoolean enableCreep);

        public delegate void EnableDragSelectPrototype(JassBoolean state, JassBoolean ui);

        public delegate void EnablePreSelectPrototype(JassBoolean state, JassBoolean ui);

        public delegate void EnableSelectPrototype(JassBoolean state, JassBoolean ui);

        public delegate JassTrackable CreateTrackablePrototype(JassStringArg trackableModelPath, JassRealArg x, JassRealArg y, JassRealArg facing);

        public delegate JassQuest CreateQuestPrototype();

        public delegate void DestroyQuestPrototype(JassQuest whichQuest);

        public delegate void QuestSetTitlePrototype(JassQuest whichQuest, JassStringArg title);

        public delegate void QuestSetDescriptionPrototype(JassQuest whichQuest, JassStringArg description);

        public delegate void QuestSetIconPathPrototype(JassQuest whichQuest, JassStringArg iconPath);

        public delegate void QuestSetRequiredPrototype(JassQuest whichQuest, JassBoolean required);

        public delegate void QuestSetCompletedPrototype(JassQuest whichQuest, JassBoolean completed);

        public delegate void QuestSetDiscoveredPrototype(JassQuest whichQuest, JassBoolean discovered);

        public delegate void QuestSetFailedPrototype(JassQuest whichQuest, JassBoolean failed);

        public delegate void QuestSetEnabledPrototype(JassQuest whichQuest, JassBoolean enabled);

        public delegate JassBoolean IsQuestRequiredPrototype(JassQuest whichQuest);

        public delegate JassBoolean IsQuestCompletedPrototype(JassQuest whichQuest);

        public delegate JassBoolean IsQuestDiscoveredPrototype(JassQuest whichQuest);

        public delegate JassBoolean IsQuestFailedPrototype(JassQuest whichQuest);

        public delegate JassBoolean IsQuestEnabledPrototype(JassQuest whichQuest);

        public delegate JassQuestItem QuestCreateItemPrototype(JassQuest whichQuest);

        public delegate void QuestItemSetDescriptionPrototype(JassQuestItem whichQuestItem, JassStringArg description);

        public delegate void QuestItemSetCompletedPrototype(JassQuestItem whichQuestItem, JassBoolean completed);

        public delegate JassBoolean IsQuestItemCompletedPrototype(JassQuestItem whichQuestItem);

        public delegate JassDefeatCondition CreateDefeatConditionPrototype();

        public delegate void DestroyDefeatConditionPrototype(JassDefeatCondition whichCondition);

        public delegate void DefeatConditionSetDescriptionPrototype(JassDefeatCondition whichCondition, JassStringArg description);

        public delegate void FlashQuestDialogButtonPrototype();

        public delegate void ForceQuestDialogUpdatePrototype();

        public delegate JassTimerDialog CreateTimerDialogPrototype(JassTimer t);

        public delegate void DestroyTimerDialogPrototype(JassTimerDialog whichDialog);

        public delegate void TimerDialogSetTitlePrototype(JassTimerDialog whichDialog, JassStringArg title);

        public delegate void TimerDialogSetTitleColorPrototype(JassTimerDialog whichDialog, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void TimerDialogSetTimeColorPrototype(JassTimerDialog whichDialog, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void TimerDialogSetSpeedPrototype(JassTimerDialog whichDialog, JassRealArg speedMultFactor);

        public delegate void TimerDialogDisplayPrototype(JassTimerDialog whichDialog, JassBoolean display);

        public delegate JassBoolean IsTimerDialogDisplayedPrototype(JassTimerDialog whichDialog);

        public delegate void TimerDialogSetRealTimeRemainingPrototype(JassTimerDialog whichDialog, JassRealArg timeRemaining);

        public delegate JassLeaderboard CreateLeaderboardPrototype();

        public delegate void DestroyLeaderboardPrototype(JassLeaderboard lb);

        public delegate void LeaderboardDisplayPrototype(JassLeaderboard lb, JassBoolean show);

        public delegate JassBoolean IsLeaderboardDisplayedPrototype(JassLeaderboard lb);

        public delegate JassInteger LeaderboardGetItemCountPrototype(JassLeaderboard lb);

        public delegate void LeaderboardSetSizeByItemCountPrototype(JassLeaderboard lb, JassInteger count);

        public delegate void LeaderboardAddItemPrototype(JassLeaderboard lb, JassStringArg label, JassInteger value, JassPlayer p);

        public delegate void LeaderboardRemoveItemPrototype(JassLeaderboard lb, JassInteger index);

        public delegate void LeaderboardRemovePlayerItemPrototype(JassLeaderboard lb, JassPlayer p);

        public delegate void LeaderboardClearPrototype(JassLeaderboard lb);

        public delegate void LeaderboardSortItemsByValuePrototype(JassLeaderboard lb, JassBoolean ascending);

        public delegate void LeaderboardSortItemsByPlayerPrototype(JassLeaderboard lb, JassBoolean ascending);

        public delegate void LeaderboardSortItemsByLabelPrototype(JassLeaderboard lb, JassBoolean ascending);

        public delegate JassBoolean LeaderboardHasPlayerItemPrototype(JassLeaderboard lb, JassPlayer p);

        public delegate JassInteger LeaderboardGetPlayerIndexPrototype(JassLeaderboard lb, JassPlayer p);

        public delegate void LeaderboardSetLabelPrototype(JassLeaderboard lb, JassStringArg label);

        public delegate JassStringRet LeaderboardGetLabelTextPrototype(JassLeaderboard lb);

        public delegate void PlayerSetLeaderboardPrototype(JassPlayer toPlayer, JassLeaderboard lb);

        public delegate JassLeaderboard PlayerGetLeaderboardPrototype(JassPlayer toPlayer);

        public delegate void LeaderboardSetLabelColorPrototype(JassLeaderboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void LeaderboardSetValueColorPrototype(JassLeaderboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void LeaderboardSetStylePrototype(JassLeaderboard lb, JassBoolean showLabel, JassBoolean showNames, JassBoolean showValues, JassBoolean showIcons);

        public delegate void LeaderboardSetItemValuePrototype(JassLeaderboard lb, JassInteger whichItem, JassInteger val);

        public delegate void LeaderboardSetItemLabelPrototype(JassLeaderboard lb, JassInteger whichItem, JassStringArg val);

        public delegate void LeaderboardSetItemStylePrototype(JassLeaderboard lb, JassInteger whichItem, JassBoolean showLabel, JassBoolean showValue, JassBoolean showIcon);

        public delegate void LeaderboardSetItemLabelColorPrototype(JassLeaderboard lb, JassInteger whichItem, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void LeaderboardSetItemValueColorPrototype(JassLeaderboard lb, JassInteger whichItem, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate JassMultiboard CreateMultiboardPrototype();

        public delegate void DestroyMultiboardPrototype(JassMultiboard lb);

        public delegate void MultiboardDisplayPrototype(JassMultiboard lb, JassBoolean show);

        public delegate JassBoolean IsMultiboardDisplayedPrototype(JassMultiboard lb);

        public delegate void MultiboardMinimizePrototype(JassMultiboard lb, JassBoolean minimize);

        public delegate JassBoolean IsMultiboardMinimizedPrototype(JassMultiboard lb);

        public delegate void MultiboardClearPrototype(JassMultiboard lb);

        public delegate void MultiboardSetTitleTextPrototype(JassMultiboard lb, JassStringArg label);

        public delegate JassStringRet MultiboardGetTitleTextPrototype(JassMultiboard lb);

        public delegate void MultiboardSetTitleTextColorPrototype(JassMultiboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate JassInteger MultiboardGetRowCountPrototype(JassMultiboard lb);

        public delegate JassInteger MultiboardGetColumnCountPrototype(JassMultiboard lb);

        public delegate void MultiboardSetColumnCountPrototype(JassMultiboard lb, JassInteger count);

        public delegate void MultiboardSetRowCountPrototype(JassMultiboard lb, JassInteger count);

        public delegate void MultiboardSetItemsStylePrototype(JassMultiboard lb, JassBoolean showValues, JassBoolean showIcons);

        public delegate void MultiboardSetItemsValuePrototype(JassMultiboard lb, JassStringArg value);

        public delegate void MultiboardSetItemsValueColorPrototype(JassMultiboard lb, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void MultiboardSetItemsWidthPrototype(JassMultiboard lb, JassRealArg width);

        public delegate void MultiboardSetItemsIconPrototype(JassMultiboard lb, JassStringArg iconPath);

        public delegate JassMultiboardItem MultiboardGetItemPrototype(JassMultiboard lb, JassInteger row, JassInteger column);

        public delegate void MultiboardReleaseItemPrototype(JassMultiboardItem mbi);

        public delegate void MultiboardSetItemStylePrototype(JassMultiboardItem mbi, JassBoolean showValue, JassBoolean showIcon);

        public delegate void MultiboardSetItemValuePrototype(JassMultiboardItem mbi, JassStringArg val);

        public delegate void MultiboardSetItemValueColorPrototype(JassMultiboardItem mbi, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void MultiboardSetItemWidthPrototype(JassMultiboardItem mbi, JassRealArg width);

        public delegate void MultiboardSetItemIconPrototype(JassMultiboardItem mbi, JassStringArg iconFileName);

        public delegate void MultiboardSuppressDisplayPrototype(JassBoolean flag);

        public delegate void SetCameraPositionPrototype(JassRealArg x, JassRealArg y);

        public delegate void SetCameraQuickPositionPrototype(JassRealArg x, JassRealArg y);

        public delegate void SetCameraBoundsPrototype(JassRealArg x1, JassRealArg y1, JassRealArg x2, JassRealArg y2, JassRealArg x3, JassRealArg y3, JassRealArg x4, JassRealArg y4);

        public delegate void StopCameraPrototype();

        public delegate void ResetToGameCameraPrototype(JassRealArg duration);

        public delegate void PanCameraToPrototype(JassRealArg x, JassRealArg y);

        public delegate void PanCameraToTimedPrototype(JassRealArg x, JassRealArg y, JassRealArg duration);

        public delegate void PanCameraToWithZPrototype(JassRealArg x, JassRealArg y, JassRealArg zOffsetDest);

        public delegate void PanCameraToTimedWithZPrototype(JassRealArg x, JassRealArg y, JassRealArg zOffsetDest, JassRealArg duration);

        public delegate void SetCinematicCameraPrototype(JassStringArg cameraModelFile);

        public delegate void SetCameraRotateModePrototype(JassRealArg x, JassRealArg y, JassRealArg radiansToSweep, JassRealArg duration);

        public delegate void SetCameraFieldPrototype(JassCameraField whichField, JassRealArg value, JassRealArg duration);

        public delegate void AdjustCameraFieldPrototype(JassCameraField whichField, JassRealArg offset, JassRealArg duration);

        public delegate void SetCameraTargetControllerPrototype(JassUnit whichUnit, JassRealArg xoffset, JassRealArg yoffset, JassBoolean inheritOrientation);

        public delegate void SetCameraOrientControllerPrototype(JassUnit whichUnit, JassRealArg xoffset, JassRealArg yoffset);

        public delegate JassCameraSetup CreateCameraSetupPrototype();

        public delegate void CameraSetupSetFieldPrototype(JassCameraSetup whichSetup, JassCameraField whichField, JassRealArg value, JassRealArg duration);

        public delegate JassRealRet CameraSetupGetFieldPrototype(JassCameraSetup whichSetup, JassCameraField whichField);

        public delegate void CameraSetupSetDestPositionPrototype(JassCameraSetup whichSetup, JassRealArg x, JassRealArg y, JassRealArg duration);

        public delegate JassLocation CameraSetupGetDestPositionLocPrototype(JassCameraSetup whichSetup);

        public delegate JassRealRet CameraSetupGetDestPositionXPrototype(JassCameraSetup whichSetup);

        public delegate JassRealRet CameraSetupGetDestPositionYPrototype(JassCameraSetup whichSetup);

        public delegate void CameraSetupApplyPrototype(JassCameraSetup whichSetup, JassBoolean doPan, JassBoolean panTimed);

        public delegate void CameraSetupApplyWithZPrototype(JassCameraSetup whichSetup, JassRealArg zDestOffset);

        public delegate void CameraSetupApplyForceDurationPrototype(JassCameraSetup whichSetup, JassBoolean doPan, JassRealArg forceDuration);

        public delegate void CameraSetupApplyForceDurationWithZPrototype(JassCameraSetup whichSetup, JassRealArg zDestOffset, JassRealArg forceDuration);

        public delegate void CameraSetTargetNoisePrototype(JassRealArg mag, JassRealArg velocity);

        public delegate void CameraSetSourceNoisePrototype(JassRealArg mag, JassRealArg velocity);

        public delegate void CameraSetTargetNoiseExPrototype(JassRealArg mag, JassRealArg velocity, JassBoolean vertOnly);

        public delegate void CameraSetSourceNoiseExPrototype(JassRealArg mag, JassRealArg velocity, JassBoolean vertOnly);

        public delegate void CameraSetSmoothingFactorPrototype(JassRealArg factor);

        public delegate void SetCineFilterTexturePrototype(JassStringArg filename);

        public delegate void SetCineFilterBlendModePrototype(JassBlendMode whichMode);

        public delegate void SetCineFilterTexMapFlagsPrototype(JassTextureMapFlags whichFlags);

        public delegate void SetCineFilterStartUVPrototype(JassRealArg minu, JassRealArg minv, JassRealArg maxu, JassRealArg maxv);

        public delegate void SetCineFilterEndUVPrototype(JassRealArg minu, JassRealArg minv, JassRealArg maxu, JassRealArg maxv);

        public delegate void SetCineFilterStartColorPrototype(JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void SetCineFilterEndColorPrototype(JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void SetCineFilterDurationPrototype(JassRealArg duration);

        public delegate void DisplayCineFilterPrototype(JassBoolean flag);

        public delegate JassBoolean IsCineFilterDisplayedPrototype();

        public delegate void SetCinematicScenePrototype(JassInteger portraitUnitId, JassPlayerColor color, JassStringArg speakerTitle, JassStringArg text, JassRealArg sceneDuration, JassRealArg voiceoverDuration);

        public delegate void EndCinematicScenePrototype();

        public delegate void ForceCinematicSubtitlesPrototype(JassBoolean flag);

        public delegate JassRealRet GetCameraMarginPrototype(JassInteger whichMargin);

        public delegate JassRealRet GetCameraBoundMinXPrototype();

        public delegate JassRealRet GetCameraBoundMinYPrototype();

        public delegate JassRealRet GetCameraBoundMaxXPrototype();

        public delegate JassRealRet GetCameraBoundMaxYPrototype();

        public delegate JassRealRet GetCameraFieldPrototype(JassCameraField whichField);

        public delegate JassRealRet GetCameraTargetPositionXPrototype();

        public delegate JassRealRet GetCameraTargetPositionYPrototype();

        public delegate JassRealRet GetCameraTargetPositionZPrototype();

        public delegate JassLocation GetCameraTargetPositionLocPrototype();

        public delegate JassRealRet GetCameraEyePositionXPrototype();

        public delegate JassRealRet GetCameraEyePositionYPrototype();

        public delegate JassRealRet GetCameraEyePositionZPrototype();

        public delegate JassLocation GetCameraEyePositionLocPrototype();

        public delegate void NewSoundEnvironmentPrototype(JassStringArg environmentName);

        public delegate JassSound CreateSoundPrototype(JassStringArg fileName, JassBoolean looping, JassBoolean is3D, JassBoolean stopwhenoutofrange, JassInteger fadeInRate, JassInteger fadeOutRate, JassStringArg eaxSetting);

        public delegate JassSound CreateSoundFilenameWithLabelPrototype(JassStringArg fileName, JassBoolean looping, JassBoolean is3D, JassBoolean stopwhenoutofrange, JassInteger fadeInRate, JassInteger fadeOutRate, JassStringArg SLKEntryName);

        public delegate JassSound CreateSoundFromLabelPrototype(JassStringArg soundLabel, JassBoolean looping, JassBoolean is3D, JassBoolean stopwhenoutofrange, JassInteger fadeInRate, JassInteger fadeOutRate);

        public delegate JassSound CreateMIDISoundPrototype(JassStringArg soundLabel, JassInteger fadeInRate, JassInteger fadeOutRate);

        public delegate void SetSoundParamsFromLabelPrototype(JassSound soundHandle, JassStringArg soundLabel);

        public delegate void SetSoundDistanceCutoffPrototype(JassSound soundHandle, JassRealArg cutoff);

        public delegate void SetSoundChannelPrototype(JassSound soundHandle, JassInteger channel);

        public delegate void SetSoundVolumePrototype(JassSound soundHandle, JassInteger volume);

        public delegate void SetSoundPitchPrototype(JassSound soundHandle, JassRealArg pitch);

        public delegate void SetSoundPlayPositionPrototype(JassSound soundHandle, JassInteger millisecs);

        public delegate void SetSoundDistancesPrototype(JassSound soundHandle, JassRealArg minDist, JassRealArg maxDist);

        public delegate void SetSoundConeAnglesPrototype(JassSound soundHandle, JassRealArg inside, JassRealArg outside, JassInteger outsideVolume);

        public delegate void SetSoundConeOrientationPrototype(JassSound soundHandle, JassRealArg x, JassRealArg y, JassRealArg z);

        public delegate void SetSoundPositionPrototype(JassSound soundHandle, JassRealArg x, JassRealArg y, JassRealArg z);

        public delegate void SetSoundVelocityPrototype(JassSound soundHandle, JassRealArg x, JassRealArg y, JassRealArg z);

        public delegate void AttachSoundToUnitPrototype(JassSound soundHandle, JassUnit whichUnit);

        public delegate void StartSoundPrototype(JassSound soundHandle);

        public delegate void StopSoundPrototype(JassSound soundHandle, JassBoolean killWhenDone, JassBoolean fadeOut);

        public delegate void KillSoundWhenDonePrototype(JassSound soundHandle);

        public delegate void SetMapMusicPrototype(JassStringArg musicName, JassBoolean random, JassInteger index);

        public delegate void ClearMapMusicPrototype();

        public delegate void PlayMusicPrototype(JassStringArg musicName);

        public delegate void PlayMusicExPrototype(JassStringArg musicName, JassInteger frommsecs, JassInteger fadeinmsecs);

        public delegate void StopMusicPrototype(JassBoolean fadeOut);

        public delegate void ResumeMusicPrototype();

        public delegate void PlayThematicMusicPrototype(JassStringArg musicFileName);

        public delegate void PlayThematicMusicExPrototype(JassStringArg musicFileName, JassInteger frommsecs);

        public delegate void EndThematicMusicPrototype();

        public delegate void SetMusicVolumePrototype(JassInteger volume);

        public delegate void SetMusicPlayPositionPrototype(JassInteger millisecs);

        public delegate void SetThematicMusicPlayPositionPrototype(JassInteger millisecs);

        public delegate void SetSoundDurationPrototype(JassSound soundHandle, JassInteger duration);

        public delegate JassInteger GetSoundDurationPrototype(JassSound soundHandle);

        public delegate JassInteger GetSoundFileDurationPrototype(JassStringArg musicFileName);

        public delegate void VolumeGroupSetVolumePrototype(JassVolumeGroup vgroup, JassRealArg scale);

        public delegate void VolumeGroupResetPrototype();

        public delegate JassBoolean GetSoundIsPlayingPrototype(JassSound soundHandle);

        public delegate JassBoolean GetSoundIsLoadingPrototype(JassSound soundHandle);

        public delegate void RegisterStackedSoundPrototype(JassSound soundHandle, JassBoolean byPosition, JassRealArg rectwidth, JassRealArg rectheight);

        public delegate void UnregisterStackedSoundPrototype(JassSound soundHandle, JassBoolean byPosition, JassRealArg rectwidth, JassRealArg rectheight);

        public delegate JassWeatherEffect AddWeatherEffectPrototype(JassRect where, JassInteger effectID);

        public delegate void RemoveWeatherEffectPrototype(JassWeatherEffect whichEffect);

        public delegate void EnableWeatherEffectPrototype(JassWeatherEffect whichEffect, JassBoolean enable);

        public delegate JassTerrainDeformation TerrainDeformCraterPrototype(JassRealArg x, JassRealArg y, JassRealArg radius, JassRealArg depth, JassInteger duration, JassBoolean permanent);

        public delegate JassTerrainDeformation TerrainDeformRipplePrototype(JassRealArg x, JassRealArg y, JassRealArg radius, JassRealArg depth, JassInteger duration, JassInteger count, JassRealArg spaceWaves, JassRealArg timeWaves, JassRealArg radiusStartPct, JassBoolean limitNeg);

        public delegate JassTerrainDeformation TerrainDeformWavePrototype(JassRealArg x, JassRealArg y, JassRealArg dirX, JassRealArg dirY, JassRealArg distance, JassRealArg speed, JassRealArg radius, JassRealArg depth, JassInteger trailTime, JassInteger count);

        public delegate JassTerrainDeformation TerrainDeformRandomPrototype(JassRealArg x, JassRealArg y, JassRealArg radius, JassRealArg minDelta, JassRealArg maxDelta, JassInteger duration, JassInteger updateInterval);

        public delegate void TerrainDeformStopPrototype(JassTerrainDeformation deformation, JassInteger duration);

        public delegate void TerrainDeformStopAllPrototype();

        public delegate JassEffect AddSpecialEffectPrototype(JassStringArg modelName, JassRealArg x, JassRealArg y);

        public delegate JassEffect AddSpecialEffectLocPrototype(JassStringArg modelName, JassLocation where);

        public delegate JassEffect AddSpecialEffectTargetPrototype(JassStringArg modelName, JassWidget targetWidget, JassStringArg attachPointName);

        public delegate void DestroyEffectPrototype(JassEffect whichEffect);

        public delegate JassEffect AddSpellEffectPrototype(JassStringArg abilityString, JassEffectType t, JassRealArg x, JassRealArg y);

        public delegate JassEffect AddSpellEffectLocPrototype(JassStringArg abilityString, JassEffectType t, JassLocation where);

        public delegate JassEffect AddSpellEffectByIdPrototype(JassObjectId abilityId, JassEffectType t, JassRealArg x, JassRealArg y);

        public delegate JassEffect AddSpellEffectByIdLocPrototype(JassObjectId abilityId, JassEffectType t, JassLocation where);

        public delegate JassEffect AddSpellEffectTargetPrototype(JassStringArg modelName, JassEffectType t, JassWidget targetWidget, JassStringArg attachPoint);

        public delegate JassEffect AddSpellEffectTargetByIdPrototype(JassObjectId abilityId, JassEffectType t, JassWidget targetWidget, JassStringArg attachPoint);

        public delegate JassLightning AddLightningPrototype(JassStringArg codeName, JassBoolean checkVisibility, JassRealArg x1, JassRealArg y1, JassRealArg x2, JassRealArg y2);

        public delegate JassLightning AddLightningExPrototype(JassStringArg codeName, JassBoolean checkVisibility, JassRealArg x1, JassRealArg y1, JassRealArg z1, JassRealArg x2, JassRealArg y2, JassRealArg z2);

        public delegate JassBoolean DestroyLightningPrototype(JassLightning whichBolt);

        public delegate JassBoolean MoveLightningPrototype(JassLightning whichBolt, JassBoolean checkVisibility, JassRealArg x1, JassRealArg y1, JassRealArg x2, JassRealArg y2);

        public delegate JassBoolean MoveLightningExPrototype(JassLightning whichBolt, JassBoolean checkVisibility, JassRealArg x1, JassRealArg y1, JassRealArg z1, JassRealArg x2, JassRealArg y2, JassRealArg z2);

        public delegate JassRealRet GetLightningColorAPrototype(JassLightning whichBolt);

        public delegate JassRealRet GetLightningColorRPrototype(JassLightning whichBolt);

        public delegate JassRealRet GetLightningColorGPrototype(JassLightning whichBolt);

        public delegate JassRealRet GetLightningColorBPrototype(JassLightning whichBolt);

        public delegate JassBoolean SetLightningColorPrototype(JassLightning whichBolt, JassRealArg r, JassRealArg g, JassRealArg b, JassRealArg a);

        public delegate JassStringRet GetAbilityEffectPrototype(JassStringArg abilityString, JassEffectType t, JassInteger index);

        public delegate JassStringRet GetAbilityEffectByIdPrototype(JassObjectId abilityId, JassEffectType t, JassInteger index);

        public delegate JassStringRet GetAbilitySoundPrototype(JassStringArg abilityString, JassSoundType t);

        public delegate JassStringRet GetAbilitySoundByIdPrototype(JassObjectId abilityId, JassSoundType t);

        public delegate JassInteger GetTerrainCliffLevelPrototype(JassRealArg x, JassRealArg y);

        public delegate void SetWaterBaseColorPrototype(JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void SetWaterDeformsPrototype(JassBoolean val);

        public delegate JassInteger GetTerrainTypePrototype(JassRealArg x, JassRealArg y);

        public delegate JassInteger GetTerrainVariancePrototype(JassRealArg x, JassRealArg y);

        public delegate void SetTerrainTypePrototype(JassRealArg x, JassRealArg y, JassInteger terrainType, JassInteger variation, JassInteger area, JassInteger shape);

        public delegate JassBoolean IsTerrainPathablePrototype(JassRealArg x, JassRealArg y, JassPathingType t);

        public delegate void SetTerrainPathablePrototype(JassRealArg x, JassRealArg y, JassPathingType t, JassBoolean flag);

        public delegate JassImage CreateImagePrototype(JassStringArg file, JassRealArg sizeX, JassRealArg sizeY, JassRealArg sizeZ, JassRealArg posX, JassRealArg posY, JassRealArg posZ, JassRealArg originX, JassRealArg originY, JassRealArg originZ, JassInteger imageType);

        public delegate void DestroyImagePrototype(JassImage whichImage);

        public delegate void ShowImagePrototype(JassImage whichImage, JassBoolean flag);

        public delegate void SetImageConstantHeightPrototype(JassImage whichImage, JassBoolean flag, JassRealArg height);

        public delegate void SetImagePositionPrototype(JassImage whichImage, JassRealArg x, JassRealArg y, JassRealArg z);

        public delegate void SetImageColorPrototype(JassImage whichImage, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha);

        public delegate void SetImageRenderPrototype(JassImage whichImage, JassBoolean flag);

        public delegate void SetImageRenderAlwaysPrototype(JassImage whichImage, JassBoolean flag);

        public delegate void SetImageAboveWaterPrototype(JassImage whichImage, JassBoolean flag, JassBoolean useWaterAlpha);

        public delegate void SetImageTypePrototype(JassImage whichImage, JassInteger imageType);

        public delegate JassUberSplat CreateUbersplatPrototype(JassRealArg x, JassRealArg y, JassStringArg name, JassInteger red, JassInteger green, JassInteger blue, JassInteger alpha, JassBoolean forcePaused, JassBoolean noBirthTime);

        public delegate void DestroyUbersplatPrototype(JassUberSplat whichSplat);

        public delegate void ResetUbersplatPrototype(JassUberSplat whichSplat);

        public delegate void FinishUbersplatPrototype(JassUberSplat whichSplat);

        public delegate void ShowUbersplatPrototype(JassUberSplat whichSplat, JassBoolean flag);

        public delegate void SetUbersplatRenderPrototype(JassUberSplat whichSplat, JassBoolean flag);

        public delegate void SetUbersplatRenderAlwaysPrototype(JassUberSplat whichSplat, JassBoolean flag);

        public delegate void SetBlightPrototype(JassPlayer whichPlayer, JassRealArg x, JassRealArg y, JassRealArg radius, JassBoolean addBlight);

        public delegate void SetBlightRectPrototype(JassPlayer whichPlayer, JassRect r, JassBoolean addBlight);

        public delegate void SetBlightPointPrototype(JassPlayer whichPlayer, JassRealArg x, JassRealArg y, JassBoolean addBlight);

        public delegate void SetBlightLocPrototype(JassPlayer whichPlayer, JassLocation whichLocation, JassRealArg radius, JassBoolean addBlight);

        public delegate JassUnit CreateBlightedGoldminePrototype(JassPlayer id, JassRealArg x, JassRealArg y, JassRealArg face);

        public delegate JassBoolean IsPointBlightedPrototype(JassRealArg x, JassRealArg y);

        public delegate void SetDoodadAnimationPrototype(JassRealArg x, JassRealArg y, JassRealArg radius, JassObjectId doodadID, JassBoolean nearestOnly, JassStringArg animName, JassBoolean animRandom);

        public delegate void SetDoodadAnimationRectPrototype(JassRect r, JassObjectId doodadID, JassStringArg animName, JassBoolean animRandom);

        public delegate void StartMeleeAIPrototype(JassPlayer num, JassStringArg script);

        public delegate void StartCampaignAIPrototype(JassPlayer num, JassStringArg script);

        public delegate void CommandAIPrototype(JassPlayer num, JassInteger command, JassInteger data);

        public delegate void PauseCompAIPrototype(JassPlayer p, JassBoolean pause);

        public delegate JassAIDifficulty GetAIDifficultyPrototype(JassPlayer num);

        public delegate void RemoveGuardPositionPrototype(JassUnit hUnit);

        public delegate void RecycleGuardPositionPrototype(JassUnit hUnit);

        public delegate void RemoveAllGuardPositionsPrototype(JassPlayer num);

        public delegate void CheatPrototype(JassStringArg cheatStr);

        public delegate JassBoolean IsNoVictoryCheatPrototype();

        public delegate JassBoolean IsNoDefeatCheatPrototype();

        public delegate void PreloadPrototype(JassStringArg filename);

        public delegate void PreloadEndPrototype(JassRealArg timeout);

        public delegate void PreloadStartPrototype();

        public delegate void PreloadRefreshPrototype();

        public delegate void PreloadEndExPrototype();

        public delegate void PreloadGenClearPrototype();

        public delegate void PreloadGenStartPrototype();

        public delegate void PreloadGenEndPrototype(JassStringArg filename);

        public delegate void PreloaderPrototype(JassStringArg filename);
    }
}