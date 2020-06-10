using System;
using System.Text;
using System.Collections.Generic;
using static Cirnix.Global.Globals;

namespace Cirnix.Global
{
    public sealed class SaveFilePath : List<SavePath>
    {
        public void Read()
        {
            string[] data = Settings.SaveFilePath.Split(new string[] { "∫" }, StringSplitOptions.None);
            if (data.Length <= 1) return;
            for (int i = 0; i < data.Length; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        Add(new SavePath());
                        this[i / 3].path = data[i];
                        break;
                    case 1:
                        this[i / 3].nameEN = data[i];
                        break;
                    case 2:
                        this[i / 3].nameKR = data[i];
                        break;
                }
            }
        }

        public void Save()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (i > 0) builder.Append("∫");
                builder.AppendFormat("{0}∫{1}∫{2}", this[i].path, this[i].nameEN, this[i].nameKR);
            }
            Settings.SaveFilePath = builder.ToString();
        }

        public void AddPath(string path, string nameEN, string nameKR = "")
        {
            int index;
            if ((index = path.IndexOf("CustomMapData")) == -1)
                throw new Exception("경로에 CustomMapData가 존재하지 않습니다.");
            Add(new SavePath(path.Substring(index + 13), nameEN, nameKR));
            Save();
        }

        public string GetPath(int index)
        {
            try
            {
                return this[index].path;
            }
            catch
            {
                return null;
            }
        }
        
        public string GetPath(string name)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].nameEN == name
                 || this[i].nameKR == name)
                    return this[i].path;
            return null;
        }

        public string GetFullPath(int index)
        {
            try
            {
                return $"{DocumentPath}\\CustomMapData{this[index].path}";
            }
            catch
            {
                return null;
            }
        }

        public string GetFullPath(string name)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].nameEN == name
                 || this[i].nameKR == name)
                    return $"{DocumentPath}\\CustomMapData{this[i].path}";
            return $"{DocumentPath}\\CustomMapData\\Unknown";
        }

        public bool RemovePath(string name)
        {
            for(int i = 0; i < Count; i++)
                if (this[i].nameEN == name
                 || this[i].nameKR == name)
                {
                    RemoveAt(i);
                    Save();
                    return true;
                }
            return false;
        }

        public string ConvertName(string name, bool IsForcedEN = false)
        {
            if (string.IsNullOrEmpty(name)) return null;
            for (int i = 0; i < Count; i++)
                if (this[i].nameEN == name)
                    if (string.IsNullOrEmpty(this[i].nameKR) || IsForcedEN)
                        return this[i].nameEN;
                    else return this[i].nameKR;
                else if (this[i].nameKR == name)
                    return this[i].nameEN;
            return null;
        }

        public SavePath GetSavePath(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            for (int i = 0; i < Count; i++)
                if (this[i].nameEN == name
                 || this[i].nameKR == name)
                    return this[i];
            return null;
        }
    }

    public sealed class SavePath
    {
        /// <summary>
        /// \로 시작하는 상대 경로
        /// </summary>
        public string path { get; set; }
        public string nameEN { get; set; }
        public string nameKR { get; set; }

        public SavePath() { }

        public SavePath(string path, string nameEN, string nameKR)
        {
            this.path = path;
            this.nameEN = nameEN;
            this.nameKR = nameKR;
        }
    }
}
