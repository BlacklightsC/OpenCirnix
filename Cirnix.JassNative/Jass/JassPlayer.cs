using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayer;")]
  [Serializable]
  public struct JassPlayer
  {
    public readonly IntPtr Handle;

    public JassPlayer(IntPtr handle)
    {
      this.Handle = handle;
    }

    public static JassPlayer FromLocal()
    {
      return Natives.GetLocalPlayer();
    }

    public static JassPlayer FromIndex(int index)
    {
      return Natives.Player(index);
    }

    public int GetIndex()
    {
      return (int) Natives.GetPlayerId(this);
    }

    public int Index
    {
      get
      {
        return this.GetIndex();
      }
    }

    public int GetTeam()
    {
      return (int) Natives.GetPlayerTeam(this);
    }

    public void SetTeam(int team)
    {
      Natives.SetPlayerTeam(this, team);
    }

    public int Team
    {
      get
      {
        return this.GetTeam();
      }
      set
      {
        this.SetTeam(value);
      }
    }

    public int GetStartLocation()
    {
      return (int) Natives.GetPlayerStartLocation(this);
    }

    public void SetStartLocation(int locationIndex)
    {
      Natives.SetPlayerStartLocation(this, locationIndex);
    }

    public void ForceStartLocation(int locationIndex)
    {
      Natives.ForcePlayerStartLocation(this, locationIndex);
    }

    public int StartLocation
    {
      get
      {
        return this.GetStartLocation();
      }
      set
      {
        this.SetStartLocation(value);
      }
    }

    public string GetName()
    {
      return Natives.GetPlayerName(this);
    }

    public void SetName(string name)
    {
      Natives.SetPlayerName(this, name);
    }

    public string Name
    {
      get
      {
        return this.GetName();
      }
      set
      {
        this.SetName(value);
      }
    }

    public JassPlayerColor GetColor()
    {
      return Natives.GetPlayerColor(this);
    }

    public void SetColor(JassPlayerColor color)
    {
      Natives.SetPlayerColor(this, color);
    }

    public JassPlayerColor Color
    {
      get
      {
        return this.GetColor();
      }
      set
      {
        this.SetColor(value);
      }
    }

    public JassMapControl GetController()
    {
      return Natives.GetPlayerController(this);
    }

    public void SetController(JassMapControl control)
    {
      Natives.SetPlayerController(this, control);
    }

    public JassMapControl Controller
    {
      get
      {
        return this.GetController();
      }
      set
      {
        this.SetController(value);
      }
    }

    public int GetTaxRate(JassPlayer other, JassPlayerState resource)
    {
      return (int) Natives.GetPlayerTaxRate(this, other, resource);
    }

    public void SetTaxRate(JassPlayer other, JassPlayerState resource, int rate)
    {
      Natives.SetPlayerTaxRate(this, other, resource, rate);
    }

    public void SetRaceSelectable(bool flag)
    {
      Natives.SetPlayerRaceSelectable(this, flag);
    }

    public bool GetRaceSelectable()
    {
      return Natives.GetPlayerSelectable(this);
    }

    public bool RaceSelectable
    {
      get
      {
        return this.GetRaceSelectable();
      }
      set
      {
        this.SetRaceSelectable(value);
      }
    }

    public JassPlayerSlotState GetSlotState()
    {
      return Natives.GetPlayerSlotState(this);
    }

    public JassPlayerSlotState SlotState
    {
      get
      {
        return this.GetSlotState();
      }
    }

    public void SetRacePreference(JassRacePreference preference)
    {
      Natives.SetPlayerRacePreference(this, preference);
    }

    public bool IsRacePreferenceSet(JassRacePreference preference)
    {
      return Natives.IsPlayerRacePrefSet(this, preference);
    }

    public void SetAlliance(JassPlayer other, JassAllianceType alliance, bool flag)
    {
      Natives.SetPlayerAlliance(this, other, alliance, flag);
    }

    public void SetOnScoreScreen(bool flag)
    {
      Natives.SetPlayerOnScoreScreen(this, flag);
    }
  }
}
