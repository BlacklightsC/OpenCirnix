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

        /// <summary>
        /// 사용자 데이터 이전 여부
        /// </summary>
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

        #region [    Graphics Options    ]
        /// <summary>
        /// 모델 디테일 (0 ~ 2)
        /// </summary>
        public static int ModelDetail {
            get => (int)com.GetValue("Video", "modeldetail", 0);
            set => com.SetValue("Video", "modeldetail", value);
        }
        /// <summary>
        /// 애니메이션 화질 (0 ~ 2)
        /// </summary>
        public static int AnimationQuality {
            get => (int)com.GetValue("Video", "animquality", 1);
            set => com.SetValue("Video", "animquality", value);
        }
        /// <summary>
        /// 텍스쳐 화질 (0 ~ 2)
        /// </summary>
        public static int TextureQuality {
            get => (int)com.GetValue("Video", "texquality", 1);
            set {
                com.SetValue("Video", "texquality", value);
                switch (value)
                {
                    case 0:
                        com.SetValue("Video", "miplevel", 1);
                        com.SetValue("Video", "texcolordepth", 0x10);
                        break;
                    case 1:
                        com.SetValue("Video", "miplevel", 0);
                        com.SetValue("Video", "texcolordepth", 0x10);
                        break;
                    case 2:
                        com.SetValue("Video", "miplevel", 0);
                        com.SetValue("Video", "texcolordepth", 0x20);
                        break;
                }
            }
        }
        /// <summary>
        /// 입자 (0 ~ 2)
        /// </summary>
        public static int Particles {
            get => (int)com.GetValue("Video", "particles", 1);
            set {
                com.SetValue("Video", "particles", value);
                com.SetValue("Video", "spellfilter", value);
            }
        }
        /// <summary>
        /// 광원 (0 ~ 2)
        /// </summary>
        public static int Lights {
            get => (int)com.GetValue("Video", "lights", 1);
            set => com.SetValue("Video", "lights", value);
        }
        /// <summary>
        /// 유닛 그림자
        /// </summary>
        public static bool UnitShadows {
            get => (int)com.GetValue("Video", "unitshadows", 1) == 1;
            set => com.SetValue("Video", "unitshadows", value);
        }
        /// <summary>
        /// 투명화
        /// </summary>
        public static bool Occlusion {
            get => (int)com.GetValue("Video", "occlusion", 1) == 1;
            set => com.SetValue("Video", "occlusion", value);
        }
        #endregion

        public static void SetFullQualityGraphics()
        {
            ModelDetail = 2;
            AnimationQuality = 2;
            TextureQuality = 2;
            Particles = 2;
            Lights = 2;
            UnitShadows = true;
            Occlusion = true;
        }
    }
}
