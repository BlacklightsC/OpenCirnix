using Cirnix.Global;

using System;
using System.ComponentModel;
using System.Threading.Tasks;

using static Cirnix.Global.Globals;
using static Cirnix.Memory.Message;

namespace Cirnix.Worker.InnerWorker
{
    public sealed class Commands
    {
        private BackgroundWorker Worker;

        public Commands()
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            Worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string prefix = string.Empty;
                try
                {
                    if (Actions.ProcessCheck()) return;
                    if (!string.IsNullOrEmpty(prefix = GetMessage()))
                    {
                        switch (prefix[0])
                        {
                            case '!':
                                UserState = CommandTag.Default;
                                return;
                            case '-':
                                UserState = CommandTag.Chat;
                                return;
                            case '@':
                            case '#':
                                UserState = CommandTag.Cheat;
                                return;
                        }
                        if (UserState == CommandTag.None) return;
                        if (prefix[0] == '\0')
                        {
                            string[] args;
                            try
                            {
                                args = prefix.Substring(1, prefix.Length - 1).Split(' ');
                            }
                            catch
                            {
                                UserState = CommandTag.None;
                                return;
                            }
                            Actions.args.AddRange(args);
                            Actions.args.Add(null);
                            string command = Actions.args[0].ToLower();
                            commandList.Find(item => item.Tag == UserState && item.CompareCommand(command))?.Function();
                            Actions.args.RemoveRange(0, Actions.args.Count);
                        }
                        UserState = CommandTag.None;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionSender.ExceptionSendAsync(ex);
                    Actions.args.RemoveRange(0, Actions.args.Count);
                    UserState = CommandTag.None;
                }
                finally
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionSender.ExceptionSendAsync(ex);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Task.Delay(200);
            Worker.RunWorkerAsync();
        }
    }
}
