using System;

using Cirnix.JassNative.WarAPI;
using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Htrigger;")]
    [Serializable]
    public struct JassTrigger
    {
        public readonly IntPtr Handle;

        public JassTrigger(IntPtr handle)
        {
            Handle = handle;
        }

        public CTriggerWar3Ptr ToCTrigger()
        {
            return GameFunctions.GetTriggerFromHandle(Handle);
        }

        public static JassTrigger Create()
        {
            return Natives.CreateTrigger();
        }

        public void AddAction(JassCode action)
        {
            Natives.TriggerAddAction(this, action);
        }

        public JassEvent RegisterVariableEvent(string variableName, JassLimitOp opcode, float value)
        {
            return Natives.TriggerRegisterVariableEvent(this, variableName, opcode, value);
        }

        public JassEvent RegisterTimerEvent(float timeout, bool periodic)
        {
            return Natives.TriggerRegisterTimerEvent(this, timeout, periodic);
        }

        public JassEvent RegisterTimerExpireEvent(JassTimer timer)
        {
            return Natives.TriggerRegisterTimerExpireEvent(this, timer);
        }

        public JassEvent RegisterGameStateEvent(JassGameState state, JassLimitOp opcode, float value)
        {
            return Natives.TriggerRegisterGameStateEvent(this, state, opcode, value);
        }

        public JassEvent RegisterDialogEvent(JassDialog dialog)
        {
            return Natives.TriggerRegisterDialogEvent(this, dialog);
        }

        public JassEvent RegisterDialogButtonEvent(JassButton button)
        {
            return Natives.TriggerRegisterDialogButtonEvent(this, button);
        }

        public JassEvent RegisterGameEvent(JassGameEvent gameEvent)
        {
            return Natives.TriggerRegisterGameEvent(this, gameEvent);
        }

        public JassEvent RegisterEnterRegion(JassRegion region, JassBooleanExpression filter)
        {
            return Natives.TriggerRegisterEnterRegion(this, region, filter);
        }

        public JassEvent RegisterLeaveRegion(JassRegion region, JassBooleanExpression filter)
        {
            return Natives.TriggerRegisterLeaveRegion(this, region, filter);
        }

        public JassEvent RegisterTrackableHitEvent(JassTrackable trackable)
        {
            return Natives.TriggerRegisterTrackableHitEvent(this, trackable);
        }

        public JassEvent RegisterTrackableTrackEvent(JassTrackable trackable)
        {
            return Natives.TriggerRegisterTrackableTrackEvent(this, trackable);
        }

        public JassEvent RegisterPlayerEvent(JassPlayer player, JassPlayerEvent playerEvent)
        {
            return Natives.TriggerRegisterPlayerEvent(this, player, playerEvent);
        }

        public JassEvent RegisterPlayerUnitEvent(JassPlayer player, JassPlayerUnitEvent playerUnitEvent, JassBooleanExpression filter)
        {
            return Natives.TriggerRegisterPlayerUnitEvent(this, player, playerUnitEvent, filter);
        }

        public JassEvent RegisterPlayerAllianceChange(JassPlayer player, JassAllianceType allianceType)
        {
            return Natives.TriggerRegisterPlayerAllianceChange(this, player, allianceType);
        }

        public JassEvent RegisterPlayerStateEvent(JassPlayer player, JassPlayerState state, JassLimitOp opcode, float value)
        {
            return Natives.TriggerRegisterPlayerStateEvent(this, player, state, opcode, value);
        }

        public JassEvent RegisterPlayerChatEvent(JassPlayer player, string message, bool exactMatchOnly)
        {
            return Natives.TriggerRegisterPlayerChatEvent(this, player, message, exactMatchOnly);
        }

        public JassEvent RegisterDeathEvent(JassWidget widget)
        {
            return Natives.TriggerRegisterDeathEvent(this, widget);
        }

        public JassEvent RegisterUnitStateEvent(JassUnit unit, JassUnitState state, JassLimitOp opcode, float value)
        {
            return Natives.TriggerRegisterUnitStateEvent(this, unit, state, opcode, value);
        }

        public JassEvent RegisterUnitEvent(JassUnit unit, JassUnitEvent unitEvent)
        {
            return Natives.TriggerRegisterUnitEvent(this, unit, unitEvent);
        }

        public JassEvent RegisterFilterUnitEvent(JassUnit unit, JassUnitEvent unitEvent, JassBooleanExpression filter)
        {
            return Natives.TriggerRegisterFilterUnitEvent(this, unit, unitEvent, filter);
        }

        public JassEvent RegisterUnitInRange(JassUnit unit, float range, JassBooleanExpression filter)
        {
            return Natives.TriggerRegisterUnitInRange(this, unit, range, filter);
        }

        public JassBoolean Evaluate()
        {
            return Natives.TriggerEvaluate(this);
        }

        public void Execute()
        {
            Natives.TriggerExecute(this);
        }

        public void Destroy()
        {
            Natives.DestroyTrigger(this);
        }

        public void Reset()
        {
            Natives.ResetTrigger(this);
        }

        public bool GetEnabled()
        {
            return Natives.IsTriggerEnabled(this);
        }

        public void SetEnabled(bool value)
        {
            if (value)
                Natives.EnableTrigger(this);
            else
                Natives.DisableTrigger(this);
        }

        public bool Enabled {
            get => GetEnabled();
            set => SetEnabled(value);
        }
    }
}
