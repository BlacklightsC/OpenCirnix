using Newtonsoft.Json.Linq;
using System.IO;

namespace Cirnix.Global
{
    public static class Theme
    {
        // TODO: 테마 리소스 가져오는 곳
        public static string MainImageFile { get; private set; }

        public static string IconFile { get; private set; }

        public static string UnknownMapPreviewFile { get; private set; }

        public static string Title { get; private set; } = "Cirnix";

        public static string MsgTitleColor { get; set; } = "|CFF33CCFF";

        public static string MsgTitle { get; set; } = "「Cirnix」";

        public static string MsgColor { get; set; } = "|CFF66FF99";


        public static void LoadTheme()
        {
            if (File.Exists("Theme.json"))
            {
                JObject theme = JObject.Parse(File.ReadAllText("Theme.json"));
                string mainImageFile = theme[nameof(MainImageFile)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(mainImageFile)) MainImageFile = mainImageFile;
                string iconFile = theme[nameof(IconFile)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(iconFile)) IconFile = iconFile;
                string unknownMapPreviewFile = theme[nameof(UnknownMapPreviewFile)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(unknownMapPreviewFile)) UnknownMapPreviewFile = unknownMapPreviewFile;
                string title = theme[nameof(Title)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(title)) Title = title;
                string msgTitleColor = theme[nameof(MsgTitleColor)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(msgTitleColor)) MsgTitleColor = msgTitleColor;
                string msgTitle = theme[nameof(MsgTitle)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(msgTitle)) MsgTitle = msgTitle;
                string msgColor = theme[nameof(MsgColor)]?.Value<string>();
                if (!string.IsNullOrWhiteSpace(msgColor)) MsgColor = msgColor;
            }
        }
    }
}
