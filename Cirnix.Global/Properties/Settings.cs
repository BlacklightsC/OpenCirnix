using CirnoLib.Settings;

namespace Cirnix.Global
{
    public static class Settings
    {
        private static readonly CryptoRegistryComponent Reg = new CryptoRegistryComponent(@"BlacklightsC\Cirnix", "チルノ⑨", true);

        public static int GlobalDelay {
            get => Reg.GetInt32(nameof(GlobalDelay), 500);
            set => Reg.SetValue(nameof(GlobalDelay), value);
        }
        public static string MapType {
            get => Reg.GetString(nameof(MapType), "Eden RPG");
            set => Reg.SetValue(nameof(MapType), value);
        }
        public static string HeroType {
            get => Reg.GetString(nameof(HeroType), "미지정");
            set => Reg.SetValue(nameof(HeroType), value);
        }
        public static string CommandPreset1 {
            get => Reg.GetString(nameof(CommandPreset1), "-시야 150");
            set => Reg.SetValue(nameof(CommandPreset1), value);
        }
        public static string CommandPreset2 {
            get => Reg.GetString(nameof(CommandPreset2), "-시야 150");
            set => Reg.SetValue(nameof(CommandPreset2), value);
        }
        public static string CommandPreset3 {
            get => Reg.GetString(nameof(CommandPreset3), "-시야 150");
            set => Reg.SetValue(nameof(CommandPreset3), value);
        }
        public static int SelectedCommand {
            get => Reg.GetInt32(nameof(SelectedCommand), 1);
            set => Reg.SetValue(nameof(SelectedCommand), value);
        }
        public static int GameDelay {
            get => Reg.GetInt32(nameof(GameDelay), 15);
            set => Reg.SetValue(nameof(GameDelay), value);
        }
        public static bool IsAutoHp {
            get => Reg.GetBoolean(nameof(IsAutoHp));
            set => Reg.SetValue(nameof(IsAutoHp), value);
        }
        public static string SaveFilePath {
            get => Reg.GetString(nameof(SaveFilePath), "\\Grabiti\'s RPG Creator\\Eden RPG∫Eden RPG∫낙원 RPG");
            set => Reg.SetValue(nameof(SaveFilePath), value);
        }
        public static bool IsAutoReplay {
            get => Reg.GetBoolean(nameof(IsAutoReplay), true);
            set => Reg.SetValue(nameof(IsAutoReplay), value);
        }
        public static float StartSpeed {
            get => Reg.GetSingle(nameof(StartSpeed), 0.01f);
            set => Reg.SetValue(nameof(StartSpeed), value);
        }
        public static float CameraDistance {
            get => Reg.GetSingle(nameof(CameraDistance), 1650);
            set => Reg.SetValue(nameof(CameraDistance), value);
        }
        public static float CameraAngleX {
            get => Reg.GetSingle(nameof(CameraAngleX), 90);
            set => Reg.SetValue(nameof(CameraAngleX), value);
        }
        public static float CameraAngleY {
            get => Reg.GetSingle(nameof(CameraAngleY), 304);
            set => Reg.SetValue(nameof(CameraAngleY), value);
        }
        public static int KeyMap7 {
            get => Reg.GetInt32(nameof(KeyMap7));
            set => Reg.SetValue(nameof(KeyMap7), value);
        }
        public static int KeyMap8 {
            get => Reg.GetInt32(nameof(KeyMap8));
            set => Reg.SetValue(nameof(KeyMap8), value);
        }
        public static int KeyMap4 {
            get => Reg.GetInt32(nameof(KeyMap4));
            set => Reg.SetValue(nameof(KeyMap4), value);
        }
        public static int KeyMap5 {
            get => Reg.GetInt32(nameof(KeyMap5));
            set => Reg.SetValue(nameof(KeyMap5), value);
        }
        public static int KeyMap1 {
            get => Reg.GetInt32(nameof(KeyMap1));
            set => Reg.SetValue(nameof(KeyMap1), value);
        }
        public static int KeyMap2 {
            get => Reg.GetInt32(nameof(KeyMap2));
            set => Reg.SetValue(nameof(KeyMap2), value);
        }
        public static int SmartKeyFlag {
            get => Reg.GetInt32(nameof(SmartKeyFlag));
            set => Reg.SetValue(nameof(SmartKeyFlag), value);
        }
        public static bool IsKeyRemapped {
            get => Reg.GetBoolean(nameof(IsKeyRemapped));
            set => Reg.SetValue(nameof(IsKeyRemapped), value);
        }
        public static bool NoSavedReplaySave {
            get => Reg.GetBoolean(nameof(NoSavedReplaySave));
            set => Reg.SetValue(nameof(NoSavedReplaySave), value);
        }
        public static bool IsConvertScreenShot {
            get => Reg.GetBoolean(nameof(IsConvertScreenShot), true);
            set => Reg.SetValue(nameof(IsConvertScreenShot), value);
        }
        public static string ConvertExtention {
            get => Reg.GetString(nameof(ConvertExtention), "png");
            set => Reg.SetValue(nameof(ConvertExtention), value);
        }
        public static bool IsOriginalRemove {
            get => Reg.GetBoolean(nameof(IsOriginalRemove), true);
            set => Reg.SetValue(nameof(IsOriginalRemove), value);
        }
        public static bool IsGrabitiSaveAutoAdd {
            get => Reg.GetBoolean(nameof(IsGrabitiSaveAutoAdd), true);
            set => Reg.SetValue(nameof(IsGrabitiSaveAutoAdd), value);
        }
        public static bool IsCommandHide {
            get => Reg.GetBoolean(nameof(IsCommandHide));
            set => Reg.SetValue(nameof(IsCommandHide), value);
        }
        public static bool IsFixClipboard {
            get => Reg.GetBoolean(nameof(IsFixClipboard));
            set => Reg.SetValue(nameof(IsFixClipboard), value);
        }
        public static int ChannelChatBGColor {
            get => Reg.GetInt32(nameof(ChannelChatBGColor), -12566464);
            set => Reg.SetValue(nameof(ChannelChatBGColor), value);
        }
        public static bool IsChannelChatDetect {
            get => Reg.GetBoolean(nameof(IsChannelChatDetect));
            set => Reg.SetValue(nameof(IsChannelChatDetect), value);
        }
        public static bool IsMemoryOptimize {
            get => Reg.GetBoolean(nameof(IsMemoryOptimize));
            set => Reg.SetValue(nameof(IsMemoryOptimize), value);
        }
        public static int MemoryOptimizeCoolDown {
            get => Reg.GetInt32(nameof(MemoryOptimizeCoolDown), 10);
            set => Reg.SetValue(nameof(MemoryOptimizeCoolDown), value);
        }
        public static bool IsOptimizeAfterEndGame {
            get => Reg.GetBoolean(nameof(IsOptimizeAfterEndGame), true);
            set => Reg.SetValue(nameof(IsOptimizeAfterEndGame), value);
        }
        public static bool IsSmartKeyClickPrevention {
            get => Reg.GetBoolean(nameof(IsSmartKeyClickPrevention));
            set => Reg.SetValue(nameof(IsSmartKeyClickPrevention), value);
        }
        public static bool IsCheatMapCheck {
            get => Reg.GetBoolean(nameof(IsCheatMapCheck));
            set => Reg.SetValue(nameof(IsCheatMapCheck), value);
        }
        public static bool IsAutoLoad {
            get => Reg.GetBoolean(nameof(IsAutoLoad));
            set => Reg.SetValue(nameof(IsAutoLoad), value);
        }
        public static string InstallPath {
            get => Reg.GetString(nameof(InstallPath));
            set => Reg.SetValue(nameof(InstallPath), value);
        }
        public static string HotkeyChat {
            get => Reg.GetString(nameof(HotkeyChat), "∫0∫False∫∫0∫False∫∫0∫False∫∫0∫False∫∫0∫False∫∫0∫False∫∫0∫False∫∫0∫False∫∫0∫False∫ ∫0∫False");
            set => Reg.SetValue(nameof(HotkeyChat), value);
        }
        public static bool IsAutoFrequency {
            get => Reg.GetBoolean(nameof(IsAutoFrequency), true);
            set => Reg.SetValue(nameof(IsAutoFrequency), value);
        }
        public static int ChatFrequency {
            get => Reg.GetInt32(nameof(ChatFrequency));
            set => Reg.SetValue(nameof(ChatFrequency), value);
        }
        public static int SmartKeyPreventionType {
            get => Reg.GetInt32(nameof(SmartKeyPreventionType), 3);
            set => Reg.SetValue(nameof(SmartKeyPreventionType), value);
        }
        public static string AutoMouse {
            get => Reg.GetString(nameof(AutoMouse), "100∫0∫0∫False");
            set => Reg.SetValue(nameof(AutoMouse), value);
        }
        public static bool BetaUser {
            get => Reg.GetBoolean(nameof(BetaUser));
            set => Reg.SetValue(nameof(BetaUser), value);
        }
    }
}