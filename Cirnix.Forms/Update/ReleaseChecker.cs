using System.Collections.Generic;

using Cirnix.Global;

using Newtonsoft.Json;

namespace Cirnix.Forms.Update
{
    public static class ReleaseChecker
    {
        public static readonly string HistoryURL = "https://github.com/BlacklightsC/OpenCirnix/releases";

        private static Release _Recommanded;
        public static Release Recommanded {
            get {
                if (_Recommanded == null)
                    GetRelease();
                return _Recommanded;
            }
        }
        private static Release _Latest;
        public static Release Latest {
            get {
                if (_Latest == null)
                    GetRelease();
                return _Latest;
            }
        }

        public static bool GetRelease()
        {
            string result = Globals.GetStringFromServer("https://api.github.com/repos/BlacklightsC/OpenCirnix/releases");
            if (result == null) return false;
            try
            {
                List<Release> list = JsonConvert.DeserializeObject<List<Release>>(result);
                if (list.Count == 0) return false;
                _Recommanded = list.Find(item => !item.prerelease);
                _Latest = list[0];
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
