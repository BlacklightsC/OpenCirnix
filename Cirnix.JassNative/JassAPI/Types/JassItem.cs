using Cirnix.JassNative.WarAPI.Types;
using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hitem;")]
    [Serializable]
    public struct JassItem
    {
        public readonly IntPtr Handle;

        public JassItem(IntPtr handle)
        {
            this.Handle = handle;
        }

        public static JassItem Create(JassObjectId itemid, float x, float y)
        {
            return Natives.CreateItem(itemid, x, y);
        }

        public CItemPtr ToCItem()
        {
            return CItemPtr.FromHandle(this.Handle);
        }

        public void Remove()
        {
            Natives.RemoveItem(this);
        }

        public JassObjectId GetTypeId()
        {
            return Natives.GetItemTypeId(this);
        }

        public JassObjectId TypeId {
            get {
                return this.GetTypeId();
            }
        }

        public JassPlayer GetPlayer()
        {
            return Natives.GetItemPlayer(this);
        }

        public void SetPlayer(JassPlayer player, bool changeColor)
        {
            Natives.SetItemPlayer(this, player, changeColor);
        }

        public void SetPlayer(JassPlayer player)
        {
            Natives.SetItemPlayer(this, player, false);
        }

        public JassPlayer Player {
            get {
                return this.GetPlayer();
            }
            set {
                this.SetPlayer(value);
            }
        }

        public bool IsOwned()
        {
            return Natives.IsItemOwned(this);
        }

        public bool Owned => IsOwned();

        public float GetX()
        {
            return Natives.GetItemX(this);
        }

        public float GetY()
        {
            return Natives.GetItemY(this);
        }

        public void SetX(float x)
        {
            this.SetPosition(x, this.GetY());
        }

        public void SetY(float y)
        {
            this.SetPosition(this.GetX(), y);
        }

        public void SetPosition(float x, float y)
        {
            Natives.SetItemPosition(this, x, y);
        }

        public float X {
            get {
                return this.GetX();
            }
            set {
                this.SetX(value);
            }
        }

        public float Y {
            get {
                return this.GetY();
            }
            set {
                this.SetY(value);
            }
        }

        public bool IsInvulnerable()
        {
            return Natives.IsItemInvulnerable(this);
        }

        public void SetInvulnerable(bool flag)
        {
            Natives.SetItemInvulnerable(this, flag);
        }

        public bool Invulnerable {
            get {
                return this.IsInvulnerable();
            }
            set {
                this.SetInvulnerable(value);
            }
        }

        public bool IsPawnable()
        {
            return Natives.IsItemPawnable(this);
        }

        public void SetPawnable(bool flag)
        {
            Natives.SetItemPawnable(this, flag);
        }

        public bool Pawnable {
            get {
                return this.IsPawnable();
            }
            set {
                this.SetPawnable(value);
            }
        }

        public bool IsVisible()
        {
            return Natives.IsItemVisible(this);
        }

        public void SetVisible(bool flag)
        {
            Natives.SetItemVisible(this, flag);
        }

        public bool Visible {
            get {
                return this.IsVisible();
            }
            set {
                this.SetVisible(value);
            }
        }

        public int GetCharges()
        {
            return (int)Natives.GetItemCharges(this);
        }

        public void SetCharges(int charges)
        {
            Natives.SetItemCharges(this, charges);
        }

        public int Charges {
            get {
                return this.GetCharges();
            }
            set {
                this.SetCharges(value);
            }
        }

        public int GetUserData()
        {
            return (int)Natives.GetItemUserData(this);
        }

        public void SetUserData(int data)
        {
            Natives.SetItemUserData(this, data);
        }

        public int UserData {
            get => GetUserData();
            set => SetUserData(value);
        }

        public string GetName()
        {
            return Natives.GetItemName(this);
        }

        public string Name {
            get => GetName();
        }

    public int GetLevel()
        {
            return Natives.GetItemLevel(this);
        }

        public int Level {
            get => GetLevel();
        }

        public JassItemType GetItemType()
        {
            return Natives.GetItemType(this);
        }

        public JassItemType ItemType {
            get => GetItemType();
        }

        public bool IsPowerup()
        {
            return Natives.IsItemPowerup(this);
        }

        public bool Powerup {
            get {
                return this.IsSellable();
            }
        }

        public bool IsSellable()
        {
            return Natives.IsItemSellable(this);
        }

        public bool Sellable {
            get {
                return this.IsSellable();
            }
        }

        public void SetDropOnDeath(bool flag)
        {
            Natives.SetItemDropOnDeath(this, flag);
        }

        public void SetDroppable(bool flag)
        {
            Natives.SetItemDroppable(this, flag);
        }

        public void SetDropID(JassObjectId unitId)
        {
            Natives.SetItemDropID(this, unitId);
        }
    }
}