using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.Runtime
{
    public partial class DebuggerWindow : Window
    {
        private ConcurrentBagListener listener = new ConcurrentBagListener();

        public DebuggerWindow(string hackPath)
        {
            InitializeComponent();

            Trace.Listeners.Add(listener);

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            StringBuilder messages = new StringBuilder();
            while (listener.Messages.TryTake(out string message))
            {
                messages.Append(message);
            }
            if (messages.Length > 0)
            {
                OutputTextBox.Text += messages.ToString();
                if (AutoScrollCheckBox.IsChecked ?? false)
                    OutputTextBox.ScrollToEnd();
            }
        }

        private void InputTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                OutputTextBox.ScrollToEnd();
                InputTextBox.Clear();
            }
        }
    }
}
