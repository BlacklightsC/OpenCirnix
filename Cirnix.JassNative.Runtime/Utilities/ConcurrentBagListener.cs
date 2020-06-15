using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Cirnix.JassNative.Runtime.Utilities
{
    public class ConcurrentBagListener : TraceListener
    {
        public ConcurrentBag<string> Messages { get; private set; }

        private bool isNewline = true;

        public ConcurrentBagListener()
        {
            Messages = new ConcurrentBag<string>();
        }

        public override void Write(string message)
        {
            var indent = string.Empty;
            if (isNewline)
                indent = new string(' ', IndentSize * IndentLevel);
            Messages.Add(indent + message);
            isNewline = false;
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
            isNewline = true;
        }
    }
}
