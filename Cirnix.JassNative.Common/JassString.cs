using System;
using System.Text.RegularExpressions;
using Cirnix.JassNative.Plugin;
using Cirnix.JassNative.JassAPI;

namespace Cirnix.JassNative.Common
{
    public sealed class JassString : IPlugin
    {
        private delegate JassInteger StringPosPrototype(JassStringArg str, JassStringArg sub);
        private JassInteger StringPos(JassStringArg str, JassStringArg sub) { return str.ToString().IndexOf(sub); }

        private delegate JassStringRet StringReversePrototype(JassStringArg str);
        private JassStringRet StringReverse(JassStringArg str)
        {
            char[] arr = str.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private delegate JassStringRet StringTrimPrototype(JassStringArg str);
        private JassStringRet StringTrim(JassStringArg str) { return str.ToString().Trim(); }

        private delegate JassStringRet StringRegexPrototype(JassStringArg str, JassStringArg regex, JassInteger index);
        private JassStringRet StringRegex(JassStringArg str, JassStringArg regex, JassInteger index)
        {
            MatchCollection matches = Regex.Matches(str, regex);
            return index < matches.Count ? matches[index].Value : string.Empty;
        }

        private delegate JassInteger StringCountPrototype(JassStringArg str, JassStringArg sub);
        private JassInteger StringCount(JassStringArg str, JassStringArg sub) { return Regex.Matches(str, sub).Count; }

        private delegate JassBoolean StringContainsPrototype(JassStringArg str, JassStringArg sub);
        private JassBoolean StringContains(JassStringArg str, JassStringArg sub) { return str.ToString().Contains(sub); }

        private delegate JassStringRet StringTrimEndPrototype(JassStringArg str);
        private JassStringRet StringTrimEnd(JassStringArg str) { return str.ToString().TrimEnd(); }

        private delegate JassStringRet StringTrimStartPrototype(JassStringArg str);
        private JassStringRet StringTrimStart(JassStringArg str) { return str.ToString().TrimStart(); }

        private delegate JassStringRet StringSplitPrototype(JassStringArg str, JassStringArg sub, JassInteger index);
        private JassStringRet StringSplit(JassStringArg str, JassStringArg sub, JassInteger index)
        {
            string[] array = str.ToString().Split(new string[] { sub }, StringSplitOptions.None);
            return index < array.Length ? array[index] : string.Empty;
        }

        private delegate JassStringRet StringReplacePrototype(JassStringArg str, JassStringArg old, JassStringArg newstr);
        private JassStringRet StringReplace(JassStringArg str, JassStringArg old, JassStringArg newstr) { return str.ToString().Replace(old, newstr); }

        private delegate JassStringRet StringInsertPrototype(JassStringArg str, JassInteger index, JassStringArg val);
        private JassStringRet StringInsert(JassStringArg str, JassInteger index, JassStringArg val) { return str.ToString().Insert(index, val); }

        public void Initialize()
        {
            Natives.Add(new StringPosPrototype(StringPos));
            Natives.Add(new StringInsertPrototype(StringInsert));
            Natives.Add(new StringTrimPrototype(StringTrim));
            Natives.Add(new StringTrimStartPrototype(StringTrimStart));
            Natives.Add(new StringTrimEndPrototype(StringTrimEnd));
            Natives.Add(new StringSplitPrototype(StringSplit));
            Natives.Add(new StringReplacePrototype(StringReplace));
            Natives.Add(new StringReversePrototype(StringReverse));
            Natives.Add(new StringContainsPrototype(StringContains));
            Natives.Add(new StringCountPrototype(StringCount));
            Natives.Add(new StringRegexPrototype(StringRegex));
        }

        public void OnGameLoad()
        {
        }

        public void OnMapStart()
        {
        }

        public void OnMapEnd()
        {
        }
    }
}
