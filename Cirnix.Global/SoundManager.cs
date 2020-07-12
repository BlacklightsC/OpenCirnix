using System.IO;
using NAudio.Wave;
using Cirnix.Global.Properties;

namespace Cirnix.Global
{
    public class SoundManager
    {
        public static void Play()
        {
            byte[] mp3Path = Resources.max;
            MemoryStream ms = new MemoryStream(mp3Path);
            WaveStream ws = new Mp3FileReader(ms);
            WaveOutEvent output = new WaveOutEvent();
            output.Init(ws);
            output.Play();

        }

    }
}
