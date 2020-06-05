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
            this.Handle = handle;
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

        //public CUnit ToCUnit()
        //{
        //  return CUnit.FromHandle(this.Handle);
        //}

        public void Kill()
        {
            Natives.KillUnit(this);
        }

        public void Remove()
        {
            Natives.RemoveUnit(this);
        }

        public float GetX()
        {
            return Natives.GetUnitX(this);
        }

        public void SetX(float value)
        {
            Natives.SetUnitX(this, value);
        }

        public void SetX(float value, bool performChecks)
        {
            if (performChecks)
                Natives.SetUnitPosition(this, value, this.GetY());
            else
                Natives.SetUnitX(this, value);
        }

        public float X {
            get {
                return this.GetX();
            }
            set {
                this.SetX(value);
            }
        }

        public float GetY()
        {
            return Natives.GetUnitY(this);
        }

        public void SetY(float value)
        {
            Natives.SetUnitY(this, value);
        }

        public void SetY(float value, bool performChecks)
        {
            if (performChecks)
                Natives.SetUnitPosition(this, this.GetX(), value);
            else
                Natives.SetUnitY(this, value);
        }

        public float Y {
            get {
                return this.GetY();
            }
            set {
                this.SetY(value);
            }
        }

        public float GetFacing()
        {
            return Natives.GetUnitFacing(this);
        }

        public void SetFacing(float value)
        {
            Natives.SetUnitFacing(this, value);
        }

        public void SetFacing(float value, float duration)
        {
            Natives.SetUnitFacingTimed(this, value, duration);
        }

        public float Facing {
            get {
                return this.GetFacing();
            }
            set {
                this.SetFacing(value);
            }
        }

        public float GetLife()
        {
            return Natives.GetUnitState(this, JassUnitState.Life);
        }

        public void SetLife(float value)
        {
            Natives.SetUnitState(this, JassUnitState.Life, value);
        }

        public float Life {
            get {
                return this.GetLife();
            }
            set {
                this.SetLife(value);
            }
        }

        public float GetMaxLife()
        {
            return Natives.GetUnitState(this, JassUnitState.MaxLife);
        }

        public void SetMaxLife(float value)
        {
            Natives.SetUnitState(this, JassUnitState.MaxLife, value);
        }

        public float MaxLife {
            get {
                return this.GetMaxLife();
            }
            set {
                this.SetMaxLife(value);
            }
        }

        public float GetMana()
        {
            return Natives.GetUnitState(this, JassUnitState.Mana);
        }

        public void SetMana(float value)
        {
            Natives.SetUnitState(this, JassUnitState.Mana, value);
        }

        public float Mana {
            get {
                return this.GetMana();
            }
            set {
                this.SetMana(value);
            }
        }

        public float GetMaxMana()
        {
            return Natives.GetUnitState(this, JassUnitState.MaxMana);
        }

        public void SetMaxMana(float value)
        {
            Natives.SetUnitState(this, JassUnitState.MaxMana, value);
        }

        public float MaxMana {
            get {
                return this.GetMaxMana();
            }
            set {
                this.SetMaxMana(value);
            }
        }

        public JassPlayer GetOwner()
        {
            return Natives.GetOwningPlayer(this);
        }

        public void SetOwner(JassPlayer owner, bool changeColor)
        {
            Natives.SetUnitOwner(this, owner, changeColor);
        }

        public void SetOwner(JassPlayer owner)
        {
            Natives.SetUnitOwner(this, owner, false);
        }

        public JassPlayer Owner {
            get {
                return this.GetOwner();
            }
            set {
                this.SetOwner(value);
            }
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