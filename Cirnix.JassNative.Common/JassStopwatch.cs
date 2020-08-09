using System.Collections.Generic;
using System.Diagnostics;

using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Plugin;

namespace Cirnix.JassNative.Common
{
    [Requires(typeof(JassAPIPlugin))]
    public sealed class JassStopwatch : IPlugin
    {
        private int SwId = -1;
        private Dictionary<int, Stopwatch> list = new Dictionary<int, Stopwatch>();

        private delegate JassInteger StopwatchCreatePrototype();
        private JassInteger StopwatchCreate()
        {
            list[++SwId] = Stopwatch.StartNew();
            return SwId;
        }

        private delegate JassInteger StopwatchElapsedMSPrototype(JassInteger id);
        private JassInteger StopwatchElapsedMS(JassInteger id)
        {
            return list[id]?.ElapsedMilliseconds ?? 0;
        }
        private delegate JassInteger StopwatchElapsedSecondPrototype(JassInteger id);
        private JassInteger StopwatchElapsedSecond(JassInteger id)
        {
            return id < list.Count ? list[id]?.Elapsed.Seconds ?? 0 : 0;
        }
        private delegate JassInteger StopwatchElapsedMinutePrototype(JassInteger id);
        private JassInteger StopwatchElapsedMinute(JassInteger id)
        {
            return list[id]?.Elapsed.Minutes;
        }
        private delegate JassInteger StopwatchElapsedHourPrototype(JassInteger id);
        private JassInteger StopwatchElapsedHour(JassInteger id)
        {
            return list[id]?.Elapsed.Hours;
        }
        private delegate JassInteger StopwatchElapsedTickPrototype(JassInteger id);
        private JassInteger StopwatchTick(JassInteger id)
        {
            return list[id]?.ElapsedTicks;
        }
        private delegate void StopwatchDestroyPrototype(JassInteger id);
        private void StopwatchDestroy(JassInteger id)
        {
            list[id]?.Stop();
        }

        public void Initialize()
        {
            Natives.Add(new StopwatchCreatePrototype(StopwatchCreate));
            Natives.Add(new StopwatchElapsedMSPrototype(StopwatchElapsedMS));
            Natives.Add(new StopwatchElapsedSecondPrototype(StopwatchElapsedSecond));
            Natives.Add(new StopwatchElapsedMinutePrototype(StopwatchElapsedMinute));
            Natives.Add(new StopwatchElapsedHourPrototype(StopwatchElapsedHour));
            Natives.Add(new StopwatchElapsedTickPrototype(StopwatchTick));
            Natives.Add(new StopwatchDestroyPrototype(StopwatchDestroy));
        }

        public void OnGameLoad()
        {
        }

        public void OnMapStart()
        {
            SwId = -1;
            list.Clear();
        }

        public void OnMapEnd()
        {
            SwId = -1;
            list.Clear();
        }
    }
}
