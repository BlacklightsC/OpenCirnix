using System.Diagnostics;

using Cirnix.JassNative.Plugin;
using Cirnix.JassNative.WarAPI;

namespace Cirnix.JassNative.JassAPI
{
    [Requires(typeof(WarAPIPlugin))]
    public class JassAPIPlugin : IPlugin
    {
        public void Initialize() { }

        public void OnGameLoad()
        {
            Trace.WriteLine("Initializing script api . . .");
            Trace.Indent();
            Stopwatch stopwatch = Stopwatch.StartNew();
            Script.Initialize();
            stopwatch.Stop();
            Trace.WriteLine($"Done! ({stopwatch.Elapsed.TotalMilliseconds:0.00} ms)");
            Trace.Unindent();
            Trace.WriteLine("Initializing natives api . . .");
            Trace.Indent();
            stopwatch.Restart();
            Natives.Initialize();
            stopwatch.Stop();
            Trace.WriteLine($"Done! ({stopwatch.Elapsed.TotalMilliseconds:0.00} ms)");
            Trace.Unindent();
        }

        public void OnMapStart() { }

        public void OnMapEnd() { }
    }
}
