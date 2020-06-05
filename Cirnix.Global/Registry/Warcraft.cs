using CirnoLib.Settings;

namespace Cirnix.Global.Registry
{
    /// <summary>
    /// 워크래프트 3 의 레지스트리 키입니다.
    /// </summary>
    public static class Warcraft
    {
        private static readonly RegistryComponent com = new RegistryComponent(@"Blizzard Entertainment\Warcraft III");

        /// <summary>
        /// 프로그램이 설치되어 있는 경로입니다.
        /// </summary>
        public static string InstallPath {
            get => com.GetValue(nameof(InstallPath), string.Empty) as string;
            set => com.SetValue(nameof(InstallPath), value);
        }

        public static bool MigrationComplete {
            get => (int)com.GetValue("Migration Complete", 0) == 1;
            set => com.SetValue("Migration Complete", value ? 1 : 0);
        }

        /// <summary>
        /// 인트로 영상  
        /// </summary>
        public static bool SeenIntroMovie {
            get => (int)com.GetValue("Misc", "seenintromovie", 0) == 1;
            set => com.SetValue("Misc", "seenintromovie", value ? 1 : 0);
        }
    }
}
