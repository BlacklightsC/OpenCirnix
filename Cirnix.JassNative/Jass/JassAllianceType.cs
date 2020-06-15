using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Halliancetype;")]
    [Serializable]
    public struct JassAllianceType
    {
        public static JassAllianceType Passive = Natives.ConvertAllianceType(0);
        public static JassAllianceType HelpRequest = Natives.ConvertAllianceType(1);
        public static JassAllianceType HelpResponse = Natives.ConvertAllianceType(2);
        public static JassAllianceType SharedExperience = Natives.ConvertAllianceType(3);
        public static JassAllianceType SharedSpells = Natives.ConvertAllianceType(4);
        public static JassAllianceType SharedVision = Natives.ConvertAllianceType(5);
        public static JassAllianceType SharedControl = Natives.ConvertAllianceType(6);
        public static JassAllianceType SharedAdvancedControl = Natives.ConvertAllianceType(7);
        public static JassAllianceType Rescuable = Natives.ConvertAllianceType(8);
        public static JassAllianceType SharedVisionForced = Natives.ConvertAllianceType(9);
        public readonly IntPtr Handle;

        public JassAllianceType(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}