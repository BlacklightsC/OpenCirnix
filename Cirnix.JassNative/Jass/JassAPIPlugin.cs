using Cirnix.JassNative.WarAPI;
using System.Diagnostics;
using Cirnix.JassNative.Runtime;
using Cirnix.JassNative.Plugin;

namespace Cirnix.JassNative.JassAPI
{
    [Requires(typeof(WarAPIPlugin))]
    public class JassAPIPlugin : IPlugin
    {
        public void Initialize()
        {
        }

        public void OnGameLoad()
        {
            Trace.WriteLine("Initializing script api . . .");
            Trace.Indent();
            Stopwatch stopwatch = Stopwatch.StartNew();
            Script.Initialize();
            stopwatch.Stop();
            Trace.WriteLine("Done! (" + stopwatch.Elapsed.TotalMilliseconds.ToString("0.00") + " ms)");
            Trace.Unindent();
            Trace.WriteLine("Initializing natives api . . .");
            Trace.Indent();
            stopwatch.Restart();
            Natives.Initialize();
            stopwatch.Stop();
            Trace.WriteLine("Done! (" + stopwatch.Elapsed.TotalMilliseconds.ToString("0.00") + " ms)");
            Trace.Unindent();
        }

        public void OnMapEnd()
        {
        }

        public void OnMapStart()
        {
        }
    }
}
