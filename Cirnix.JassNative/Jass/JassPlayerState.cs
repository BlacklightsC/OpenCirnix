using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayerstate;")]
  [Serializable]
  public struct JassPlayerState
  {
    public static JassPlayerState GameResult = Natives.ConvertPlayerState(0);
    public static JassPlayerState ResourceGold = Natives.ConvertPlayerState(1);
    public static JassPlayerState ResourceLumber = Natives.ConvertPlayerState(2);
    public static JassPlayerState ResourceHeroTokens = Natives.ConvertPlayerState(3);
    public static JassPlayerState ResourceFoodCap = Natives.ConvertPlayerState(4);
    public static JassPlayerState ResourceFoodUsed = Natives.ConvertPlayerState(5);
    public static JassPlayerState FoodCapCeiling = Natives.ConvertPlayerState(6);
    public static JassPlayerState GivesBounty = Natives.ConvertPlayerState(7);
    public static JassPlayerState AlliedVictory = Natives.ConvertPlayerState(8);
    public static JassPlayerState Placed = Natives.ConvertPlayerState(9);
    public static JassPlayerState ObserverOnDeath = Natives.ConvertPlayerState(10);
    public static JassPlayerState Observer = Natives.ConvertPlayerState(11);
    public static JassPlayerState Unfollowable = Natives.ConvertPlayerState(12);
    public static JassPlayerState GoldUpkeepRate = Natives.ConvertPlayerState(13);
    public static JassPlayerState LumberUpkeepRate = Natives.ConvertPlayerState(14);
    public static JassPlayerState GoldGathered = Natives.ConvertPlayerState(15);
    public static JassPlayerState LumberGathered = Natives.ConvertPlayerState(16);
    public static JassPlayerState NoCreepSleep = Natives.ConvertPlayerState(25);
    public readonly IntPtr Handle;

    public JassPlayerState(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
