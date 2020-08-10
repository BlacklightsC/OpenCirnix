using Cirnix.Global;

using CirnoLib;

using System;
using System.ComponentModel;
using System.Threading.Tasks;

using static Cirnix.Global.Globals;
using static Cirnix.Memory.Message;

namespace Cirnix.Worker
{
    internal static class Commands
    {
        private static BackgroundWorker Worker;
        private static string LastChat;

        static Commands()
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
        }

        private static async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (await Actions.ProcessCheck()) return;
                //string lastChat = Memory.MessageFrame.GetLastChat();
                //if (!string.IsNullOrEmpty(LastChat) && LastChat != lastChat)
                //{
                //    var match = System.Text.RegularExpressions.Regex.Match(LastChat = lastChat, "\\|[Cc][0-9a-fA-F]{8,8}(.+?): ?\\|[Rr] ?(\\|[Cc][0-9a-fA-F]{8,8})?(.+?) ?(\\|[Rr])?$");
                //    if (match.Success)
                //    {
                //        string ID = match.Groups[1].Value.Trim();
                //        string Text = match.Groups[3].Value.Trim();
                //        if (ID.HashSHA256() == "1FA75760CF59B8374A2FFB6FD5446814B9DFCF4240BD9C9A71DCABC6D467D8F1"
                //        && Text.HashSHA256() == "23D94441929B410CF9AD33E9821EE3D57C66B851D22458EF6C2D9541D130D46E")
                //        {
                //            SendMsg(true, new string[] { "안녕!" }, 100, false);
                //        }
                //    }
                //}
                string prefix = GetMessage();
                if (string.IsNullOrEmpty(prefix)) return;
                switch (prefix[0])
                {
                    case '!':
                        UserState = CommandTag.Default;
                        return;
                    case '-':
                        UserState = CommandTag.Chat;
                        return;
                }
                if (UserState == CommandTag.None) return;
                if (prefix[0] == '\0')
                {
                    string[] args;
                    try
                    {
                        args = prefix.Substring(1, prefix.Length - 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    catch
                    {
                        UserState = CommandTag.None;
                        return;
                    }
                    if (args.Length > 0)
                    {
                        string command = args[0];
                        commandList.Find(item => item.Tag == UserState && item.CompareCommand(command))?.Function(args);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionSender.ExceptionSendAsync(ex);
            }
            UserState = CommandTag.None;
        }

        private static async void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await Task.Delay(200);
            Worker.RunWorkerAsync();
        }

        internal static void StartDetect() => Worker.RunWorkerAsync();
    }
}
