using System.IO;

using NAudio.Wave;

namespace Cirnix.Global
{
    public static class SoundManager
    {
        public static void Play(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            WaveStream ws = new Mp3FileReader(ms);
            WaveOutEvent output = new WaveOutEvent();
            output.Init(ws);
            output.Play();
        }
    }
}
