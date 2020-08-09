using Cirnix.JassNative.WarAPI.Types;
using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hunit;")]
    [Serializable]
    public struct JassUnit
    {
        public readonly IntPtr Handle;

        public JassUnit(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator JassWidget(JassUnit from)
        {
            return new JassWidget(from.Handle);
        }

        public static explicit operator JassUnit(JassWidget from)
        {
            return new JassUnit(from.Handle);
        }

        public static JassUnit Create(JassPlayer player, JassObjectId unitId, float x, float y, float facing)
        {
            return Natives.CreateUnit(player, unitId, x, y, facing);
        }

        public static JassUnit Create(JassPlayer player, string unitname, float x, float y, float facing)
        {
            return Natives.CreateUnitByName(player, unitname, x, y, facing);
        }

        public static JassUnit CreateCorpse(JassPlayer player, JassObjectId unitid, float x, float y, float facing)
        {
            return Natives.CreateCorpse(player, unitid, x, y, facing);
        }

        public CUnit ToCUnit()
        {
            return CUnit.FromHandle(Handle);
        }

        public void Kill()
        {
            Natives.KillUnit(this);
        }

        public void Remove()
        {
            Natives.RemoveUnit(this);
        }

        public float GetX() => Natives.GetUnitX(this);
        public void SetX(float value) => Natives.SetUnitX(this, value);
        public void SetX(float value, bool performChecks)
        {
            if (performChecks)
                Natives.SetUnitPosition(this, value, GetY());
            else
                Natives.SetUnitX(this, value);
        }
        public float X {
            get => GetX();
            set => SetX(value);
        }

        public float GetY() => Natives.GetUnitY(this);
        public void SetY(float value) => Natives.SetUnitY(this, value);
        public void SetY(float value, bool performChecks)
        {
            if (performChecks)
                Natives.SetUnitPosition(this, GetX(), value);
            else
                Natives.SetUnitY(this, value);
        }
        public float Y {
            get => GetY();
            set => SetY(value);
        }

        public float GetFacing() => Natives.GetUnitFacing(this);
        public void SetFacing(float value) => Natives.SetUnitFacing(this, value);
        public void SetFacing(float value, float duration) => Natives.SetUnitFacingTimed(this, value, duration);
        public float Facing {
            get => GetFacing();
            set => SetFacing(value);
        }

        public float GetLife() => Natives.GetUnitState(this, JassUnitState.Life);
        public void SetLife(float value) => Natives.SetUnitState(this, JassUnitState.Life, value);
        public float Life {
            get => GetLife();
            set => SetLife(value);
        }

        public float GetMaxLife() => Natives.GetUnitState(this, JassUnitState.MaxLife);
        public void SetMaxLife(float value) => Natives.SetUnitState(this, JassUnitState.MaxLife, value);
        public float MaxLife {
            get => GetMaxLife();
            set => SetMaxLife(value);
        }

        public float GetMana() => Natives.GetUnitState(this, JassUnitState.Mana);
        public void SetMana(float value) => Natives.SetUnitState(this, JassUnitState.Mana, value);
        public float Mana {
            get => GetMana();
            set => SetMana(value);
        }

        public float GetMaxMana() => Natives.GetUnitState(this, JassUnitState.MaxMana);
        public void SetMaxMana(float value) => Natives.SetUnitState(this, JassUnitState.MaxMana, value);
        public float MaxMana {
            get => GetMaxMana();
            set => SetMaxMana(value);
        }

        public JassPlayer GetOwner() => Natives.GetOwningPlayer(this);
        public void SetOwner(JassPlayer owner, bool changeColor) => Natives.SetUnitOwner(this, owner, changeColor);
        public void SetOwner(JassPlayer owner) => Natives.SetUnitOwner(this, owner, false);
        public JassPlayer Owner {
            get => GetOwner();
            set => SetOwner(value);
        }

        public void Show()
        {
            Natives.ShowUnit(this, true);
        }

        public void Hide()
        {
            Natives.ShowUnit(this, false);
        }

        public bool AddAbility(JassObjectId id)
        {
            return Natives.UnitAddAbility(this, id);
        }

        public bool RemoveAbility(JassObjectId id)
        {
            return Natives.UnitRemoveAbility(this, id);
        }
    }
}