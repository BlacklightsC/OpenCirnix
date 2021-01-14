using System;
using System.Diagnostics;

namespace Cirnix.Global
{
    public class HangWatchdog
    {
        private readonly Stopwatch Timer = new Stopwatch();

        private TimeSpan _Interval;

        public TimeSpan Interval {
            get => DynamicInterval == null ? _Interval : DynamicInterval();
            set {
                DynamicInterval = null;
                _Interval = value;
            }
        }

        public Func<TimeSpan> DynamicInterval;

        public Func<bool> Condition;

        public event Action Actions;

        public HangWatchdog(TimeSpan interval) => Interval = interval;

        public HangWatchdog(int hours, int minutes, int seconds) => Interval = new TimeSpan(hours, minutes, seconds);

        public HangWatchdog(Func<TimeSpan> dynamicInterval) => DynamicInterval = dynamicInterval;

        public void Check()
        {
            bool? condition;
            try
            {
                condition = Condition?.Invoke();
            }
            catch
            {
                condition = false;
            }
            if (condition ?? true)
            {
                if (Timer.IsRunning)
                {
                    if (Timer.Elapsed >= Interval)
                    {
                        Actions?.Invoke();
                        Timer.Restart();
                    }
                }
                else Timer.Start();
            }
            else if (Timer.IsRunning) Timer.Stop();
        }

        public void Restart() => Timer.Restart();

        public void Reset() => Timer.Reset();
    }
}