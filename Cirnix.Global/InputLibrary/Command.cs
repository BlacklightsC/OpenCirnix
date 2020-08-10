using System;
using System.Collections.Generic;

namespace Cirnix.Global
{
    // Command Tag
    public enum CommandTag
    {
        None = 0,   // null
        Default = 1, // !
        Chat = 2, // -
        Cheat = 3   // @
    }

    public sealed class CommandComponent
    {
        // Trigger Elements
        public string CommandEng { get; private set; }
        public string CommandKor { get; private set; }
        public CommandTag Tag { get; private set; }
        public Action<string[]> Function { get; private set; }

        // Description Elements
        public string Name { get; internal set; }
        public string Params { get; internal set; }
        public string Description { get; internal set; }

        internal CommandComponent(string CommandEng, string CommandKor, CommandTag Tag, Action<string[]> Function)
        {
            this.CommandEng = CommandEng;
            this.CommandKor = CommandKor;
            this.Tag = Tag;
            this.Function = Function;
        }
        public bool CompareCommand(string Text)
            => CommandEng.Equals(Text, StringComparison.OrdinalIgnoreCase) || CommandKor.Equals(Text, StringComparison.OrdinalIgnoreCase);
    }

    public sealed class CommandList : List<CommandComponent>
    {
        public void Register(string CommandEng, string CommandKor, Action<string[]> Function, CommandTag Tag = CommandTag.Default)
        {
            if (string.IsNullOrEmpty(CommandEng)) CommandEng = "CirnixNullCommandMessage";
            if (string.IsNullOrEmpty(CommandKor)) CommandKor = "CirnixNullCommandMessage";
            Add(new CommandComponent(CommandEng, CommandKor, Tag, Function));
        }

        public void SetLastDescription(string Name, string Params, string Description)
        {
            if (Count == 0) return;
            CommandComponent command = this[Count - 1];
            command.Name = Name;
            command.Params = Params;
            command.Description = Description;
        }

        public bool Unregister(string command)
            => RemoveAll(item => item.CommandEng == command || item.CommandKor == command) > 0;
    }
}
