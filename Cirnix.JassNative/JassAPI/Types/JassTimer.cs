using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Htimer;")]
    [Serializable]
    public struct JassTimer
    {
        public readonly IntPtr Handle;

        public JassTimer(IntPtr handle)
        {
            Handle = handle;
        }

        public static JassTimer GetExpired()
        {
            return Natives.GetExpiredTimer();
        }

        public static JassTimer Create()
        {
            return Natives.CreateTimer();
        }

        public void Destroy()
        {
            Natives.DestroyTimer(this);
        }

        public void Start(float timeout, bool periodic, JassCode function)
        {
            Natives.TimerStart(this, timeout, periodic, function);
        }

        public void Start(float timeout, bool periodic)
        {
            Natives.TimerStart(this, timeout, periodic, new JassCode(IntPtr.Zero));
        }

        public void Pause()
        {
            Natives.PauseTimer(this);
        }

        public void Resume()
        {
            Natives.ResumeTimer(this);
        }

        public float GetElapsed() => Natives.TimerGetElapsed(this);

        public float Elapsed => GetElapsed();

        public float GetRemaining() => Natives.TimerGetRemaining(this);

        public float Remaining => GetRemaining();

        public float GetTimeout() => Natives.TimerGetTimeout(this);

        public float Timeout => GetTimeout();
    }
}
